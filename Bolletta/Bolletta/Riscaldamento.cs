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
        protected string tipoConsumo;
        protected double costoAnnuale;
        protected double consumi;
        protected double totale;
        protected double utilizzo;
        protected int costoInstallazione;

        public Riscaldamento()
        {
            
        }

        public virtual void CalcolaUtilizzo(double cons)
        {
        }

        public void SetConsumi(double cons)
        {
            this.consumi = cons;
        }

        public double GetRendimento()
        {
            return this.rendimento;
        }

        public string GetTipoConsumo()
        {
            return $"{this.tipoConsumo}";
        }

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
            this.totale = this.costoAnnuale * (this.consumi + this.utilizzo);
        }

        public double GetTotale()
        {
            return this.totale;
        }

        public double GetUtilizzo()
        {
            return this.utilizzo;
        }


        public int GetCostoInstallazione()
        {
            return this.costoInstallazione;
        }
    }
}
