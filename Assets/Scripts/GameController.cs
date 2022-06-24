using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject obstacleSpawner;
    private void OnEnable()
    {
        UIController.onStartBtn += OnStartBtn;
        BirdController.birdDie += BirdDie;
    }

    private void OnDisable()
    {
        UIController.onStartBtn -= OnStartBtn;
        BirdController.birdDie -= BirdDie;
    }

    private void BirdDie()
    {
        Destroy(bird);
        ObstacleSpawner.instance.DestroyAllObstacle();
        StopAllCoroutines();
        //StopCoroutine(ObstacleSpawner.instance.SpawnObstacle());
    }

    private void OnStartBtn()
    {
        Instantiate(bird);
        StartCoroutine(ObstacleSpawner.instance.SpawnObstacle());
    }
}