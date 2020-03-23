using UnityEngine;

public class Maccaud : NPCDialog
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.TxtAction.text = npcName;
            GameObject inHand = collision.gameObject.GetComponent<Player>().inHand;
            if (inHand != null)
            {
                FuckStick fuckStick = inHand.GetComponent<FuckStick>();
                if (fuckStick != null)
                {
                    fuckStick.transform.parent = gameObject.transform.parent;
                    fuckStick.transform.localPosition = Vector2.zero;
                    gameObject.transform.parent.GetComponent<Entity>().inHand = gameObject;
                    collision.gameObject.GetComponent<Player>().inHand = null;
                }
            }
            Message();
        }
    }
}
