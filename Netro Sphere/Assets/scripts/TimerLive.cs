using UnityEngine;
using System.Collections;

public class TimerLive : MonoBehaviour
{
    [SerializeField] float time;

    public float Time { get => time; set => time = value; }

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
