using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqHomework;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject1 {
    [TestClass]
    public class PeopleTests {

        /* This is the #1 of the homework */
        [TestMethod]
        public void LoadNames() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            /* create a new list of people each one has a name from the 
             * list names
             */
            var people = names.Select(x => new People { Name = x });
            /*var people = from x in names
                         select new People {
                             Name = x,
                         };
             */
            Assert.AreEqual(names.Count(), people.Count());
        }

        /* This is #2 of the homework */
        [TestMethod]
        public void PeopleStartWithM() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = names.Select(x => new People { Name = x });
            /* only get the ones with a name that starts with an M */
            var peopleNameM = people.Where(x => x.Name.StartsWith("M"));
            Assert.AreEqual(4, peopleNameM.Count());
        }

        /*This is #3 of the homework */
        [TestMethod]
        public void PeoplesNamesToUppercase() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = names.Select(x => new People { Name = x });
            // Create a new list of people but with the names to upper case
            var peopleUpperCase = people.Select(x => x.Name = x.Name.ToUpper());
            Assert.AreEqual(names.Count(), peopleUpperCase.Count());

        }

        /*This is #4 of the homework */
        [TestMethod]
        public void PeoplesNameLength() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = names.Select(x => new People { Name = x });
            /*create a list that holds the lengths of each people object and then turn it into an array
             */
            var peopleNameLength = people.Select(x => x.Name.Length).ToArray();
            Assert.AreEqual(names.Count(), peopleNameLength.Count());
        }

        /* This is #5 of the homework */
        [TestMethod]
        public void PeopleOrderSmallName() {
            var names = new[] {"Bessie", "Vashti", "Frederica", "Nisha", "Kendall", "Magdalena", "Brendon"
            , "Eve", "Manda", "Elvera", "Miquel", "Tyra", "Lucie", "Marvella", "Tracee", "Ramiro", "Irene", "Davina", "Jeromy" , "Siu"};
            var people = names.Select(x => new People { Name = x });
            /*create a new list of people witht he name shortened to just the first 3 letters
             * and ordered by name 
             */ 
            var peopleOrderedShortend = people.Select(x => new People { Name = x.Name.Substring(0, 3) }).OrderBy(x => x.Name);
            Assert.AreEqual(names.Count(), peopleOrderedShortend.Count());
        }
    }
}
