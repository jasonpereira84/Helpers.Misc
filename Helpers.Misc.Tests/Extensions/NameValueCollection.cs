using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_NameValueCollection
        {
            [TestMethod]
            public void ToPairs()
            {
                {
                    var source = default(NameValueCollection);
                    Assert.ThrowsException<ArgumentNullException>(
                        () => source.AsPairs());
                }

                {
                    var source = new NameValueCollection()
                        .Do(nameValueCollection =>
                        {
                            nameValueCollection.Add("1", "2");
                            return nameValueCollection;
                        });
                    Assert.IsTrue(
                        new[] { new KeyValuePair<String, String>("1", "2") }
                            .SequenceEqual(source.AsPairs()));
                }

            }

        }
    }
}
