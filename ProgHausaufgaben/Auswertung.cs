using System;
using System.Collections.Generic;
using Daten;


namespace Datenauswertung
{
    public class Auswertung
    {
        public int anzahlFächer;
        public int anzahlSchulhalbjahre;
        public int anzahlSchüler;
        public int anzahlErgebnisse;
        public int anzahlFachnamen;

        public List<Fach> fächer;
        public List<Schulhalbjahr> schulhalbjahre;
        public List<Schüler> schüler;
        public List<string> fachnamen;


        //Interpretation: Die Liste ergebnisse wird als tiefe Kopie gespeichert.
        public List<Ergebnis> ergebnisListe;

        public Auswertung(List<Fach> fächer, List<Schulhalbjahr> schulhalbjahre, List<Schüler> schüler, List<Ergebnis> ergebnisse)
        {
            if (!(Konsistenzprüfung(fächer, schulhalbjahre, schüler, ergebnisse)))
                throw new Exception("Fehler bei der Konsistenzprüfung :( So nicht BURSCH!");

            this.fächer = fächer;
            this.schulhalbjahre = schulhalbjahre;
            this.schüler = schüler;

            List<string> übergabe = new List<string>();
            foreach (var v in fächer)
            {
                if (!(übergabe.Contains(v.Fachname)))
                    übergabe.Add(v.Fachname);
            }

            this.fachnamen = übergabe;
            this.anzahlErgebnisse = ergebnisse.Count;
            this.anzahlFächer = fächer.Count;
            this.anzahlSchüler = schüler.Count;
            this.anzahlFachnamen = fachnamen.Count;
            this.anzahlSchulhalbjahre = schulhalbjahre.Count;

            //Interpretation: Die Liste ergebnisse wird als tiefe Kopie gespeichert.
            this.ergebnisListe = new List<Ergebnis>();
            foreach (Ergebnis e in ergebnisse)
            {
                this.ergebnisListe.Add(new Ergebnis(new Schüler(e.Schüler.Schülernummer, e.Schüler.Name, e.Schüler.Vorname), new Fach(e.Fach.Fachname, e.Fach.Schuljahr), new Schulhalbjahr(e.Schulhalbjahr.Schuljahr, e.Schulhalbjahr.Halbjahr), e.Note));
            }
        }



