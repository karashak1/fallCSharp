using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using firstAndLast;
using System.Linq;
using System.Collections.Generic;


namespace UnitTestProject1 {
    [TestClass]
    public class PeopleTests {

        [TestMethod]
        public void LoadNames() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = from x in names
                         select new People {
                             Name = x,
                         }; 
            Assert.AreEqual(names.Count(), people.Count());
        }

        [TestMethod]
        public void PeopleStartWithM() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = from x in names
                         select new People {
                             Name = x,
                         }; 
            var peopleNameM = people.Where(x => x.Name.StartsWith("M"));
            Assert.AreEqual(4, peopleNameM.Count());
        }

        [TestMethod]
        public void PeoplesNamesToUppercase() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = from x in names
                         select new People {
                             Name = x,
                         };
            var peopleUpperCase = from x in people
                                  select new People {
                                      Name = x.Name.ToUpper(),
                                  };
            Assert.AreEqual(names.Count(), peopleUpperCase.Count());

        }

        [TestMethod]
        public void PeoplesNameLength() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = from x in names
                         select new People {
                             Name = x,
                         };
            var peopleNameLength = people.Select(x => x.Name.Length).ToArray();
            Assert.AreEqual(names.Count(), peopleNameLength.Count());
        }

        [TestMethod]
        public void PeopleOrderSmallName() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = from x in names
                         select new People {
                             Name = x,
                         };
            //var peopleOderedName = people.OrderBy(x => x.Name);
            var peopleOrderedShortend = from x in people
                                        select new People {
                                            Name = x.Name.Substring(0, 3),
                                        };
            peopleOrderedShortend = peopleOrderedShortend.OrderBy(x => x.Name);
            Assert.AreEqual(names.Count(), peopleOrderedShortend.Count());
 
        }
    }
}
