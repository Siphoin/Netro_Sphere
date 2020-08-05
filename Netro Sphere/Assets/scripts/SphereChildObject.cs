using UnityEngine;
using System.Collections;

public class SphereChildObject : MonoBehaviour
{
   protected GameObject sphere;

  protected  Vector3 startPos;
    // Use this for initialization
    void Start()
    {
    }

    protected void FindSphere()
    {
       
        sphere = GameObject.FindGameObjectWithTag("Player");
    }

    protected void SetPosition ()
    {
        float x = sphere.transform.position.x;
        float y = sphere.transform.position.y;
        Vector3 pos = new Vector3(x, startPos.y - y, startPos.z);
        transform.position = pos;
    }


    protected void IniOldPosition ()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
