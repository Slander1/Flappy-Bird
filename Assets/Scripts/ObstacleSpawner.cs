using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstacles;
    private List<GameObject> _specacles = new List<GameObject>();
    public static ObstacleSpawner instance { get; private set; }
    public bool coroutineWork;
    

    private void Awake()
    {
        instance = this;
        coroutineWork = true;
    }

    public IEnumerator SpawnObstacle()
    {
        while (coroutineWork)
        {
            if (!coroutineWork)
                yield break;
            var time = Random.Range(2f, 5f);
            yield return new WaitForSeconds(time);
            var yUpObstacle = Random.Range(1f, -8f);
            _specacles.Add(Instantiate(obstacles, new Vector3(2, yUpObstacle, 0), Quaternion.identity, transform));
            DestroyObstacle(_specacles[_specacles.Count-1]);
        }
    }

    private async void DestroyObstacle(GameObject obstacle)
    {
        await Task.Delay(10000);
        if (!_specacles.Contains(obstacle)) return;
        _specacles.Remove(obstacles);
        Destroy(obstacle);
    }
    
    public void DestroyAllObstacle()
    {
        foreach (var specacle in _specacles)
        {
            Destroy(specacle);
        }
        _specacles.Clear();
        //
    }
        
}