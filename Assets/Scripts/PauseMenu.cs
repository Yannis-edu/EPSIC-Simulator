using UnityEngine;

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

    public void SaveAndQuit()
    {
        
    }
}