using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    private Animator anim;
    private bool OnOff = true;
    private bool inArea;
    public GameObject block;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
		anim.SetBool("OnOff", OnOff);
		if (Input.GetKeyDown(KeyCode.E))
            {
                if (inArea == true)
                {
                    OnOff = !OnOff;
                    block.SetActive(!block.activeSelf);
                }
            }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
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
