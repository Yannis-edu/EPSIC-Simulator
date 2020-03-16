using SimpleInputNamespace;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Questionnaire : MonoBehaviour
{
    public string questionnaireName;
    public string categoryName;
    private int categoryID, questionID;
    private float points;
    private CameraScript cam;
    
    private void Start()
    {
        cam = Camera.main.GetComponent<CameraScript>();
        SqliteHelper sqlite = new SqliteHelper();
        var category = sqlite.getDataByString("categories", "category", categoryName);
        category.Read();
        categoryID = category.GetInt32(0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.TxtAction.text = questionnaireName;
            if (!StaticClass.disableInput && SimpleInput.GetButtonDown("Fire1"))
            {
                SqliteHelper sqlite = new SqliteHelper();
                var question = sqlite.getRandomQuestion(categoryID.ToString());
                if (question.Read())
                {
                    cam.TxtQuestion.text = question.GetString(1);
                    points = question.GetFloat(2);
                    questionID = question.GetInt32(0);

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
                            cam.answers[i].GetComponentInChildren<Button>().interactable = true;
                            cam.answers[i].GetComponentInChildren<Text>().text = i + 1 + ") " + answers.GetString(2);
                            cam.answers[i].GetComponentInChildren<Answer>().correct = answers.GetBoolean(3);
                        }
                        else
                        {
                            cam.answers[i].GetComponentInChildren<Button>().interactable = false;
                            cam.answers[i].GetComponentInChildren<Text>().text = "";
                            cam.answers[i].GetComponentInChildren<Answer>().correct = false;
                        }
                    }

                    cam.TxtQuestion.transform.parent.gameObject.SetActive(true);
                    StaticClass.disableInput = true;
                }
                else
                {
                    
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (StaticClass.disableInput && SimpleInput.GetButtonDown("Answer " + (i + 1)))
                    {
                        if (cam.answers[i].GetComponentInChildren<Button>().interactable)
                        {
                            if (cam.answers[i].GetComponentInChildren<Answer>().correct)
                            {
                                PointsSystem.categories[categoryName].Points += points;
                                SqliteHelper sqlite = new SqliteHelper();
                                sqlite.validateQuestion(questionID);
                            }
                            else
                            {

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraScript>().TxtAction.text = string.Empty;
        }
    }
}
