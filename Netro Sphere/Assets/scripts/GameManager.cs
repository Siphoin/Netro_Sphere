using UnityEngine;
using System.Collections;
using System;
using System.IO;

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

    const string nameFileRecord = "record.json";

    private float record_km;

    private int record_score;

    public string TimePlay { get => string.Format("{00:00}", timer_gameplay.Minute) + ":" + string.Format("{00:00}", timer_gameplay.Second); }
    public float Record_km { get => (float)Math.Round(record_km, 2); }
    public int Record_score { get => record_score; }
    public float CurrentTimeScale { get => currentTimeScale; }

    DateTime timer_gameplay = new DateTime();
    // Use this for initialization
    void Start()
    {
        sphere = GameObject.FindGameObjectWithTag("Player").GetComponent<Sphere>();
        SetCurrentTimeScale();
        StartCoroutine(NewSpeedGame());
        StartCoroutine(TimePlayTick());

        
    }

    private void Awake()
    {
 // load last record if file record not null

        if (SaverManager.CheckFile(nameFileRecord))
        {
            string data = SaverManager.ReadFile(nameFileRecord);
            Record last_record = JsonUtility.FromJson<Record>(data);
            record_km = last_record.km;
            record_score = last_record.score;
        }       
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

    public void SaveRecord ()
    {
        if (kmTotal > 0 || Money > 0)
        {
            int money = 0;
            if (Money > record_score)
            {
               money = Money;

            }

            else 
            {
                money = record_score;

            }

            float km = 0;
            if (kmTotal > record_km)
            {
                km = kmTotal;

            }

            else
            {
                km = record_km;

            }
            Record record = new Record(km, money);
            string json = JsonUtility.ToJson(record);
            SaverManager.SaveFile(nameFileRecord, json);
        }
    }

    private void OnApplicationQuit()
    {
        SaveRecord();
    }
    // android
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveRecord();
        }
    }
}
