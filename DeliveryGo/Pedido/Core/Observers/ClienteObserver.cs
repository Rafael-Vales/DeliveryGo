using System;
namespace DeliveryGo.Pedido.Core.Observers
{
    public class ClienteObserver
    {
        public void Actualizar(Pedido pedido)
        {
            Console.WriteLine($"[Cliente] Tu pedido ahora está: {pedido.Estado}");
        }
    }
}

