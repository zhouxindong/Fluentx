using System;
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

        [TestMethod]
        public void DoWhileTest()
        {
            int result = 0;

            Flux.Do(() =>
            {
                ++result;
            }).While(() => { return result < 5; });

            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void LateLoopLateBreakOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;

            Flux.Do(() =>
            {
                result += 1;
            })
                .LateBreakOn(() => result == 4)
                .While(() =>
                {
                    condition_evaluation_count += 1;
                    return result < 6;
                });

            Assert.AreEqual(condition_evaluation_count, 3);
        }

        [TestMethod]
        public void LateLoopEarlyBreakOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;

            Flux.Do(() =>
            {
                result += 1;
            })
                .EarlyBreakOn(() => result == 4)
                .While(() =>
                {
                    condition_evaluation_count += 1;
                    return result < 6;
                });

            Assert.AreEqual(condition_evaluation_count, 4);
        }

        [TestMethod]
        public void LateLoopLateContinueOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;

            Flux.Do(() =>
            {
                result += 1;
            })
                .LateContinueOn(() => result == 4)
                .While(() =>
                {
                    condition_evaluation_count += 1;
                    return result < 6;
                });

            Assert.AreEqual(condition_evaluation_count, 6);
        }

        [TestMethod]
        public void LateLoopEarlyContinueOnTest()
        {
            int result = 0;
            int condition_evaluation_count = 0;

            Flux.Do(() =>
            {
                result += 1;
            })
                .EarlyContinueOn(() => result == 4)
                .While(() =>
                {
                    condition_evaluation_count += 1;
                    return result < 6 && condition_evaluation_count < 100;
                });

            Assert.AreEqual(condition_evaluation_count, 100);
        }

        [TestMethod]
        public void TrySwallowTest()
        {
            var result = 0;
            Flux.Try(() =>
            {
                throw new NotImplementedException();
                ++result;
            }).Swallow();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TrySwallowIfTest()
        {
            int result = 0;
            Flux.Try(() =>
            {
                throw new NotImplementedException();
                ++result;
            }).SwallowIf<NotImplementedException>();

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TrySwallowIfUnmatchedTest()
        {
            int result = 0;
            Flux.Try(() =>
            {
                throw new NotImplementedException();
                ++result;
            }).SwallowIf<NullReferenceException>();

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TrySwallowIfTest2()
        {
            int result = 0;
            Flux.Try(() =>
            {
                throw new NullReferenceException();
                ++result;
            }).SwallowIf<NullReferenceException, ArgumentException>();
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TrySwallowIfTest3()
        {
            int result = 0;
            Flux.Try(() =>
            {
                throw new ArithmeticException();
                ++result;
            }).SwallowIf<NullReferenceException, OutOfMemoryException, ArithmeticException>();
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TrySwallowIfTest4()
        {
            int result = 0;
            Flux.Try(() =>
            {
                throw new ArithmeticException();
                ++result;
            }).SwallowIf<NullReferenceException, OutOfMemoryException, ArithmeticException, IndexOutOfRangeException>();
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TryCatchTest()
        {
            var result = 0;
            Flux.Try(() =>
            {
                throw new NotImplementedException();
                result = 10;
            }).Catch(exception => { result = 20; });
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TryCatchNoExceptionTest()
        {
            bool exception_occured = false;
            Flux.Try(() => { }).Catch<Exception>(ex => { exception_occured = true; });
            Assert.IsFalse(exception_occured);
        }

        [TestMethod]
        public void TryCatchExcutedTest()
        {
            bool exception_occured = false;
            Flux.Try(() => { throw new NotImplementedException(); })
                .Catch<NotImplementedException>(ex => { exception_occured = true; });
            Assert.IsTrue(exception_occured);
        }

        [TestMethod]
        public void Test_Try_4_Catch_CatchExcuted_ByCorrectOrder()
        {
            bool exception_occured = false;
            Flux.Try(() => { throw new NotImplementedException(); })
                .Catch<NotImplementedException, Exception>(ex1 => { exception_occured = true; }, ex2 => { });// catch more than one

            Assert.IsTrue(exception_occured);
        }
    }
}