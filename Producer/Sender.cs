using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "xmelan",
    Password = "Orange07",
};

using ( var connection = factory.CreateConnection())
using ( var channel = connection.CreateModel())
{
    channel.QueueDeclare("XmelanQueue", false, false, false, null);
    var message = "Bienvenido al curso de RabbitMQ y .NET";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("", "XmelanQueue", null, body);
    Console.WriteLine("El mensaje fue enviado {0}", message);
}

Console.WriteLine("Presiona [enter] para salir de la aplicacion");
Console.ReadLine();