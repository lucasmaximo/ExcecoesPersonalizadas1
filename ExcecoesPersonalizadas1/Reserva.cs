using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcecoesPersonalizadas1.Entities.Exceptions;

namespace ExcecoesPersonalizadas1
{
    internal class Reserva
    {
        public int NumeroQuarto { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public Reserva() { }
        public Reserva(int numeroQuarto, DateTime checkin, DateTime checkout)
        {
            if (checkout <= checkin)
            {
                throw new DomainException("As datas de saída devem ser posteriores às datas de entrada.");
            }

            NumeroQuarto = numeroQuarto;
            Checkin = checkin;
            Checkout = checkout;
        }

        public int Duracao()
        {
            TimeSpan duracao = Checkout.Subtract(Checkin);
            return (int)duracao.TotalDays;
        }

        public void AtualizarReserva(DateTime checkin, DateTime checkout)
        {
            if (checkin < DateTime.Now || checkout < DateTime.Now)
            {
                throw new DomainException("As datas de atualização devem ser datas futuras.");
            }
            if (checkout <= checkin)
            {
                throw new DomainException("As datas de saída devem ser posteriores às datas de entrada.");
            }

            Checkin = checkin;
            Checkout = checkout;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Quarto ");
            s.Append(NumeroQuarto.ToString());
            s.Append(", Checkin: ");
            s.Append(Checkin.ToString("dd/MM/yyyy"));
            s.Append(", Checkout: ");
            s.Append(Checkout.ToString("dd/MM/yyyy"));
            s.Append(", ");
            s.Append(Duracao().ToString());
            s.Append(" noites");
            return s.ToString();
        }
    }
}
