using UnityEngine;

public class Hall : MonoBehaviour
{
    public Hall destinationBack;
    public Hall destinationFront;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && InputManager.GetButtonDown("Vertical"))
        {
            if (InputManager.GetAxis("Vertical") > 0 && destinationBack != null)
            {
                collision.gameObject.transform.position += destinationBack.transform.position - transform.position;
                Camera.main.transform.position += destinationBack.transform.position - transform.position;
            }
            else if (InputManager.GetAxis("Vertical") < 0 && destinationFront != null)
            {
                collision.gameObject.transform.position += destinationFront.transform.position - transform.position;
                Camera.main.transform.position += destinationFront.transform.position - transform.position;
            }
        }
    }
}
