using System;
using System.Collections.Generic;
namespace DeliveryGo.Pedido.Core
{
    public class PedidoService
    {
        public event Action<Pedido>? EstadoCambiado;

        private Pedido? _pedidoActual; 

        public void AsignarPedido(Pedido pedido)
        {
            _pedidoActual = pedido;
        }

        
        public void CambiarEstado(EstadoPedido nuevoEstado)
        {
            if (_pedidoActual == null)
            {
                Console.WriteLine("[PedidoService] No hay pedido asignado.");
                return;
            }

            _pedidoActual.Estado = nuevoEstado;
            EstadoCambiado?.Invoke(_pedidoActual);
        }

        
        public void CambiarEstado(Pedido pedido, EstadoPedido nuevoEstado)
        {
            _pedidoActual = pedido; 
            _pedidoActual.Estado = nuevoEstado;
            EstadoCambiado?.Invoke(_pedidoActual);
        }

        public void Suscribir(Action<Pedido> observer) => EstadoCambiado += observer;
        public void Desuscribir(Action<Pedido> observer) => EstadoCambiado -= observer;
    }
}

