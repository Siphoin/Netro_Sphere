using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] list;
    [SerializeField] AudioSource audioSource;
    private UIManager UI;

    // Use this for initialization
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
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
            MusicPlayerWidget musicPlayerWidget = UI.SetupMusicPlayerWidget();
            musicPlayerWidget.SetTextMusic(clip.name);
        }
    }
}
