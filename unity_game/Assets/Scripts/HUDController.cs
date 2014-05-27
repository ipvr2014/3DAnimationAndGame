using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour
{
	public MiniMap map;
	public CharacterMotor cMotor;
	public MouseLook mLook;
	// Use this for initialization
	void Start ()
	{
		map = GetComponentInChildren<MiniMap> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.M)) {
			map.isOpen = !map.isOpen;
			cMotor.canControl = !map.isOpen;
			mLook.canControl= !map.isOpen;
		}
		
	}
}
