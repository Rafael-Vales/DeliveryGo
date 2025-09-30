using System;
namespace DeliveryGo.Interfaces
{
	public interface IEnvioStrategy
	{
		string Nombre { get; }
		decimal Calcular(decimal subtotal);
	}
}

