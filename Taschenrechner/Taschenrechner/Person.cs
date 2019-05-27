using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
        
        // Anforderungen
        /* 
         * Wenn die werte gleich sidn -> true
         */

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (! (obj is Person) )
                return false;
            if (obj == this) // Referenzvergleich
                return true;
            else // Wertevergleich
            {
                var p2 = (Person)obj;
                if (this.Vorname == p2.Vorname &&
                   this.Nachname == p2.Nachname &&
                   this.Alter == p2.Alter &&
                   this.Kontostand == p2.Kontostand)
                    return true; // Alle Werte gleich;
            }
            return false; // Ungleich
        }
    }
}
