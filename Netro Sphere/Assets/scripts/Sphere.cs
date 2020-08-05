using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  script for simulation sphere movement
/// </summary>
public class Sphere : MonoBehaviour
{
    /// <summary>
    /// speed rotation and move
    /// </summary>
    [SerializeField] private float speed;
    /// <summary>
    /// for clamp (argument max)
    /// </summary>
    const float width_screen = 4.07f;
    /// <summary>
    /// for clamp (argument min)
    /// </summary>
    float width_screen_min = 0;
    /// <summary>
    /// rightbody for jump
    /// </summary>
    private Rigidbody rigidbody;

    private Vector3 forceJump = new Vector3(0, 4.4f, 0);
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // set min argument clamp 
        width_screen_min = width_screen * -1;
    }

    // Update is called once per frame
    void Update()
    {
        // lose move with rotation
        transform.Rotate(new Vector3(100f, 0, 0) * speed * Time.deltaTime);
        // left dir
        if (Input.GetKey(KeyCode.A))
        {
            Moving(transform.right * - 1);
        }
       // right dir
        if (Input.GetKey(KeyCode.D))
        {
            Moving(transform.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Moving(Vector3 dir)
    {
        // moving
        transform.Translate(dir * speed * Time.deltaTime);
        // fix position of screen 
        Clamp();
    }

    private void Clamp()
    {
        float x = Mathf.Clamp(transform.position.x, width_screen_min, width_screen);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }


    private void Jump ()
    {
        if (rigidbody.velocity.y == 0)
        {
        rigidbody.AddForce(forceJump, ForceMode.Impulse);
        }

    }
}
