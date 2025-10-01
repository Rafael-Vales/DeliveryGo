using System.Collections.Generic;
using System;
using DeliveryGo.Carrito;
using DeliveryGo.Envio.Core.Singleton;
using DeliveryGo.Envio.Core.Strategy;
using DeliveryGo.Pedido.Core;
using DeliveryGo.Pedido.Core.Observers;
using DeliveryGo.Checkout;




ConfigManager.Instance.EnvioGratisDesde = 5000m;

ConfigManager.Instance.IVA = 0.21m;

var carritoPort = new CarritoPort();
var envioService = new EnvioService();
envioService.SetStrategy(new EnvioMoto());

var pedidoService = new PedidoService();

var clienteObs = new ClienteObserver();
var logisticaObs = new LogisticaObserver();
var auditoriaObs = new AuditoriaObserver();

ClienteObserver.Suscribir(pedidoService);
LogisticaObserver.Suscribir(pedidoService);
AuditoriaObserver.Suscribir(pedidoService);

var facade = new CheckoutFacade(carritoPort, new EnvioMoto(), pedidoService);


//Prueba etapa 1
Console.WriteLine("Etapa 1: Command");
facade.AgregarItem("123", "Pantalon", 15000m, 2);
facade.AgregarItem("456", "Remera", 12000m, 1);
facade.CambiarCantidad("456", 2);
facade.QuitarItem("123");
carritoPort.MostrarCarrito();
Console.WriteLine("------------------------------------------------");
Console.WriteLine();

// Prueba etapa 2
Console.WriteLine("Etapa 2: Strategy");
Console.WriteLine($"Costo total con envío Moto: {facade.CalcularTotal()}");
facade.ElegirEnvio(new EnvioCorreo());
Console.WriteLine($"Costo total con envío Correo: {facade.CalcularTotal()}");
Console.WriteLine("------------------------------------------------");
Console.WriteLine();

// Prueba etapa 3 
Console.WriteLine("🔹 Etapa 3: Pago");
bool pagado = facade.Pagar("Tarjeta", aplicarIVA: true, cupon: 0.10m);

if (pagado)
{
    var pedido = facade.ConfirmarPedido("Calle Falsa 123", "tarjeta");
    Console.WriteLine($"[Pedido confirmado] ID: {pedido.Id} - Monto: {pedido.Monto} - Estado final: {pedido.Estado}");
}
else
{
    Console.WriteLine("Pago fallido.");
}

// dessuscripcion mediante el observer
LogisticaObserver.Desuscribir(pedidoService);
Console.WriteLine("\n🔕 Logística desuscrita.");

// Confirmar pedido
var pedidoConfirmado = facade.ConfirmarPedido("Calle 123", "tarjeta");

// después cambiar manualmente
pedidoService.CambiarEstado(EstadoPedido.Enviando);

Console.ReadKey();
