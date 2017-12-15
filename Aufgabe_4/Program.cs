using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_4
{

    class Program
    {
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Verschiebe(int umX, int umY)
            {
                this.X += umX;
                this.Y += umY;
            }
        }

        public abstract class Form
        {
            private Position zentrum = new Position();
            private int breite;
            private int höhe;

            public abstract double BerechneFläche();
            public abstract double BerechneUmfang();

            public Position Zentrum
            {
                get
                {
                    return this.zentrum;
                }
            }

            public int Breite
            {
                get
                {
                    return this.breite;
                }
                set
                {
                    if (value >= 0)
                    {
                        this.breite = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }

            public int Höhe
            {
                get
                {
                    return this.höhe;
                }
                set
                {
                    if (value >= 0)
                    {
                        this.höhe = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }

        public class Rechteck : Form
        {
            public override double BerechneFläche()
            {
                return this.Höhe * this.Breite;
            }

            public override double BerechneUmfang()
            {
                return 2 * this.Höhe + 2 * this.Breite;
            }
        }

        public class Kreis : Form
        {
            public override double BerechneFläche()
            {
                return Math.PI / 4.0 * this.Breite * this.Breite;
            }

            public override double BerechneUmfang()
            {
                return Math.PI * this.Breite;
            }

            public new int Höhe
            {
                set
                {
                    this.Breite = value;
                }
                get
                {
                    return this.Breite;
                }
            }
        }

        public class Dreieck : Form
        {
            public override double BerechneFläche()
            {
                return this.Breite * this.Höhe / 2.0;
            }

            public override double BerechneUmfang()
            {
                double basislänge = this.Breite;
                double seitenlänge = Math.Sqrt(
                    0.25 * basislänge * basislänge +
                    this.Höhe * this.Höhe);
                return 2 * seitenlänge + basislänge;
            }
        }

        public static Form[] formen = new Form[1000]; 
 
        static void Main()
        {
            
            string input; //universelle, lokale EingabeVariable für Konsoleneingabe

            formen[0] = new Rechteck();
            Console.Write("Bitte Rechteckbreite als Ganzahl (zwischen –32.768 bis 32.767) eingeben: ");
            formen[0].Breite = Convert.ToInt16(input=Console.ReadLine()); // Konsoleeingabe + Konvertierung in Short(_Int16)

            Console.Write("Bitte Rechteckhöhe als Ganzahl (zwischen –32.768 bis 32.767) eingeben: ");
            formen[0].Höhe = Convert.ToInt16(input = Console.ReadLine()); // Konsoleeingabe + Konvertierung in Short(_Int16)
            formen[0].Zentrum.Verschiebe(20, 50);
            // Ermittlung Index = Pos. von Rechteck im Formen-Array
            //int positionRechteck = Array.IndexOf (formen,);

            // AUSGABE Berechnungen Rechteck
            Console.WriteLine("Fläche Rechteck 0: {0}", formen[0].BerechneFläche());
            Console.WriteLine("Umfang Rechteck 0: {0}", formen[0].BerechneUmfang());

            formen[1] = new Kreis();
            formen[1].Breite = 100;
            formen[1].Zentrum.Verschiebe(-10, 10);
            Console.WriteLine("Fläche Kreis 0: {0}", formen[1].BerechneFläche());
            Console.WriteLine("Umfang Kreis 0: {0}", formen[1].BerechneUmfang());

            formen[2] = new Dreieck();
            formen[2].Breite = 100;
            formen[2].Höhe = 200;
            formen[2].Zentrum.X = 50;
            formen[2].Zentrum.Y = 120;
            Console.WriteLine("Fläche Dreieck 0: {0}", formen[2].BerechneFläche());
            Console.WriteLine("Umfang Dreieck 0: {0}", formen[2].BerechneUmfang());

            Console.ReadKey();
        }
    }
}
