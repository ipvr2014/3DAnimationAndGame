
import System.IO;

var test_prefab1 : GameObject;
var start_prefab : GameObject;
var terrain : GameObject;

var wall_side_length : float = 2;

function Start ()
{
	//***** 取得 terrain 的長跟寬 *****//
	terrain = GameObject.Find("Plane");
	//Debug.Log(terrain.name);
	var size_x : float = terrain.collider.bounds.size.x;
	var scale_x : float = terrain.transform.localScale.x;
	
	var size_z : float = terrain.collider.bounds.size.z;
	var scale_z : float = terrain.transform.localScale.z;
	
	var MapWidth : float = size_x * scale_x;
	var MapHeight : float = size_z * scale_z;
	
	
	//***** 取得 wall 的長跟寬 *****//
	// ????
	
	//***** 迷宮初始產生的位置 *****//
	
    //theSourceFile = System.IO.FileInfo("Data.txt");
    transform.position.x = 0/*wall_side_length/2*/ ;
	transform.position.y = 1;
	transform.position.z = 0/*MapHeight - wall_side_length/2*/;
	
	var theSourceFile : StreamReader = new System.IO.StreamReader("RandomMaze.txt");
	//Debug.Log(theSourceFile.CurrentEncoding);
	var line : String;
	
	while (!theSourceFile.EndOfStream)
	{
		line = theSourceFile.ReadLine();
		var split : String[] = line.Split(" "[0]);
	
		for(var s in split)
		{
			var str2int : int = parseInt(s);
			transform.position.x += wall_side_length ;
			
			// WALL
			if(str2int == 0)
			{
		  		//print("x");
		  		var CubeClone1: GameObject = Instantiate(test_prefab1,transform.position,transform.rotation);
			}
			// ROAD
			else if(str2int == 1)
			{
		  		//print("o");
			}
			// Start Position
			else if(str2int == 9)
			{
				var StartPoint : GameObject = Instantiate(start_prefab, transform.position, transform.rotation);
			}
		}
		Debug.Log(line);
		//nextline
		transform.position.z -= wall_side_length;
		transform.position.x = wall_side_length/2 ;//reset xx
	}
}