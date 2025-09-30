using System;
namespace DeliveryGo.Interfaces
{
    using DeliveryGo.Carrito;

    public interface ICarritoCommand
    {
        void Ejecutar(Carrito carrito);
    }
}