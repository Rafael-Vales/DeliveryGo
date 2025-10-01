using System;
namespace DeliveryGo.Interfaces
{
	public interface IPago
	{
		String Nombre { get; }
		bool Procesar(decimal monto);
	}
}

