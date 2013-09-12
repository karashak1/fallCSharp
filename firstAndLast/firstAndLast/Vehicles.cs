using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstAndLast {
    public class Vehicle {
        public string Log { get; set; }

        public Vehicle(){
            BreakDown = x => Log += "\nWe broke down"+ x ;
        }

        public const int Speed = 10;

        public IEnumerable<string> Seats = new List<string>{"Driver","Shotgun","Rear","Backseat driver"};
        public virtual void Drive() {
            Log += "\nWe drove somewhere";
        }

        public void Crash(Func<int, int> impact) {
            foreach (var seat in Seats) {
                Log += seat + " affected ";
            }
            Log += " that is: " + string.Join(",", Seats); 
            Log += "\r\nThe impact was:" + impact(Speed);
        }

        public Action<string> BreakDown {get;set;}
    }

    public class Car : Vehicle {
        public void Park() {
            Drive();
            //get into park state
        }
    }

    public class Plane : Vehicle {

        public Plane()
            : base() {
                BreakDown = x => Log += "\nWe fell down" + x;
        }

        public override void Drive() {
            //base.Drive();
            Log += "\nWe flew somewhere";
        } 
 
    }

    public static class Extensions {

        public static void Transfrom(this Vehicle v) {
            v.Log += "I am now an autobot";
        }
    }
}
