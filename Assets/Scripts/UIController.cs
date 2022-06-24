using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image restartMenu;
    [SerializeField] private Image startMenu;
    
    public static Action onStartBtn; 
    public static Action onReStartBtn; 
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
        restartMenu.gameObject.SetActive(true);
    }

    public void OnRestartBtn()
    {
        ObstacleSpawner.instance.coroutineWork = true;
        onReStartBtn?.Invoke();
        restartMenu.gameObject.SetActive(false);
    }

    public void OnStartBtn()
    {
        ObstacleSpawner.instance.coroutineWork = true;
        onStartBtn?.Invoke();
        startMenu.gameObject.SetActive(false);
    }

    public void OnMenuBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnExitBtn()
    {
        Application.Quit();
    }
}
