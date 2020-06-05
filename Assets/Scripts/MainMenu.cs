using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("epsic");
    }

    public void Delete()
    {
        /*if (EditorUtility.DisplayDialog("Suppression définitive", "Voulez-vous vraiment supprimer tout votre avancement ? ", "Oui", "Non"))
        {*/
            new SqliteHelper().factoryReset();
            PlayerPrefs.DeleteAll();
            StartCoroutine(GetComponent<DbUpgrade>().GetText());
        //}
    }
}
