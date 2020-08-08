using UnityEngine;
using System.Collections;
using System.IO;

public static class SaverManager
{
    private static string folberName = "/user";
    private static string DataPath = null;

    static SaverManager ()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            DataPath = Application.persistentDataPath;
        }

        else
        {
            DataPath = Application.dataPath;
        }
    }
   public static void SaveFile (string fileName, string content)
    {
        string path = DataPath + folberName;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string pathFile = path + "/" + fileName;
        File.WriteAllText(pathFile, content);
    }

    public static string ReadFile(string fileName)
    {
        string path = DataPath + folberName;
        string pathFile = path + "/" + fileName;
      return  File.ReadAllText(pathFile);
    }

    public static  bool CheckFile (string fileName)
    {
        string path = DataPath + folberName;
        string pathFile = path + "/" + fileName;
        return File.Exists(pathFile);
    }

    
}
