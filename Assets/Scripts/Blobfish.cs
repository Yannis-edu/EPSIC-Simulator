using UnityEngine;

public class Blobfish : MonoBehaviour
{
    public float power;
    private bool sens;
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
            sens = Random.Range(0, 2) != 0;
            rb.velocity = transform.up * power;
        }
        transform.Rotate(0, 0, Random.Range(0, 10) * (sens ? -1 : 1));
    }
}
