using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Pago.Core
{
	public class PagoConCupon:IPago
	{
		private readonly IPago _inner;
		private readonly decimal _porcentajeDescuento;

		public PagoConCupon(IPago inner,decimal porcentaje)
		{
			_inner = inner;
			_porcentajeDescuento = porcentaje;
		}

		public string Nombre=>_inner.Nombre + $" + Cupon({_porcentajeDescuento:P0})";

		public bool Procesar(decimal monto)
		{
			decimal total = monto * (1 - _porcentajeDescuento);
            Console.WriteLine($"[Decorator] Aplicando cupón de descuento: Total con descuento = {total}");
            return _inner.Procesar(total);
        }

    }
}

