using Rentacar.Entities;
using Rentacar.Services;
using System;
using System.Globalization;

namespace Rentacar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dado do aluguel:");
            Console.Write("Modelo do carro: ");
            string modelo = Console.ReadLine();
            Console.Write("Retirada (DD/MM/AAAA HH:MM): ");
            DateTime retirada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Entrega (DD/MM/AAAA HH:MM): ");
            DateTime entrega = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Preço por hora: R$");
            double precoHora = double.Parse(Console.ReadLine());
            Console.Write("Preço por dia: R$");
            double precoDia = double.Parse(Console.ReadLine());

            CarRental cr = new CarRental(retirada, entrega, new Vehicle(modelo));

            RentalService rs = new RentalService(precoHora, precoDia);

            rs.ProcessInvoice(cr);

            Console.WriteLine("INVOICE:");

            Console.WriteLine(cr.Invoice);


            

            
        }
    }
}
