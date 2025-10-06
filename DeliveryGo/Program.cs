using System.Collections.Generic;
using System;
using DeliveryGo.Carrito;
using DeliveryGo.Envio.Core.Singleton;
using DeliveryGo.Envio.Core.Strategy;
using DeliveryGo.Pedido.Core;
using DeliveryGo.Pedido.Core.Observers;
using DeliveryGo.Checkout;
using DeliveryGo.Utils;




ConfigManager.Instance.EnvioGratisDesde = 5000m;

ConfigManager.Instance.IVA = 0.21m;

var carritoPort = new CarritoPort();
var envioService = new EnvioService();
envioService.SetStrategy(new EnvioMoto());

var pedidoService = new PedidoService();

var clienteObs = new ClienteObserver();
var logisticaObs = new LogisticaObserver();
var auditoriaObs = new AuditoriaObserver();

pedidoService.Suscribir(clienteObs.Actualizar);
pedidoService.Suscribir(logisticaObs.Actualizar);
pedidoService.Suscribir(auditoriaObs.Actualizar);

var facade = new CheckoutFacade(carritoPort, new EnvioMoto(), pedidoService);


int opcion;
bool salir = false;





do
{
    Console.Clear();
    Console.WriteLine("==== DELIVERYGO — MENÚ PRINCIPAL ====");
    Console.WriteLine("1. Agregar ítem");
    Console.WriteLine("2. Cambiar cantidad");
    Console.WriteLine("3. Quitar ítem");
    Console.WriteLine("4. Ver subtotal y total");
    Console.WriteLine("5. Deshacer último cambio ");
    Console.WriteLine("6. Rehacer cambio ");
    Console.WriteLine("7. Elegir tipo de envío");
    Console.WriteLine("8. Pagar");
    Console.WriteLine("9. Confirmar pedido");
    Console.WriteLine("10. (Des)Suscribir logística");
    Console.WriteLine("0. Salir");
    Console.Write("\nElegí una opción: ");

    string? input = Console.ReadLine();
    Console.WriteLine();

    if (!int.TryParse(input, out opcion))
    {
        Console.WriteLine(" Entrada inválida. Presioná una tecla para continuar...");
        Console.ReadKey();
        continue;
    }

    switch (opcion)
    {
        case 1:
            Menu.AgregarItem(facade);
            break;
        case 2:
            Menu.CambiarCantidad(facade);
            break;
        case 3:
            Menu.QuitarItem(facade);
            break;
        case 4:
            Menu.VerTotales(carritoPort, facade);
            break;
        case 5:
            Menu.Undo(carritoPort);
            break;
        case 6:
            Menu.Redo(carritoPort);
            break;
        case 7:
            Menu.ElegirEnvio(facade);
            break;
        case 8:
            Menu.Pagar(facade);
            break;
        case 9:
            Menu.ConfirmarPedido(facade);
            break;
        case 10:
            Menu.ToggleLogistica(pedidoService, logisticaObs);
            break;
        case 0:
            salir = true;
            Console.WriteLine(" Saliendo del sistema...");
            break;
        default:
            Console.WriteLine(" Opción inválida.");
            break;
    }

    if (!salir)
    {
        Console.WriteLine("\nPresioná una tecla para continuar...");
        Console.ReadKey();
    }

} while (!salir);








