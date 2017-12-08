using System;

namespace Daten
{
    public class Fach
    {
        private string fachname;
        public string Fachname
        {
            get { return fachname; }
        }

        private int schuljahr;
        public int Schuljahr
        {
            get { return schuljahr; }

        }

        public Fach(string fachname, int schuljahr)
        {
            if (schuljahr < 1 || schuljahr > 5)
                throw new Exception("Ungültiges Schuljahr");
            if (String.IsNullOrEmpty(fachname))
                throw new Exception("Es fehlt der Fachname!");

            this.fachname = fachname;
            this.schuljahr = schuljahr;
        }

        public override bool Equals(object obj)
        {
            Fach fach = obj as Fach;
            return fach != null && this.fachname.Equals(fach.fachname) && this.schuljahr.Equals(fach.schuljahr);
        }

        public override int GetHashCode()
        {
            return fachname.GetHashCode() ^ schuljahr.GetHashCode();
        }

        public override string ToString()
        {

            return fachname + " (" + schuljahr + ".)";
        }
    }
}