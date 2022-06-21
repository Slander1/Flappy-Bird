using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image RestartImage;
    private void OnEnable()
    {
        BirdController.birdDie += BirdDie;
    }

    private void BirdDie()
    {
        RestartImage.gameObject.SetActive(true);
    }

    public void OnRestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDisable()
    {
        BirdController.birdDie -= BirdDie;
    }

}
