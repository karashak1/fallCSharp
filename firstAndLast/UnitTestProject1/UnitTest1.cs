using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using firstAndLast;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var json = firstAndLast.Program.GetProfile("jewpaltz");
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Contains("Moshe"));
        }

        [TestMethod]
        public void TestThatDogBarks() {
            var d = new Dog();
            var actual = d.Bark();
            Assert.AreEqual("woof", actual);
        }

        [TestMethod]
        public void TestThatDogCanSayOtherThings() {
            var d = new Dog();
            //d.dogsWord = "meyow";
            d.DogsWord = "meyow";
            var actual = d.Bark();
            Assert.AreEqual("meyow", actual);
        }

        [TestMethod]
        public void TestThatDogCanSayLotsOfThings() {
            var d = new Dog();
            //d.dogsWord = "meyow";
            d.DogsWord = "meyow";
            d.LearnNewWord("Hello");
            d.LearnNewWord("How Are You");
            var actual = d.Bark();
            Assert.AreNotEqual("meyow", actual);
        }
        [TestMethod]
        public void TestThatDogCanRunAtAnySpeed() {
            var d = new Dog();
            //d.dogsWord = "meyow";
            d.Speed = "200";
            var actual = d.Run();
            Assert.AreEqual("I am running at 200 Miles per Hour", actual);
        }

        [TestMethod]
        public void TestDelegate() {
            Multiply MYFunc = (x,y) => x*y;//lamda function
            Assert.AreEqual(4, MYFunc(2, 2));
            MYFunc = (x, y) => x - y;
            /*
            MYFunc = delegate(int x, int y){//delegate function
                return x - y;
            };
             * */
            Assert.AreEqual(0,MYFunc(2,2));
        }

        [TestMethod]
        public void TestDelegate() {
            Func<int,int> Squared = x => x * x;
            Assert.AreEqual(4, Squared(2));
            Assert.AreEqual(9, Squared(3));
        }

        [TestMethod]
        public void TestDelegate() {
            Multiply MYFunc = (x, y) => x * y;//lamda function
            Assert.AreEqual(4, MYFunc(2, 2));
            MYFunc = (x, y) => x - y;
            /*
            MYFunc = delegate(int x, int y){//delegate function
                return x - y;
            };
             * */
            Assert.AreEqual(0, MYFunc(2, 2));
        }
    }
}
