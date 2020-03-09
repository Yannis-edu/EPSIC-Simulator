using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Questionnaire : MonoBehaviour
{
    public string questionnaireName;
    private CameraScript cam;
    
    private void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.TxtAction.text = questionnaireName;
            if (InputManager.GetButtonDown("Fire1"))
            {
                SqliteHelper sqlite = new SqliteHelper();
                var question = sqlite.getRandom("questions");
                question.Read();
                cam.TxtQuestion.text = question.GetString(1);

                if (question.GetString(4) != "")
                {
                    byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/images/" + question.GetString(4));
                    Texture2D imgTexture = new Texture2D(1, 1);
                    imgTexture.filterMode = FilterMode.Bilinear;
                    imgTexture.LoadImage(bytes);
                    Sprite sprite = Sprite.Create(imgTexture, new Rect(0, 0, imgTexture.width, imgTexture.height), new Vector2(0f, 0f), 1.0f);
                    cam.ImgQuestion.GetComponent<AspectRatioFitter>().aspectRatio = (float)imgTexture.width / imgTexture.height;
                    cam.ImgQuestion.sprite = sprite;
                    cam.ImgQuestion.gameObject.SetActive(true);
                }

                cam.TxtQuestion.transform.parent.gameObject.SetActive(true);
                InputManager.disabled = true;
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                cam.TxtQuestion.transform.parent.gameObject.SetActive(false);
                cam.ImgQuestion.gameObject.SetActive(false);
                InputManager.disabled = false;
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
