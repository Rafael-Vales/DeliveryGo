using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Pago.Core
{
	public class PagoMp:IPago
	{
		public string Nombre => "MercadoPago";

		public bool Procesar(decimal monto)
		{
			Console.WriteLine($"[PagoMp] Procesando pago de ${monto} con MercadoPago...");
			return true;
		}
	}
}

