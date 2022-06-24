using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject obstacleSpawner;
    private GameObject thisBird;
    private void OnEnable()
    {
        UIController.onStartBtn += OnStartBtn;
        UIController.onReStartBtn += OnStartBtn;
        BirdController.birdDie += BirdDie;
    }

    private void OnDisable()
    {
        UIController.onStartBtn -= OnStartBtn;
        UIController.onReStartBtn += OnStartBtn;
        BirdController.birdDie -= BirdDie;
    }

    private void BirdDie()
    {
        Destroy(thisBird);
        ObstacleSpawner.instance.DestroyAllObstacle();
        StopAllCoroutines();
        //StopCoroutine(ObstacleSpawner.instance.SpawnObstacle());
    }

    private void OnStartBtn()
    {
        thisBird = Instantiate(bird);
        StartCoroutine(ObstacleSpawner.instance.SpawnObstacle());
    }
}