#region Code Identifications

// Created on     2018/03/10
// Last update on 2018/03/10 by Mohammad Mir mostafa 

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mohammad.Helpers;

namespace CoreLib45.Test
{
    [TestClass]
    public class EnumerableHelperTest
    {
        [TestMethod]
        public void TestDistinct()
        {
            var data = new List<Person>
                       {
                           new Person("Ali")
                           {
                               Age = 5
                           },
                           new Person("Ali")
                           {
                               Age = 5
                           },
                           new Person("Mohammad")
                           {
                               Age = 5
                           }
                       };
            var distinct = data.Distinct((x, y) => x.Name == y.Name).ToList();
            Assert.AreEqual(distinct.Count, 2);
        }

        [TestMethod]
        public void CastTest()
        {
            Assert.IsNotNull(EnumerableHelper.AsEnuemrable(1, 2, 3, 4, 5).Cast(i => i.ToString()));
        }

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(EnumerableHelper.Count(1, 2, 3, 4, 5), 5);
        }

        [TestMethod]
        public void ElementAtTest()
        {
            Assert.AreEqual(EnumerableHelper.ElementAt(EnumerableHelper.ToArray(1, 2, 3, 4, 5), 2), 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ElementAtExceptionTest()
        {
            EnumerableHelper.ElementAt(EnumerableHelper.ToArray(1), 2);
        }

        [TestMethod]
        public void TakeGroupsTest()
        {
            var result = EnumerableHelper.TakeGroups(EnumerableHelper.ToArray(1, 2, 3, 4, 5), 2);
            Assert.IsNotNull(result);
        }
    }
}