﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{

    class PompaBuonLvl : Riscaldamento 
    {
        protected int costoInstallazione;
        public PompaBuonLvl()
        {
            this.costoInstallazione = 3000;
            this.rendimento = 3.6;
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
