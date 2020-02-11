using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if (Input.GetKeyUp(KeyCode.Space) && !other.isTrigger)
            {
                Fungus.Flowchart.BroadcastFungusMessage("flashlight_obtained");
                
            }
        }
        
    }

    public void PickUp()
    {
        gameObject.SetActive(false);
    }

}
