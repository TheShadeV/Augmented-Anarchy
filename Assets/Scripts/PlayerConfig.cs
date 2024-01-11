using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DataModel
{

    [System.Serializable]
    public class SampleData
    {
        public Model01 testObject;

    }

    [System.Serializable]
    public class Model01
    {
        public string someText;
        public InLineModel01 someObject;
        public string[] someArray;
    }

    [System.Serializable]
    public class InLineModel01
    {
        public int someNumber;
        public bool someBool;
    }

    // load file from the path
    string jsonPath = Application.streamingAssetsPath + "/SampleJsonFile.json");

    // read file as text
    string jsonStr = File.ReadAllText(jsonPath); // using System;
}
