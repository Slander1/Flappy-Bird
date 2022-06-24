using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image RestartImage;
    [SerializeField] private Button StartBtn;
    
    public static Action onStartBtn; 
    private void OnEnable()
    {
        BirdController.birdDie += BirdDie;
    }
    private void OnDisable()
    {
        BirdController.birdDie -= BirdDie;
    }
    private void BirdDie()
    {
        RestartImage.gameObject.SetActive(true);
    }

    public void OnRestartBtn()
    {
        ObstacleSpawner.instance.coroutineWork = true;
        onStartBtn?.Invoke();
        RestartImage.gameObject.SetActive(false);
    }

    public void OnStartBtn()
    {
        ObstacleSpawner.instance.coroutineWork = true;
        onStartBtn?.Invoke();
        StartBtn.gameObject.SetActive(false);
    }

    public void OnMenuBtn()
    {
        
    }
}
