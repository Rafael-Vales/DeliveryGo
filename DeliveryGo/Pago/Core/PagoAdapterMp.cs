using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Pago.Core
{
	public class PagoAdapterMp:IPago
	{
		private readonly MpSdkFalsa _sdk;

		public PagoAdapterMp(MpSdkFalsa sdk)
		{
			_sdk = sdk;
		}

		public string Nombre => "Pago adaptado via SDK MP";

		public bool Procesar(decimal monto)
		{
			Console.WriteLine($"[Adapter] Usando SDK para procesar ${monto}"); ;
			return _sdk.Cobrar(monto);
		}
	}
}

