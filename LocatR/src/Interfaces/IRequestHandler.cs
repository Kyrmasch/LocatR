using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocatR
{
    public interface IBaseRequestHandler
    {

    }

    public interface IRequestHandler<IRequest, T2> : IBaseRequestHandler
    {
        Task<T2> Handle(IRequest request, CancellationToken cancellationToken);
    }

    public interface IRequestHandler<IRequest> : IBaseRequestHandler
    {
        Task Handle(IRequest request, CancellationToken cancellationToken);
    }
}
