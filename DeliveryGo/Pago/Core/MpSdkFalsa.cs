using System;
namespace DeliveryGo.Pago.Core
{
	public class MpSdkFalsa
	{
		public bool Cobrar(decimal monto)
		{
			Console.WriteLine($"[MpSdkFalsa] Procesando pago de ${monto}...");
			return true;
		}
	}
}

