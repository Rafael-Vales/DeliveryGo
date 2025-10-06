using System;
using DeliveryGo.Interfaces;
using DeliveryGo.Pedido.Core.Observers;
using DeliveryGo.Pedido.Core;
using DeliveryGo.Carrito;
using DeliveryGo.Envio.Core.Singleton;
using DeliveryGo.Envio.Core.Strategy;
using DeliveryGo.Pago.Core;


namespace DeliveryGo.Checkout
{
	public class CheckoutFacade
	{
		private readonly CarritoPort _carrito;
		private IEnvioStrategy _envioActual;
		private readonly PedidoService _pedidoService;

		public CheckoutFacade(CarritoPort carrito,IEnvioStrategy envioInicial,PedidoService pedidos)
		{
			_carrito = carrito;
			_envioActual = envioInicial;
			_pedidoService = pedidos;
		}



        public void AgregarItem(string sku, string nombre, decimal precio, int cantidad)
        {
            _carrito.AgregarProducto(sku, nombre, precio, cantidad);
        }

        public void CambiarCantidad(string sku, int cantidad)
        {
            _carrito.CambiarCantidad(sku, cantidad);
        }

        public void QuitarItem(string sku)
        {
            _carrito.QuitarProducto(sku);
        }

        public void ElegirEnvio(IEnvioStrategy nueva)
		{
			_envioActual = nueva;
		}

		public decimal CalcularTotal()
		{
			var subtotal = _carrito.ObtenerSubtotal();
			var envio = _envioActual.Calcular(subtotal);
			return subtotal + envio;
		}

		public bool Pagar(string tipoPago, bool aplicarIVA, decimal? cupon = null)
		{
			IPago pago;
			if (tipoPago == "Mp-adapter")
			{
				pago = new PagoAdapterMp(new MpSdkFalsa());
			}
			else
			{
				pago = PagoFactory.Create(tipoPago);
			}

            if (aplicarIVA)
                pago = new PagoConImpuesto(pago);

            if (cupon.HasValue)
                pago = new PagoConCupon(pago, cupon.Value);

            return pago.Procesar(CalcularTotal());
        }

        public Pedido.Core.Pedido ConfirmarPedido(string direccion, string tipoPago)
        {
            var pedido = new PedidoBuilder()
                .ConItems(_carrito.Carrito.ObtenerItems().ToList())
                .ConDireccion(direccion)
                .ConMetodoPago(tipoPago)
                .ConMonto(CalcularTotal())
                .Build();

            
            _pedidoService.AsignarPedido(pedido);

            _pedidoService.CambiarEstado(EstadoPedido.Recibido);
            Thread.Sleep(500);
            _pedidoService.CambiarEstado(EstadoPedido.Preparando);
            Thread.Sleep(500);
            _pedidoService.CambiarEstado(EstadoPedido.Enviando);
            Thread.Sleep(500);
            _pedidoService.CambiarEstado(EstadoPedido.Entregado);

            return pedido;
        }



    }
}

