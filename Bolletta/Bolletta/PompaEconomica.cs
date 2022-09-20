using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    class PompaEconomica : Riscaldamento
    {
        protected int costoInstallazione;
        public PompaEconomica()
        {
            this.costoInstallazione = 1000;
            this.rendimento = 2.8;
            this.costoAnnuale = 0.27;
        }

        public int GetCostoInstallazione()
        {
            return this.costoInstallazione;
        }

        public void CalcolaUtilizzo()
        {
            this.utilizzo = (this.consumi * 10.7) / this.rendimento;
        }
    }
}
