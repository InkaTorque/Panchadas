using UnityEngine;
using System.Collections;

public class Ataque : MonoBehaviour {
	public Transform BulletPrefab;
	//Vector3 posicion;
	// Use this for initialization
	void Start () {
		//posicion = GetComponent<Transform> ().localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("j"))
		{
			generarBala();
		}
	}
	public void generarBala()
	{
		//posicion.Set (posicion.x+32, posicion.y, posicion.z);
		//Instantiate (BulletPrefab, posicion, Quaternion.identity);
		Instantiate (BulletPrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
	}
}
