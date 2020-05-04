using UnityEngine;

public class Takable : MonoBehaviour
{
    public bool dropped = true;
    public Sprite pickedSprite;
    public Sprite droppedSprite;

    private void FixedUpdate()
    {
        if (!dropped)
        {
            if (transform.parent.GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.localPosition = new Vector2(-1.5f, 0);
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                transform.localPosition = new Vector2(1.5f, 0);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (dropped && collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Player>().inHand == null && SimpleInput.GetButton("Fire1"))
        {
            dropped = false;
            GetComponent<SpriteRenderer>().sprite = pickedSprite;
            transform.parent = collision.gameObject.transform;
            transform.localPosition = Vector2.zero;
            collision.gameObject.GetComponent<Player>().inHand = gameObject;
            GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Drop(Entity entity)
    {
        dropped = true;
        GetComponent<SpriteRenderer>().sprite = droppedSprite;
        transform.parent = null;
        entity.inHand = null;
        GetComponent<Rigidbody2D>().simulated = true;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
        }
    }
}