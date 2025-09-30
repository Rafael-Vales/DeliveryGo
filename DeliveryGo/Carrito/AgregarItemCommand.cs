using System;
using DeliveryGo.Carrito;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Carrito
{
	public class AgregarItemCommand:ICarritoCommand
	{
		private readonly Item _item;

		public AgregarItemCommand(Item item)
		{
			_item = item;
		}


		public void Ejecutar(Carrito carrito)
		{
			carrito.AgregarItem(_item);
		}

        public override string ToString()
        {
			return $"Agregar: {_item.Nombre} x {_item.Cantidad}";
        }
    }
}

