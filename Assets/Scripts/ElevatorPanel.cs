using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    public Elevator elevator;

    private void FixedUpdate()
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKey(i.ToString()))
            {
                elevator.SetDestination(i);
                break;
            }
        }
    }
}
