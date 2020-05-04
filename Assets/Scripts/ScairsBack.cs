using UnityEngine;

public class ScairsBack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }
}
