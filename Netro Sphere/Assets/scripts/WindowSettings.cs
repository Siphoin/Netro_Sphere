using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindowSettings : MonoBehaviour
{
    [SerializeField] Slider slider_music;
    [SerializeField] Slider slider_fx;
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
       try
        {
gameManager = Camera.main.GetComponent<GameManager>();
            Time.timeScale = 0;
        }
        catch
        {

        }
        
        slider_fx.value = AudioManager.data.volume_fx;
        slider_music.value = AudioManager.data.volume_music;
    }

    // Update is called once per frame
    void Update()
    {
         AudioManager.data.volume_fx = slider_fx.value;
         AudioManager.data.volume_music = slider_music.value;
    }

    public void Exit ()
    {
        AudioManager.SaveData(slider_fx.value, slider_music.value);
        if (gameManager != null)
        {
            Time.timeScale = gameManager.CurrentTimeScale;
        }
        Destroy(gameObject);
    }
}
