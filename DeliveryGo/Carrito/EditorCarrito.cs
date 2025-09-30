using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Carrito
{
	public class EditorCarrito
	{
		private readonly List<ICarritoCommand> _historial = new();

		public void Ejecutar(ICarritoCommand command, Carrito carrito)
		{
			command.Ejecutar(carrito);
			_historial.Add(command);
		}

		public void MostrarHistorial()
		{
			Console.WriteLine("Historial de comandos ejecutados: " + _historial.Count);
		}
	}
}

