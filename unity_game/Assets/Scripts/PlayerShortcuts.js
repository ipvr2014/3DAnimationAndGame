#pragma strict

static var isMenuOpen : boolean = false;
var windowRect : Rect;

var textGUI : GameObject;
var countTime : float;

var miniMapCamera : GameObject;

var guiTextTure : GUITexture;

var home : Texture;
var wall : Texture;
var road : Texture;
var mapArray : int[];
var graphSize_W = 15;
var graphSize_H = 15;
function Start () {
	windowRect = Rect(Screen.width/8, Screen.height/8, Screen.width/4*3, Screen.height/4*3);
	textGUI = GameObject.Find("textGUI");
	textGUI.guiText.text = "M : 開啟地圖";
	countTime=0;
	
	miniMapCamera = GameObject.Find("miniMapCamera");
	miniMapCamera.camera.active=true;
	
	mapArray = new Array(
0,0,0,0,0,0,0,0,0,
0,9,1,1,1,1,1,1,0,
0,0,0,0,0,0,0,1,0,
0,1,1,1,0,1,1,1,0,
0,1,0,0,0,1,0,0,0,
0,1,1,1,1,1,0,1,0,
0,1,0,0,0,0,0,1,0,
0,1,1,1,1,1,1,1,0,
0,0,0,0,0,0,0,0,0);

	

}
function Update () {
	if(Input.GetKeyDown(KeyCode.M))
		isMenuOpen = !isMenuOpen;
}
function OnGUI(){
	if(isMenuOpen)
	{
		
		
		miniMapCamera.camera.active=true;
		showOpenTime();
		//if(Event.current.type.Equals(EventType.Repaint))
		var x=100;
		var y=100;
		var count=1;
		for(var arrayIndex=0;arrayIndex < mapArray.Length;arrayIndex++)
		{
		

			if(mapArray[arrayIndex]==9)
			{
				Graphics.DrawTexture(Rect(x, y, graphSize_W, graphSize_H), home);
			}
			else if(mapArray[arrayIndex]==0)
			{
				Graphics.DrawTexture(Rect(x, y, graphSize_W, graphSize_H), road);
			}
			else if(mapArray[arrayIndex]==1)
			{
				Graphics.DrawTexture(Rect(x, y, graphSize_W, graphSize_H), wall);
			}
			
			x+=15;
			count++;
			if(count==10)
			{
				x=100;
				y+=15;
				count=1;
			}
			
		
		}
		
			
	}
	else
	{
		miniMapCamera.camera.active=false;
		textGUI.guiText.text = "M : 開啟地圖";
		
		guiTextTure.active=false;
	}
		
}
function menuWindow(windowNum : int){} 

function showOpenTime()
{
	countTime+=Time.deltaTime;
	textGUI.guiText.text = "已開啟地圖:"+countTime.ToString()+"秒";
	//testGUI.guiText.text = Random.Range(0,100).ToString();
}


