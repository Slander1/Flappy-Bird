using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private void OnEnable()
    {
        UIController.onStartBtn += Restart;
    }
    private void OnDisable()
    {
        UIController.onStartBtn= Restart;
    }
    
    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }

    private void Restart()
    {
        transform.position = new Vector3(-2,0,0);
    }
}
