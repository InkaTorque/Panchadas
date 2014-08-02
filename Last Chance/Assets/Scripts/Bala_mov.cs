using UnityEngine;
using System.Collections;

public class Bala_mov : MonoBehaviour {
	private float vel_x;
	private float vel_y;
	// Use this for initialization
	void Start () {
		vel_x = 110;
		vel_y = 0;
		rigidbody2D.velocity = new Vector2(vel_x,vel_y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
