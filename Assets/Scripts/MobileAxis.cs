using UnityEngine;

public class MobileAxis : MobileButton
{
    public int position;

    private void Start()
    {
        if (!InputManager.axis.ContainsKey(buttonName))
        {
            InputManager.axis.Add(buttonName, 0);
        }
    }

    public override void Down()
    {
        base.Down();
        InputManager.axis[buttonName] = position;
    }

    public override void Up()
    {
        base.Up();
        InputManager.axis[buttonName] = 0;
    }
}
