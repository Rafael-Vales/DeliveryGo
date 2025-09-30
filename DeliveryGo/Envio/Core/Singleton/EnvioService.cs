using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Envio.Core.Singleton
{
	public class EnvioService
	{
		private IEnvioStrategy _actual;

		public void SetStrategy(IEnvioStrategy estrategia)
		{
			_actual = estrategia;
		}

		public decimal Calcular(decimal subtotal)
		{
			return _actual.Calcular(subtotal);
		}

		public string NombreActual => _actual?.Nombre ?? "Sin estrategia seleccionada";


	}
}

