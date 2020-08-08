using UnityEngine;
using System.Collections;

public class HTP : MonoBehaviour
{
    const string nameFileSave = "htp.ns";
    // Use this for initialization
    void Start()
    {
        if (SaverManager.CheckFile(nameFileSave))
        {
            Exit();
            return;
        }
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Exit ()
    {
        Time.timeScale = 1;
        SaverManager.SaveFile(nameFileSave, "1");
        Destroy(gameObject);
    }
}
