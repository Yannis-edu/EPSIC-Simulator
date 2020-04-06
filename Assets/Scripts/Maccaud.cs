using UnityEngine;

public class Maccaud : NPCDialog
{
    protected override void BeforeFirstMessage(Collider2D collision)
    {
        GameObject inHand = collision.gameObject.GetComponent<Player>().inHand;
        if (inHand != null)
        {
            FuckStick fuckStick = inHand.GetComponent<FuckStick>();
            if (fuckStick != null)
            {
                GetComponent<VIDE_Assign>().overrideStartNode = 6;
                return;
            }
        }

        GetComponent<VIDE_Assign>().overrideStartNode = Random.Range(0, 5);
    }

    public void GetFuckStick()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GameObject inHand = player.inHand;
        if (inHand != null)
        {
            FuckStick fuckStick = inHand.GetComponent<FuckStick>();
            if (fuckStick != null)
            {
                fuckStick.transform.parent = gameObject.transform.parent;
                fuckStick.transform.localPosition = Vector2.zero;
                gameObject.transform.parent.GetComponent<Entity>().inHand = gameObject;
                player.inHand = null;
            }
        }
    }
}
