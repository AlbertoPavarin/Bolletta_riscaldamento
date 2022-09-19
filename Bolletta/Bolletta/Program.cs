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
            Console.WriteLine($"\n\n\n{scelta}");
            Console.WriteLine("Inserisci i kWh annui medi consumati");
            Console.WriteLine("Inserisci gli SMC annui medi consumati");
            Console.ReadKey();
        }
    }
}
