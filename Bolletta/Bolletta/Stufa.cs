using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    class Stufa : Riscaldamento
    {
        public Stufa()
        {
            this.rendimento = 1;
            this.costoAnnuale = 0.27;
            this.tipoConsumo = "Elettricita";
        }

        public override void CalcolaUtilizzo(double cons)
        {
            this.utilizzo = (cons * 10.7) / this.rendimento;
        }
    }
}
