using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPath : MonoBehaviour
{
	//[SerializeField]
	bool isMove;
	Vector3 prePos;
	[SerializeField] 
	float period;
	float count = 0;
	public List<Vector3> path;
	// Use this for initialization
	void Start ()
	{
		prePos = transform.position;
		path = new List<Vector3> ();
	}
	
	void FixedUpdate ()
	{
		if (!isSamePos ()) {//diff
			isMove = true;
		} else {
			isMove = false;
		}
		prePos = transform.position;
	}
	
	void Update ()
	{
		if (isMove) {
			count += Time.deltaTime;
			if (count >= period) {
				path.Add (transform.position);
				count=0;
			}
		}else{
			count=0;
		}
	}
	
	bool isSamePos ()
	{
		return transform.position.x == prePos.x &&
			transform.position.z == prePos.z;
	}
}
