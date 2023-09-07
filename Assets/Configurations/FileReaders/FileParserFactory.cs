using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FileParser
{
    /// <summary>
    /// This class is a factory for file parsers
    /// </summary>
    public static class FileParserFactory
    {
        public static IFIleParser GetFileReder(string extention)
        {
            switch (extention.ToLower())
            {
                case "json":
                    return new JsonFileParser();                    
                case "xml":
                    return new XMLFileParser();                    
                default:                    
                    return null;                    
            }            
        }
    }
}
