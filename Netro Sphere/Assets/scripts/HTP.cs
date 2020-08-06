using UnityEngine;
using System.Collections;

public class HTP : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Exit ()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
