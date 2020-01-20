using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string npcName;
    public string[] answers;
    public bool randomMode;
    private CameraScript cam;
    private int currentDialog;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.TxtAction.text = npcName;
            if (InputManager.GetButtonDown("Fire1"))
            {
                cam.TxtDialog.transform.parent.gameObject.SetActive(true);
                if (randomMode)
                {
                    cam.TxtDialog.text = answers[Random.Range(0, answers.Length - 1)];
                }
                else
                {
                    cam.TxtDialog.text = answers[currentDialog++];
                }
                InputManager.disabled = true;
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                if (++currentDialog < answers.Length && !randomMode)
                {
                    cam.TxtDialog.text = answers[currentDialog];
                }
                else
                {
                    cam.TxtDialog.transform.parent.gameObject.SetActive(false);
                    InputManager.disabled = false;
                    currentDialog = 0;
                }
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
