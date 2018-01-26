using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationSingletonInstance
    {
        public Guid OperationId { get; private set; }

        public Operation() : this(Guid.NewGuid())
        {
        }

        public Operation(Guid guid)
        {
            OperationId = guid;
        }
    }
}
