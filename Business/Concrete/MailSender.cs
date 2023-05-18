using Core.MessageBroker.Abstract;
using Core.Utilities.Results;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MessageBroker.Concrete
{
    public class MailSender : IMailSender
    {
        public IResult Mail(string mail)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://fdumoanq:NTd0vQfdnoZn-dPg08X5BhKtIv1aRi87@rat.rmq2.cloudamqp.com/fdumoanq");
            using IConnection connection = factory.CreateConnection();
            using IModel channel= connection.CreateModel();
            channel.QueueDeclare("mail-queue", exclusive:false,autoDelete:false );
            byte[] message=Encoding.UTF8.GetBytes(mail);
            channel.BasicPublish("",routingKey: "mail-queue", body:message);
            return new SuccessResult("Başarılı");
        }
    }
}
