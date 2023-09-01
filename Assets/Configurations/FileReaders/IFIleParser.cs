using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FileParser
{
    /// <summary>
    /// IFileParser childern are designed to parse files to wanted objects
    /// </summary>
    public abstract class IFIleParser
    {
        protected string _filePath;
        public void SetFileName(string filePath)
        {
            _filePath = filePath;
        }
        public abstract T ParseFile<T>(T Output);
    }
}