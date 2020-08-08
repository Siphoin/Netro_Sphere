using UnityEngine;
using System.Collections;

public class StaticSphere : MonoBehaviour
{
    [SerializeField] private float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(100f, 0, 0) * speed * Time.deltaTime);
    }
}
