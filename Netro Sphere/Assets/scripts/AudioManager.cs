using UnityEngine;
using System.Collections;

public static class AudioManager
{
  static  AudioData DATA = new AudioData();

    private static string nameFileSave = "audio.json";
 static AudioManager ()
    {
        if (SaverManager.CheckFile(nameFileSave))
        {
            string data = SaverManager.ReadFile(nameFileSave);
            DATA = JsonUtility.FromJson<AudioData>(data);
        }
    }

    public static void SaveData (float volume_fx,  float volume_music)
    {
        DATA.volume_fx = volume_fx;
        DATA.volume_music = volume_music;
        string json = JsonUtility.ToJson(DATA);
        SaverManager.SaveFile(nameFileSave, json);
    }

    public static AudioData data { get => DATA; }
}
