using System;
using System.Threading;
using DeliveryGo.Carrito;
namespace DeliveryGo.Pedido.Core
{
	public enum EstadoPedido
	{
		Recibido,
		Preparando,
		Enviando,
		Entregado
	}

	public class Pedido
	{
		public int Id { get; set; }
		public List<Item> Items { get; set; } = new();
		public string Direccion { get; set; } = "";
		public string TipoPago { get; set; } = "";
		public EstadoPedido Estado { get; set; } = EstadoPedido.Recibido;
		public decimal Monto { get; set; }

        public override string ToString()
        {
            return $"Pedido #{Id} - {Estado} - ${Monto} - {Items.Count} ítems a entregar en: {Direccion}";
        }
    }
}

