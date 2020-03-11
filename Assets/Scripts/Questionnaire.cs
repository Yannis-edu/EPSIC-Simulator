using SimpleInputNamespace;
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
            if (!StaticClass.disableInput && SimpleInput.GetButtonDown("Fire1"))
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

                var answers = sqlite.getDataByString("answers", "fk_question", question.GetInt32(0).ToString());
                for (int i = 0; i < cam.answers.Length; i++)
                {
                    if (answers.Read())
                    {
                        cam.answers[i].GetComponentInChildren<Text>().text = i + 1 + ") " + answers.GetString(2);
                        cam.answers[i].GetComponentInChildren<Answer>().correct = answers.GetBoolean(3);
                    }
                }

                cam.TxtQuestion.transform.parent.gameObject.SetActive(true);
                StaticClass.disableInput = true;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (StaticClass.disableInput && SimpleInput.GetButtonDown("Answer " + (i + 1)))
                    {
                        if (cam.answers[i].GetComponentInChildren<Answer>().correct)
                        {
                            // True answer
                        }
                        else
                        {
                            // False answer
                        }
                        cam.answers[i].GetComponentInChildren<ButtonInputUI>().button.value = false;
                        cam.TxtQuestion.transform.parent.gameObject.SetActive(false);
                        cam.ImgQuestion.gameObject.SetActive(false);
                        StaticClass.disableInput = false;
                    }
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
