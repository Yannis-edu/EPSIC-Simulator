using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    public Elevator elevator;

    private void FixedUpdate()
    {
        for (int i = 5; i <= 9; i++)
        {
            if (Input.GetKey(i.ToString()))
            {
                elevator.SetDestination(i);
                break;
            }
        }
    }
}
