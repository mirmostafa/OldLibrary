#region Code Identifications

// Created on     2018/03/11
// Last update on 2018/03/11 by Mohammad Mir mostafa 

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Mohammad.Annotations;
using Mohammad.DesignPatterns.ExceptionHandlingPattern;
using Mohammad.Diagnostics;
using Mohammad.Exceptions;
using Mohammad.Threading.Tasks;

namespace Mohammad.Helpers
{
    public static class CodeHelper
    {
        public static readonly Action EmptyDelegate = () => { };

        public static TDelegate GetDelegate<TType, TDelegate>(string methodName) => (TDelegate) (ISerializable) Delegate.CreateDelegate(typeof(TDelegate),
            typeof(TType).GetMethod(methodName));

        /// <summary>
        ///     Determines whether [is design time].
        /// </summary>
        /// <returns>
        ///     <c>true</c> if [is design time]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDesignTime()
        {
            var result = true;
#if CORELIB
            return result = false;
#endif
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return result;
        }

        /// <summary>
        ///     Invokes the specified target.
        /// </summary>
        /// <typeparam name="TTargetType">The type of the target type.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object Invoke<TTargetType>(TTargetType target, string methodName, params object[] parameters)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    var types = new Type[parameters.Length];
                    for (var counter = 0; counter != parameters.Length; counter++)
                        types[counter] = parameters.GetType();
                }
                var contstructors = typeof(TTargetType).GetConstructors();
                return (from contstructor in contstructors
                        where parameters != null
                        where parameters != null && contstructor.GetParameters().GetLength(0) == parameters.Length
                        select contstructor.Invoke(parameters)).FirstOrDefault();
            }
            var methods = typeof(TTargetType).GetMethods();
            return (from method in methods
                    where string.Compare(method.Name, methodName, StringComparison.Ordinal) == 0
                    where method.GetParameters().GetLength(0) == parameters.Length
                    select method.Invoke(target, parameters)).FirstOrDefault();
        }

        public static Exception Catch(Action tryMethod) => Catch(tryMethod, null, null, null);

        public static Exception Catch(Action tryMethod, ExceptionHandling handling, bool throwException = false) => Catch(tryMethod,
            null,
            null,
            null,
            throwException);

        public static Exception Catch(Action tryMethod, Action finallyMethod, ExceptionHandling handling = null, bool throwException = false) => Catch(tryMethod,
            null,
            finallyMethod,
            handling,
            throwException);

        public static Exception Catch(Action tryMethod, Action<Exception> catchMethod, Action finallyMethod = null, ExceptionHandling handling = null,
            bool throwException = false)
        {
            if (tryMethod == null)
                throw new ArgumentNullException(nameof(tryMethod));
            handling?.Reset();
            try
            {
                tryMethod();
            }
            catch (Exception ex)
            {
                catchMethod?.Invoke(ex);
                handling?.HandleException(ex);
                if (throwException)
                    throw;
                return ex;
            }
            finally
            {
                finallyMethod?.Invoke();
            }
            return null;
        }

        public static TResult Catch<TResult>(Func<TResult> tryMethod, Func<Exception, TResult> catchMethod, Action finallyMethod, ExceptionHandling handling,
            bool throwException)
        {
            if (tryMethod == null)
                throw new ArgumentNullException(nameof(tryMethod));
            handling?.Reset();
            try
            {
                return tryMethod();
            }
            catch (Exception ex)
            {
                handling?.HandleException(ex);
                if (throwException)
                    throw;
                return catchMethod != null ? catchMethod(ex) : default(TResult);
            }
            finally
            {
                finallyMethod?.Invoke();
            }
        }

        public static TResult Catch<TResult>(Func<TResult> tryMethod, TResult defaultResult, Action finallyMethod, ExceptionHandling handling, bool throwException)
        {
            handling?.Reset();
            try
            {
                return tryMethod();
            }
            catch (Exception ex)
            {
                handling?.HandleException(ex);
                if (throwException)
                    throw;
                return defaultResult;
            }
            finally
            {
                finallyMethod?.Invoke();
            }
        }

        public static (Exception Exception, TResult Result) Try<TResult>([NotNull] Func<TResult> tryMethod, TResult defaultResult = default(TResult),
            Action finallyMethod = null)
        {
            return Try(tryMethod, ex => defaultResult, finallyMethod);
        }

        public static (Exception Exception, TResult Result) Try<TResult>([NotNull] Func<TResult> tryMethod, Func<Exception, TResult> catchMethod,
            Action finallyMethod = null)
        {
            if (tryMethod == null)
                throw new ArgumentNullException(nameof(tryMethod));
            try
            {
                return (null, tryMethod());
            }
            catch (Exception ex)
            {
                return (ex, catchMethod(ex));
            }
            finally
            {
                finallyMethod?.Invoke();
            }
        }

        public static TResult Catch<TResult>(Func<TResult> tryMethod, Action finallyMethod, ExceptionHandling handling, bool throwException) => Catch(tryMethod,
            null,
            finallyMethod,
            handling,
            throwException);

        public static TResult Catch<TResult>(Func<TResult> tryMethod, Func<Exception, TResult> catchMethod) => Catch(tryMethod, catchMethod, null, null, false);

        public static TResult Catch<TResult>(Func<TResult> tryMethod, ExceptionHandling handling, bool throwException) => Catch(tryMethod,
            null,
            null,
            handling,
            throwException);

        public static TResult Catch<TResult>(Func<TResult> tryMethod, ExceptionHandling handling) => Catch(tryMethod, null, null, handling, false);

        public static TResult Catch<TResult>(Func<TResult> tryMethod, TResult defaultResult = default(TResult)) =>
            Catch(tryMethod, defaultResult, null, null, false);

        public static async Task<Exception> Catch([NotNull] Func<Task> tryMethod, Action<Exception> catchAction, Action finallyMethod = null,
            ExceptionHandling handling = null, bool throwException = false)
        {
            if (tryMethod == null)
                throw new ArgumentNullException(nameof(tryMethod));
            handling?.Reset();
            try
            {
                await tryMethod();
                return null;
            }
            catch (Exception ex)
            {
                catchAction.Invoke(ex);
                handling?.HandleException(ex);
                if (throwException)
                    throw;
                return ex;
            }
            finally
            {
                finallyMethod?.Invoke();
            }
        }

        public static TResult CatchFinally<TResult>(Func<TResult> tryMethod, Action finallyMethod) => Catch(tryMethod, null, finallyMethod, null, false);

        public static bool CatchSpecExc<TException>(Action action, Action<TException> catchMethod = null, Action finallyMethod = null)
            where TException : Exception
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(TException))
                    catchMethod?.Invoke(ex.As<TException>());
                else
                    throw;
                return false;
            }
            finally
            {
                finallyMethod?.Invoke();
            }
        }

        public static TResult CatchFunc<TResult>(Func<TResult> action, Action<Exception> catchMethod, Action finallyMethod = null,
            TResult defauklResult = default(TResult))
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            try
            {
                return action();
            }
            catch (Exception exception)
            {
                catchMethod?.Invoke(exception);
            }
            finally
            {
                finallyMethod?.Invoke();
            }
            return defauklResult;
        }

        public static (TResult result, Exception exception) CatchFunc<TResult>(Func<TResult> action)
        {
            Exception exception = null;
            return (CatchFunc(action, ex => exception = ex), exception);
        }

        public static bool HasException(Action tryFunc)
        {
            return Catch(() =>
                {
                    tryFunc();
                    return false;
                },
                _ => true);
        }

        public static void DoWhile(Func<bool> predicate, Action action = null)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            do
                action?.Invoke(); while (predicate());
        }

        public static IEnumerable<TResult> DoWhile<TResult>(Func<bool> predicate, [NotNull] Func<TResult> action)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            do
                yield return action(); while (predicate());
        }

        public static void While(Func<bool> predicate, Action action = null)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            while (predicate())
                action?.Invoke();
        }

        public static IEnumerable<TResult> While<TResult>(Func<bool> predicate, [NotNull] Func<TResult> action, Action onIterationDone = null)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            while (predicate())
                yield return action();
            onIterationDone?.Invoke();
        }

        public static (bool IsSucceed, int RetryCount) Retry([NotNull] Func<bool> func, int retryCount, TimeSpan waitForRetry = default(TimeSpan))
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            var index = 0;
            for (; index < retryCount; index++)
            {
                if (func())
                    return (true, index);
                if (waitForRetry != default(TimeSpan))
                    Thread.Sleep(waitForRetry);
            }
            return (false, index);
        }

        public static (bool isSucceed, int retryCount) Retry([NotNull] Func<int, bool> func, int retryCount, TimeSpan waitForRetry = default(TimeSpan))
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            var index = 0;
            for (; index < retryCount; index++)
            {
                if (func(index))
                    return (true, index);
                if (waitForRetry != default(TimeSpan))
                    Thread.Sleep(waitForRetry);
            }
            return (false, index);
        }

        public static (bool isSucceed, int retryCount, TResult result) Retry<TResult>(Func<(bool isOk, TResult result)> func, int retryCount,
            TimeSpan waitForRetry = default(TimeSpan))
        {
            var index = 0;
            for (; index < retryCount; index++)
            {
                var oper = func();
                if (oper.isOk)
                    return (true, index, oper.result);
                if (waitForRetry != default(TimeSpan))
                    Thread.Sleep(waitForRetry);
            }
            return (false, index, default(TResult));
        }

        public static void Break() { throw new BreakException(); }

        public static void ExecOnDebugger(Action action)
        {
            if (Debugger.IsAttached)
                action?.Invoke();
        }

        public static IEnumerable<Action> GetRepeat(Action del, int count)
        {
            for (var index = 0; index < count; index++)
                yield return del;
        }

        public static void Do(IEnumerable<Action> dels, Action<int> onGoNext = null, bool continueOnException = false)
        {
            var ds = dels.ToList();
            var failed = false;
            Action<Exception> onException = null;
            if (!continueOnException)
                onException = ex => failed = true;
            for (var i = 0; i < ds.Count(); i++)
            {
                Catch(ds[i], onException);
                if (failed)
                    break;
                onGoNext?.Invoke(i);
            }
        }

        public static void DoFor(Action<int> action, int count)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            for (var i = 0; i < count; i++)
                action(i);
        }

        public static void DoFor(Action action, int count, Action<int> onGoNext = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            for (var i = 0; i < count; i++)
            {
                action();
                onGoNext?.Invoke(i);
            }
        }

        public static async void DoForAsync(Action action, int count)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            for (var i = 0; i < count; i++)
                await Async.Run(action);
        }

        public static void DoForAsParallel(Action action, int count)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            for (var i = 0; i < count; i++)
