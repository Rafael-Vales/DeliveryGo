using System;
using DeliveryGo.Envio.Core.Strategy;
using DeliveryGo.Interfaces;

namespace DeliveryGo.Pago.Core
{
	public class PagoConImpuesto:IPago
	{
		private readonly IPago _inner;

		public PagoConImpuesto(IPago inner)
		{
			_inner = inner;
		}

		public string Nombre => _inner.Nombre + " + IVA";

		public bool Procesar(decimal monto)
		{
			decimal total = monto * (1 + ConfigManager.Instance.IVA);
			Console.WriteLine($"[Decorator] Aplicando IVA: Total con IVA = {total}");
			return _inner.Procesar(total);
		}

		
	}
}

 