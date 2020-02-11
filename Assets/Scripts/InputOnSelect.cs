using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class InputOnSelect : MonoBehaviour
{
	public EventSystem eventSystem;
	public GameObject selectedObject;
	[DllImport("user32.dll")] static extern bool SetCursorPos(int X, int Y);

	private bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") !=0 && !isSelected)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			isSelected = true;
			SetCursorPos(0, 0);
			
		}
    }

	private void OnDisable()
	{
		isSelected = false;
	}
}
