using System;
using DeliveryGo.Carrito;
namespace DeliveryGo.Interfaces
{
	public interface ICarritoCommand
	{
		void Ejecutar(Carrito carrito);
	}
}

