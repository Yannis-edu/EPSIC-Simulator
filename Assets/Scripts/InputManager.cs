using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool disabled;
    public static List<string> buttons = new List<string>();
    public static List<string> buttonsDown = new List<string>();
    public static List<string> buttonsUp = new List<string>();
    public static Dictionary<string, float> axis = new Dictionary<string, float>();

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
        return !disabled && (Input.GetButton(buttonName) || buttons.Contains(buttonName)); ;
    }

    public static bool GetButtonDown(string buttonName)
    {
        return !disabled && (Input.GetButtonDown(buttonName) || buttonsDown.Contains(buttonName));
    }

    public static bool GetButtonUp(string buttonName)
    {
        return !disabled && (Input.GetButtonUp(buttonName) || buttonsUp.Contains(buttonName));
    }

    public static float GetAxis(string axisName)
    {
        if (disabled) return 0;
        if (axis.ContainsKey(axisName))
        {
            return axis[axisName];
        }
        return Input.GetAxis(axisName);
    }
}
