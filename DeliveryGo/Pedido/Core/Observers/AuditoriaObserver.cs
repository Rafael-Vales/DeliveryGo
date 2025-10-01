using System;
namespace DeliveryGo.Pedido.Core.Observers
{
    public class AuditoriaObserver
    {
        public static void Suscribir(PedidoService s) =>
            s.Suscribir(p => Console.WriteLine($"[Auditoría] Registro en bitácora: Pedido cambió a {p.Estado} a las {DateTime.Now}"));

        public static void Desuscribir(PedidoService s) =>
            s.Desuscribir(p => Console.WriteLine($"[Auditoría] Registro en bitácora: Pedido cambió a {p.Estado} a las {DateTime.Now}"));
    }
}

