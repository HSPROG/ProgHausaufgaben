using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daten
{
    class Schulhalbjahr
    {
        private string _schuljahr;
        public string schuljahr
        {
            get { return _schuljahr; }
        }

        private int _halbjahr;
        public int halbjahr
        {
            get { return _halbjahr; }
        }

        public Schulhalbjahr(string schuljahr, int halbjahr)
        {
            if (halbjahr < 1 || halbjahr > 2)
                throw new Exception("Das Halbjahr muss einen Wert zwischen 1 und 2 haben!");
            if (String.IsNullOrEmpty(schuljahr))
                throw new Exception("Es fehlt der Parameter Schuljahr für das Schulhalbjahr!");
            this._schuljahr = schuljahr;
            this._halbjahr = halbjahr;
        }
		
		public override bool Equals(object obj)
        {
            Schulhalbjahr schuljahr = obj as Schulhalbjahr;
            return schuljahr != null && this._schuljahr.Equals(schuljahr._schuljahr) && this._halbjahr.Equals(schuljahr._halbjahr);
        }
		
		public override int GetHashCode()
        {
            return _schuljahr.GetHashCode() ^ _halbjahr.GetHashCode();
        }

        public override string ToString()
        {

            return schuljahr + " (" + halbjahr + ".)";
        }
    }
}
