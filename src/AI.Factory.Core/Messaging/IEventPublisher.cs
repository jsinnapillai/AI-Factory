using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Messaging
{

    public interface IEventPublisher
    {
        Task PublishAsync<T>(T message) where T : class;
    }

}