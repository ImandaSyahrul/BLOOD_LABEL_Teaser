using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float[] 
		listMoveSpeed = { 1, 5, 4 }, //Move speed variation
		listRunning = { 1, 10, 9 }; //Running speed variation
	public float moveSpeed;
	public int status; //   0 define cut, 1 define base, 2 define mutated
	// public int stamina;
	
	private bool isRunning;
	public bool stopPlayer;
	
	private bool playerMoving;
	private bool lightActive;
	private Vector2 lastMove;

	[SerializeField] private Animator anim;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private GameObject flashLight;
	//[SerializeField] private GameObject torchLight;

	

	[SerializeField] private float maxStamina;
	[SerializeField] private float updatedStamina;
	[SerializeField] private float staminaIncrementPerSec;
    [SerializeField] private float staminaDecrementPerSec;

	public float UpdatedStamina
	{
		get
		{
			return updatedStamina;
		}
		set
		{
			updatedStamina = value;
		}
	}

	public bool Run
	{
		get => isRunning;
		set
		{
			// Change movement speed based on character status
			if (value == true) moveSpeed = listRunning[status];
			else moveSpeed = listMoveSpeed[status];
			isRunning = value;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		playerMoving = false;
        SetupStamina();
		lightActive = false;
		flashLight.SetActive(lightActive);
	}


    // Update is called once per frame
    void Update()
    {
		anim.SetInteger("Status", status);
		
		if (!stopPlayer)
		{
			Move();
			if (Input.GetKeyUp(KeyCode.F))
			{
				CheckFlashLight();
			}
		}
		else
		{
			playerMoving = false;
		}
		//Debug.Log(status + " " + playerMoving + " " + lastMove.x + " " + lastMove.y);
		Animate();
	}

	public int CharacterStatus
	{
		get => status;
		set => status = value;
	}

	public bool CharacterStop
	{
		get => stopPlayer;
		set
		{
			stopPlayer = value;
			if (value == true) anim.SetBool("PlayerMoving", value: false);
		}	
	}

	private void SetupStamina()
	{
		maxStamina = 100;
		updatedStamina = 100;
		staminaIncrementPerSec = 0.75f;
		staminaDecrementPerSec = 1f;
	}

	private void Move()
	{
		playerMoving = false;
		Run = Input.GetKey(KeyCode.LeftShift) ? true : false;

		if (updatedStamina < 0)
		{
			updatedStamina = 0;
			moveSpeed = listMoveSpeed[1];
		}

		if (updatedStamina > maxStamina) updatedStamina = maxStamina;


		if (status == 0) // Only for Prolog hospital scene
		{
			if (Input.GetAxisRaw("Vertical") < -0.5f)
			{
				rb.velocity = new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed, 0f);
				//transform.parent.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				playerMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}
			if (Input.GetAxisRaw("Vertical") > 0.5f)
			{
				Fungus.Flowchart.BroadcastFungusMessage("noUp");
				Debug.Log("Up button clicked");
			}
			if (Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				Fungus.Flowchart.BroadcastFungusMessage("noLeft");
				Debug.Log("Left button clicked");
			}
		}
		else // Normal condition
		{
			if (Input.GetAxisRaw("Horizontal")!=0)
			{
				flashLight.transform.localEulerAngles = new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * 90);
				rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, 0f);
				//transform.parent.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				playerMoving = true;
				lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

			}
			if (Input.GetAxisRaw("Vertical")!=0)
			{
				if (Input.GetAxisRaw("Vertical") > 0) flashLight.transform.localEulerAngles = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * 180);
				if (Input.GetAxisRaw("Vertical") < 0) flashLight.transform.localEulerAngles = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * 0);

				rb.velocity = new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed, 0f);
				//transform.parent.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				playerMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}
		}

		if (Run && playerMoving) updatedStamina -= staminaDecrementPerSec;
		else
		{
			if (!playerMoving) updatedStamina += staminaIncrementPerSec;
			else updatedStamina += (staminaIncrementPerSec / 4);
		}

		
	}

	void CheckFlashLight()
	{
		
		lightActive = !lightActive;
		flashLight.SetActive(lightActive);

	}

	void Animate()
	{
		anim.SetFloat("MoveX", lastMove.x);
		anim.SetFloat("MoveY", lastMove.y);
		anim.SetBool("FlashActive", lightActive);
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}

	public void Fall()
	{
		anim.SetBool("Death", true);
		transform.parent.Translate(new Vector3(0f, -0.1f, 0f));
	}

	public void ChangeMovable()
	{
		stopPlayer = !stopPlayer;
	}

	public void BackOff()
	{
		if(lastMove.y == 0)
		{
			if (lastMove.x > 0.5)
			{
				rb.velocity = new Vector3(-2 * moveSpeed, 0f, 0f);
				//anim.PlayInFixedTime("anisette_up");
			}

			if (lastMove.x < 0.5)
			{
				rb.velocity = new Vector3(2 * moveSpeed, 0f, 0f);
				//anim.PlayInFixedTime("anisette_down");
			}
		}
		else if (lastMove.x == 0)
		{
			if (lastMove.y > 0.5)
			{
				rb.velocity = new Vector3(0f, -2 * moveSpeed, 0f);
				lastMove.y = 1.0f;
				
			}

			if (lastMove.y < 0.5)
			{
				rb.velocity = new Vector3(0f, 2 * moveSpeed, 0f);
				lastMove.y = -1.0f;
				
			}
		}

	}

}
