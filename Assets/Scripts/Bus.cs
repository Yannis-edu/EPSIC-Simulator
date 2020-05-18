using UnityEngine;
using UnityEngine.SceneManagement;

public class Bus : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraScript>().TxtAction.text = "Prendre le bus est s'enfuir";
            if (!StaticClass.disableInput && SimpleInput.GetButtonDown("Vertical") && SimpleInput.GetAxis("Vertical") > 0)
            {
                //collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                SceneManager.LoadScene("Congratulation");
            }
        }
    }
}