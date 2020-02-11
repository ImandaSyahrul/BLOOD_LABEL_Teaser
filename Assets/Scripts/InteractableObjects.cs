using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObjects : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            other.gameObject.GetComponent<Emotions>().EnableContextClue();
   
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            other.gameObject.GetComponent<Emotions>().Disable();

        }
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("Environment"))
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Debug.Log("Interact with car");
                    Fungus.Flowchart.BroadcastFungusMessage("checkcar");
                }
                
            }
        }
        if (gameObject.CompareTag("Item"))
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Fungus.Flowchart.BroadcastFungusMessage("FlashLightObtained");
                }

            }
        }
    }

}
