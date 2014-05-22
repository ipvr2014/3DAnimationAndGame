#pragma strict

var Target:Transform;

function LateUpdate()
{
	transform.position = Vector3(0,transform.position.y,0);
	//transform.position = Vector3(transform.position.x,transform.position.y,transform.position.z);
}