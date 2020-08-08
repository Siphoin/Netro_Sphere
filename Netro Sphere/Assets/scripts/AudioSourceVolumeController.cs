using UnityEngine;
using System.Collections;

public class AudioSourceVolumeController : MonoBehaviour
{
    [SerializeField] AudioType type = AudioType.Music;
    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == AudioType.Music)
        {
            audioSource.volume = AudioManager.data.volume_music;
        }

        else
        {
            audioSource.volume = AudioManager.data.volume_fx;
        }
    }
}
