using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FileParser
{
    /// <summary>
    /// FileParser childern are designed to parse files to wanted objects
    /// </summary>
    public abstract class FIleParser
    {        
        public abstract T ParseFile<T>(T Output, string filePath);
    }
}