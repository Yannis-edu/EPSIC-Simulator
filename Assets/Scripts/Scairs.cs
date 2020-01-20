using UnityEngine;

public class Scairs : MonoBehaviour
{
    public float climbRatio;
    private float gravity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grounder"))
        {
            gravity = collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale;
            collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grounder"))
        {
            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, InputManager.GetAxis("Vertical") * collision.gameObject.GetComponentInParent<Player>().speed * climbRatio * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grounder"))
        {
            collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = gravity;
        }
    }
}
