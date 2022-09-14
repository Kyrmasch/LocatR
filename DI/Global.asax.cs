using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Unity;

using DI.Figure.Interfaces;
using DI.Figure.Implemetation;

using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using DI.Base.Interfaces;
using DI.Base.Implemetation;
using System.Web;
using System.Web.Routing;
using System.Web.Optimization;
using DI.Figure.Command;
using Unity.Injection;
using LocatR;

namespace DI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Injection
            var container = this.AddUnity();
            container.RegisterType<IBase, BaseFigure>();
            container.RegisterType<IFigure, RectangleFigure>();
            
            container.RegisterType<ILocatR, LocatR.LocatR>(new InjectionConstructor(container));
        }
    }
}