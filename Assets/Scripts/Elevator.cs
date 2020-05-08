using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed;
    public float currentLevel;
    public float destinationLevel;
    public float levelHeight;
    public GameObject elevatorPanel;

    private float initialLevel;
    private float initialY;

    private void Start()
    {
        initialLevel = currentLevel;
        initialY = transform.position.y;
        destinationLevel = currentLevel;
    }

    public void SetDestination(float level)
    {
        elevatorPanel.SetActive(false);
        destinationLevel = level;
    }

    private void FixedUpdate()
    {
        float destinationY = initialY + levelHeight * (destinationLevel - initialLevel);
        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, destinationY, speed * Time.fixedDeltaTime));
        if (transform.position.y == destinationY)
        {
            currentLevel = destinationLevel;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Camera.main.GetComponent<CameraScript>().TxtAction.text = "Ascensseur";
        if (collision.gameObject.CompareTag("Player") && SimpleInput.GetButton("Fire1"))
        {
            GameObject inHand = collision.gameObject.GetComponent<Player>().inHand;
            if (inHand != null)
            {
                ElevatorCard card = inHand.GetComponent<ElevatorCard>();
                if (card != null)
                {
                    elevatorPanel.SetActive(true);
                    return;
                }
            }
        }
        Camera.main.GetComponent<CameraScript>().TxtAction.text += "\nNécessite un pass";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            elevatorPanel.SetActive(false);
            Camera.main.GetComponent<CameraScript>().TxtAction.text = string.Empty;
        }
    }
}
