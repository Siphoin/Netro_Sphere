using UnityEngine;
using System.Collections;

public class Tranpline : DynamicObject
{
    [SerializeField] float movedSpeed = 0;
    // Use this for initialization
    void Start()
    {
        FindSphere();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.z -= movedSpeed * Time.deltaTime;
        transform.position = pos;
        UpdateDestroy();
    }
}
