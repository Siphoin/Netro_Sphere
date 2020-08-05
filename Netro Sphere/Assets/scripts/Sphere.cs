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

    const string enemyTag = "Enemy";
    /// <summary>
    /// for clamp (argument min)
    /// </summary>
    float width_screen_min = 0;
    /// <summary>
    /// rightbody for jump
    /// </summary>
    private Rigidbody rigidbody;

    private Vector3 forceJump = new Vector3(0, 4.8f, 0);

    public float Speed { get => speed; }

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
            Jump(forceJump);
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


    public void Jump (Vector3 force)
    {
        if (rigidbody.velocity.y == 0)
        {
        rigidbody.AddForce(force, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            // TODO: game over
            Debug.Log(32343);
        }

        if (collision.gameObject.tag == "Money")
        {
            collision.gameObject.GetComponent<Monetka>().DestrotyMonetka();
        }

        if (collision.gameObject.tag == "Batut")
        {
            Debug.Log(32343);
            rigidbody.AddForce(forceJump * 1.29f, ForceMode.Impulse);
        }
    }
}
