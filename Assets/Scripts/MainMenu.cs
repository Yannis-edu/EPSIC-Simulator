using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChooseSave(int i)
    {
        StaticClass.save = i;
        SceneManager.LoadScene("epsic");
    }
}
