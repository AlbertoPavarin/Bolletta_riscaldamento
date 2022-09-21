using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    class PompaEconomica : Riscaldamento
    {
        public PompaEconomica()
        {
            this.costoInstallazione = 1000;
            this.rendimento = 2.8;
            this.costoAnnuale = 0.276;
            this.tipoConsumo = "Elettricita";
        }

        public override void CalcolaUtilizzo(double cons)
        {
            this.utilizzo = (cons * 10.7) / this.rendimento;
        }

        public override string ToString()
        {
            return "Pompa Economica";
        }
    }
}
