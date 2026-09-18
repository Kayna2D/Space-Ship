using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        if (GameManager.Instance.gameOver)
            return;

        float currentSpeed = TimeManager.Instance.GetSpeed(speed);

        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        if (transform.position.x < -5f)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.gameOver)
            return;

        if (other.CompareTag("Bullet"))
        {
            GameManager.Instance.AddScore(10);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}