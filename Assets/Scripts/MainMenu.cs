using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    //Buttons
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject creditButton;
    [SerializeField] GameObject yesButton;
    [SerializeField] GameObject noButton;
    private GameObject lastMenuButton;
    //Panels
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject quitPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject creditPanel;
    private GameObject activePanel;
#if UNITY_EDITOR
    [SerializeField] bool saveExist;
#endif
    // Start is called before the first frame update
    void Start()
    {
        lastMenuButton = null;
        activePanel = menuPanel;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        quitPanel.SetActive(false);
        creditPanel.SetActive(false);
#if UNITY_EDITOR
        if (saveExist) eventSystem.firstSelectedGameObject = continueButton;
        else
        {
            continueButton.SetActive(false);
            eventSystem.firstSelectedGameObject = startButton;
        }
#endif
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if (activePanel != menuPanel)
            {
                activePanel.SetActive(false);
                activePanel = menuPanel;
                menuPanel.SetActive(true);
                eventSystem.SetSelectedGameObject(lastMenuButton);
                
            }
            else Quit();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void Return()
    {
        activePanel.SetActive(false);
        menuPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(lastMenuButton);
    }

    public void Credit()
    {
        lastMenuButton = creditButton;
        activePanel = creditPanel;
        creditPanel.SetActive(true);
    }
   
    public void Quit()
    {
        lastMenuButton = quitButton;
        activePanel = quitPanel;
        quitPanel.SetActive(true);
        menuPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(noButton);
        
    }

    public void ConfirmQuit(bool confirm)
    {
        
        if (confirm)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
        else
        {
            menuPanel.SetActive(true);
            activePanel = menuPanel;
            quitPanel.SetActive(false);
            eventSystem.SetSelectedGameObject(quitButton);
        }
    }
}
