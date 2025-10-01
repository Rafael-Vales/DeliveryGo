using System;
namespace DeliveryGo.Pedido.Core.Observers
{
    public class ClienteObserver
    {
        public static void Suscribir(PedidoService s) =>
            s.Suscribir(p => Console.WriteLine($"[Cliente] Tu pedido ahora está: {p.Estado}"));

        public static void Desuscribir(PedidoService s) =>
            s.Desuscribir(p => Console.WriteLine($"[Cliente] Tu pedido ahora está: {p.Estado}"));
    }
}

