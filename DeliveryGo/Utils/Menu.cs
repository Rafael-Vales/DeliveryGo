using System.Collections.Generic;
using System;
using DeliveryGo.Carrito;
using DeliveryGo.Envio.Core.Singleton;
using DeliveryGo.Envio.Core.Strategy;
using DeliveryGo.Pedido.Core;
using DeliveryGo.Pedido.Core.Observers;
using DeliveryGo.Checkout;
using DeliveryGo.Interfaces;

namespace DeliveryGo.Utils
{
    public class Menu
    {
        private static bool logisticaActiva = true;
        private static LogisticaObserver logisticaObs = new();



        public static void AgregarItem(CheckoutFacade facade)
        {
            string sku = InputHelper.LeerTexto("SKU del producto: ");
            string nombre = InputHelper.LeerTexto("Nombre del producto: ");
            decimal precio = InputHelper.LeerDecimal("Precio del producto: ");
            int cantidad = InputHelper.LeerEntero("Cantidad: ");

            facade.AgregarItem(sku, nombre, precio, cantidad);
            Console.WriteLine("Producto agregado al carrito.");

        }


        public static void CambiarCantidad(CheckoutFacade facade)
        {
            Console.WriteLine("Cambiar cantidad de un item");


            string sku = InputHelper.LeerTexto("Ingrese el SKU del producto: ");
            int cantidad = InputHelper.LeerEntero("Ingrese la nueva cantidad: ");

            facade.CambiarCantidad(sku, cantidad);
            Console.WriteLine($"Cantidad actualizada para el SKU: '{sku}' a {cantidad} unidades");

        }


        public static void QuitarItem(CheckoutFacade facade)
        {
            Console.WriteLine("Quitar item del carrito");

            string sku = InputHelper.LeerTexto("Ingrese el SKU del producto a quitar: ");

            facade.QuitarItem(sku);
            Console.WriteLine($"El item con SKU '{sku}' se a eliminado ");


        }


        public static void VerTotales(CarritoPort carrito, CheckoutFacade facade)
        {
            Console.WriteLine("Ver totales");

            decimal subtotal = carrito.ObtenerSubtotal();
            decimal total = facade.CalcularTotal();

            Console.WriteLine($"Subtotal: ${subtotal}");
            Console.WriteLine();
            Console.WriteLine($"Total (con envio): ${total}");
            Console.WriteLine();

            Console.WriteLine("\nCarrito actual:");
            carrito.MostrarCarrito();


        }

        public static void Undo(CarritoPort carrito)
        {
            carrito.Undo();
            carrito.MostrarHistorial();
            Console.WriteLine(" Deshacer acción: OK");
            Console.WriteLine("-------------------------------");
        }

        public static void Redo(CarritoPort carrito)
        {
            carrito.Redo();
            Console.WriteLine("Rehacer acción: OK");
            Console.WriteLine("-------------------------------");
        }

        public static void ElegirEnvio(CheckoutFacade facade)
        {
            Console.WriteLine("Elegí tipo de envío: [moto / correo / retiro]");
            string? opcion = Console.ReadLine()?.Trim().ToLower();

            IEnvioStrategy estrategia;

            switch (opcion)
            {
                case "moto":
                    estrategia = new EnvioMoto();
                    break;
                case "correo":
                    estrategia = new EnvioCorreo();
                    break;
                case "retiro":
                    estrategia = new RetiroEnTienda();
                    break;
                default:
                    Console.WriteLine("Tipo de envío no válido. Opciones: moto / correo / retiro.");
                    return;
            }

            facade.ElegirEnvio(estrategia);
            Console.WriteLine($"Envío seleccionado: {estrategia.Nombre}");
            Console.WriteLine();
            Console.WriteLine($"Recordá que el envío por correo es gratis a partir de: ${ConfigManager.Instance.EnvioGratisDesde}");
        }

        public static void Pagar(CheckoutFacade facade)
        {
            Console.WriteLine("Ingrese el tipo de pago [tarjeta / transf / mp / mp-adapter]:");
            string tipoPago = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (tipoPago != "tarjeta" && tipoPago != "transf" && tipoPago != "mp" && tipoPago != "mp-adapter")
            {
                Console.WriteLine("Tipo de pago no válido.");
                return;
            }

            bool aplicarIVA = InputHelper.LeerSiNo("¿Aplicar IVA?: ");
            Console.WriteLine();

            bool aplicarCupon = InputHelper.LeerSiNo("¿Aplicar cupón de descuento?: ");

            decimal? cupon = null;

            if (aplicarCupon)
            {
                cupon = InputHelper.LeerPorcentaje("Ingrese el porcentaje de descuento (ej: 0.10 para 10%): ");
            }


            bool resultado = facade.Pagar(tipoPago, aplicarIVA, cupon);

            if (resultado)
            {
                Console.WriteLine("Pago aprobado.");
            }
            else
            {
                Console.WriteLine("Pago rechazado.");
            }
        }

        public static void ConfirmarPedido(CheckoutFacade facade)
        {
            Console.WriteLine("Confirmar Pedido:");

            string direccion = InputHelper.LeerTexto("Dirección de entrega: ");
            string tipoPago = InputHelper.LeerTexto("Tipo de pago (solo informativo, ej: tarjeta): ");

            try
            {
                var pedido = facade.ConfirmarPedido(direccion, tipoPago);

                Console.WriteLine($"Pedido confirmado:");
                Console.WriteLine($"ID: {pedido.Id}");
                Console.WriteLine($"Estado final: {pedido.Estado}");
                Console.WriteLine($"Monto: {pedido.Monto}");
                Console.WriteLine($"Dirección: {pedido.Direccion}");
                Console.WriteLine($"Items: {pedido.Items.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo confirmar el pedido: {ex.Message}");
            }
        }


        public static void ToggleLogistica(PedidoService pedidos, LogisticaObserver logisticaObs)
        {
            if (logisticaActiva)
            {
                pedidos.Desuscribir(logisticaObs.Actualizar);
                Console.WriteLine("Logística desuscripta.");
                logisticaActiva = false;
            }
            else
            {
                pedidos.Suscribir(logisticaObs.Actualizar);
                Console.WriteLine("Logística suscripta nuevamente.");
                logisticaActiva = true;
            }
        }



    }





    public static class InputHelper
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                    return valor;
                Console.WriteLine("Ingrese un número entero válido (>= 0).");
            }
        }

        public static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                    return valor;
                Console.WriteLine("Ingrese un número decimal válido (>= 0).");
            }
        }

        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                Console.WriteLine("El texto no puede estar vacío.");
            }
        }

        public static bool LeerSiNo(string mensaje)
        {
            while (true)
            {
                Console.Write($"{mensaje} (s/n): ");
                var input = Console.ReadLine()?.Trim().ToLower();
                if (input == "s") return true;
                if (input == "n") return false;
                Console.WriteLine("Respuesta inválida. Escriba 's' o 'n'.");
            }
        }

        public static decimal LeerPorcentaje(string mensaje)
        {
            while (true)
            {
                decimal valor = LeerDecimal(mensaje);
                if (valor > 0 && valor < 1)
                    return valor;
                Console.WriteLine("Ingrese un valor decimal entre 0 y 1 (por ejemplo: 0.10 para 10%).");
            }
        }
    }

}

