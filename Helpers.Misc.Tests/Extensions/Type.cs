using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace JasonPereira84.Helpers.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_Type
        {
            [TestMethod]
            public void GetPublicProperties()
            {
                {
                    {
                        var type = typeof(SomeClass);

                        var propertyInfos = type.GetPublicProperties();
                        Assert.IsNotNull(propertyInfos);

                        var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name.Equals(nameof(SomeClass.Value)));
                        Assert.IsNotNull(propertyInfo);
                    }

                    {
                        var type = default(Type);
                        Assert.ThrowsException<ArgumentNullException>(
                            () => type.GetPublicProperties());
                    }

                }

                {
                    var propertyInfos = Misc.GetPublicProperties<SomeClass>();
                    Assert.IsNotNull(propertyInfos);

                    var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name.Equals(nameof(SomeClass.Value)));
                    Assert.IsNotNull(propertyInfo);
                }

            }

        }
    }
}
