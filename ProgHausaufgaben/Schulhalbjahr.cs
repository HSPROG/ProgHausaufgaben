using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daten
{
    public class Schulhalbjahr
    {
        private string schuljahr;
        public string Schuljahr
        {
            get { return schuljahr; }
        }

        private int halbjahr;
        public int Halbjahr
        {
            get { return halbjahr; }
        }

        public Schulhalbjahr(string schuljahr, int halbjahr)
        {
            if (halbjahr < 1 || halbjahr > 2)
                throw new Exception("Das Halbjahr muss einen Wert zwischen 1 und 2 haben!");
            if (String.IsNullOrEmpty(schuljahr))
                throw new Exception("Es fehlt der Parameter Schuljahr für das Schulhalbjahr!");
            this.schuljahr = schuljahr;
            this.halbjahr = halbjahr;
        }

        public override bool Equals(object obj)
        {
            Schulhalbjahr schuljahr = obj as Schulhalbjahr;
            return schuljahr != null && this.schuljahr.Equals(schuljahr.schuljahr) && this.halbjahr.Equals(schuljahr.halbjahr);
        }

        public override int GetHashCode()
        {
            return schuljahr.GetHashCode() ^ halbjahr.GetHashCode();
        }

        public override string ToString()
        {

            return schuljahr + " (" + halbjahr + ".)";
        }
    }
}