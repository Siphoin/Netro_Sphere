using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text text_km_total;
    [SerializeField] Text text_money;
    [SerializeField] Text text_time_gameplay;
    [SerializeField] Sprite sprite_resume_b;
    [SerializeField] Sprite sprite_pause_b;
    [SerializeField] Sprite health_full_sprite;
    [SerializeField] Sprite health_none_sprite;
    [SerializeField] Image image_button_time;
    [SerializeField] Image[] healths;
    [SerializeField] Animation animator_damage_screen;
    [SerializeField] AudioSource audioSource;
    
    private GameManager gameManager;
    int health_old;
    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
        health_old = gameManager.health;
        StartCoroutine(RefreshHealthStatus());
    }

    // Update is called once per frame
    void Update()
    {
        text_money.text = gameManager.money.ToString();
        text_km_total.text = gameManager.km + " KM:";
        text_time_gameplay.text = gameManager.TimePlay;

        if (Time.timeScale == 0)
        {
            image_button_time.sprite = sprite_resume_b;
        }

        else
        {
            image_button_time.sprite = sprite_pause_b;
        }

        if (gameManager.health < health_old)
        {
            health_old = gameManager.health;
            animator_damage_screen.Play();
            audioSource.Play();
        }

        else
        {
            health_old = gameManager.health;
        }

        if (gameManager.health <= 0)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/GameOver"));
            Destroy(gameObject);
        }
    }

    public void SetTimeState ()
    {
        gameManager.SetStatusGame();
    }

    IEnumerator RefreshHealthStatus ()
    {
        while (gameManager.health > 0)
        {
            yield return new WaitForSeconds(1 / 60);

            
            for (int i = 0; i < healths.Length; i++)
            {
                healths[i].sprite = health_none_sprite;
            }

            for (int i = 0; i < gameManager.health; i++)
            {
                healths[i].sprite = health_full_sprite;
            }
        }
    }

    
}
