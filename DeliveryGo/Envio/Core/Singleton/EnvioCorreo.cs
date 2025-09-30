using System;
using DeliveryGo.Interfaces;
using DeliveryGo.Envio.Core.Strategy;
namespace DeliveryGo.Envio.Core.Singleton
{
	public class EnvioCorreo:IEnvioStrategy
	{
		public string Nombre => "Correo";

		public decimal Calcular(decimal subtotal)
		{
			decimal umbral = ConfigManager.Instance.EnvioGratisDesde;

			return subtotal >= umbral ? 0m : 3500m;
		}
	}
}

