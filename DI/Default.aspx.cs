using DI.Figure.Command;
using DI.Figure.Implemetation;
using DI.Figure.Interfaces;

using LocatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DI
{
    public partial class _Default : Page
    {
        private readonly IFigure _figure;
        private readonly ILocatR _locator;
        public _Default(IFigure figure, ILocatR locator)
        {
            _figure = figure;
            _locator = locator;
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            string di = _figure.GetString();
            
            await _locator.SendCommand(new WtiteEventCommand() { value = "MediatR" });
            string ass = await _locator.SendQuery<CopyFileCommand, string>(new CopyFileCommand() { size = 200 });
            
            Injection.Text = $"{di} - {ass}";
        }
    }
}