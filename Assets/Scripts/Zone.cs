using UnityEngine;

public class Zone : MonoBehaviour
{
    public string zoneName;

    private CameraScript cam;
    private BoxCollider2D collider;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 size = collider.size;
            Vector2 worldPos = transform.TransformPoint(collider.offset);

            float top = worldPos.y + (size.y / 2f);
            float btm = worldPos.y - (size.y / 2f);
            float left = worldPos.x - (size.x / 2f);
            float right = worldPos.x + (size.x / 2f);

            cam.minPosition = new Vector2(left, btm);
            cam.maxPosition = new Vector2(right, top);
        }

        cam.TxtZone.text = zoneName;
    }
}
