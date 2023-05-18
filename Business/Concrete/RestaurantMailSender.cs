using Business.Abstract;
using Core.Utilities.Results;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RestaurantMailSender : IRestaurantMailSender
    {
        public IResult Mail(string mail)
        {

            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://fdumoanq:NTd0vQfdnoZn-dPg08X5BhKtIv1aRi87@rat.rmq2.cloudamqp.com/fdumoanq");
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();
            channel.QueueDeclare("restaurant-queue", exclusive: false, autoDelete: false);
            byte[] message = Encoding.UTF8.GetBytes(mail);
            channel.BasicPublish("", routingKey: "restaurant-queue", body: message);
            return new SuccessResult("Başarılı");
        }
    }
}
