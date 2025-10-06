using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Carrito
{
	public class SetCantidadCommand:ICarritoCommand
	{
		private readonly string _sku;
		private readonly int _nuevaCantidad;
        private int _cantidadAnterior;


        public SetCantidadCommand(string sku,int nuevaCantidad)
		{
			_sku = sku;
			_nuevaCantidad = nuevaCantidad;

		}

		public void Ejecutar (Carrito carrito)
		{
            _cantidadAnterior = carrito.ObtenerCantidad(_sku);
            carrito.CambiarCantidad(_sku, _nuevaCantidad);
        }

        public void Deshacer(Carrito carrito)
        {
            carrito.CambiarCantidad(_sku, _cantidadAnterior);
        }

        public override string ToString()
        {
			return $"SetCantidad: SKU {_sku} a {_nuevaCantidad}";
        }
    }
}

