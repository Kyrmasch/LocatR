using DI.Figure.Interfaces;

using System.Text;

namespace DI.Figure.Implemetation
{
    public class WriteEvent : IFigure
    {
        public string GetString()
        {
            return new StringBuilder("Привет мир").ToString();
        }
    }
}
