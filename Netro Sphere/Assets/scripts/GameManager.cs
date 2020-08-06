using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    const float plusTimeScale = 0.05f;
    [SerializeField] float timeNewSpeedGame;
    const float maxScaleTime = 4;
    private float currentTimeScale = 0;
    private float kmTotal = 0;
    private Sphere sphere;
    private int Money = 0;
    public float km { get => (float)Math.Round(kmTotal, 2); }
    public int money { get => Money; set => Money = value; }
    public bool Status { get => status; }
    public int health { get => healthCount; set => healthCount = value; }

    bool status = true;

    private int healthCount = 3;

    public string TimePlay { get => string.Format("{00:00}", timer_gameplay.Minute) + ":" + string.Format("{00:00}", timer_gameplay.Second); }

    DateTime timer_gameplay = new DateTime();
    // Use this for initialization
    void Start()
    {
        sphere = GameObject.FindGameObjectWithTag("Player").GetComponent<Sphere>();
        SetCurrentTimeScale();
        StartCoroutine(NewSpeedGame());
        StartCoroutine(TimePlayTick());
    }

    private void SetCurrentTimeScale()
    {
        currentTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        kmTotal += 0.0001f * sphere.Speed * Time.timeScale;
    }

    IEnumerator NewSpeedGame ()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeNewSpeedGame);
            if (Time.timeScale < maxScaleTime)
            {
            Time.timeScale += plusTimeScale;
                SetCurrentTimeScale();
            }

            else
            {
                break;
            }


            
        }
    }

    IEnumerator TimePlayTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer_gameplay = timer_gameplay.AddSeconds(1);


        }
    }



    public void SetStatusGame ()
    {
        status = !status;
        if (status)
        {
            Time.timeScale = currentTimeScale;
        }

        else
        {
            Time.timeScale = 0;
        }
    }
}
