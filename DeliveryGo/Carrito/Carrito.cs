using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryGo.Carrito
{
	public class Carrito
	{
        private Dictionary<string, Item> _items = new();

        public IReadOnlyCollection<Item> ObtenerItems() => _items.Values.ToList().AsReadOnly();



        public void AgregarItem(Item item)
        {
            if (_items.ContainsKey(item.Sku))
            {
                _items[item.Sku].Cantidad += item.Cantidad;
            }
            else
            {
                _items[item.Sku] = item;
            }
        }


        public void QuitarItem(string sku)
        {
            if (_items.ContainsKey(sku))
            {
                _items.Remove(sku);
            }
            else
            {
                Console.WriteLine($"[Carrito] No se encontro producto con SKU: {sku}");
            }
        }


        public Item? ObtenerItem(string sku)
        {
            if (_items.TryGetValue(sku, out var item))
            {
                return new Item
                {
                    Sku = item.Sku,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad
                };
            }
            return null;
        }


        public void CambiarCantidad(string sku, int nuevaCantidad)
        {
            if (_items.ContainsKey(sku))
            {
                _items[sku].Cantidad = nuevaCantidad;
            }
            else
            {
                Console.WriteLine($"[Carrito] No se encontró el producto con SKU: {sku}");
            }
        }


        public int ObtenerCantidad(string sku)
        {
            if (_items.TryGetValue(sku, out var item))
            {
                return item.Cantidad;
            }
            return 0; 
        }


        public void Mostrar()
        {
            Console.WriteLine("Carrito: ");
            foreach(var item in _items.Values)
            {
                Console.WriteLine($"-{item.Nombre} x {item.Cantidad} (${item.Precio})");
                //Console.WriteLine($"[DEBUG] Productos en carrito: {_items.Count}");
            }
        }


        public decimal ObtenerSubtotal()
        {
            return _items.Values.Sum(item => item.Precio * item.Cantidad);
        }

    }
}

