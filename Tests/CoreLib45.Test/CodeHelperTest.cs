#region Code Identifications

// Created on     2017/09/23
// Last update on 2018/03/10 by Mohammad Mir mostafa 

#endregion

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mohammad.Exceptions;
using static Mohammad.Helpers.CodeHelper;

namespace CoreLib45.Test
{
    [TestClass]
    [TestCategory("CodeHelper Tests")]
    public class CodeHelperTest
    {
        [TestMethod]
        public void TestCatch1()
        {
            var res = Catch(() => throw new Exception());
            Assert.AreNotEqual(null, res);
        }

        [TestMethod]
        public void TestCatch2()
        {
            var res = Catch(() => { });
            Assert.AreEqual(null, res);
        }

        [TestMethod]
        public void TestCatch3()
        {
            var res = Catch(() => throw new Exception(), ex => true);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void TestCatch4()
        {
            var res = Catch(() => true);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void TestCatch5()
        {
            var res = Catch(() => throw new Exception(), true);
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCatch6()
        {
            Catch(() => throw new Exception(), () => { }, null, true);
        }

        [TestMethod]
        public void TestCatch7()
        {
            var res = CatchFinally(() => true, () => { });
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void TestCatch8()
        {
            var res = CatchSpecExc<NullReferenceException>(() => throw new NullReferenceException());
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCatch9()
        {
            CatchSpecExc<NullReferenceException>(() => throw new ArgumentException(), ex => { });
        }

        [TestMethod]
        public void TestCatch10()
        {
            var res = CatchFunc<bool>(() => throw new Exception(), ex => { });
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void TestCatch11()
        {
            var res = CatchFunc(() => true, ex => { });
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void TestCatch12()
        {
            var res = CatchFunc(() => true);
            Assert.AreEqual(true, res.result);
        }

        [TestMethod]
        public void TestCatch14()
        {
            var res = CatchFunc(() => true);
            Assert.AreEqual(null, res.exception);
        }

        [TestMethod]
        public void TestCatch13()
        {
            var res = CatchFunc<bool>(() => throw new Exception());
            Assert.AreNotEqual(null, res.exception);
        }

        [TestMethod]
        public void TestDoWhile()
        {
            var counter = 0;
            DoWhile(() => ++counter < 10, () => { });
        }

        [TestMethod]
        public void TestDoWhileFunc()
        {
            var counter = 0;
            var res = DoWhile(() => ++counter < 10, () => true);
            Assert.IsTrue(res.All(r => r));
        }

        [TestMethod]
        public void TestWhile()
        {
            var counter = 0;
            While(() => ++counter < 10, () => { });
        }

        [TestMethod]
        public void TestWhileFunc()
        {
            var counter = 0;
            var res = While(() => ++counter < 10, () => true);
            Assert.IsTrue(res.All(r => r));
        }

        [TestMethod]
        public void TestRetry1()
        {
            var counter = 0;
            var res = Retry(() => ++counter == 10, 100);
            Assert.AreEqual(true, res.IsSucceed);
        }

        [TestMethod]
        public void TestRetry2()
        {
            var counter = 0;
            var res = Retry(() => ++counter == 100, 10);
            Assert.AreEqual(false, res.IsSucceed);
        }

        [TestMethod]
        public void IfTest()
        {
            Assert.AreEqual("".If(string.IsNullOrEmpty, true, false), true);
            Assert.AreEqual("".If(string.IsNullOrEmpty, _ => true, _ => false), true);
            "".If(string.IsNullOrEmpty, _ => { }, _ => { });
            "Test".If(string.IsNullOrEmpty, _ => { }, _ => { });
        }

        [TestMethod]
        public void ComputeTest()
        {
            Compute(new[] {1, 2}.ToList);
        }

        [TestMethod]
        public void GetCurrenntMethodTest()
        {
            Assert.AreEqual(GetCurrentMethod().Name, "GetCurrenntMethodTest");
        }

        [TestMethod]
        public void GetCallerMethodNameTest()
        {
            Assert.AreEqual(GetCallerMethodName(), "GetCallerMethodNameTest");
        }

        [TestMethod]
        public void GetCallerMethodNameTest3()
        {
            Assert.AreEqual(GetCallerMethodName(3), "InvokeMethod");
        }

        [TestMethod]
        public void HasExceptionTest()
        {
            Assert.AreEqual(HasException(() => { }), false);
            Assert.AreEqual(HasException(() => throw new Exception()), true);
        }

        [TestMethod]
        [ExpectedException(typeof(BreakException))]
        public void BreakTest()
        {
            Break();
        }

        [TestMethod]
        public void DoAndLockTest()
        {
            Action action = () => { };
            Action<int> action1 = _ => { };

            var actions = GetRepeat(action, 5);
            Do(actions);
            DoFor(action, 5);
            DoForAsync(action, 5);
            DoForAsParallel(action, 5);
            DoFor(action1, 5);
            Lock(action);
            LockAndCatch(action);
        }
    }
}