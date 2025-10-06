using System;
using DeliveryGo.Interfaces;

namespace DeliveryGo.Carrito
{
	public class QuitarItemCommand : ICarritoCommand
	{
		private readonly string _sku;
        private Item? _backup;


        public QuitarItemCommand(string sku)
		{
			_sku = sku;
		}

		public void Ejecutar(Carrito carrito)
		{
            _backup = carrito.ObtenerItem(_sku);
            carrito.QuitarItem(_sku);
		}

        public void Deshacer(Carrito carrito)
        {
            
            if (_backup != null)
            {
                carrito.AgregarItem(_backup); 
            }
        }



        public override string ToString()
		{
			return $"Quitar: SKU {_sku}";
		}
    }
}

