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
            Riscaldamento metodoScelto = new Riscaldamento();

            do
            {
                Console.WriteLine("Inserisci i kWh annui medi consumati");
                s = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(s, out consumikWh); // Variabile boolena per controllare se il tipo di dato inserito è un double, => False: se non è un double, True: se lo è
            } while (!controllo || consumikWh < 0); // Vengono letti i kWh annui medi finchè non viene inserito un numero maggiore di 0

            do
            {
                Console.WriteLine("Inserisci gli SMC annui medi consumati");
                s = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(s, out consumiSmc); // Variabile boolena per controllare se il tipo di dato inserito è un double, => False: se non è un double, True: se lo è
            } while (!controllo || consumiSmc < 0); // Vengono letti gli smc annui medi finchè non viene inserito un numero maggiore di 0

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
                controllo = int.TryParse(s, out scelta); // Variabile boolena per controllare se il tipo di dato inserito è un int, => False: se non è un int, True: se lo è
            } while (!controllo ||scelta < 1 || scelta > 5); // Viene letto il metodo di riscaldamento attualmento installato finchè non ne viene selezionato uno, inserendo un numero intero >= 1 e <= 5

            CaldaiaCondensazione caldaiaCond = new CaldaiaCondensazione();
            CaldaiaTradizionale caldaiaTrad = new CaldaiaTradizionale();
            Stufa stufa = new Stufa();
            PompaEconomica pompaEco = new PompaEconomica();
            PompaBuonLvl pompaBuonLvl = new PompaBuonLvl();

            switch (scelta) // Assegnazione metodo di riscaldamento tramite la variabile scelta
            {
                case 1:
                    metodoScelto = caldaiaCond;
                    break;
                case 2:
                    metodoScelto = caldaiaTrad;
                    break;
                case 3:
                    metodoScelto = stufa;
                    break;
                case 4:
                    metodoScelto = pompaEco;
                    break;
                case 5:
                    metodoScelto = pompaBuonLvl;
                    break;
            }

            metodiRiscaldamento = new List<object>(){caldaiaCond, caldaiaTrad, stufa, pompaBuonLvl, pompaEco }; // Lista che contiene tutti i vari metodi di riscaldamento

            foreach (Riscaldamento metodo in metodiRiscaldamento) // Per ogni elemento nella lista metodiRiscaldamento
            {
                // Vengono settati i consumi e viene calcolato l'utilizzo per ogni metodo
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
                bolletta.SetCostoInstallazione(metodo.GetCostoInstallazione());
                bolletta.SetMetodoRiscaldamento(metodo);
                bollette.Add(bolletta);
            }

            foreach (Bolletta b in bollette)
            {
                b.CalcolaBolletta();
            }

            bollette = bollette.OrderBy(b => b.GetTotale()).ToList(); // Viene ordinata la lista di bollette tramite il totale di ogni bolletta

            foreach (Bolletta b in bollette)
            {
                Console.WriteLine($"{b.ToString()}");
            }

            if (metodoScelto.ToString() == bollette[0].GetMetodoRiscaldamento().ToString())
            {
                Console.Write("\n\nIl metodo attualmente installato è il più conveniente\n");
            }
            else
            {
                Console.WriteLine($"\n\nL'offerta più conveniente è la seguente: {bollette[0].ToString()}");
            }

            Console.ReadKey();
        }
    }
}
