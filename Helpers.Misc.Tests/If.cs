using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.UnitTests
{
    [TestClass]
    public class Test_If
    {
        [TestMethod]
        public void Predicate_Value()
        {
            //struct
            {
                var valueIfTrue = Struct.From(1);
                var valueIfFalse = Struct.From(-1);

                Assert.AreSame(valueIfTrue, If.Predicate(true, valueIfTrue, valueIfFalse));
                Assert.AreSame(valueIfFalse, If.Predicate(false, valueIfTrue, valueIfFalse));
            }

            //class
            {
                var valueIfTrue = Class.From(1);
                var valueIfFalse = Class.From(-1);


                Assert.AreSame(valueIfTrue, If.Predicate(true, valueIfTrue, valueIfFalse));
                Assert.AreSame(valueIfFalse, If.Predicate(false, valueIfTrue, valueIfFalse));
            }
        }

        [TestMethod]
        public void Predicate_Func()
        {
            //struct
            {
                var valueIfTrue = Struct.From(1);
                var valueIfFalse = Struct.From(-1);

                Assert.AreSame(valueIfTrue, If.Predicate(true, () => valueIfTrue, () => valueIfFalse));
                Assert.AreSame(valueIfFalse, If.Predicate(false, () => valueIfTrue, () => valueIfFalse));
            }

            //class
            {
                var valueIfTrue = Class.From(1);
                var valueIfFalse = Class.From(-1);

                Assert.AreSame(valueIfTrue, If.Predicate(true, () => valueIfTrue, () => valueIfFalse));
                Assert.AreSame(valueIfFalse, If.Predicate(false, () => valueIfTrue, () => valueIfFalse));
            }
        }

        [TestMethod]
        public void Predicate_Source_Action()
        {
            //struct
            {
                {
                    var source = Struct.From(0);
                    If.Predicate(true, source, (x) => { x.Value = x.Value + 1; }, (x) => { x.Value = x.Value - 1; });
                    Assert.AreEqual(1, source.Value);
                }
                {
                    var source = Struct.From(0);
                    If.Predicate(false, source, (x) => { x.Value = x.Value + 1; }, (x) => { x.Value = x.Value - 1; });
                    Assert.AreEqual(-1, source.Value);
                }
            }

            //class
            {
                {
                    var source = Class.From(0);
                    If.Predicate(true, source, (x) => { x.Value = x.Value + 1; }, (x) => { x.Value = x.Value - 1; });
                    Assert.AreEqual(1, source.Value);
                }
                {
                    var source = Class.From(0);
                    If.Predicate(false, source, (x) => { x.Value = x.Value + 1; }, (x) => { x.Value = x.Value - 1; });
                    Assert.AreEqual(-1, source.Value);
                }
            }
        }

        [TestMethod]
        public void Predicate_Source_Func()
        {
            //struct
            {
                {
                    var source = Struct.From(0);
                    Assert.AreEqual(1, If.Predicate(true, source, (x) => { return x.Value + 1; }, (x) => { return x.Value - 1; }));
                }
                {
                    var source = Struct.From(0);
                    Assert.AreEqual(-1, If.Predicate(false, source, (x) => { return x.Value + 1; }, (x) => { return x.Value - 1; }));
                }
            }

            //class
            {
                {
                    var source = Class.From(0);
                    Assert.AreEqual(1, If.Predicate(true, source, (x) => { return x.Value + 1; }, (x) => { return x.Value - 1; }));
                }
                {
                    var source = Class.From(0);
                    Assert.AreEqual(-1, If.Predicate(false, source, (x) => { return x.Value + 1; }, (x) => { return x.Value - 1; }));
                }
            }
        }
    }
}
