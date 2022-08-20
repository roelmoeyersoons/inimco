using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Operations
{
    internal interface IAsyncOperation<T, U> where T : IOperationParameters
    {
        public Task<U> ExecuteAsync(T parameter);
    }

    internal interface IOperationParameters
    {

    }
}
