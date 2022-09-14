using DI.Figure.Interfaces;

using LocatR;

using System.Text;

namespace DI.Figure.Command
{
    public class WtiteEventCommand: IRequest
    {
        public string value { get; set; }
    }
}
