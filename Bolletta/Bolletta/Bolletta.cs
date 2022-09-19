using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    class Bolletta
    {
        protected double spesaMateria;
        protected int spesaTrasGestCont;
        protected int spesaOneri;
        protected int qvd;
        protected double totale;

        public Bolletta()
        {
            this.spesaMateria = 0;
            this.spesaTrasGestCont = 96;
            this.spesaOneri = 47;
            this.qvd = 70;
        }

        public void SetSpesaMateria(double spesa)
        {
            this.spesaMateria = spesa;
        }

        public string GetSpesaMateria()
        {
            return $"Spesa materia {this.spesaMateria}";
        }

        public override string ToString()
        {
            return $"Bolletta: {this.spesaMateria + this.spesaOneri + this.spesaTrasGestCont + this.qvd}€";
        }

        public void CalcolaBolletta()
        {
            this.totale = this.spesaMateria + this.spesaOneri + this.spesaTrasGestCont + this.qvd;
        }

        public double GetTotale()
        {
            return this.totale;
        }
    }
}
