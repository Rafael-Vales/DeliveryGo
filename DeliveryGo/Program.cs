using DeliveryGo.Carrito;
using DeliveryGo.Envio.Core.Singleton;
using DeliveryGo.Envio.Core.Strategy;
using DeliveryGo.Interfaces;


ConfigManager.Instance.EnvioGratisDesde = 5000m;

var carritoPort = new CarritoPort();
var envioService = new EnvioService();

decimal subtotal1 = 4200m;

carritoPort.AgregarProducto("SKU001", "Pantalón", 29.99m, 2);
carritoPort.AgregarProducto("SKU001", "Pantalón", 29.99m, 3); 
carritoPort.CambiarCantidad("SKU001", 5);
carritoPort.QuitarProducto("SKU999"); 

carritoPort.MostrarCarrito();
carritoPort.MostrarHistorial();

Console.WriteLine("--------------------------------------------");


envioService.SetStrategy(new EnvioMoto());
Console.WriteLine($"Moto: ${envioService.Calcular(subtotal1)}");

envioService.SetStrategy(new EnvioCorreo());
Console.WriteLine($"Correo: ${envioService.Calcular(subtotal1)}");

envioService.SetStrategy(new RetiroEnTienda());
Console.WriteLine($"Retiro: ${envioService.Calcular(subtotal1)}");

Console.WriteLine("--------------------------------------------");


decimal subtotal2 = 52000m;

envioService.SetStrategy(new EnvioCorreo());
Console.WriteLine($"Correo con subtotal mayor: ${envioService.Calcular(subtotal2)}");

Console.ReadKey();