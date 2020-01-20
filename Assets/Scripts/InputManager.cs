using UnityEngine;

public static class InputManager
{
    public static bool disabled;

    public static bool GetKey(string keyName)
    {
        return !disabled && Input.GetKey(keyName);
    }

    public static bool GetKeyDown(string keyName)
    {
        return !disabled && Input.GetKeyDown(keyName);
    }

    public static bool GetKeyUp(string keyName)
    {
        return !disabled && Input.GetKeyUp(keyName);
    }

    public static bool GetButton(string buttonName)
    {
        return !disabled && Input.GetButton(buttonName);
    }

    public static bool GetButtonDown(string buttonName)
    {
        return !disabled && Input.GetButtonDown(buttonName);
    }

    public static bool GetButtonUp(string buttonName)
    {
        return !disabled && Input.GetButtonUp(buttonName);
    }

    public static float GetAxis(string axisName)
    {
        if (disabled) return 0;
        return Input.GetAxis(axisName);
    }
}
