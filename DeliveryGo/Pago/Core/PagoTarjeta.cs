using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Pago.Core
{
	public class PagoTarjeta:IPago
	{
		public string Nombre => "Tarjeta";

		public bool Procesar(decimal monto)
		{
			Console.WriteLine($"[PagoTarjeta] Procesando pago de ${monto} con tarjeta...");
			return true;
		}
	}
}

