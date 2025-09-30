using System;
using DeliveryGo.Interfaces;

namespace DeliveryGo.Carrito
{
	public class QuitarItemCommand : ICarritoCommand
	{
		private readonly string _sku;

		public QuitarItemCommand(string sku)
		{
			_sku = sku;
		}

		public void Ejecutar(Carrito carrito)
		{
			carrito.QuitarItem(_sku);
		}

		public override string ToString()
		{
			return $"Quitar: SKU {_sku}";
		}
    }
}

