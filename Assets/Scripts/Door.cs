using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Door destinationDoor;
    public string destinationName;
    private Text txtAction;
    public AudioClip openSound;

    private void Start()
    {
        txtAction = Camera.main.GetComponent<CameraScript>().TxtAction;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            txtAction.text = destinationName;
            if (SimpleInput.GetButtonDown("Vertical") && SimpleInput.GetAxis("Vertical") > 0)
            {
                sound();
                collision.gameObject.transform.position = destinationDoor.transform.position;
                Camera.main.transform.position = new Vector3(destinationDoor.transform.position.x, destinationDoor.transform.position.y, Camera.main.transform.position.z);
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
    //Methode sonor
    public void sound()
    {
        GetComponent<AudioSource>().PlayOneShot(openSound);
    }
}
