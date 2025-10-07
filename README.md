# DeliveryGo 

DeliveryGo es un sistema de simulación de pedidos para una plataforma de e-commerce con envío de productos, armado en consola con C#. Permite gestionar un carrito de compras, aplicar estrategias de envío, realizar pagos con distintos métodos, confirmar pedidos y visualizar cómo avanzan los estados del mismo (Recibido, Preparando, Enviando, Entregado).

Este proyecto fue realizado como la  **actividad integradora** de la materia **Programacion II** utilizando los patros de diseño dictados por la consigna.
---

## ¿Cómo usar la app?


	1.	Clonar o descargar este repositorio.
	2.	Asegurarte de tener instalado el .NET SDK 7.0 o superior.
	3.	Abrir el proyecto en tu entorno de desarrollo preferido que soporte .NET (por ejemplo, Visual Studio, Rider o VS Code).
	4.	Compilar el proyecto o ejecutar directamente desde la terminal: dotnet run --project DeliveryGo
    5. El sistema iniciará mostrando el menú principal:
    - Agregar productos al carrito
    - Cambiar cantidades
    - Quitar producto
    - Ver totales y subtotales
    - Elegir tipo de envío
    - Pagar y confirmar el pedido
    - Deshacer/Rehacer acciones
    - Simular el avance del pedido
    - Suscribir o desuscribir logisticas
    6. Seleccionar opciones numéricas del 1 al 10 para interactuar.

---

## ¿Cómo se dividieron las tareas?

- **Etapa 1 - Carrito con Command**: Matias Mestre
- **Etapa 2 - Costos de envío con Strategy + Config (Singleton)**: Mariano Scarcella
- **Etapa 3 - Pago (Factory/Adapter/Decorator) + Pedido (Builder/Observer) + Facade**: Rafael Vales
- **Etapa 4 - Un menú para el usuario.**: Rafael Vales



---

## Estructura y patrones aplicados

El proyecto se organiza en carpetas según su funcionalidad. A continuación se resumen los **patrones de diseño utilizados**, su objetivo y en qué parte están aplicados:

 Patrón        Aplicación concreta en DeliveryGo                                           

 **Command**:   AgregarItem, QuitarItem, SetCantidad – permite deshacer/rehacer en el carrito 
 **Strategy**:  Envíos (Moto, Correo, Retiro) – permite cambiar la forma de cálculo dinámicamente 
 **Singleton**: ConfigManager (parámetros como IVA y umbral de envío gratis)                
 **Facade**:    CheckoutFacade – unifica todas las operaciones complejas de pago/envío/pedido 
 **Decorator**: PagoConIVA y PagoConCupon – permite aplicar impuestos y descuentos al vuelo  
 **Adapter**:   PagoAdapterMp – adapta una clase externa de MercadoPago a nuestra interfaz   
 **Builder**:   PedidoBuilder – construye objetos "Pedido" con múltiples atributos opcionales 
 **Observer**:  ClienteObserver, LogisticaObserver, AuditoriaObserver – reaccionan a los cambios de estado del pedido 

---

## Caso de uso: Simulación completa

1. El usuario inicia el programa.
2. Agrega productos al carrito (SKU, nombre, precio, cantidad).
3. Cambia la cantidad de un producto .
4. Elige tipo de envío (Moto, Correo, Retiro).
5. Realiza un pago aplicando IVA y cupón de descuento .
6. Confirma el pedido. Se crea un Pedido y se dispara una notificación a los observadores .
7. Se muestra la evolución del pedido por consola.
8. Si desea puede deshacer o rehacer acciones (Undo/Redo).

---

## Diagrama UML



---

## Posibles mejoras futuras

- Soporte para múltiples pedidos simultáneos
- Interfaz gráfica
- Persistencia en base de datos
- Registro de usuarios y login

---

## Notas finales

- El sistema fue diseñado con un enfoque educativo para practicar el uso de múltiples **patrones de diseño en un contexto real**.
- Se buscó mantener el código **modular, escalable y fácilmente mantenible**.
- Todos los patrones están aplicados de forma funcional y probada con casos de uso reales en consola.

---
