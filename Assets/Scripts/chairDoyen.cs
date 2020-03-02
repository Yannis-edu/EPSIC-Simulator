using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chairDoyen : MonoBehaviour
{
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
            if (InputManager.GetButtonDown("Vertical") && InputManager.GetAxis("Vertical") < 0)
            {
                collision.gameObject.GetComponent<Player>().animator.SetBool("isAssis", true);
                //*** Déplacement horizontale stop ***//
                //float h = Input.GetAxis("Horizontal");
                //collision.gameObject.getAxis(("horizontale)", false);
                //animator.SetBool("walk_left", false);

            }
            if (InputManager.GetButtonDown("Vertical") && InputManager.GetAxis("Vertical") > 0)
            {
                collision.gameObject.GetComponent<Player>().animator.SetBool("isAssis", false);
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
