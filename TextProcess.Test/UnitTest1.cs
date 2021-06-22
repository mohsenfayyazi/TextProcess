using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TextProcess.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var Form = new Form1();
            bool results;


            //Act
            
            string FileName = @"C:\Users\test.png";            

            results =Form.TextFileProcess(FileName);

            //Assert

            Assert.AreEqual(true, results);
           
            

        }
    }
}
