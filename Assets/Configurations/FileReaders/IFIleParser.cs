using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FileParser
{
    /// <summary>
    /// FileParser childern are designed to parse files to wanted objects
    /// </summary>
    /// 

    // This is an interface so I'll keep the design as simple and flexible as possible
    public interface IFIleParser
    {        
        public T ParseFile<T>(T Output, string filePath);
    }
}