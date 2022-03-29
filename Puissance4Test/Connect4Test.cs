using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puissance4;
using System;

namespace Puissance4Test
{
    [TestClass]
    public class Connect4Test
    {
        [TestMethod]
        public void VerticalVictory()
        {
            var test = new Connect4();
            test.Play(1);
            test.Play(4);
            test.Play(1);
            test.Play(4);
            test.Play(1);
            test.Play(4);
            test.Play(1);
            Assert.AreEqual(true, test.Ended);
            Assert.AreEqual(1, test.Winner);
        }


        [TestMethod]
        public void HorizontalVictory()
        {
            var test = new Connect4();
            test.Play(6);
            test.Play(2);
            test.Play(6);
            test.Play(4);
            test.Play(6);
            test.Play(3);
            test.Play(2);
            test.Play(1);
            Assert.AreEqual(true, test.Ended);
            Assert.AreEqual(2, test.Winner);
        }
        [TestMethod]
        public void diagonalSouthWestToNorthEstVictory()
        {
            var test = new Connect4();
            //1
            test.Play(2);
            //2
            test.Play(4);
            //1
            test.Play(4);
            //2
            test.Play(5);
            //1
            test.Play(4);
            //2
            test.Play(5);
            //1
            test.Play(5);
            //2
            test.Play(1);
            //1
            test.Play(5);
            //2
            test.Play(3);
            //1
            test.Play(3);
            Assert.AreEqual(true, test.Ended);
            Assert.AreEqual(1, test.Winner);
        }

        [TestMethod]
        public void diagonalSouthEstToNorthWestVictory()
        {
            var test = new Connect4();
            //1
            test.Play(5);
            //2
            test.Play(3);
            //1
            test.Play(3);
            //2
            test.Play(2);
            //1
            test.Play(3);
            //2
            test.Play(2);
            //1
            test.Play(2);
            //2
            test.Play(1);
            //1
            test.Play(2);
            //2
            test.Play(1);
            //1
            test.Play(4);
            //2
            test.Play(7);
            //1
            test.Play(4);
            Assert.AreEqual(true, test.Ended);
            Assert.AreEqual(1, test.Winner);
        }
        [TestMethod]
        public void DrawTest()
        {
            var test = new Connect4();


            for (int j = 1; j <= test.ColCount; j++)
            {
                for (int i = 0; i < test.LineCount; i++)
                {
                    test.Play(j);
                }
            }

            Assert.AreEqual(true, test.Ended);
            Assert.AreEqual(0, test.Winner);
        }

        [TestMethod]
        public void FullColumn()
        {
            var test = new Connect4();


            for (int j = 0; j < test.LineCount; j++)
            {

                test.Play(1);

            }
            Action act = () => test.Play(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public void OutOfBound()
        {
            var test = new Connect4();
            Action act = () => test.Play(8);
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }
    }
}
