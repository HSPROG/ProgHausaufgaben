using System;

namespace Daten
{
    public class Schüler
    {
        private string schülernummer;
        public string Schülernummer
        {
            get { return schülernummer; }
        }

        private string name;
        public string Name
        {
            get { return name; }
        }

        private string vorname;
        public string Vorname
        {
            get { return vorname; }
        }

        public Schüler(string schülernummer, string name, string vorname)
        {
            if (String.IsNullOrEmpty(schülernummer) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(vorname))
                throw new Exception("Es fehlt mindestens ein Parameter für Schüler!");

            this.schülernummer = schülernummer;
            this.name = name;
            this.vorname = vorname;

        }

        public override bool Equals(object obj)
        {
            Schüler Schüler = obj as Schüler;
            return Schüler != null && this.Schülernummer.Equals(Schüler.schülernummer) && this.name.Equals(Schüler.name) && this.vorname.Equals(Schüler.vorname);
        }

        public override int GetHashCode()
        {
            return schülernummer.GetHashCode() ^ name.GetHashCode() ^ vorname.GetHashCode();
        }

        public override string ToString()
        {

            return schülernummer + " (" + name + ", " + vorname + ")";
        }

    }
}