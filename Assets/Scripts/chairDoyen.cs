using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chairDoyen : MonoBehaviour
{
    public string destinationName;
    private Text txtAction;
    /*
    public float width = 1;
    public float height = 1;
    public Vector3 position = new Vector3(10, 5, 0);

    void Awake()
    {
        // set the scaling
        Vector3 scale = new Vector3(width, height, 1f);
        transform.localScale = scale;
        // set the position
        transform.position = position;
    }
    */

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
