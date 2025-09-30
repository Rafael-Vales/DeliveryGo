using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Carrito
{
	public class SetCantidadCommand:ICarritoCommand
	{
		private readonly string _sku;
		private readonly int _nuevaCantidad;
		public SetCantidadCommand(string sku,int nuevaCantidad)
		{
			_sku = sku;
			_nuevaCantidad = nuevaCantidad;

		}

		public void Ejecutar (Carrito carrito)
		{
			carrito.CambiarCantidad(_sku, _nuevaCantidad);
		}

        public override string ToString()
        {
			return $"SetCantidad: SKU {_sku} a {_nuevaCantidad}";
        }
    }
}

