using Fluentx;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fluentx.Tests
{
    [TestClass()]
    public class FluxTests
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        [TestMethod()]
        public void IfTest()
        {
            var result = string.Empty;
            Flux.If(8 % 2 == 0).Then(() => result = "even");
            Assert.AreEqual("even", result);

            Flux.If(() => 9 % 2 == 1).Then(() => result = "odd");
            Assert.AreEqual("odd", result);
        }

        [TestMethod]
        public void IfElseTest()
        {
            var result = string.Empty;
            Flux.If(8%2 == 0).Then(() => result = "even").Else(() => result = "odd");
            Assert.AreEqual("even", result);

            Flux.If(() => 9%2 == 0).Then(() => result = "even").Else(() => result = "odd");
            Assert.AreEqual("odd", result);
        }

        [TestMethod]
        public void ElseIfTest()
        {
            var result = 0;
            var expected = 3;
            Flux
                .If(() => expected == 997).Then(() => { result = 1; })
                .ElseIf(() => expected == 998).Then(() => { result = 2; })
                .Else(() => result = 3);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AndTest()
        {
            int result = 0;
            int expected = 1;
            Flux
                .If(() => true).And(() => true).Then(() => { result = 1; });
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AndNotTest()
        {
            int result = 0;
            int expected = 1;
            Flux
                .If(() => true).And(() => true).AndNot(false).Then(() => { result = 1; });
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OrTest()
        {
            int result = 0;
            int expected = 1;
            Flux
                .If(() => true).And(() => true).AndNot(true).Or(true).Then(() => { result = 1; });
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OrNotTest()
        {
            int result = 0;
            int expected = 1;
            Flux
                .If(() => true).And(() => true).AndNot(true).OrNot(false).Then(() => { result = 1; });
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void XorTest()
        {
            int result = 0;
            int expected = 0;
            Flux
                .If(() => true).And(() => true).AndNot(true).OrNot(false).Xor(true).Then(() => { result = 1; });
            Assert.AreEqual(expected, result);

            expected = 2;
            Flux
                .If(() => true).And(() => true).AndNot(true).OrNot(false).Xor(false).Then(() => { result = 2; });
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void XnorTest()
        {
            int result = 0;
            int expected = 0;
            Flux
                .If(() => true).And(() => true).AndNot(true).OrNot(false).Xnor(false).Then(() => { result = 1; });
            Assert.AreEqual(expected, result);

            expected = 2;
            Flux
                .If(() => true).And(() => true).AndNot(true).OrNot(false).Xnor(true).Then(() => { result = 2; });
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhileTest()
        {
            var result = 0;
            Flux.While(() => result != 6, () => result++);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void WhileDoTest()
        {
            var result = 0;
            var sum = 0;
            Flux.While(() => ++result != 6).Do(() => sum += result);
            Assert.AreEqual(15, sum);
        }

        [TestMethod]
        public void EarlyLoopLateBreakOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;

            Flux.While(() =>
            {
                condition_evaluation_count += 1;
                return result < 6;
            })
            .LateBreakOn(() => result == 4)
            .Do(() =>
            {
                result += 1;
            });

            Assert.AreEqual(condition_evaluation_count, 4);
        }

        [TestMethod]
        public void EarlyLoopEarlyBreakOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;
            Flux.While(() =>
            {
                condition_evaluation_count += 1;
                return result < 6;
            })
            .EarlyBreakOn(() => result == 4)
            .Do(() =>
            {
                result += 1;
            });

            Assert.AreEqual(condition_evaluation_count, 5);
        }

        [TestMethod]
        public void EarlyLoopLateContinueOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;

            Flux.While(() =>
            {
                condition_evaluation_count += 1;
                return result < 6;
            })
            .LateContinueOn(() => result == 4)
            .Do(() =>
            {
                result += 1;
            });

            Assert.AreEqual(condition_evaluation_count, 7);
        }

        [TestMethod]
        public void EarlyLoopEarlyContinueOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;
            Flux.While(() =>
            {
                condition_evaluation_count += 1;
                return result < 6 && condition_evaluation_count < 100;
            })
            .EarlyContinueOn(() => result == 4)
            .Do(() =>
            {
                result += 1;
            });

            Assert.AreEqual(condition_evaluation_count, 100);
        }
    }
}