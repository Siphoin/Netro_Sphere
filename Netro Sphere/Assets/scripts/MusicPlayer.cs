using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] list;
    [SerializeField] AudioSource audioSource;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            NewClip();
        }
    }

    void NewClip ()
    {
        AudioClip clip = list[Random.Range(0, list.Length)];

        if (clip == audioSource.clip)
        {
            NewClip();
        }

        else
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
