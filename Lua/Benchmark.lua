ll.registerPlugin("Benchmark.Lua", "基准测试（Lua侧）", {1, 0, 0})

EVENT_SUB_COUNT = 100
getTick = ll.import("Benchmark", "GetTick")

mc.listen("onServerStarted", function()
    startTime = getTick()
    for i = 0, EVENT_SUB_COUNT do
        mc.listen("onScoreChanged", function()
        end)
    end
    endTime = getTick()
    logger.debug("Lua - Event subscribe*" .. EVENT_SUB_COUNT .. ": " .. endTime - startTime)
end)
