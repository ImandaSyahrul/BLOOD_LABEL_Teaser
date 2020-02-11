using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	// Start is called before the first frame update
	// GameObject player;
	// Use SerializeField to make it possible to assign private variables using inspector intead of finding game object in start method
	[SerializeField] PlayerController playerController;
    [SerializeField] private Slider staminaBar;
    void Start()
	{

    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null) staminaBar.value = playerController.UpdatedStamina;
        else Debug.Log("NULL");
    }
}
