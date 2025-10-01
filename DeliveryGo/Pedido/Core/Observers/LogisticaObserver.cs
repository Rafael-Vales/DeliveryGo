using System;
namespace DeliveryGo.Pedido.Core.Observers
{
    public class LogisticaObserver
    {
        public static void Suscribir(PedidoService s) =>
            s.Suscribir(p => Console.WriteLine($"[Logística] Actualizando tablero: {p.Estado}"));

        public static void Desuscribir(PedidoService s) =>
            s.Desuscribir(p => Console.WriteLine($"[Logística] Actualizando tablero: {p.Estado}"));
    }

}

