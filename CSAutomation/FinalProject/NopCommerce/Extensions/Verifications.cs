using FinalProject.NopCommerce.Utilities;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;


namespace FinalProject.NopCommerce.Extensions
{
    class Verifications : CommonOps
    {
        public static void VerifyEquals(int actual, int expected)
        {
            try
            {
                Assert.AreEqual(actual, expected);
                Console.WriteLine("Verification passed");
                test.Log(LogStatus.Pass, "Verification passed");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verification failed" + e.Message);
                test.Log(LogStatus.Fail, "Verification failed" + e.Message + test.AddScreenCapture(ScreenShot()));
                //Assert.Fail("Verification failed" + e.Message);
            }
        }
        public static void VerifyEquals(string actual, string expected)
        {
            try
            {
                Assert.AreEqual(actual, expected);
                Console.WriteLine("Verification passed");
                test.Log(LogStatus.Pass, "Verification passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Verification failed" + e.Message);
                test.Log(LogStatus.Fail, "Verification failed" + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Verification failed" + e.Message);
            }
        }
    }
}
 

