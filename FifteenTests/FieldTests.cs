using Microsoft.VisualStudio.TestTools.UnitTesting;
using TorrowTechTest.GameCore;

namespace FifteenTests
{
    [TestClass]
    public class FieldTests
    {
        
        [TestMethod]
        public void PossibleTurnTest()
        {
            var fieldSource = "16,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15";

            var field = new Field(fieldSource);
            field.Turn(0, 1);

            var result = field.ToString();
            var correctResult = "1,16,2,3,4,5,6,7,8,9,10,11,12,13,14,15";

            Assert.AreEqual(result, correctResult);
        }

        [TestMethod]
        public void ImpossibleTurnTest()
        {
            var fieldSource = "16,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15";

            var field = new Field(fieldSource);
            field.Turn(3, 1);

            var result = field.ToString();            

            Assert.AreEqual(result, fieldSource);
        }

        [TestMethod]
        public void OutOfRangeTurnTest()
        {
            var fieldSource = "16,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15";

            var field = new Field(fieldSource);
            field.Turn(100, 100);

            var result = field.ToString();

            Assert.AreEqual(result, fieldSource);
        }

        [TestMethod]
        public void OutOfRangeTurnTestNegativeArgs()
        {
            var fieldSource = "16,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15";

            var field = new Field(fieldSource);
            field.Turn(-100, -100);

            var result = field.ToString();

            Assert.AreEqual(result, fieldSource);
        }

        [TestMethod]
        public void BlankTurnTest()
        {
            var fieldSource = "16,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15";

            var field = new Field(fieldSource);
            field.Turn(0, 0);

            var result = field.ToString();

            Assert.AreEqual(result, fieldSource);
        }
    }
}
