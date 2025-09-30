using System;
using DeliveryGo.Interfaces;

namespace DeliveryGo.Carrito
{
    public class CarritoPort
    {
        private readonly Carrito _carrito = new();
        private readonly EditorCarrito _editor = new();

        public void AgregarProducto(string sku, string nombre, decimal precio, int cantidad)
        {
            var item = new Item
            {
                Sku = sku,
                Nombre = nombre,
                Precio = precio,
                Cantidad = cantidad
            };

            var cmd = new AgregarItemCommand(item);
            _editor.Ejecutar(cmd, _carrito);
        }

        public void QuitarProducto(string sku)
        {
            var cmd = new QuitarItemCommand(sku);
            _editor.Ejecutar(cmd, _carrito);
        }

        public void CambiarCantidad(string sku, int nuevaCantidad)
        {
            var cmd = new SetCantidadCommand(sku, nuevaCantidad);
            _editor.Ejecutar(cmd, _carrito);
        }

        public void MostrarCarrito()
        {
            _carrito.Mostrar();
        }

        public void MostrarHistorial()
        {
            _editor.MostrarHistorial();
        }
    }
}