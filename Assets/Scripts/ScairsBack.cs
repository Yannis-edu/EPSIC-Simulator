using UnityEngine;

public class ScairsBack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        Debug.Log(128);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        Debug.Log(255);
    }
}
