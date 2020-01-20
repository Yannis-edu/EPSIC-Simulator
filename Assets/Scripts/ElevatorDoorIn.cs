using UnityEngine;

public class ElevatorDoorIn : MonoBehaviour
{
    public ElevatorDoor elevatorDoor;

    private void FixedUpdate()
    {
        float destinationY = transform.position.y;
        destinationY += elevatorDoor.open ? elevatorDoor.height : 0;
        elevatorDoor.sprite.transform.position = new Vector2(elevatorDoor.sprite.transform.position.x, Mathf.MoveTowards(elevatorDoor.sprite.transform.position.y, destinationY, elevatorDoor.speed * Time.fixedDeltaTime));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && InputManager.GetButton("Fire1") && elevatorDoor.level == elevatorDoor.elevator.currentLevel && elevatorDoor.elevator.currentLevel == elevatorDoor.elevator.destinationLevel)
        {
            elevatorDoor.open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            elevatorDoor.open = false;
        }
    }
}
