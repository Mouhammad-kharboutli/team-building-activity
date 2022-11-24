using System;

namespace Polestar.TB.Payments.Application.Options;

public class FooOptions
{
    public FooOptions()
    {
        Region = Environment.GetEnvironmentVariable("AWS_REGION");
    }
        
    public string Secret { get; set; }
    public string Name { get; set; }
    public string Region { get; }
}