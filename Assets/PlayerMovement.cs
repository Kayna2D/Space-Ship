using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public float minX = -4f;
    public float maxX = 4f;
    public float minY = -1.8f;
    public float maxY = 1.8f;

    // Tiro
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        Move();

        Shoot();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f);

        transform.position += movement.normalized * speed * Time.deltaTime;

        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}