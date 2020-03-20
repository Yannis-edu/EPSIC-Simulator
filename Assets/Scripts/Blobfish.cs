using UnityEngine;

public class Blobfish : MonoBehaviour
{
    public float power;
    private float timeToChangeDirection;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        timeToChangeDirection -= Time.fixedDeltaTime;
        if (timeToChangeDirection <= 0)
        {
            timeToChangeDirection = Random.Range(0.5f, 2);
            transform.Rotate(0, 0, Random.Range(0, 360));
            rb.velocity = transform.up * power;
        }
    }
}
