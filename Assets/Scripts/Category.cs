using UnityEngine;
using UnityEngine.UI;

public class Category : MonoBehaviour
{
    public string CategoryName;
    public float Total;
    private float points;
    public float Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            GetComponentInChildren<Text>().text = CategoryName + " (" + points + " / " + Total + ")";
            GetComponentInChildren<Slider>().value = points / Total;
            PlayerPrefs.SetFloat("pts_" + CategoryName, points);
        }
    }

    private void Start()
    {
        SqliteHelper sqlite = new SqliteHelper();
        var category = sqlite.getDataByString("categories", "category", CategoryName);
        category.Read();
        Total = sqlite.sum("questions", "points", "fk_category", category.GetInt32(0).ToString());
        Points = PlayerPrefs.GetFloat("pts_" + CategoryName, 0);
        PointsSystem.categories.Add(CategoryName, this);
    }

    public void Delete()
    {
        PlayerPrefs.DeleteKey("pts_" + CategoryName);
    }
}
