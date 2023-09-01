using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configurations
{
    public abstract class IFIleReader : MonoBehaviour
    {
        protected string _filePath;
        public void SetFileName(string filePath)
        {
            _filePath = filePath;
        }
        public abstract void ReadConfig<T>(ref T Config);
    }
}