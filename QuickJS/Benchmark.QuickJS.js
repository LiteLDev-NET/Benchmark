ll.registerPlugin("Benchmark.QuickJS", "基准测试（QuickJS侧）", [1, 0, 0]);

const EVENT_SUB_COUNT = 100;
const HOOK_REG_COUNT = 100;

mc.listen("onServerStarted", () => {
    const getTick = ll.import("Benchmark", "GetTick");
    /*
    const startTime = getTick();
    for (let i = 0; i < EVENT_SUB_COUNT; ++i)
        mc.listen("onScoreChanged", () => {});
    const endTime = getTick();
    logger.debug(
        `QuickJS - Event subscribe*${EVENT_SUB_COUNT}: ${endTime - startTime}`
    );
    //*/
    ///*
    const startTime = getTick();
    var TestHook = NativeFunction.fromSymbol(
        "?useItem@Player@@UEAAXAEAVItemStackBase@@W4ItemUseMethod@@_N@Z"
    );
    for (let i = 0; i < HOOK_REG_COUNT; ++i)
        TestHook.hook((a1, a2, a3, a4) => TestHook.call(a1, a2, a3, a4));
    const endTime = getTick();
    logger.debug(
        `QuickJS - Hook register*${HOOK_REG_COUNT}: ${endTime - startTime}`
    );
    //*/
});
