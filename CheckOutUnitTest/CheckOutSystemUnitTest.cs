using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace CheckOutUnitTest
{
    [TestClass]
    public class CheckOutSystemUnitTest
    {
        private const double Expected1 = 249.00;
        private const double Expected2 = 2718.95;
        private const double Expected3 =1949.98 ;
        private const double Expected4 = 1788.49;
        private const double Expected5 = 1634.99;
        [TestMethod]
        public void TestMethod1()
        {
            List<string> inputs = new List<string>();
            inputs.Add("atv");
            inputs.Add("atv");
            inputs.Add("atv");
            inputs.Add("vga");
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CheckOutSystem.Program.Checkout(inputs);

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected1,double.Parse( result));
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<string> inputs = new List<string>();
            inputs.Add("atv");
            inputs.Add("ipd");
            inputs.Add("ipd");
            inputs.Add("atv");
            inputs.Add("ipd");
            inputs.Add("ipd");
            inputs.Add("ipd");
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CheckOutSystem.Program.Checkout(inputs);

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected2, double.Parse(result));
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<string> inputs = new List<string>();
            inputs.Add("mbp");
            inputs.Add("vga");
            inputs.Add("ipd");
         
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CheckOutSystem.Program.Checkout(inputs);

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected3, double.Parse(result));
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            List<string> inputs = new List<string>();
            inputs.Add("atv");
            inputs.Add("atv");
            inputs.Add("atv");
            inputs.Add("atv");
            inputs.Add("vga");
            inputs.Add("vga");
            inputs.Add("vga");
            inputs.Add("mbp");

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CheckOutSystem.Program.Checkout(inputs);

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected4, double.Parse(result));
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            List<string> inputs = new List<string>();
            inputs.Add("chi");
            inputs.Add("chi");
            inputs.Add("chi");
            inputs.Add("chi");
            inputs.Add("chi");
            inputs.Add("chi");
            inputs.Add("chi");
            inputs.Add("chi");
            inputs.Add("atv");
            inputs.Add("atv");
            inputs.Add("atv");
            inputs.Add("vga");
            inputs.Add("mbp");

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CheckOutSystem.Program.Checkout(inputs);

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected5, double.Parse(result));
            }
        }
    }
}
