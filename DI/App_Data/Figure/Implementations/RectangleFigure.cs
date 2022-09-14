using DI.Base.Interfaces;
using DI.Figure.Interfaces;

using System.Text;

namespace DI.Figure.Implemetation
{
    public class RectangleFigure : IFigure
    {
        private readonly IBase _base;

        public RectangleFigure(IBase @base)
        {
            _base = @base;
        } 

        public string GetString()
        {
            return _base.GetStringBase();
        }
    }
}
