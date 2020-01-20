using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Vector2 minPosition, maxPosition;
    public Text TxtZone, TxtAction, TxtDialog;
    private float width, height;

    private void Start()
    {
        Camera camera = GetComponent<Camera>();
        height = 2f * camera.orthographicSize;
        width = height * camera.aspect;
        minPosition = maxPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(
            Mathf.Clamp(player.transform.position.x, minPosition.x + width / 2f, maxPosition.x - width / 2f),
            Mathf.Clamp(player.transform.position.y, minPosition.y + height / 2f, maxPosition.y - height / 2f),
            transform.position.z
        ), 50 * Time.fixedDeltaTime);
    }
}
