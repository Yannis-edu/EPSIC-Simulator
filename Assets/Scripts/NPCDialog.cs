using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string npcName;
    public string[] answers;
    public bool randomMode;
    private CameraScript cam;
    private int currentDialog;

    /// <summary>
    /// Initialisation du script NPC
    /// </summary>
    private void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();
    }

    /// <summary>
    /// Methode de gestion des dialogues d'un PNJ
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.TxtAction.text = npcName;
            if (answers.Length != 0)
            {
                if (!StaticClass.disableInput && SimpleInput.GetButtonDown("Fire1"))
                {
                    GetComponentInParent<NPC>().talking = true;
                    cam.TxtDialog.transform.parent.gameObject.SetActive(true);
                    if (randomMode)
                    {
                        cam.TxtDialog.text = answers[Random.Range(0, answers.Length)];
                    }
                    else
                    {
                        cam.TxtDialog.text = answers[currentDialog++];// Passe au dialog suivant par incrémentation.
                    }
                    StaticClass.disableInput = true;// Bloque les mouvements du personnage
                }
                else if (StaticClass.disableInput && (SimpleInput.GetButtonDown("Fire1") || SimpleInput.GetButtonDown("Touch anywhere")))
                {
                    // A vérifier si le ++currentDialog ne saute pas
                    // le dialogue de position 0
                    if (++currentDialog < answers.Length && !randomMode)
                    {
                        cam.TxtDialog.text = answers[currentDialog];
                    }
                    else
                    {
                        cam.TxtDialog.transform.parent.gameObject.SetActive(false);
                        StaticClass.disableInput = false; // Réactive les input de mouvements.
                        currentDialog = 0; // Réinitialisation des dialogues en position 0.
                        GetComponentInParent<NPC>().talking = false;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Méthode permettant d'afficher le nom d'un PNJ
    /// s'il est à proximité.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraScript>().TxtAction.text = string.Empty;
            cam.TxtDialog.transform.parent.gameObject.SetActive(false);
            StaticClass.disableInput = false; // Réactive les input de mouvements.
            currentDialog = 0; // Réinitialisation des dialogues en position 0.
            GetComponentInParent<NPC>().talking = false;
        }
    }
}
