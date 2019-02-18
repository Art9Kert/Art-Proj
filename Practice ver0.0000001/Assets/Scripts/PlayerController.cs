using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rigid;
	public float speed;
	public GameObject Help;
	void Start () {
		
	}
	
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal");

		Vector3 movement = new Vector3(moveHorizontal, 0f,0f);
		rigid.velocity = movement * speed;
	}
	public void Destroy(){
		Help.SetActive(false);
	}

}
