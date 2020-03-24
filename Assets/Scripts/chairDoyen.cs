using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class chairDoyen : MonoBehaviour
{
    public string destinationName;
    private Text txtAction;
    public GameObject chair1;
    public GameObject chair2;

    private void Start()
    {
        txtAction = Camera.main.GetComponent<CameraScript>().TxtAction;   
      
    }

    void Update()
    {
        
    }

        private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            txtAction.text = destinationName;
            if (SimpleInput.GetButtonDown("Vertical") && SimpleInput.GetAxis("Vertical") < 0)
            {
                collision.gameObject.GetComponent<Player>().animator.SetBool("isAssis", true);
                
                ////////////////////////////////////////
                //*** Déplacement horizontale stop ***//                             
                StaticClass.disableInput = true;

                //*** positionnnement du player assis sur le sprite de la chaise ***//
                //*** position de la chaise du doyen, x = -83 -- y = 145.5 ***//
                chair1 = GameObject.Find("Chair");
                chair2 = GameObject.Find("player-chair");

                Vector3 position = new Vector3(-83, 145, 0);

                position.x = chair1.transform.position.x;
                position.y = chair1.transform.position.y;
                position.z = chair1.transform.position.z;

                chair2.transform.position = position;
            }

            if (SimpleInput.GetButtonDown("Vertical") && SimpleInput.GetAxis("Vertical") > 0)
            {
                collision.gameObject.GetComponent<Player>().animator.SetBool("isAssis", false);
                StaticClass.disableInput = false;
            }
        }
    }

    // Methode qui se déclanche quand l'objet movable ne touche plus la hitbox d'un objet fixe
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraScript>().TxtAction.text = string.Empty;
        }
    }
   
}
