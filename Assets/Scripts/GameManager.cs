using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerController;
    [SerializeField] private GameObject pauseController;
    public bool onDialogue;


    private PauseMenu pauseMenu;
    public enum GameState
    {
        DEFAULT,      //Fall-back state, should never happen
        PAUSE,      //Pausing the game
        INVENTORY,       //Accessing inventory
        PLAYING,      //player is adventuring 
        FIRST_PLAY,      //player play this game for the first time
        GAMEOVER,       //Player's character is dead
        SAFEPLACE,     //Entering safe place
        SAVEPOINT,        //Accessing savepoint
        MENU,         //On main menu
        OPTIONS       //Adjusting game options
    };

    private GameState state;


    private void Singleton()
    {
        if (instance!= null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Awake is called first whenever an object in instantiated or not
    void Awake()
    {
        Singleton();
        pauseMenu = pauseController.GetComponent<PauseMenu>();
        onDialogue = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.PLAYING;
        
    }

    // Update is called once per frame
    void Update()
    {
      
        switch (state)
        {
            case GameState.PLAYING:
                Time.timeScale = 1;
                if (Input.GetKeyUp("escape"))
                {
                    Pause();
                }
                break;
            case GameState.PAUSE:
                Time.timeScale = 0;
                if (Input.GetKeyUp("escape"))
                {
                    Resume();
                }
                break;
        }
    }

    public void Pause()
    {
        state = GameState.PAUSE;
        if(playerController.CharacterStop == false) playerController.CharacterStop = true;
        pauseMenu.PauseGame();
    }

    public void Resume()
    {
        state = GameState.PLAYING;
        if(!onDialogue) playerController.CharacterStop = false;
        pauseMenu.ResumeGame();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void IsOnDialogue()
    {
        onDialogue = true;
    }

    public void IsNotOnDialogue()
    {
        onDialogue = false;
    }

}
