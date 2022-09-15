LocatR
========

[![NuGet](https://img.shields.io/nuget/dt/locatr.svg)](https://www.nuget.org/packages/locatr) 
[![NuGet](https://img.shields.io/nuget/vpre/locatr.svg)](https://www.nuget.org/packages/locatr)

Messaging with no dependencies.

Supports request/response, commands, queries  synchronous and async with dispatching via C# generic variance.

### Installing LocatR

You should install [LocatR with NuGet](https://www.nuget.org/packages/LocatR):

```sh
Install-Package LocatR
Install-Packag Microsoft.AspNet.WebFormsDependencyInjection.Unity
```
    

### Using Contracts-Only Package

To reference only the contracts for LocatR, which includes:

- `IRequest`

### Basic usage

The following code demonstrates basic usage.

Add Global.asax.cs in Application_Start

```cs
var container = this.AddUnity();
container.RegisterType<ILocatR, LocatR.LocatR>(new InjectionConstructor(container));
```

Create Example Command

```cs
public class WtiteEventCommand: IRequest
{
    public string value { get; set; }
}
```

and CommandHandler

```cs
public class WtiteEventCommandHandler : IRequestHandler<WtiteEventCommand>
{
    Task IRequestHandler<WtiteEventCommand>.Handle(WtiteEventCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
```

in Page

```cs
public partial class _Default : Page
{
    private readonly ILocatR _locator;
    
    public _Default(ILocatR locator)
    {
        _locator = locator;
    }

    protected async void Page_Load(object sender, EventArgs e)
    {
        await _locator.SendCommand(new WtiteEventCommand() { value = "Hello World" });
    }
}
```



