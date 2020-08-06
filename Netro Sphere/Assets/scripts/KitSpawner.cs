using UnityEngine;
using System.Collections;

public class KitSpawner : MonoBehaviour
{
    const float width_screen = 4.07f;
    const float startPoint = 34.9f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnTick());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            float time = Random.Range(12, 21);
            yield return new WaitForSeconds(time);
            GameObject kit = Instantiate(Resources.Load<GameObject>("Prefabs/Kit"));
            Vector3 vec = new Vector3(Random.Range(width_screen * -1, width_screen), 0.242f, startPoint);
           kit.transform.position = vec;
        }
    }
}
