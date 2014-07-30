using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.SimpleCqrs;

namespace Sample.Core.Commands
{
    public class CreateBook : ICommand
    {
        public string Title { get; set; }
    }
}
