using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Pago.Core
{
	public class PagoTransfer:IPago
	{
		public String Nombre => "Transferencia";

		public bool Procesar(decimal monto)
		{
			Console.WriteLine($"[PagoTransfer] Procesando transferencia por ${monto}...");
			return true;
		}
		
	}
}

