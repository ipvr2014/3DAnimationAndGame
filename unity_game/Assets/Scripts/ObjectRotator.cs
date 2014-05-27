using UnityEngine;
using System.Collections;
 
public class ObjectRotator : MonoBehaviour
{
	private bool _isRotating = false;
 
	void Start ()
	{
	}
 
	void Update ()
	{
		
		if (Input.GetMouseButton (0)) {
			float speed = 10;
			float x = -Input.GetAxis ("Mouse X");
			float y = Input.GetAxis ("Mouse Y");
			Vector3 r=new Vector3(y * speed,x * speed,0);
			transform.Rotate(r,Space.World);
			//transform.RotateAround (transform.position, Vector3.up, x * speed);
			//transform.RotateAround (transform.position, Vector3.left, y * speed);
		//	transform.rotation *= Quaternion.AngleAxis (x * speed, Vector3.up);
		//	transform.rotation *= Quaternion.AngleAxis (y * speed, Vector3.right);
		}
	}
 

 
}