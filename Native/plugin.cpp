/**
 * @file plugin.cpp
 * @brief The main file of the plugin
 */

#include <llapi/LoggerAPI.h>

#include "version.hpp"

#include <llapi/RemoteCallAPI.h>
#include <llapi/EventAPI.h>

class Config
{
public:
    static const int EVENT_SUB_COUNT = 100;
};

// We recommend using the global logger.
extern Logger logger;

/**
 * @brief The entrypoint of the plugin. DO NOT remove or rename this function.
 *
 */
void PluginInit()
{
    Event::ServerStartedEvent::subscribe([](Event::ServerStartedEvent)
    {
        auto getTick = RemoteCall::importAs<std::function<int64_t()>>("Benchmark", "GetTick");
        auto startTime = getTick();
        for (int i = 0; i < Config::EVENT_SUB_COUNT; ++i)
        {
            Event::PlayerScoreChangedEvent::subscribe([](Event::PlayerScoreChangedEvent) { return true; });
        }
        auto endTime = getTick();
        logger.debug("Native - Event subscribe*{}: {}", Config::EVENT_SUB_COUNT, endTime - startTime);
        return true;
    });
}
