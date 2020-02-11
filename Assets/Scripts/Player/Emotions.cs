using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotions : MonoBehaviour
{
    public GameObject emotion;
    [SerializeField] private Sprite[] sprites = new Sprite[7];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableContextClue()
    {
        emotion.GetComponent<SpriteRenderer>().sprite = sprites[1];
        emotion.SetActive(true);
    }

    public void EnableExclamation()
    {
        emotion.GetComponent<SpriteRenderer>().sprite = sprites[0];
        emotion.SetActive(true);
    }

    public void EnableLike()
    {
        emotion.GetComponent<SpriteRenderer>().sprite = sprites[2];
        emotion.SetActive(true);
    }

    public void EnableNoResponse()
    {
        emotion.GetComponent<SpriteRenderer>().sprite = sprites[3];
        emotion.SetActive(true);
    }

    public void EnableSad()
    {
        emotion.GetComponent<SpriteRenderer>().sprite = sprites[4];
        emotion.SetActive(true);
    }

    public void EnableIdea()
    {
        emotion.GetComponent<SpriteRenderer>().sprite = sprites[5];
        emotion.SetActive(true);
    }

    public void EnableAngry()
    {
        emotion.GetComponent<SpriteRenderer>().sprite = sprites[6];
        emotion.SetActive(true);
    }


    public void Disable()
    {
        emotion.SetActive(false);
    }
}
