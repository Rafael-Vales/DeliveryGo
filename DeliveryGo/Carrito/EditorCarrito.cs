using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Carrito
{
	public class EditorCarrito
	{
		private readonly List<ICarritoCommand> _historial = new();
        private readonly Stack<ICarritoCommand> _deshacer = new();
        private readonly Stack<ICarritoCommand> _rehacer = new();



        public void Ejecutar(ICarritoCommand command, Carrito carrito)
		{
            command.Ejecutar(carrito);
            _deshacer.Push(command);
            _rehacer.Clear();
            _historial.Add(command);

        }

        public void Undo(Carrito carrito)
        {
            if (_deshacer.Count > 0)
            {
                var comando = _deshacer.Pop();
                comando.Deshacer(carrito);
                _rehacer.Push(comando);
                Console.WriteLine("[Editor] Se deshizo el último comando.");
            }
            else
            {
                Console.WriteLine("[Editor] No hay nada para deshacer.");
            }
        }


        public void Redo(Carrito carrito)
        {
            if (_rehacer.Count > 0)
            {
                var comando = _rehacer.Pop();
                comando.Ejecutar(carrito);
                _deshacer.Push(comando);
                Console.WriteLine("[Editor] Se rehizo el último comando.");
            }
            else
            {
                Console.WriteLine("[Editor] No hay nada para rehacer.");
            }
        }



        public void MostrarHistorial()
		{
			Console.WriteLine("Historial de comandos ejecutados: " + _historial.Count);
            Console.WriteLine($"Historial: {_deshacer.Count} comandos en deshacer, {_rehacer.Count} en rehacer.");
        }
	}
}

