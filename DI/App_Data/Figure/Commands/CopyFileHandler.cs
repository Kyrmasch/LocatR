using DI.Figure.Interfaces;

using LocatR;

using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DI.Figure.Command
{
    public class CopyFileCommandHandler : IRequestHandler<CopyFileCommand, string>
    {
        public Task<string> Handle(CopyFileCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Assembly");
        }
    }
}
