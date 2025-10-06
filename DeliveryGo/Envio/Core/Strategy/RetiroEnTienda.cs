using System;
using DeliveryGo.Envio;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Envio.Core.Singleton
{
	public class RetiroEnTienda:IEnvioStrategy
	{
		public string Nombre => "Retiro";

		public decimal Calcular(decimal subtotal)
		{
			return 0m;
		}
		
	}
}

