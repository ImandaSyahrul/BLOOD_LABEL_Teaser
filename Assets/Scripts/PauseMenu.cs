using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pausePanel;
    [SerializeField] EventSystem eventSystem;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        eventSystem.SetSelectedGameObject(GameObject.Find("ResumeButton"));
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        eventSystem.SetSelectedGameObject(null);
    }
}
