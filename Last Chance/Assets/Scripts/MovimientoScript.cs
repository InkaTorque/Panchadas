using UnityEngine;
using System.Collections;

public class MovimientoScript : MonoBehaviour {
	
	private float vel_x;
	private float vel_y;
	
	private bool moviendo_izq;
	private bool moviendo_der;

	private bool saltando;
	private bool doble_salto;
	
	// Use this for initialization
	void Start () 
	{
		vel_x = 0;
		vel_y = 0;
		
		moviendo_izq = false;
		moviendo_der = false;

		saltando = false;
		doble_salto = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		verificar_movimiento();
		verificar_salto();
		verificar_intermedio ();
		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
	
	private void verificar_movimiento()
	{
		if(Input.GetKeyDown("d"))
		{
			vel_x = 5;
			moviendo_der = true;
			moviendo_izq = false;
			(GetComponent<Animator>()).SetBool("isMove",true);
		}
		else if(Input.GetKeyDown("a"))
		{
			vel_x = -5;
			moviendo_izq = true;
			moviendo_der = false;
			(GetComponent<Animator>()).SetBool("isMove",true);
		}
		else if(Input.GetKey("d") && moviendo_der == true)
		{
			vel_x = 5;
			(GetComponent<Animator>()).SetBool("isMove",true);
		}
		else if(Input.GetKey("a") && moviendo_izq == true)
		{
			vel_x = -5;
			(GetComponent<Animator>()).SetBool("isMove",true);
		}
		else if(Input.GetKeyUp ("d"))
		{
			vel_x = 0;
			moviendo_der = false;
			moviendo_izq = true;
			(GetComponent<Animator>()).SetBool("isMove",false);
		}
		else if(Input.GetKeyUp ("a"))
		{
			vel_x = 0;
			moviendo_izq = false;
			moviendo_der = true;
			(GetComponent<Animator>()).SetBool("isMove",false);
		}
		
		rigidbody2D.velocity = new Vector2(vel_x,rigidbody2D.velocity.y);

		Debug.Log(rigidbody2D.velocity.x);
	}
	
	private void verificar_salto()
	{
		if (Input.GetKeyDown ("space") && (saltando == false || doble_salto == false)) {
			vel_y = 5;
			rigidbody2D.velocity = new Vector2 (vel_x, vel_y);

			if (saltando == false) {
					saltando = true;
			} else {
					doble_salto = true;
			}
			(GetComponent<Animator> ()).SetBool ("isJump", true);
		} else if(saltando==false && doble_salto==false)
		{
			(GetComponent<Animator> ()).SetBool ("isJump", false);
		}
	}
	private void verificar_intermedio(){
		if ((moviendo_izq == true && saltando == true) || (moviendo_izq == true && doble_salto == true)) {
				(GetComponent<Animator> ()).SetBool ("isJump", true);
		} else if ((moviendo_der == true && saltando == true) || (moviendo_der == true && doble_salto == true))
		{
				(GetComponent<Animator> ()).SetBool ("isJump", true);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag.Equals("Platform") == true)
		{
			saltando = false;
			doble_salto = false;
		}
	}
}
