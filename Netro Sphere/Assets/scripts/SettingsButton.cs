using UnityEngine;

public class SettingsButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenSettings()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/WindowSettings"));
    }
}
