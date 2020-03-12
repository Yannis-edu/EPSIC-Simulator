using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doyen : MonoBehaviour
{
    public string destinationName;
    private Text txtAction;

    // Start is called before the first frame update
    void Start()
    {
        txtAction = Camera.main.GetComponent<CameraScript>().TxtAction;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            txtAction.text = "ASSIS!!";
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
