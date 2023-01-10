ll.registerPlugin("Benchmark.QuickJS", "基准测试（QuickJS侧）", [1, 0, 0]);

const EVENT_SUB_COUNT = 100;
const getTick = ll.import("Benchmark", "GetTick");

mc.listen("onServerStarted", () => {
    const startTime = getTick();
    for (let i = 0; i < EVENT_SUB_COUNT; ++i)
        mc.listen("onScoreChanged", () => {});
    const endTime = getTick();
    logger.debug(
        `QuickJS - Event subscribe*${EVENT_SUB_COUNT}: ${endTime - startTime}`
    );
});
