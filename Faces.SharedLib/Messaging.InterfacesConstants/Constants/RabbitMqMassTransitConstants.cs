using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.InterfacesConstants.Constants
{
    public class RabbitMqMassTransitConstants
    {
        public const string RabbitMqUri = "rabbitmq://rabbitmq:5672";
        public const string UserName = "quest";
        public const string Password = "quest";
        public const string RegisterOrderCommandQueue = "register.order.command";
    }
}
