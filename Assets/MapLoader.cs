﻿using System.Linq;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class MapLoader : MonoBehaviour
{
    private static string _csvPath;
    public static Map LoadPath(string path)
    {
        _csvPath = Directory.GetFiles(path, @"*.json").First();
        string json = File.ReadAllText(_csvPath);
        Map currentMap = JsonConvert.DeserializeObject<Map>(json);
        currentMap.Path = path;
        return currentMap;
    }
}