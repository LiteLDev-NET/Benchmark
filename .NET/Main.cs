using LiteLoader.Event;
using LiteLoader.Hook;
using LiteLoader.Logger;
using LiteLoader.NET;
using LiteLoader.RemoteCall;
using System;
using System.Collections.Generic;

namespace Benchmark;

[PluginMain("Benchmark.NET")]
public class Main : IPluginInitializer
{
    public string Introduction => "基准测试（.NET侧）";
    public Dictionary<string, string> MetaData => new();
    public Version Version => new(1, 1, 0);
    internal static Logger Logger = new("Benchmark.NET");
    public void OnInitialize()
    {
        _ = ServerStartedEvent.Subscribe(_ev =>
        {
            Func<long> GetTick = RemoteCallAPI.ImportAs<Func<long>>("Benchmark", "GetTick");
            /*
            long startTime = GetTick();
            for (int i = 0; i < Config.EVENT_SUB_COUNT; ++i)
            {
                _ = PlayerScoreChangedEvent.Subscribe(_ev => true);
            }
            long endTime = GetTick();
            Logger.Debug.WriteLine($".NET - Event subscribe*{Config.EVENT_SUB_COUNT}: {endTime - startTime}");
            //*/
            ///*
            long startTime = GetTick();
            for (int i = 0; i < Config.HOOK_REG_COUNT; ++i)
            {
                Thook.RegisterHook<TestHook, TestHookDelegate>();
            }
            long endTime = GetTick();
            Logger.Debug.WriteLine($".NET - Hook register*{Config.HOOK_REG_COUNT}: {endTime - startTime}");
            //*/
            return true;
        });
    }
}

internal delegate void TestHookDelegate(nint @this, nint a2, int a3, bool a4);
[HookSymbol("?useItem@Player@@UEAAXAEAVItemStackBase@@W4ItemUseMethod@@_N@Z")]
internal class TestHook : THookBase<TestHookDelegate>
{
    public override TestHookDelegate Hook => (@this, a2, a3, a4) => Original(@this, a2, a3, a4);
}


public static class Config
{
    public const int EVENT_SUB_COUNT = 100;
    public const int HOOK_REG_COUNT = 100;
}
