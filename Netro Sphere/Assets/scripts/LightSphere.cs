using UnityEngine;
using System.Collections;

public class LightSphere : SphereChildObject
{
    // Use this for initialization
    void Start()
    {
        IniOldPosition();
        FindSphere();
    }

    private void Awake()
    {
    }

    // Update is called once per frame

    private void Update()
    {
        SetPosition();
    }
}