        public static bool Konsistenzprüfung(List<Fach> fächer, List<Schulhalbjahr> schulhalbjahre, List<Schüler> schüler, List<Ergebnis> ergebnisse)
        {
            //Benutzung von GetHashCode

            bool b = true;

            //Jedes Fach, jedes Schulhalbjahr und jeder Schüler muss in den Ergebnissen mindestens einmal vorkommen. -> Findet man in jeder der einzelnen Schleifen

            //Jeder Fachname in den Fächern muss in jedem Schuljahr genau einmal vorkommen .
            for (int x = 0; x < fächer.Count; x++)
            {
                for (int xx = 0; xx < ergebnisse.Count; xx++)
                {
                    if (fächer[x].Equals(ergebnisse[xx].Fach))
                        break;
                    if (xx == ergebnisse.Count - 1)
                        b = false;
                }
                for (int xx = 0; xx < fächer.Count; xx++)
                {
                    if (fächer[x].GetHashCode() == fächer[xx].GetHashCode() && x != xx)
                        b = false;
                }
            }

            //Jede Kombination von Schuljahr und Halbjahr aus den Schulhalbjahren darf nur einmal vorkommen .
            for (int x = 0; x < schulhalbjahre.Count; x++)
            {
                for (int xx = 0; xx < ergebnisse.Count; xx++)
                {
                    if (schulhalbjahre[x].Equals(ergebnisse[xx].Schulhalbjahr))
                        break;
                    if (xx == ergebnisse.Count - 1)
                        b = false;
                }
                for (int xx = 0; xx < schulhalbjahre.Count; xx++)
                {
                    if (schulhalbjahre[x].GetHashCode() == schulhalbjahre[xx].GetHashCode() && x != xx)
                        b = false;
                }
            }

            //Belegt ein Schüler in einem Halbjahr ein Fach, so muss er auch alle anderen Fächer belegen.
            //Jedes Fach, jedes Schulhalbjahr und jeder Schüler aus den Ergebnissen muss in den jeweiligen Listen auch vorkommen .
            //Jede Kombination aus Fachname, Schulhalbjahr und Schüler darf höchstens einmal in den Ergebnissen vorkommen.
            int hilfeSchülersuche = ergebnisse[0].Schüler.Schülernummer.GetHashCode();
            int hilfeHalbjahre = ergebnisse[0].Schulhalbjahr.Halbjahr.GetHashCode();

            int zählerHalbjahre = 0;

            //Test
            //ergebnisse.RemoveAt(34);
            //Console.WriteLine(ergebnisse.Count);
            List<string> namen = new List<string>();
            foreach (var v in fächer)
            {
                if (!(namen.Contains(v.Fachname)))
                    namen.Add(v.Fachname);
            }
            int längeFächer = namen.Count;
            namen = new List<string>();

            for (int x = 0; x < ergebnisse.Count; x++)
            {
                if (ergebnisse[x].Schüler.Schülernummer.GetHashCode() != hilfeSchülersuche)
                {
                    if (längeFächer != zählerHalbjahre)
                        b = false;

                }
                if (hilfeHalbjahre != ergebnisse[x].Schulhalbjahr.Halbjahr.GetHashCode())
                {
                    if (längeFächer != zählerHalbjahre)
                        b = false;
                    namen = new List<string>();
                    zählerHalbjahre = 0;
                }
                if (!(namen.Contains(ergebnisse[x].Fach.Fachname)))
                {
                    namen.Add(ergebnisse[x].Fach.Fachname);
                    zählerHalbjahre++;
                }


                if (!(schüler.Contains(ergebnisse[x].Schüler)))
                    b = false;
                if (!(fächer.Contains(ergebnisse[x].Fach)))
                    b = false;
                if (!(schulhalbjahre.Contains(ergebnisse[x].Schulhalbjahr)))
                    b = false;

                for (int xx = 0; xx < ergebnisse.Count; xx++)
                {
                    //Davor
                    //if(ergebnisse[x].GetHashCode() == ergebnisse[xx].GetHashCode() && x != xx)
                    //Funktionierte z.b. nicht bei ergebnisse[15] und ergebnisse[22]! Ziemlich fies :/
                    if (ergebnisse[x].Equals(ergebnisse[xx]) && x != xx)
                        b = false;
                }
                hilfeSchülersuche = ergebnisse[x].Schüler.Schülernummer.GetHashCode();
                hilfeHalbjahre = ergebnisse[x].Schulhalbjahr.Halbjahr.GetHashCode();
            }


            for (int x = 0; x < schüler.Count; x++)
            {
                for (int xx = 0; xx < ergebnisse.Count; xx++)
                {
                    if (schüler[x].Equals(ergebnisse[xx].Schüler))
                        break;
                    if (xx == ergebnisse.Count - 1)
                        b = false;
                }

                //Prüfung Schüler optional?
                //                  for (int xx = 0; xx < schüler.Count; xx++){
                //                      if(schüler[x].GetHashCode() == schüler[xx].GetHashCode() && x != xx)
                //                          b = false;
                //                  }
            }




            //erster (falscher) Versuch
            //          foreach(Schulhalbjahr s in schulhalbjahre){
            //              foreach(Schulhalbjahr ss in schulhalbjahre){
            //                  if(s.Halbjahr == ss.Halbjahr && s.Schuljahr == ss.Schuljahr)
            //                      b = false;
            //              }
            //          }
            //          foreach(Schulhalbjahr s in schulhalbjahre){
            //              foreach(Schulhalbjahr ss in schulhalbjahre){
            //                  if(s.Halbjahr == ss.Halbjahr && s.Schuljahr == ss.Schuljahr)
            //                      b = false;
            //              }
            //          }

            return b;

        }

        //Hier werden für einen gegebenen Schüler und ein gegebenes Schulhalbjahr alle wichtigen Angaben für das Halbjahreszeugnis zurückgegeben,
        //namentlich die Liste der besuchten Fächer und die Liste der Noten eines jeden Fachs (am selben Index in der Liste des Fächer).

        public void Zeugnis(Schüler schüler, Schulhalbjahr schulhalbjahr, out List<Fach> fächer, out List<int> noten)
        {

            fächer = new List<Fach>();
            noten = new List<int>();
            foreach (Ergebnis e in this.ergebnisListe)
            {
                if (e.Schüler.Equals(schüler) && e.Schulhalbjahr.Equals(schulhalbjahr))
                {
                    fächer.Add(e.Fach);
                    noten.Add(e.Note);
                }
            }

            //Test
            //          Console.WriteLine(fächer.Count);
            //          Console.WriteLine(noten.Count);
            //          for(int x = 0; x < fächer.Count; x++){
            //              Console.WriteLine("Fach " + fächer[x] + " mit Note " + noten[x]);
            //          }
        }

