using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Interfaces
{
    public interface IEvent
    {
        string EventId { get; }
        DateTime Timestamp { get; }
        string Source { get; }
        object Payload { get; }
    }
}
