using UnityEngine;
using UnityEngine.UI;

public class ChairDoyen : MonoBehaviour
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
            if (SimpleInput.GetButtonDown("Vertical") && SimpleInput.GetAxis("Vertical") < 0)
            {
                collision.gameObject.GetComponent<Player>().animator.SetBool("isAssis", true);
                //*** Arrete de mouvement horizontaux ***//
                StaticClass.disableInput = true;

                //*** positionnnement du player assis sur le sprite de la chaise ***//
                collision.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                collision.gameObject.transform.position = transform.position;
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