        //Wie oben, jedoch liefert diese Methode das Zeugnis in druckbarer Form.
        public string ZeugnisText(Schüler schüler, Schulhalbjahr schulhalbjahr)
        {
            List<int> notenNeu;
            List<Fach> fächerNeu;
            string übergabe = "ZEUGNIS \nfür " + schüler + "\nim Schulhalbjahr " + schulhalbjahr + "\n\n";

            Zeugnis(schüler, schulhalbjahr, out fächerNeu, out notenNeu);


            for (int x = 0; x < fächerNeu.Count; x++)
            {
                übergabe = übergabe + fächerNeu[x] + "........" + notenNeu[x] + "\n";
            }

            return übergabe;
        }

        public int[,] Entwicklung(Schüler schüler)
        {
            int[,] Matrix = new int[anzahlFächer, anzahlSchulhalbjahre];

            for (int x = 0; x < anzahlFachnamen; x++)
            {
                for (int xx = 0; xx < anzahlSchulhalbjahre; xx++)
                {
                    for (int y = 0; y < anzahlErgebnisse; y++)
                    {
                        if (ergebnisListe[y].Schüler.Equals(schüler) && ergebnisListe[y].Schulhalbjahr.Equals(schulhalbjahre[xx]))
                        {
                            Matrix[x, xx] = ergebnisListe[y].Note;
                            break;
                        }
                        if (y == anzahlErgebnisse - 1)
                            Matrix[x, xx] = 0;
                    }

                }
            }

            return Matrix;
        }

        public string EntwicklungText(Schüler schüler)
        {
            int[,] übergabeMatrix = Entwicklung(schüler);
            string ausgabe = "Entwicklung von: " + schüler + "\n" + "Halbjahr \t";

            foreach (Schulhalbjahr sh in schulhalbjahre)
                ausgabe = ausgabe + sh.Halbjahr + "\t";
            ausgabe = ausgabe + "\n";
            for (int x = 0; x < anzahlFachnamen; x++)
            {
                ausgabe = ausgabe + fachnamen[x] + "\t";
                if (fachnamen[x].Length < 8)
                    ausgabe = ausgabe + "\t";
                for (int xx = 0; xx < anzahlSchulhalbjahre; xx++)
                {
                    ausgabe = ausgabe + übergabeMatrix[x, xx] + "\t";
                }
                ausgabe = ausgabe + "\n";
            }
            ausgabe = ausgabe + "\n" + "erstes Schuljahr: " + schulhalbjahre[0].Schuljahr;
            return ausgabe;

        }

        public double[,] Durchschnittsnoten()
        {

            double[,] Matrix = new double[anzahlFächer, anzahlSchulhalbjahre / 2];
            double summe = 0.0;
            int zähler = 0;
            int EsIstTraurigDassIchHierFürEineHilfsvariableBrauche = 0;
            for (int x = 0; x < anzahlFachnamen; x++)
            {
                for (int xx = 0; xx < anzahlSchulhalbjahre; xx = xx + 2)
                {

                    for (int y = 0; y < anzahlErgebnisse; y++)
                    {
                        if (fachnamen[x].Equals(ergebnisListe[y].Fach.Fachname) && schulhalbjahre[xx].Schuljahr.Equals(ergebnisListe[y].Schulhalbjahr.Schuljahr))
                        {
                            summe = summe + ergebnisListe[y].Note;
                            zähler++;
                        }
                    }
                    Matrix[x, EsIstTraurigDassIchHierFürEineHilfsvariableBrauche] = Math.Round((summe / (zähler)), 2);
                    summe = 0.0;
                    zähler = 0;
                    EsIstTraurigDassIchHierFürEineHilfsvariableBrauche++;
                }
                EsIstTraurigDassIchHierFürEineHilfsvariableBrauche = 0;
            }

            return Matrix;
        }

        public string DurchschnittsnotenText()
        {
            double[,] übergabeMatrix = Durchschnittsnoten();
            string ausgabe = "Durchschnittsnoten:\n\n" + "Schuljahr\t";
            int zähler = 1;
            foreach (Schulhalbjahr sh in schulhalbjahre)
            {
                if (sh.Halbjahr == 2)
                {
                    ausgabe = ausgabe + zähler + "\t";
                    zähler++;
                }
            }

            ausgabe = ausgabe + "\n";
            for (int x = 0; x < anzahlFachnamen; x++)
            {
                ausgabe = ausgabe + fachnamen[x] + "\t";
                if (fachnamen[x].Length < 8)
                    ausgabe = ausgabe + "\t";
                for (int xx = 0; xx < anzahlSchulhalbjahre / 2; xx++)
                {
                    ausgabe = ausgabe + übergabeMatrix[x, xx] + "\t";
                }
                ausgabe = ausgabe + "\n";
            }

            return ausgabe;

        }
    }

}