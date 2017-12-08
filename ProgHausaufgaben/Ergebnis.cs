using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Daten
{
    class Ergebnis
    {
        private Schüler _schüler;
        public Schüler schüler
        {
            get { return _schüler; }
        }

        private Fach _fach;
        public Fach fach
        {
            get { return _fach; }
        }

        private Schulhalbjahr _schulhalbjahr;
        public Schulhalbjahr schulhalbjahr
        {
            get { return _schulhalbjahr; }
        }

        private int _note;
        public int note
        {
            get { return _note; }
        }

        public Ergebnis(Schüler schüler, Fach fach, Schulhalbjahr schulhalbjahr, int note)
        {
            if (note < 1 || note > 6)
                throw new Exception("Ungültige Note");
            if (schüler == null || fach == null || schulhalbjahr == null)
                throw new Exception("Es Fehlt mindestens eine Angabe des Ergebisses");

            this._schüler = schüler;
            this._fach = fach;
            this._schulhalbjahr = schulhalbjahr;
            this._note = note;

        }

        public override bool Equals(object obj)
        {
            Ergebnis ergebnis = obj as Ergebnis;
            return ergebnis != null && this._schüler.Equals(ergebnis._schüler) && this._fach.Equals(ergebnis._fach)
            && this._schulhalbjahr.Equals(ergebnis._schulhalbjahr) && this._note.Equals(ergebnis._note);
        }

        public override int GetHashCode()
        {
            return _schüler.GetHashCode() ^ _fach.GetHashCode() ^ _schulhalbjahr.GetHashCode() ^ _note.GetHashCode();
        }

        public override string ToString()
        {

            return string.Format("Schüler: {0}; Fach: {1}; Schulhalbjahr: {2}; Note: {3}", schüler, fach, schulhalbjahr, note);
        }

    }
}