using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string npcName;
    protected CameraScript cam;
    protected UIManager dialogue;

    /// <summary>
    /// Initialisation du script NPC
    /// </summary>
    private void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();
        dialogue = Camera.main.GetComponent<UIManager>();
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
            if (!StaticClass.disableInput && SimpleInput.GetButtonDown("Fire1"))
            {
                StaticClass.disableInput = true;
                GetComponentInParent<NPC>().talking = true;
                BeforeFirstMessage();
                dialogue.Interact(GetComponent<VIDE_Assign>());
            }
            else if (StaticClass.disableInput && (SimpleInput.GetButtonDown("Fire1") || SimpleInput.GetButtonDown("Touch anywhere")))
            {
                if (!dialogue.playerContainer.activeSelf) //affiche le prochain dialogue au clic seulement si ce n'est pas une question
                {
                    dialogue.CallNext();
                }
                if (!dialogue.IsActive())
                {
                    StaticClass.disableInput = false;
                    GetComponentInParent<NPC>().talking = false;
                }

            }
        }
    }

    protected virtual void BeforeFirstMessage()
    {
        
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
            StaticClass.disableInput = false;
            GetComponentInParent<NPC>().talking = false;
        }
    }
}
