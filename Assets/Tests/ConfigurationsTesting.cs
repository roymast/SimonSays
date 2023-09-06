using System.Collections;
using System.Collections.Generic;
using System.IO;
using Configurations;
using FileParser;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ConfigurationsTesting
{
    [Test]
    public void file_parser_factory_test_json()
    {
        // test to make sure the general logic of getting FileParser by the name of the file is good
        string path = "Configurations/Config.json";        
        FIleParser iFIleParser = FileParserFactory.GetFileReder(path.Split('.')[1]);        

        Assert.IsTrue(iFIleParser is JsonFileParser);
    }
    [Test]
    public void file_parser_factory_test_xml()
    {
        // test to make sure the general logic of getting FileParser by the name of the file is good
        string path = "Configurations/Config.xml";
        FIleParser iFIleParser = FileParserFactory.GetFileReder(path.Split('.')[1]);

        Assert.IsTrue(iFIleParser is XMLFileParser);
    }
    [Test]
    public void file_parser_factory_test_null()
    {
        string path = "Config.txt";
        FIleParser iFIleParser = FileParserFactory.GetFileReder(path.Split('.')[1]);

        Assert.IsNull(iFIleParser);
    }
    [Test] 
    public void file_parser_no_path()
    {
        string path = null;
        string fullPath = ConfigurationPath.GetPath(path);
        GameConfigurations.Root config = GameConfigurations.LoadConfig(fullPath);

        Assert.IsNull(config);
    }
    [Test]
    public void file_read_correctly_xml()
    {
        string configPath = "Configurations/Config.xml";
        string fullPath = ConfigurationPath.GetPath(configPath);        
        GameConfigurations.Root config = GameConfigurations.LoadConfig(fullPath);

        Assert.IsNotNull(config);
    }
    [Test]
    public void file_read_correctly_json()
    {
        string configPath = "Configurations/Config.json";
        string fullPath = ConfigurationPath.GetPath(configPath);
        GameConfigurations.Root config = GameConfigurations.LoadConfig(fullPath);

        Assert.IsNotNull(config);
    }
    [Test]
    public void too_few_buttons_config()
    {
        int minButtons = FixGameConfigs.MinButtonsAmount;
        GameConfigurations.Root config = new GameConfigurations.Root()
        {
            Easy = new GameConfigurations.ModeConfig() { GameButtons = minButtons - 1, GameTime = 50, PointEachStep = 1, RepeatMode = true },
            Medium = new GameConfigurations.ModeConfig() { GameButtons = minButtons, GameTime = 50, PointEachStep = 1, RepeatMode = true },
            Hard = new GameConfigurations.ModeConfig() { GameButtons = minButtons - 5, GameTime = 50, PointEachStep = 1, RepeatMode = true }
        };

        FixGameConfigs.FixButtonsAmount(config);

        Assert.AreEqual(config.Easy.GameButtons, minButtons);
        Assert.AreEqual(config.Medium.GameButtons, minButtons);
        Assert.AreEqual(config.Hard.GameButtons, minButtons);
    }

    [Test]
    public void too_much_buttons_config()
    {
        int maxButtons = FixGameConfigs.MaxButtonsAmount;
        GameConfigurations.Root config = new GameConfigurations.Root()
        {
            Easy = new GameConfigurations.ModeConfig() { GameButtons = maxButtons+1, GameTime = 50, PointEachStep = 1, RepeatMode = true },
            Medium = new GameConfigurations.ModeConfig() { GameButtons = maxButtons+16, GameTime = 50, PointEachStep = 1, RepeatMode = true },
            Hard = new GameConfigurations.ModeConfig() { GameButtons = FixGameConfigs.MaxButtonsAmount, GameTime = 50, PointEachStep = 1, RepeatMode = true }
        };        
        FixGameConfigs.FixButtonsAmount(config);
        Assert.AreEqual(config.Easy.GameButtons, FixGameConfigs.MaxButtonsAmount);
        Assert.AreEqual(config.Medium.GameButtons, FixGameConfigs.MaxButtonsAmount);
        Assert.AreEqual(config.Hard.GameButtons, FixGameConfigs.MaxButtonsAmount);
    }
}
