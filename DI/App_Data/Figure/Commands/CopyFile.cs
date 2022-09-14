using DI.Figure.Interfaces;

using LocatR;

using System.Text;

namespace DI.Figure.Command
{
    public class CopyFileCommand: IRequest<string>
    {
        public int size { get; set; }
    }

    public class Dto
    {
        public int size { get; set; }
    }
}
