using UnityEngine;

public class MobileButton : MonoBehaviour
{
    public string buttonName;

    public virtual void Down()
    {
        InputManager.buttons.Add(buttonName);
        InputManager.buttonsDown.Add(buttonName);
    }

    private void Update()
    {
        if (InputManager.buttonsDown.Contains(buttonName))
        {
            InputManager.buttonsDown.Remove(buttonName);
        }
        if (InputManager.buttonsUp.Contains(buttonName))
        {
            InputManager.buttonsUp.Remove(buttonName);
        }
    }

    public virtual void Up()
    {
        InputManager.buttons.Remove(buttonName);
        InputManager.buttonsUp.Add(buttonName);
    }
}
