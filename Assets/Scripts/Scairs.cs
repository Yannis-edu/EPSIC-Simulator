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
            Entity entity = collision.gameObject.GetComponentInParent<Entity>();
            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, entity.vertical * entity.speed * climbRatio * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grounder"))
        {
            collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = gravity;
        }
    }

    /// <summary>
    /// Méthode pour empecher de monter plus haut que le sommet des escaliers
    /// </summary>
    /// <param name="collision"></param>
    /*
    private void OnCollisionEnter(Collider2D collision)
    {
        if(Player.GetAxis(y) = Scairs.GetHeight(top)
        {
            player.move(axis(y)) = false;
        }
    }
    */
}
