using UnityEngine;
using System.Collections;

public class Batut : DynamicObject
{
    [SerializeField] float angleSpeed;
    [SerializeField] float moveSpeed;
    // Use this for initialization
    void Start()
    {
        FindSphere();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 100, 0) * angleSpeed * Time.deltaTime);
        var pos = transform.position;
        pos.z -= moveSpeed * Time.deltaTime;
        transform.position = pos;
        UpdateDestroy();
    }

   
}
