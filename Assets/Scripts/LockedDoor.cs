using UnityEngine;

public class LockedDoor : MonoBehaviour
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

            if (!StaticClass.disableInput && SimpleInput.GetButtonDown("Vertical") && SimpleInput.GetAxis("Vertical") > 0)
            {
                if (points >= total * seuil - 0.1)
                {
                    gameObject.AddComponent<Door>();
                    GetComponent<Door>().destinationDoor = GameObject.Find(gameObject.name).GetComponent<Door>();
                    GetComponent<Door>().destinationName = comName;
                    GameObject.Find(gameObject.name).GetComponent<Door>().destinationDoor = GetComponent<Door>();
                    cam.customText.text = "Félicitation ! Vous avez débloqué la porte";
                    cam.customText.transform.parent.gameObject.SetActive(true);
                }
                else
                {
                    cam.customText.text = "Vous devez avoir au minimum " + total * seuil + " points dans le domaine " + categoryName + " pour utiliser cettre compétence.";
                    cam.customText.transform.parent.gameObject.SetActive(true);
                }
                StaticClass.disableInput = true;
            }
            else if (StaticClass.disableInput && SimpleInput.GetButtonDown("Vertical") && SimpleInput.GetAxis("Vertical") > 0 || SimpleInput.GetButtonDown("Touch anywhere"))
            {
                cam.customText.text = string.Empty;
                cam.customText.transform.parent.gameObject.SetActive(false);
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
