using UnityEngine;
using System.Collections;

public class TimerLive : MonoBehaviour
{
    [SerializeField] float time;
    // Use this for initialization
    void Start()
    {
        Invoke("CallDestroy", time);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CallDestroy ()
    {
        Destroy(gameObject);
    }
}
