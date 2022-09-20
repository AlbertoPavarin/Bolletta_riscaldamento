using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    class Riscaldamento
    {
        protected double rendimento;
        protected double utilizzo;
        protected double costoAnnuale;
        protected double consumi;
        protected double totale;

        public Riscaldamento()
        {
            
        }

        public void setCostoAnnuale(double costoAnn)
        {
            this.costoAnnuale = costoAnn;
        }

        public void SetConsumi(double cons)
        {
            this.consumi = cons;
        }

        public double GetRendimento()
        {
            return this.rendimento;
        }

        /*public string GetTipoConsumo()
        {
            return $"{this.tipoConsumo}";
        }*/

        public double GetCostoAttuale()
        {
            return this.costoAnnuale;
        }

        public double GetConsumi()
        {
            return this.consumi;
        }

        public override string ToString()
        {
            return $"Il rendimento del modello è: {this.rendimento}, il costo annuale è: {this.costoAnnuale} e i consumi sono: {this.consumi}";
        }

        public void CalcolaCostoTotale() 
        {
            this.totale = this.costoAnnuale * this.consumi;
        }

        public double GetTotale()
        {
            return this.totale;
        }

        public double GetUtilizzo()
        {
            return this.utilizzo;
        }

    }
}
