using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Door destinationDoor;
    public string destinationName;
    private Text txtAction;

    private void Start()
    {
        txtAction = Camera.main.GetComponent<CameraScript>().TxtAction;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            txtAction.text = destinationName;
            if (InputManager.GetButtonDown("Vertical") && InputManager.GetAxis("Vertical") > 0)
            {
                collision.gameObject.transform.position = destinationDoor.transform.position;
                Camera.main.transform.position = new Vector3(destinationDoor.transform.position.x, destinationDoor.transform.position.y, Camera.main.transform.position.z);
                destinationDoor.destinationDoor = this;
                destinationDoor.destinationName = GetComponentInParent<Zone>()?.zoneName;
                destinationDoor.GetComponentInParent<Zone>().zoneName = destinationName;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraScript>().TxtAction.text = string.Empty;

        }
    }
}
