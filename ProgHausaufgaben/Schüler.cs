using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daten
{
    class Schüler
    {
        private string _schülernummer;
        public string schülernummer
        {
            get { return _schülernummer; }
        }

        private string _name;
        public string name
        {
            get { return _name; }
        }

        private string _vorname;
        public string vorname
        {
            get { return _vorname; }
        }

        public Schüler(string schülernummer, string name, string vorname)
        {
            if (String.IsNullOrEmpty(schülernummer) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(vorname))
                throw new Exception("Es fehlt mindestens ein Parameter für Schüler!");

            this._schülernummer = schülernummer;
            this._name = name;
            this._vorname = vorname;

        }

        public override bool Equals(object obj)
        {
            Schüler schüler = obj as Schüler;
            return schüler != null && this._schülernummer.Equals(schüler._schülernummer) && this._name.Equals(schüler._name) && this._vorname.Equals(schüler._vorname);
        }

        public override int GetHashCode()
        {
            return _schülernummer.GetHashCode() ^ _name.GetHashCode() ^ _vorname.GetHashCode();
        }

        public override string ToString()
        {

            return schülernummer + " (" + name + ", " + vorname + ")";
        }

    }
}