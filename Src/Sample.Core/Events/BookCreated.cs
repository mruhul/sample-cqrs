using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.SimpleCqrs;

namespace Sample.Core.Events
{
    public class BookCreated : IEvent
    {
        public long Id { get; set; }
    }
}
