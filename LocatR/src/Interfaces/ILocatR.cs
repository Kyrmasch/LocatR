using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocatR
{
    public interface ILocatR
    {
        Task SendCommand<T1>(T1 wtiteEventCommand, CancellationToken cancellationToken = default(CancellationToken));
        Task<T2> SendQuery<T1, T2>(T1 wtiteEventCommand, CancellationToken cancellationToken = default(CancellationToken));
    }
}
