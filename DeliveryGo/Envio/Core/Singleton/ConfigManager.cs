using System;
using DeliveryGo.Envio;
namespace DeliveryGo.Envio.Core.Strategy
{
	public class ConfigManager
	{

		private static ConfigManager? _instance;

		public static ConfigManager Instance => _instance ??= new ConfigManager();

		private ConfigManager() { }

		public decimal EnvioGratisDesde { get; set; }
        public decimal IVA { get; set; }
    }
}

