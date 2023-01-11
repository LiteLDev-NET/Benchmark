ll.registerPlugin("Benchmark.Lua", "基准测试（Lua侧）", {1, 0, 0})

EVENT_SUB_COUNT = 100
HOOK_REG_COUNT = 100

mc.listen("onServerStarted", function()
    getTick = ll.import("Benchmark", "GetTick")
    --[[
    startTime = getTick()
    for i = 0, EVENT_SUB_COUNT do
        mc.listen("onScoreChanged", function()
        end)
    end
    endTime = getTick()
    logger.debug("Lua - Event subscribe*" .. EVENT_SUB_COUNT .. ": " .. endTime - startTime)
    -- ]]
    ----[[
    startTime = getTick()
    TestHook = NativeFunction.fromSymbol("?useItem@Player@@UEAAXAEAVItemStackBase@@W4ItemUseMethod@@_N@Z")
    for i = 0, EVENT_SUB_COUNT do
        TestHook:hook(function(a1, a2, a3, a4)
            TestHook.call(a1, a2, a3, a4)
        end)
    end
    endTime = getTick()
    logger.debug("Lua - Hook register*" .. HOOK_REG_COUNT .. ": " .. endTime - startTime)
    -- ]]
end)
