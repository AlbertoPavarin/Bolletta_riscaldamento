using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    class CaldaiaCondensazione : Riscaldamento
    {

        public CaldaiaCondensazione()
        {
            this.rendimento = 1;
            this.costoAnnuale = 1.05;
            this.tipoConsumo = "Gas";
        }

        public override void CalcolaUtilizzo(double cons)
        {
            this.utilizzo = cons / (10.7 * this.rendimento);
        }
    }
}
