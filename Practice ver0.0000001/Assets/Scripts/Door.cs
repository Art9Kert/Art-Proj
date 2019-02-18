using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator anim;
    private bool OpenClose = true;
    private bool inArea;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("OpenClose", OpenClose);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(1);
            if (inArea == true)
            {
                OpenClose = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Craft");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            inArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            inArea = false;
        }
    }
}
