using DI.Base.Interfaces;

using System.Text;

namespace DI.Base.Implemetation
{
    public class BaseFigure : IBase
    {
        public string GetStringBase()
        {
            return new StringBuilder("Привет мир из зависимости").ToString();
        }
    }
}
