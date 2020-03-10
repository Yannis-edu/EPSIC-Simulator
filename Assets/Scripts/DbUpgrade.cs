using Leguar.TotalJSON;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DbUpgrade : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.137.1/epsic-simulator/upgrade.php");
        yield return www.SendWebRequest();

        if (!www.isNetworkError)
        {
            SqliteHelper sqlite = new SqliteHelper();
            sqlite.createDatabase();
            JSON o = JSON.ParseString(www.downloadHandler.text);

            var questions = o.GetJArray("questions");
            for (int i = 0; i < questions.Length; i++)
            {
                var question = JSON.ParseString(questions[i].CreateString());
                if (sqlite.count("questions", "id", question.GetString("id")) == 0)
                {
                    sqlite.insert("questions", new string[] {
                        question.GetString("id"),
                        question.GetString("question"),
                        question.GetString("points"),
                        question.GetString("fk_category"),
                        question.GetString("picture")
                    });
                }

                string pictureName = question.GetString("picture");
                if (pictureName != null)
                {
                    string url = "http://192.168.137.1/epsic-simulator/images/" + pictureName;
                    using (UnityWebRequest www2 = UnityWebRequest.Get(url))
                    {
                        yield return www2.SendWebRequest();
                        if (www2.isNetworkError || www2.isHttpError)
                        {
                            Debug.Log(www2.error);
                        }
                        else
                        {
                            Directory.CreateDirectory(Application.persistentDataPath + "/images");
                            File.WriteAllBytes(Application.persistentDataPath + "/images/" + pictureName, www2.downloadHandler.data);
                        }
                    }
                }
            }

            var answers = o.GetJArray("answers");
            for (int i = 0; i < answers.Length; i++)
            {
                var answer = JSON.ParseString(answers[i].CreateString());
                if (sqlite.count("answers", "id", answer.GetString("id")) == 0)
                {
                    sqlite.insert("answers", new string[] {
                        answer.GetString("id"),
                        answer.GetString("fk_question"),
                        answer.GetString("answer"),
                        answer.GetString("correct")
                    });
                }
            }

            var categories = o.GetJArray("categories");
            for (int i = 0; i < categories.Length; i++)
            {
                var category = JSON.ParseString(categories[i].CreateString());
                if (sqlite.count("categories", "id", category.GetString("id")) == 0)
                {
                    sqlite.insert("categories", new string[] {
                        category.GetString("id"),
                        category.GetString("category"),
                        category.GetString("fk_parent")
                    });
                }
            }

            sqlite.close();
        }
    }
}
