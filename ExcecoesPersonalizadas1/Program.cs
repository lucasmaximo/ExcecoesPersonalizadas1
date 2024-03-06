// See https://aka.ms/new-console-template for more information

using ExcecoesPersonalizadas1;
using ExcecoesPersonalizadas1.Entities.Exceptions;
try
{
    Console.Write("Número do quarto: ");
    int numeroQuarto = int.Parse(Console.ReadLine());
    Console.Write("Data de entrada: ");
    DateTime checkin = DateTime.Parse(Console.ReadLine());
    Console.Write("Data de saida: ");
    DateTime checkout = DateTime.Parse(Console.ReadLine());

    Reserva reserva = new Reserva(numeroQuarto, checkin, checkout);

    Console.WriteLine();
    Console.WriteLine("DADOS DA RESERVA: ");
    Console.WriteLine(reserva);

    Console.WriteLine();

    Console.WriteLine("Entre os dados para alterar a reserva: ");
    Console.Write("Nova data de entrada (dd/MM/yyyy): ");
    checkin = DateTime.Parse(Console.ReadLine());
    Console.Write("Nova data de saída (dd/MM/yyyy): ");
    checkout = DateTime.Parse(Console.ReadLine());

    reserva.AtualizarReserva(checkin, checkout);

    Console.WriteLine();
    Console.WriteLine("DADOS DA RESERVA: ");
    Console.WriteLine(reserva);
}
catch (DomainException e)
{
    Console.WriteLine("Erro na reserva: " + e.Message);
}
catch (FormatException e)
{
    Console.WriteLine("Formado errado: " + e.Message);
}
catch (Exception e)
{
    Console.WriteLine("Erro inesperado: " + e.Message);
}