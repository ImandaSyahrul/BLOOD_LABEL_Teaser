using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementNotification : MonoBehaviour
{
    public string sceneToLoad;
    public GameManager gameManager;
    private int satisfiedCounter, unsatisfiedCounter;
    public CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        satisfiedCounter = 0;
        unsatisfiedCounter = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if(gameObject.name == "FlashlightNotification")
            {
                if (other.gameObject.GetComponentInChildren<Light>())
                {
                    
                    if (satisfiedCounter == 0)
                    {
                        Fungus.Flowchart.BroadcastFungusMessage("FlashLightEquipped");
                        satisfiedCounter++;
                        
                    }

                }
                else
                {
                    GameObject.Find("FlashlightLocNotification").SetActive(true);
                    if (unsatisfiedCounter == 0)
                    {
                        Fungus.Flowchart.BroadcastFungusMessage("FlashLightNotEquipped1");
                        unsatisfiedCounter++;
                    }
                    else Fungus.Flowchart.BroadcastFungusMessage("FlashLightNotEquipped");
                }
                
            }
            if(gameObject.name == "FlashlightLocNotification")
            {
                if (unsatisfiedCounter == 0)
                {
                    Fungus.Flowchart.BroadcastFungusMessage("there_it_is");
                    unsatisfiedCounter++;
                }
                
            }
        }
    }

    public void HighlightObject()
    {
        cameraController.SetFollowTarget(GameObject.Find("FlashlightView"));
    }

    public void Inactive()
    {
        gameObject.SetActive(false);
    }

}
