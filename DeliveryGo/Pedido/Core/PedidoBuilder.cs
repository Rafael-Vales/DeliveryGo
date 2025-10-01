using System;
using DeliveryGo.Carrito;
namespace DeliveryGo.Pedido.Core
{
	public class PedidoBuilder
	{
		private readonly Pedido _pedido = new();

		public PedidoBuilder ConItems(List<Item> items)
		{
			_pedido.Items = items;
			return this;
		}

		public PedidoBuilder ConDireccion(string direccion)
		{
			_pedido.Direccion = direccion;
			return this;
		}

		public PedidoBuilder ConMetodoPago(string tipo)
		{
			_pedido.TipoPago = tipo;
			return this;
		}

		public PedidoBuilder ConMonto(decimal monto)
		{
			_pedido.Monto = monto;
			return this;
		}

        public Pedido Build()
        {
            if (_pedido.Items == null || !_pedido.Items.Any())
                throw new InvalidOperationException("El pedido debe tener al menos un ítem.");

            if (string.IsNullOrWhiteSpace(_pedido.Direccion))
                throw new InvalidOperationException("El pedido debe tener una dirección.");

            _pedido.Id = new Random().Next(1000, 9999); 
            return _pedido;
        }






    }
}

