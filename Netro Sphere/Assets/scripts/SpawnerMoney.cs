using UnityEngine;
using System.Collections;

public class SpawnerMoney : MonoBehaviour
{
    const float shageSpawn = 0.95f;
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

    IEnumerator SpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, timeSpawn));
            float shag = startPoint;
            float x = Random.Range(width_screen * -1, width_screen);
            int count_moneys = Random.Range(1, 13);
            for (int i = 0; i < count_moneys; i++)
            {
            GameObject money = Instantiate(Resources.Load<GameObject>("Prefabs/money"));
            Vector3 vec = new Vector3(x, 0.16f, shag);
            money.transform.position = vec;
                shag -= shageSpawn;
            }

        }
    }
}
