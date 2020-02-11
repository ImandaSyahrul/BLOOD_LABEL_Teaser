using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBoundaries : MonoBehaviour
{
    public Vector2 maxPosition;
    public Vector2 minPosition;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TestScene"))
        {
            maxPosition = new Vector2(10.72f, 2.39f);
            minPosition = new Vector2(-3.27f, -3.03f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
