using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daten
{
    class Fach
    {
        private string _fachname;
        public string fachname
        {
            get { return _fachname; }
        }

        private int _schuljahr;
        public int schuljahr
        {
            get { return _schuljahr; }

        }

        public Fach(string fachname, int schuljahr)
        {
            if (schuljahr < 1 || schuljahr > 5)
                throw new Exception("Ungültiges Schuljahr");
            if (String.IsNullOrEmpty(fachname))
                throw new Exception("Es fehlt der Fachname!");

            this._fachname = fachname;
            this._schuljahr = schuljahr;
        }
		
		public override bool Equals(object obj)
        {
            Fach fach = obj as Fach;
            return fach != null && this._fachname.Equals(fach._fachname) && this._schuljahr.Equals(fach._schuljahr);
        }
		
		public override int GetHashCode()
        {
            return _fachname.GetHashCode() ^ _schuljahr.GetHashCode();
        }
		
		public override string ToString()
        {
            
            return fachname + " (" + schuljahr + ".)" ;
        }
    }
}
