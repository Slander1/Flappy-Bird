using System;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float force = 1f;

    [SerializeField] private Rigidbody2D bird;

    public static Action birdDie;

    private const string GroundTag = "Ground";
    private const string ObstacleTag = "Obstacle";
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            bird.velocity = Vector2.up * force;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(ObstacleTag) || other.collider.CompareTag(GroundTag))
        {
            Destroy(transform.gameObject);
            birdDie?.Invoke();
        }
        
    }
}
