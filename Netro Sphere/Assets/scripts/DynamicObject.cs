using UnityEngine;
using System.Collections;

public class DynamicObject : MonoBehaviour
{
    [SerializeField] float checkDistance = 0;
    private GameObject sphere;

    // Use this for initialization
    void Start()
    {
    }

    protected void FindSphere()
    {
        sphere = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void UpdateDestroy ()
    {
        float d = Vector3.Distance(transform.position, sphere.transform.position);
   //     Debug.Log(d);
        if (Vector3.Distance(transform.position, sphere.transform.position) > checkDistance)
        {
            if (transform.position.z < sphere.transform.position.z)
            {
        Destroy(gameObject);
            }
    
        }
    }
}
