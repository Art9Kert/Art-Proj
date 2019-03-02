using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private Animator anim;
    private bool Press = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        anim.SetBool("Press", Press);
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            Press = false;
            if (gameObject.name == "ButtonRed")
            {
                Destroy(GameObject.Find("Weight"));
            }
        }
        if (col.transform.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("Quest1") == 1)
            {
                PlayerPrefs.SetInt("Quest1", 2);
            }
        }
    }
}
