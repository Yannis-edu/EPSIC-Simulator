using UnityEngine;

public class Grounder : MonoBehaviour
{
    public Player playerScript;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Structure"))
        {
            playerScript.grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Structure"))
        {
            playerScript.grounded = false;
        }
    }
}
