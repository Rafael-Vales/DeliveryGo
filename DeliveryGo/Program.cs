using DeliveryGo.Carrito;

var carritoPort = new CarritoPort();

carritoPort.AgregarProducto("SKU001", "Pantalón", 29.99m, 2);
carritoPort.AgregarProducto("SKU001", "Pantalón", 29.99m, 3); 
carritoPort.CambiarCantidad("SKU001", 5);
carritoPort.QuitarProducto("SKU999"); 

carritoPort.MostrarCarrito();
carritoPort.MostrarHistorial();
Console.ReadKey();