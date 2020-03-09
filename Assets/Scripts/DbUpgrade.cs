using Leguar.TotalJSON;
using System.Collections;
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
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/epsic-simulator/upgrade.php");
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
                        question.GetString("image_path"),
                        question.GetString("date_insert")
                    });
                }

                string url = "http://localhost/epsic-simulator/images_QR/images_questions/" + question.GetString("image_path");
                using (UnityWebRequest www2 = UnityWebRequest.Get(url))
                {
                    yield return www2.SendWebRequest();
                    if (www2.isNetworkError || www2.isHttpError)
                    {
                        Debug.Log(www2.error);
                    }
                    else
                    {
                        string savePath = string.Format("{0}/{1}", Application.persistentDataPath + "/images_QR/images_questions/", question.GetString("image_path"));
                        System.IO.File.WriteAllBytes(savePath, www2.downloadHandler.data);
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
                        answer.GetString("answer"),
                        answer.GetString("image_path"),
                        answer.GetString("source_answer"),
                        answer.GetString("points"),
                        answer.GetString("date_insert")
                    });
                }
            }

            var questions_answers = o.GetJArray("questions_answers");
            for (int i = 0; i < questions_answers.Length; i++)
            {
                var question_answer = JSON.ParseString(questions_answers[i].CreateString());
                if (sqlite.count("questions_answers", "id", question_answer.GetString("id")) == 0)
                {
                    sqlite.insert("questions_answers", new string[] {
                        question_answer.GetString("id"),
                        question_answer.GetString("fk_question"),
                        question_answer.GetString("fk_answer"),
                        question_answer.GetString("date_insert")
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
                        category.GetString("category_folder"),
                        category.GetString("category_name"),
                        category.GetString("date_insert")
                    });
                }
            }

            var questions_categories = o.GetJArray("questions_categories");
            for (int i = 0; i < questions_categories.Length; i++)
            {
                var question_category = JSON.ParseString(questions_categories[i].CreateString());
                if (sqlite.count("questions_categories", "id", question_category.GetString("id")) == 0)
                {
                    sqlite.insert("questions_categories", new string[] {
                        question_category.GetString("id"),
                        question_category.GetString("fk_question"),
                        question_category.GetString("fk_category"),
                        question_category.GetString("date_insert")
                    });
                }
            }

            var sub_categories = o.GetJArray("sub_categories");
            for (int i = 0; i < sub_categories.Length; i++)
            {
                var sub_category = JSON.ParseString(sub_categories[i].CreateString());
                if (sqlite.count("sub_categories", "id", sub_category.GetString("id")) == 0)
                {
                    sqlite.insert("sub_categories", new string[] {
                        sub_category.GetString("id"),
                        sub_category.GetString("sub_category_name"),
                        sub_category.GetString("date_insert")
                    });
                }
            }

            var questions_sub_categories = o.GetJArray("questions_sub_categories");
            for (int i = 0; i < questions_sub_categories.Length; i++)
            {
                var question_sub_category = JSON.ParseString(questions_sub_categories[i].CreateString());
                if (sqlite.count("questions_sub_categories", "id", question_sub_category.GetString("id")) == 0)
                {
                    sqlite.insert("questions_sub_categories", new string[] {
                        question_sub_category.GetString("id"),
                        question_sub_category.GetString("fk_question"),
                        question_sub_category.GetString("fk_sub_category"),
                        question_sub_category.GetString("date_insert")
                    });
                }
            }

            sqlite.close();
        }
    }
}
