using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject obstacles;
    
    private void Awake()
    {
        StartCoroutine(SpawnObstacle());
    }
    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            var time = Random.Range(2f, 5f);
            yield return new WaitForSeconds(time);
            var yUpObstacle = Random.Range(1f, -8f);
            var obstacle = Instantiate(obstacles, new Vector3(2, yUpObstacle, 0), Quaternion.identity, transform);
            Destroy(obstacle, 10);
        }
    }
}
