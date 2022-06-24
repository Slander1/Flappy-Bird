using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }
    
}
