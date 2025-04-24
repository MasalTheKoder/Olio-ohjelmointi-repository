using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuolia_kaupan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa nuoli kauppaan!");

            int karkiInput;
            do
            {
                Console.Write("Valitse nuolen kärki (1: puu, 2: teräs, 3: timantti): ");
                karkiInput = Convert.ToInt32(Console.ReadLine());
            } while (karkiInput < 1 || karkiInput > 3);

            int peruInput;
            do
            {
                Console.Write("Valitse nuolen perä (1: lehti, 2: kanansulka, 3: kotkansulka): ");
                peruInput = Convert.ToInt32(Console.ReadLine());
            } while (peruInput < 1 || peruInput > 3);

            int pituusInput;
            do
            {
                Console.Write("Syötä nuolen varren pituus (cm, väliltä 60-100): ");
                pituusInput = Convert.ToInt32(Console.ReadLine());
            } while (pituusInput < 60 || pituusInput > 100);

            Nuoli nuoli = new Nuoli((Kärki)karkiInput, (Peru)peruInput, pituusInput);
            double hinta = nuoli.PalautaHinta();

            Console.WriteLine("Nuolen hinta on: " + hinta + " kultaa.");

            Console.WriteLine("Paina Enter sulkeaksesi ohjelman...");
            Console.ReadLine();
        }
    }

    enum Kärki
    {
        PUU = 1,
        TERAS = 2,
        TIMANTTI = 3
    }

    enum Peru
    {
        LEHTI = 1,
        KANANSULKA = 2,
        KOTKANSULKA = 3
    }

    class Nuoli
    {
        private Kärki karki;
        private Peru peru;
        private int pituus;

        public Nuoli(Kärki karki, Peru peru, int pituus)
        {
            this.karki = karki;
            this.peru = peru;
            this.pituus = pituus;
        }

        public double PalautaHinta()
        {
            double karkiHinta = this.karki == Kärki.PUU ? 3 : this.karki == Kärki.TERAS ? 5 : 50;
            double peruHinta = this.peru == Peru.LEHTI ? 0 : this.peru == Peru.KANANSULKA ? 1 : 5;
            double varsiHinta = this.pituus * 0.05;
            double hinta = karkiHinta + peruHinta + varsiHinta;
            return hinta;
        }
    }
}
