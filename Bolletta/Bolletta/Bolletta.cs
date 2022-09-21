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
        protected int spesaFissaVendita; //QVD o PVC
        protected double totale;
        protected int installazione;
        protected Riscaldamento metodoRiscaldamento;

        public Bolletta()
        {
            this.spesaTrasGestCont = 96;
            this.spesaOneri = 47;
            this.spesaFissaVendita = 70;
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
            return $"Costo bolletta {this.metodoRiscaldamento}: {Math.Round(this.totale, 4) + this.installazione}$ per il primo anno, causa installazione, {Math.Round(this.totale, 4)}$ per gli anni successivi";
        }

        public void CalcolaBolletta()
        {
            this.totale = this.spesaMateria + this.spesaOneri + this.spesaTrasGestCont + this.spesaFissaVendita;
        }

        public double GetTotale()
        {
            return this.totale;
        }

        public void SetCostoInstallazione(int costoInt)
        {
            this.installazione = costoInt;
        }

        public void SetMetodoRiscaldamento(Riscaldamento metodo)
        {
            this.metodoRiscaldamento = metodo;
        }

        public Riscaldamento GetMetodoRiscaldamento()
        {
            return this.metodoRiscaldamento;
        }
    }
}
