using UnityEngine;
using System.Collections;

public class SpawnTranplines : MonoBehaviour
{
    const float width_screen = 2.72f;
    const float startPoint = 34.9f;
    [SerializeField] float timeSpawn;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnTick());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTick ()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, timeSpawn));
            GameObject tranpline = Instantiate(Resources.Load<GameObject>("Prefabs/Tranpline"));
            Vector3 vec = new Vector3(Random.Range(width_screen * -1, width_screen), 0, startPoint);
            tranpline.transform.position = vec;
        }
    }
}
