using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using firstAndLast;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject1 {
    [TestClass]
    public class VehicleUnitTest {
        [TestMethod]
        public void VehicleCanDrive() {
            var v = new Vehicle();
            v.Drive();
            Assert.IsTrue(v.Log.Contains("drove"));

            v.BreakDown("Out of gas");
            Assert.IsTrue(v.Log.Contains("broke"));
        }

        [TestMethod]
        public void PlaneCanFly() {
            var v = new Plane();
            v.Drive();
            Assert.IsTrue(v.Log.Contains("flew"));
            v.BreakDown("Engine failed");
            Assert.IsTrue(v.Log.Contains("fell"));

            v.BreakDown = x => v.Log += "\nWe are just fine" + x;
            v.Log = "";
            v.BreakDown("Gremlins");
            Assert.IsTrue(v.Log.Contains("fine"));

        }

        [TestMethod]
        public void CrashesHurt() {
            var v = new Vehicle();
            v.Crash(x => x);
            Assert.IsTrue(v.Log.Contains("1"));

            v.Crash(x => x*55);
            Assert.IsTrue(v.Log.Contains("55"));
            
        }

        [TestMethod]
        public void VehiclesCanTransform() {
            var v = new Vehicle();
            v.Transfrom();
            Assert.IsTrue(v.Log.Contains("autobot"));
        }

        IEnumerable<int> numbers = Enumerable.Range(0, 100);
        [TestMethod]
        public void Ling101() {
            //var numbers = Enumerable.Range(0,100)// new[] { 0, 1, 2, 3, 4, 5 };
            var actual = new List<int>();
            foreach (var x in numbers) {
                if (x % 2 == 0)
                    actual.Add(x);
            }
            Assert.AreEqual(50, actual.Count);
            var actual2 = numbers.Where(y => y % 2 == 0);
            //if(x % 2 == 0)
            //numbers.
            Assert.AreEqual(50, actual2.Count());

            Assert.AreEqual(50, numbers.Count(y => y % 2 == 0));
        }

        [TestMethod]
        public void LinqSelect() {
            var actual = numbers.Select(x => x*x);
            Assert.IsTrue(actual.Contains(9801));
            var actual2 = numbers.Where(x => x % 3 == 0).Select(x => x * x);
            Assert.IsTrue(actual2.Contains(9801));

        }
        
        [TestMethod]
        public void LinqComplex() {
            var processess = System.Diagnostics.Process.GetProcesses();

            var names = processess
                .Select(x => new { x.ProcessName, ThreadCount = x.Threads.Count })
                .Where(x => x.ThreadCount < 10);

            var otherStuff = from x in processess 
                             where x.Threads.Count > 3
                             orderby x.ProcessName
                             select new {x.ProcessName, x.PeakWorkingSet64, x.Responding };
            
            var otherStuff2 = from x in processess 
                             where x.Modules.OfType<System.Diagnostics.ProcessModule>().Any(y => y.ModuleMemorySize > 1000)
                             orderby x.ProcessName
                             select new {x.ProcessName, x.PeakWorkingSet64, x.Responding };
        
        }
         
    }
}
