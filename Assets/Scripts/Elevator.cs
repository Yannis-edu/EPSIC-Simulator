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
        if (collision.gameObject.CompareTag("Player") && InputManager.GetButton("Fire1"))
        {
            elevatorPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            elevatorPanel.SetActive(false);
        }
    }
}
