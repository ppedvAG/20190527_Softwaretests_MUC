using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [TestCategory("PersonTests")]
        public void Person_Equals_compare_with_null_returns_false()
        {
            var p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            var result = p1.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PersonTests")]
        public void Person_Equals_compare_with_wrong_type_returns_false()
        {
            var p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            var wrongType = new StringBuilder();

            var result = p1.Equals(wrongType);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PersonTests")]
        public void Person_Equals_compare_when_references_are_equal_returns_true()
        {
            var p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            var p2 = p1; // Referenzkopie

            var result = p1.Equals(p2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("PersonTests")]
        public void Person_Equals_compare_when_values_are_equal_returns_true()
        {
            var p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            var p2 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            var result = p1.Equals(p2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("PersonTests")]
        public void Person_Equals_compare_when_values_are_not_equal_returns_false()
        {
            var p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            var p2 = new Person { Vorname = "Anna", Nachname = "Nass", Alter = 10, Kontostand = 100 };

            var result = p1.Equals(p2);

            Assert.IsFalse(result);
        }
    }
}
