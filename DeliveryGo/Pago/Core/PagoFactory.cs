using System;
using DeliveryGo.Interfaces;
namespace DeliveryGo.Pago.Core
{
	public class PagoFactory
	{
        public static IPago Create(string tipo)
        {
            tipo = tipo.Trim().ToLower();

            return tipo switch
            {
                "tarjeta" => new PagoTarjeta(),
                "transf" => new PagoTransfer(),
                "mp" => new PagoMp(),
                _ => throw new ArgumentException($"Tipo de pago no reconocido: {tipo}")
            };
        }

    }
}

