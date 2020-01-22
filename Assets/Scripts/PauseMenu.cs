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
        InputManager.disabled = false;
        gameObject.SetActive(false);
    }

    public void Save()
    {
        
    }

    public void SaveAndQuit()
    {
        Save();
        SceneManager.LoadScene("Menu");
    }
}