using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Configurations.GameConfigurations;

namespace Configurations
{
    public class FixGameConfigs
    {
        const int MinButtonsAmount = 2;
        const int MaxButtonsAmount = 6;
        public static Root FixButtonsAmount(Root config)
        {
            config.Easy = FixButtonsAmount(config.Easy);
            config.Medium = FixButtonsAmount(config.Medium);
            config.Hard = FixButtonsAmount(config.Hard);
            return config;
        }        
        public static ModeConfig FixButtonsAmount(ModeConfig mode)
        {
            if (mode.GameButtons < MinButtonsAmount)
                mode.GameButtons = MinButtonsAmount;
            else if (mode.GameButtons > MaxButtonsAmount)
                mode.GameButtons = MaxButtonsAmount;
            return mode;
        }
        //Just in case config wan't found
        public static Root SetConfigDefaultValues(Root gameConfig)
        {
            ModeConfig Easy = new ModeConfig() { GameButtons = 4, GameTime = 60, PointEachStep = 1, RepeatMode = true };
            ModeConfig Medium = new ModeConfig() { GameButtons = 4, GameTime = 60, PointEachStep = 1, RepeatMode = true };
            ModeConfig Hard = new ModeConfig() { GameButtons = 4, GameTime = 60, PointEachStep = 1, RepeatMode = true };
            gameConfig.Easy = Easy;
            gameConfig.Medium = Medium;
            gameConfig.Hard = Hard;
            return gameConfig;
        }
    }
}