using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDummy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * 0.25f, 0f, 0f);
        }

    }
}
