using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Play();
        }
    }

    public void Play()
    {
        StaticClass.disableInput = false;
        gameObject.SetActive(false);
    }

    public void Save()
    {
        
    }

    public void SaveAndQuit()
    {
        Save();
        SceneManager.LoadScene("menu");
        StaticClass.disableInput = false;
        PointsSystem.categories.Clear();
    }
}