using UnityEngine;
using System.Collections;

public class Monetka : DynamicObject
{
    [SerializeField] float angleSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] AudioSource audioSource;
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        FindSphere();
        gameManager = Camera.main.GetComponent<GameManager>();
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


    public void DestroyMonetka()
    {
        GameObject effectDestroy = Instantiate(Resources.Load<GameObject>("Prefabs/effect_money"));
        var pos = transform.position;
        pos.y += 2;
        effectDestroy.transform.position = pos;
        gameManager.money++;
        audioSource.Play();
        audioSource.transform.SetParent(null);
        audioSource.gameObject.AddComponent<TimerLive>().Time = 0.5f;
        Destroy(gameObject);
    }
}
