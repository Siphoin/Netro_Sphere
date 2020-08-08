using System;

[Serializable]
  public  class AudioData
    {
    public float volume_music = 1f;
    public float volume_fx = 1f;

    public AudioData (float v_fx, float v_music)
    {
        volume_music = v_music;
        volume_fx = v_fx;
    }

    public AudioData ()
    {

    }
    }
