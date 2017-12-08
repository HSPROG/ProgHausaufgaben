using System;
using System.Collections.Generic;
using Daten;
using System.Data.OleDb;

namespace Datenbank
{
    //zum Auslesen der Datenbank:
    public class SchulnotenDatenbank
    {
        private static OleDbConnection con;
        private static OleDbCommand sql;

        // vorläufig wird der Pfad hier angelegt:
        //string pfad = "Provider=Microsoft.ACE.OLEDB.12.0" + "Data Source=database1.accdb";

        public static void DatenbankAuslesen
            (string pfad, out List<Fach> fächer, out List<Schulhalbjahr> schulhalbjahre,
            out List<Schüler> schüler, out List<Ergebnis> ergebnisse)
        {
            con = new OleDbConnection(pfad);
            con.Open();


            // Befüllen der Liste "fächer":
            fächer = new List<Fach>();
            sql = con.CreateCommand();
            sql.CommandText = "SELECT Fachname, Schuljahr FROM Fächer ORDER BY Fachnummer";
            OleDbDataReader reader1 = sql.ExecuteReader();
            while (reader1.Read())
            {
                fächer.Add(new Fach(reader1.GetString(0), reader1.GetInt32(1)));

            }
            reader1.Close();

            // Befüllen der Liste "schulhalbjahre":
            schulhalbjahre = new List<Schulhalbjahr>();
            sql = con.CreateCommand();
            sql.CommandText = "SELECT Schuljahr, Halbjahr FROM Schulhalbjahre";
            OleDbDataReader reader2 = sql.ExecuteReader();
            while (reader2.Read())
            {
                schulhalbjahre.Add(new Schulhalbjahr(reader2.GetString(0), reader2.GetInt32(1)));
            }
            reader2.Close();

            // Befüllen der Liste "schüler":
            schüler = new List<Schüler>();
            sql = con.CreateCommand();
            sql.CommandText = "SELECT * FROM Schüler";
            OleDbDataReader reader3 = sql.ExecuteReader();
            while (reader3.Read())
            {
                schüler.Add(new Schüler(reader3.GetString(0), reader3.GetString(1), reader3.GetString(2)));
            }
            reader3.Close();

            // Befüllen der Liste "ergebnisse":
            ergebnisse = new List<Ergebnis>();
            sql = con.CreateCommand();
            sql.CommandText = "SELECT * " +
                "               FROM (((Ergebnisse" +
                "               LEFT JOIN Schüler ON Ergebnisse.Schülernummer = Schüler.Schülernummer)" +
                "               LEFT JOIN Fächer ON Ergebnisse.Fachnummer = Fächer.Fachnummer)" +
                "               LEFT JOIN Schulhalbjahre ON Ergebnisse.SchulhalbjahrID = Schulhalbjahre.SchulhalbjahrID)";
            OleDbDataReader reader4 = sql.ExecuteReader();
            while (reader4.Read())
            {
                ergebnisse.Add(new Ergebnis(new Schüler(reader4[5].ToString(), reader4[6].ToString(), reader4[7].ToString()),
                                             new Fach(reader4[9].ToString(), Convert.ToInt16(reader4[10].ToString())),
                                             new Schulhalbjahr(reader4[12].ToString(), Convert.ToUInt16(reader4[13].ToString())),
                                             Convert.ToInt16(reader4[5].ToString())));
            }
            reader4.Close();


            /*
                    // Test durch Ausgabe:
                    foreach (Ergebnis element in ergebnisse)
                    {
                        Console.WriteLine(element);
                    }
                    //Console.WriteLine(fächer[1]);
            
            */

            /*
             
              ergebnisse.Add(new Ergebnis(new Schueler(Convert.ToString(reader4.GetString(5)), Convert.ToString(reader4.GetString(6)), Convert.ToString(reader4.GetString(7))),
                                            new Fach(Convert.ToString(reader4.GetString(9)), Convert.ToInt16(reader4.GetValue(10))),
                                            new Schulhalbjahr(Convert.ToString(reader4.GetString(12)), Convert.ToInt16(reader4.GetInt16(13))),
                                            Convert.ToInt16(reader4.GetInt16(4))));
            
             */




            // Syntax 3:
            /*sql.CommandText = "SELECT Schülernummer FROM Ergebnisse ON Ergebnisse.Schülernummer = Schüler.Schülernummer" +
                "               SELECT Fachnummer FROM Ergebnisse ON Ergebnisse.Fachnummer = Fächer.Fachnummer" +
                "               SELECT SchulhalbjahrID FROM Ergebnisse ON Ergebnisse.SchulhalbjahrID = Schulhalbjahre.SchulhalbjahrID";*/

            // Syntax 2:
            /*sql.CommandText = "SELECT Schülernummer, Fachnummer, SchulhalbjahrID, Note" +
              "               FROM  Ergebnisse" +
              "               ON (Ergebnisse.Schülernummer = Schüler.Schülernummer" +
              "                 AND Ergebnisse.Fachnummer = Fächer.Fachnummer" +
              "                 AND Ergebnisse.SchulhalbjahrID = Schulhalbjahre.SchulhalbjahrID)";*/

            // Syntax 1:
            /*sql.CommandText = "SELECT Schülernummer, Fachnummer, SchulhalbjahrID, Note" +
                "               FROM" +
                "               ((Ergebnisse INNER JOIN Schüler ON Ergebnisse.Schülernummer = Schüler.Schülernummer)" +
                "               (Ergebnisse INNER JOIN Fächer ON Ergebnisse.Fachnummer = Fächer.Fachnummer)" +
                "               (Ergebnisse INNER JOIN Schulhalbjahre ON Ergebnisse.SchulhalbjahrID = Schulhalbjahre.SchulhalbjahrID))";*/
        }
    }
}
