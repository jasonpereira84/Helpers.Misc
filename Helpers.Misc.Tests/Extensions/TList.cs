using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_TList
        {
            [TestMethod]
            public void AddItem()
            {
                var source = new List<Object>();
                var value = new Object();
                Assert.IsTrue(source.AddItem(value).Contains(value));
            }

            [TestMethod]
            public void EnsureAtLeastOne()
            {
                {
                    var source = new List<Object> 
                    { 
                        new Object() 
                    };
                    var value = new Object();
                    Assert.IsFalse(source.EnsureAtLeastOne(value).Contains(value));
                }

                {
                    var source = new List<Object>();
                    var value = new Object();
                    Assert.IsTrue(source.EnsureAtLeastOne(value).Contains(value));
                }

                {
                    var source = new List<Object>();
                    var value = new Object();
                    Assert.IsTrue(source.EnsureAtLeastOne<Object, List<Object>>().Any());
                }

            }

        }
    }
}
