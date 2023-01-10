using LiteLoader.Event;
using LiteLoader.Logger;
using LiteLoader.NET;
using LiteLoader.RemoteCall;
using System;
using System.Collections.Generic;

namespace Benchmark;

[PluginMain("Benchmark.NET")]
public class Main : IPluginInitializer
{
    public string Introduction => "性能测试（.NET侧）";
    public Dictionary<string, string> MetaData => new();
    public Version Version => new(1, 0, 0);
    internal static Logger Logger = new("Benchmark.NET");
    public void OnInitialize()
    {
        _ = RemoteCallAPI.ExportAs("Benchmark", "GetTick", () => DateTime.Now.Ticks);
        DateTime startTime = DateTime.Now;
        for (int i = 0; i < Config.EVENT_SUB_COUNT; ++i)
        {
            _ = PlayerScoreChangedEvent.Subscribe(ev => true);
        }
        DateTime endTime = DateTime.Now;
        Logger.Debug.WriteLine($".NET - Event subscribe*{Config.EVENT_SUB_COUNT}: {(endTime - startTime).Ticks}");
    }
}

public static class Config
{
    public const int EVENT_SUB_COUNT = 100;
}
