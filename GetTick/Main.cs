using LiteLoader.Logger;
using LiteLoader.NET;
using LiteLoader.RemoteCall;
using System;
using System.Collections.Generic;

namespace Benchmark;

[PluginMain("GetTick")]
public class Main : IPluginInitializer
{
    public string Introduction => "GetTickAPI";
    public Dictionary<string, string> MetaData => new();
    public Version Version => new(1, 0, 0);
    internal static Logger Logger = new("GetTick");
    public void OnInitialize() => RemoteCallAPI.ExportAs("Benchmark", "GetTick", () => DateTime.Now.Ticks);
}
