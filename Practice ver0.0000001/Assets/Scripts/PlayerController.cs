using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigid;
    public float speed;
    public GameObject Help;
    public static int Gold;
    public static bool LockMovement;
    public Text GoldText;
    public float distance;
    void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rigid.velocity = movement * speed;
        GoldText.text = Gold + " Gold";
        if (LockMovement == true)
        {
            speed = 0;
        }
        else
        {
            speed = 10;
        }
    }
    public void Destroy()
    {
        Help.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.GetComponent<InstantiateDialog>())
        {
            if (distance != 0 && Input.GetKeyDown(KeyCode.E))
            {
                col.GetComponent<InstantiateDialog>().ShowDialogue = true;
                LockMovement = true;
                col.GetComponent<InstantiateDialog>().UpdateAnswers();
            }
        }
        distance = (col.transform.position.x - transform.position.x);
        //Debug.Log(distance);
    }

}
