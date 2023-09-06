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
    public void file_reader_factory_test_json()
    {
        // test to make sure the general logic of getting FileParser by the name of the file is good
        string path = "Configurations/Config.json";        
        FIleParser iFIleParser = FileParserFactory.GetFileReder(path.Split('.')[1]);        

        Assert.IsTrue(iFIleParser is JsonFileParser);
    }
    [Test]
    public void file_reader_factory_test_xml()
    {
        // test to make sure the general logic of getting FileParser by the name of the file is good
        string path = "Configurations/Config.xml";
        FIleParser iFIleParser = FileParserFactory.GetFileReder(path.Split('.')[1]);        

        Assert.IsNotNull(iFIleParser is XMLFileParser);
    }
    [Test]
    public void testing_file_read_correctly_xml()
    {
        string configPath = "Configurations/Config.xml";
        string fullPath = ConfigurationPath.GetPath(configPath);        
        GameConfigurations.Root config = GameConfigurations.LoadConfig(fullPath);

        Assert.IsNotNull(config);
    }
    [Test]
    public void testing_file_read_correctly_json()
    {
        string configPath = "Configurations/Config.json";
        string fullPath = ConfigurationPath.GetPath(configPath);
        GameConfigurations.Root config = GameConfigurations.LoadConfig(fullPath);

        Assert.IsNotNull(config);
    }
}
