using System;
namespace DeliveryGo.Pedido.Core.Observers
{
    public class LogisticaObserver
    {
        public void Actualizar(Pedido pedido)
        {
            Console.WriteLine($"[Logística] Actualizando tablero: {pedido.Estado}");
        }
    }

}

