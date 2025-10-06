using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Envio.Core.Singleton
{
	public class EnvioMoto:IEnvioStrategy
	{
		public string Nombre => "Moto";

		public decimal Calcular(decimal subtotal)
		{
			return 1200m;

		}
		
	}
}

