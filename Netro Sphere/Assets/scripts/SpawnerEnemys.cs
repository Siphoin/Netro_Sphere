using UnityEngine;
using System.Collections;

public class SpawnerEnemys : MonoBehaviour
{
    const string pathEnemysPrefabs = "Prefabs";
    private GameObject[] arrayPrefabs = new GameObject[0];
    const float width_screen = 4.07f;
    const float startPoint = 34.9f;
    private int countEnemys = 1;
    const float timeHardingSpawn = 30;
    // Use this for initialization
    void Start()
    {
        arrayPrefabs = Resources.LoadAll<GameObject>(pathEnemysPrefabs);
        StartCoroutine(SpawnTick());
        StartCoroutine(HardingSpawnTick());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnTick ()
    {
        while (true)
        {
            float time = Random.Range(3, 6);
            yield return new WaitForSeconds(time);
            if (countEnemys > 0)
            {
            for (int i = 0; i < countEnemys; i++)
            {
                    yield return new WaitForSeconds(1f);
                    SpawnEnemy();
            }
            }

            else
            {
                SpawnEnemy();
            }


        }
    }

    private IEnumerator HardingSpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeHardingSpawn);
            countEnemys++;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 vec = new Vector3(Random.Range(width_screen * -1, width_screen), 0, startPoint);
        GameObject enemy = Instantiate(arrayPrefabs[Random.Range(0, arrayPrefabs.Length)]);
        enemy.transform.position = vec;
    }
}
