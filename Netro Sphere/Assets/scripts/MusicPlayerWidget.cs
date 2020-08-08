using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicPlayerWidget : MonoBehaviour
{
    Animation anim;
    [SerializeField] Text text_music_bame;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hide ()
    {
        Destroy(gameObject);
    }

    public void PlayHideAnim ()
    {
        anim.Play("musicPlayerOff");
    }

    public void SetTextMusic (string nameMusic)
    {
        text_music_bame.text = nameMusic;
    }
}
