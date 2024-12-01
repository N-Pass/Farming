using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform minPosition, maxPosition;

    public GameObject[] objects;

    public float timeBetweenSpawns;
    private float spawnCounter;

    private void Update()
    {
        spawnCounter -= Time.deltaTime;

        if(spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawns;

            GameObject newObject = Instantiate(objects[Random.Range(0, objects.Length)]);

            newObject.transform.position = new Vector3(Random.Range(minPosition.position.x, maxPosition.position.x), minPosition.position.y, 0f);
            newObject.SetActive(true);
        }
    }
}
