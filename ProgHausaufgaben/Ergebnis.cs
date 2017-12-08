using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Daten
{
    public class Ergebnis
    {
        private Schüler schüler;
        public Schüler Schüler
        {
            get { return schüler; }
        }

        private Fach fach;
        public Fach Fach
        {
            get { return fach; }
        }

        private Schulhalbjahr schulhalbjahr;
        public Schulhalbjahr Schulhalbjahr
        {
            get { return schulhalbjahr; }
        }

        private int note;
        public int Note
        {
            get { return note; }
        }

        public Ergebnis(Schüler schüler, Fach fach, Schulhalbjahr schulhalbjahr, int note)
        {
            if (note < 1 || note > 6)
                throw new Exception("Ungültige Note");
            if (schüler == null || fach == null || schulhalbjahr == null)
                throw new Exception("Es Fehlt mindestens eine Angabe des Ergebisses");

            this.schüler = schüler;
            this.fach = fach;
            this.schulhalbjahr = schulhalbjahr;
            this.note = note;

        }

        public override bool Equals(object obj)
        {
            Ergebnis ergebnis = obj as Ergebnis;
            return ergebnis != null && this.schüler.Equals(ergebnis.schüler) && this.fach.Equals(ergebnis.fach)
            && this.schulhalbjahr.Equals(ergebnis.schulhalbjahr) && this.note.Equals(ergebnis.note);
        }

        public override int GetHashCode()
        {
            return schüler.GetHashCode() ^ fach.GetHashCode() ^ schulhalbjahr.GetHashCode() ^ note.GetHashCode();
        }

        public override string ToString()
        {

            return string.Format("Schüler: {0}; Fach: {1}; Schulhalbjahr: {2}; Note: {3}", Schüler, fach, schulhalbjahr, note);
        }

    }
}