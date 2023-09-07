using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Configurations.GameConfigurations;

namespace Configurations
{
    /// <summary>
    /// FixGameConfigs fix game config data. For now it fix the amount of buttons to the limited amount
    /// </summary>
    public class FixGameConfigs
    {
        public const int MinButtonsAmount = 2;
        public const int MaxButtonsAmount = 6;
        const int defaultGameButtons = 4;
        const int defaultGameTIme = 60;
        const int defaultPointEachStep = 1;
        const bool defaultRepeatMode = true;
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
        public static Root SetConfigDefaultValues()
        {
            ModeConfig Easy = new ModeConfig() { GameButtons = defaultGameButtons, GameTime = defaultGameTIme, PointEachStep = defaultPointEachStep, RepeatMode = defaultRepeatMode };
            ModeConfig Medium = new ModeConfig() { GameButtons = defaultGameButtons, GameTime = defaultGameTIme, PointEachStep = defaultPointEachStep, RepeatMode = defaultRepeatMode };
            ModeConfig Hard = new ModeConfig() { GameButtons = defaultGameButtons, GameTime = defaultGameTIme, PointEachStep = defaultPointEachStep, RepeatMode = defaultRepeatMode };
            Root root = new Root()
            {
                Easy = Easy,
                Medium = Medium,
                Hard = Hard
            };
            return root;
        }
    }
}