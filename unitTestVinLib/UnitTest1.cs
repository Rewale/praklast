using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VIN_LIB;

namespace unitTestVinLib
{
    [TestClass]
    public class UnitTest1
    {
        #region Тестирование CheckVin
        [TestMethod]
        public void CheckVINSuccses()
        {
            Assert.AreEqual(VIN.CheckVIN("1C4RJEAG6CC011603"), true);
        }

        [TestMethod]
        public void CheckVINFalseLength()
        {
            Assert.AreEqual(VIN.CheckVIN("1C4RJEAG6CC0116"), true);
        }

        [TestMethod]
        public void CheckVINFailed()
        {
            Assert.AreEqual(VIN.CheckVIN("1C4RJEAG6CF0116"), true);
        }

        [TestMethod]
        public void CheckVINSuccses2()
        {
            Assert.AreEqual(VIN.CheckVIN("1FMJK1J51AE558998"), true);
        }

        [TestMethod]
        public void CheckVINSuccses3()
        {
            Assert.AreEqual(VIN.CheckVIN("1FTEX1CM1BF296018"), true);
        }
        #endregion 123

        #region Тестирование GetYear
        [TestMethod]
        public void GetYearSuccses()
        {
            int year = VIN.GetTransportYear("1FTFW1CT5DFC10312");
            Assert.AreEqual(year,2013);
        }

        [TestMethod]
        public void GetYearSuccses2()
        {
            int year = VIN.GetTransportYear("1GC5CZEG0F0017106");
            Assert.AreEqual(year, 2015);
        }

        [TestMethod]
        public void GetYearFailed()
        {
            int year = VIN.GetTransportYear("4T1BG28K81U7");
            Assert.AreEqual(year, 2001);
        }

        [TestMethod]
        public void GetYearSuccses4()
        {
            int year = VIN.GetTransportYear("WBA5B3C50GG252337");
            Assert.AreEqual(year, 2016);
        }

        [TestMethod]
        public void GetYearFailed2()
        {
            int year = VIN.GetTransportYear("WBA5B3C50Gh252337");
            Assert.AreEqual(year, 2016);
        }
        [TestMethod]
        public void GetYearSuccses5()
        {
            int year = VIN.GetTransportYear("LVVDC12B68D154252");
            Assert.AreEqual(year, 2008);
        }
        


        #endregion
    }
}