#pragma warning disable 4014
                Async.Run(action);
#pragma warning restore 4014
        }

        public static void RunAndCleanupMemory(Action action, object owner = null, Action disposer = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            var mp = MemoryProfiler.StartNew();
            try
            {
                action();
            }
            finally
            {
                if (disposer != null)
                    Catch(disposer);
                mp.Stop();
                mp.Cleanup(owner);
            }
        }

        public static TResult RunAndCleanupMemory<TResult>(Func<TResult> action, object owner = null, Action disposer = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            var mp = MemoryProfiler.StartNew();
            try
            {
                return action();
            }
            finally
            {
                if (disposer != null)
                    Catch(disposer);
                mp.Stop();
                mp.Cleanup(owner);
            }
        }

        public static string GetCallerMethodName(int index = 2) => GetCallerMethod(index)?.Name;

        public static MethodBase GetCallerMethod(int index = 2) => new StackTrace(true).GetFrame(index)?.GetMethod();

        public static MethodBase GetCallerMethod(int index, bool parsePrevIfNull)
        {
            var stackTrace = new StackTrace(true);
            if (stackTrace.GetFrame(index) != null || !parsePrevIfNull)
                return stackTrace.GetFrame(index)?.GetMethod();
            while (stackTrace.GetFrame(--index) == null) { }
            return stackTrace.GetFrame(index)?.GetMethod();
        }

        public static MethodBase GetCurrentMethod() => GetCallerMethod();

        public static void Lock(Action action, object lockObject = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            Lock(() =>
                {
                    action();
                    return true;
                },
                lockObject);
        }

        public static Exception LockAndCatch(Action tryMethod, object lockObject = null, Action<Exception> catchMethod = null, Action finallyMethod = null,
            ExceptionHandling handling = null, bool throwException = false)
        {
            return Lock(() => Catch(tryMethod, catchMethod, finallyMethod, handling, throwException), lockObject ?? GetCallerMethod().DeclaringType);
        }

        public static TResult Lock<TResult>(Func<TResult> action, object lockObject = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            lock (lockObject ?? GetCallerMethod().DeclaringType)
                return action();
        }

        public static void Dispose<TDisposable>(Func<TDisposable> creator, Action<TDisposable> action)
            where TDisposable : IDisposable
        {
            creator().Dispose(action);
        }

        public static TResult Dispose<TDisposable, TResult>(Func<TDisposable> creator, Func<TDisposable, TResult> action)
            where TDisposable : IDisposable => creator().Dispose(action);

        public static void Dispose<TDisposable>([NotNull] Action<TDisposable> action)
            where TDisposable : IDisposable, new()
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            using (var disposable = new TDisposable())
                action(disposable);
        }

        public static TResult Dispose<TDisposable, TResult>([NotNull] Func<TDisposable, TResult> action)
            where TDisposable : IDisposable, new()
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            using (var disposable = new TDisposable())
                return action(disposable);
        }

        public static void If(this bool condition, Action ifTrue = null, Action ifFalse = null)
        {
            if (condition)
                ifTrue?.Invoke();
            else
                ifFalse?.Invoke();
        }

        public static bool IsTrue(this bool condition, Action ifTrue)
        {
            if (condition)
                ifTrue?.Invoke();
            return condition;
        }

        public static bool IsFalse(this bool condition, Action ifFalse)
        {
            if (!condition)
                ifFalse?.Invoke();
            return condition;
        }

        public static void If<T>(this T obj, Func<T, bool> condition, Action<T> ifTrue = null, Action<T> ifFalse = null)
        {
            if (condition(obj))
                ifTrue?.Invoke(obj);
            else
                ifFalse?.Invoke(obj);
        }

        public static TResult If<T, TResult>(this T obj, Func<T, bool> condition, Func<T, TResult> ifTrue, Func<T, TResult> ifFalse) => condition(obj)
            ? ifTrue(obj)
            : ifFalse(obj);

        public static TResult If<T, TResult>(this T obj, Func<T, bool> condition, TResult ifTrue, TResult ifFalse) => condition(obj) ? ifTrue : ifFalse;

        public static void Compute<TResult>(Func<TResult> func) => func();
    }
}