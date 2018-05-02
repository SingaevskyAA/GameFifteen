using TorrowTechTest.GameCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FieldTests
{
    [TestClass]
    public class FieldTests
    {
        var field = "16,2,3,4,5,6,7,8,9,10,11,12,13,14,15";
        
        [TestMethod]
        public void CorrectTurnTest()
        {
            var field = new Filed(solvableField);
            field.Turn(0,1);

            var result = field.ToString();
            var correctResult = "2,16,3,4,5,6,7,8,9,10,11,12,13,14,15";
            Assert.AreEqual(result, correctResult);
        }
    }
}
