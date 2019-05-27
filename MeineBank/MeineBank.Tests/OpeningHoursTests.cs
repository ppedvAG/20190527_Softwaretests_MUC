using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineBank.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2019, 5, 27, 10, 29, false)] // mo
        [DataRow(2019, 5, 27, 10, 30, true)]  // mo
        [DataRow(2019, 5, 27, 19, 00, false)] // mo
        [DataRow(2019, 5, 28, 10, 29, false)] // di
        [DataRow(2019, 5, 28, 10, 30, true)]  // di
        [DataRow(2019, 5, 28, 19, 00, false)] // di
        [DataRow(2019, 5, 29, 10, 29, false)] // mi
        [DataRow(2019, 5, 29, 10, 30, true)]  // mi
        [DataRow(2019, 5, 29, 19, 00, false)] // mi
        [DataRow(2019, 5, 30, 10, 29, false)] // do
        [DataRow(2019, 5, 30, 10, 30, true)]  // do
        [DataRow(2019, 5, 30, 19, 00, false)] // do
        [DataRow(2019, 5, 31, 10, 29, false)] // fr
        [DataRow(2019, 5, 31, 10, 30, true)]  // fr
        [DataRow(2019, 5, 31, 19, 00, false)] // fr
        [DataRow(2019, 6, 1, 10, 29, false)] // sa
        [DataRow(2019, 6, 1, 10, 30, true)]  // sa
        [DataRow(2019, 6, 1, 14, 00, false)] // sa
        [DataRow(2019, 6, 2, 10, 29, false)] // so
        [DataRow(2019, 6, 2, 10, 30, false)] // so
        [DataRow(2019, 6, 2, 12, 00, false)] // so
        [DataRow(2019, 6, 2, 14, 00, false)] // so
        public void OpeningHours_IsOpen(int year, int month, int day, int hour, int minute, bool result)
        {
            var dt = new DateTime(year, month, day, hour, minute, 0);
            var oh = new OpeningHours();

            Assert.AreEqual(result, oh.IsOpen(dt));
        }

        // FakesFramework: .NET 4.7.* macht öfters probleme => 4.6.* verwenden !
        [TestMethod]
        public void OpeningHours_IsNowOpen()
        {
            // var oh = new OpeningHours();
            // var result = oh.IsNowOpen(); // Test funktioniert nur zwischen 10:30 und 19:00 :(
            // Assert.IsTrue(result); // es ist offen

            using (ShimsContext.Create()) // Nur innerhalb des using-Blocks sind meine Fakes gültig
            {
                // Nach dieser Zeile Code wird DateTime.Now immer den 1.1.2019 um 20:00 zurückliefern
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 1, 1, 20, 00, 00);

                // Andere abhängigkeiten:
                System.IO.Fakes.ShimFile.ExistsString = filename => true; // File.Exists(..) liefert immer True

                Assert.IsTrue(File.Exists("7:\\kjads%%&(%&.IGASD%QQQQ@@q³³³"));

                var oh = new OpeningHours();
                var result = oh.IsNowOpen();

                Assert.IsFalse(result); // Dienstag um 20:00 muss zu sein !!!
            }

            // Ab hier ist wieder alles normal 
        }
    }
}
