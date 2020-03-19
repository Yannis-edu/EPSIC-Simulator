using UnityEngine;

public class DoyenComputer : MonoBehaviour
{
    public string comName;
    public string categoryName;
    public float seuil;
    private CameraScript cam;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.TxtAction.text = comName;
            float points = PointsSystem.categories[categoryName].Points;
            float total = PointsSystem.categories[categoryName].Total;

            if (!StaticClass.disableInput && SimpleInput.GetButtonDown("Fire1"))
            {
                if (points >= total * seuil - 0.1)
                {
                    cam.TxtDialog.text = "Félicitation ! Vous avez changé vos notes à l'insu du doyen. Nouvelle moyenne : 6.0";
                }
                else
                {
                    cam.TxtDialog.text = "Vous devez avoir au minimum " + total * seuil + " points dans le domaine " + categoryName + " pour utiliser cettre compétence.";
                }
                cam.TxtDialog.transform.parent.gameObject.SetActive(true);
                StaticClass.disableInput = true;
            }
            else if (StaticClass.disableInput && (SimpleInput.GetButtonDown("Fire1") || SimpleInput.GetButtonDown("Touch anywhere")))
            {
                Camera.main.GetComponent<CameraScript>().TxtAction.text = string.Empty;
                cam.TxtDialog.transform.parent.gameObject.SetActive(false);
                StaticClass.disableInput = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraScript>().TxtAction.text = string.Empty;
            cam.TxtDialog.transform.parent.gameObject.SetActive(false);
            StaticClass.disableInput = false;
        }
    }
}
