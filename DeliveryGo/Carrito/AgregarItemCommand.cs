using System;
using DeliveryGo.Carrito;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Carrito
{
    public class AgregarItemCommand : ICarritoCommand
    {
        private readonly Item _item;
        private Item? _estadoPrevio;

        public AgregarItemCommand(Item item)
        {
            _item = item;
        }

        public void Ejecutar(Carrito carrito)
        {
            _estadoPrevio = carrito.ObtenerItem(_item.Sku);
            carrito.AgregarItem(_item);
        }

        public void Deshacer(Carrito carrito)
        {
            int cantidadActual = carrito.ObtenerCantidad(_item.Sku);

            int nuevaCantidad = cantidadActual - _item.Cantidad;

            if (nuevaCantidad <= 0)
            {
                carrito.QuitarItem(_item.Sku);
            }
            else
            {
                carrito.CambiarCantidad(_item.Sku, nuevaCantidad);
            }
        }

        public override string ToString()
        {
            return $"Agregar: {_item.Nombre} x {_item.Cantidad}";
        }
    }
}

