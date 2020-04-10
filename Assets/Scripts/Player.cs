using System;
using UnityEngine;

public class Player : Entity
{
    public GameObject pointsScreen;

    private void FixedUpdate()
    {
        pointsScreen.SetActive(!StaticClass.disableInput && SimpleInput.GetButton("Points Screen"));
        if (StaticClass.disableInput)
        {
            Move(0, false, false);
            
        }
        else
        {
            vertical = SimpleInput.GetAxis("Vertical");
            Move(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetButton("Jump"), SimpleInput.GetButton("Run"));
            
        }
    }
}
