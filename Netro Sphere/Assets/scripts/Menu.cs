using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    const string nameGameScene = "game";
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlay ()
    {
        SceneManager.LoadScene(nameGameScene);
    }

    public void OpenSettings ()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/WindowSettings"));
    }
}
