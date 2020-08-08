using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] Text text_time;
    [SerializeField] Text text_score;
    [SerializeField] Text text_km;
    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
        Time.timeScale = 0;
        text_time.text = "Time: " + gameManager.TimePlay;
        text_score.text = gameManager.money.ToString();
        text_km.text = gameManager.km + " KM";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartLevel ()
    {
        gameManager.SaveRecord();
        Time.timeScale = 1;
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
}
