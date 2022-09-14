using DI.Figure.Interfaces;

using LocatR;

using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DI.Figure.Command
{
    public class WtiteEventCommandHandler : IRequestHandler<WtiteEventCommand>
    {
        Task IRequestHandler<WtiteEventCommand>.Handle(WtiteEventCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
