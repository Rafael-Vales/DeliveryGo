using System;
namespace DeliveryGo.Pedido.Core.Observers
{
    public class AuditoriaObserver
    {
        public void Actualizar(Pedido pedido)
        {
            Console.WriteLine($"[Auditoría] Registro en bitácora: Pedido cambió a {pedido.Estado} a las {DateTime.Now}");
        }
    }
}

