using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    class Program
    {
        static void Main(string[] args)
        {
            bool controllo;
            string s;
            int scelta;
            double consumikWh, consumiSmc, kWhTot, smcTot = 0;
            List<object> metodiRiscaldamento;
            List<Bolletta> bollette = new List<Bolletta>();
            Bolletta bolletta;

            do
            {
                Console.WriteLine("Inserisci i kWh annui medi consumati");
                s = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(s, out consumikWh);
            } while (!controllo || consumikWh < 0);

            do
            {
                Console.WriteLine("Inserisci gli SMC annui medi consumati");
                s = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(s, out consumiSmc);
            } while (!controllo || consumiSmc < 0);

            kWhTot = (consumiSmc * 10.7) + consumikWh;
            smcTot = (consumikWh / 10.7) + consumiSmc;

            do
            {
                Console.WriteLine("Scegli il tuo metodo di riscaldamento\n" +
                              "Premi 1 per la caldaia a condesazione\n" +
                              "Premi 2 per la caldaia tradizionale\n" +
                              "Premi 3 per la stufa elettrica\n" +
                              "Premi 4 per la pompa di calore economica\n" +
                              "Premi 5 per pompa di calore di buon livello\n");
                s = Convert.ToString(Console.ReadLine());
                controllo = int.TryParse(s, out scelta);
            } while (!controllo ||scelta < 1 || scelta > 5);

            Console.WriteLine("\n\n");

            CaldaiaCondensazione caldaiaCond = new CaldaiaCondensazione();
            CaldaiaTradizionale caldaiaTrad = new CaldaiaTradizionale();
            Stufa stufa = new Stufa();
            PompaEconomica pompaEco = new PompaEconomica();
            PompaBuonLvl pompaBuonLvl = new PompaBuonLvl();

            metodiRiscaldamento = new List<object>(){caldaiaCond, caldaiaTrad, stufa, pompaBuonLvl, pompaEco };

            foreach (Riscaldamento metodo in metodiRiscaldamento)
            {
                if (metodo.GetTipoConsumo() == "Gas")
                {
                    metodo.SetConsumi(consumiSmc);
                    metodo.CalcolaUtilizzo(consumikWh);
                }
                else
                {
                    metodo.SetConsumi(consumikWh);
                    metodo.CalcolaUtilizzo(consumiSmc);
                }
                metodo.CalcolaCostoTotale();
                bolletta = new Bolletta();
                bolletta.SetSpesaMateria(metodo.GetTotale());
                bollette.Add(bolletta);
            }

            foreach (Bolletta b in bollette)
            {
                b.CalcolaBolletta();
            }

            bollette = bollette.OrderBy(b => b.GetTotale()).ToList();

            foreach (Bolletta b in bollette)
            {
                Console.WriteLine($"{b.ToString()}");
            }

            Console.ReadKey();
        }
    }
}
