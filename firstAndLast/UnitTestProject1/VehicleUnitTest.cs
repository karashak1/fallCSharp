using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using firstAndLast;

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
    }
}
