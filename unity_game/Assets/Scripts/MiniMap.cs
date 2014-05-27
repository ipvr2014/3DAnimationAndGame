using UnityEngine;
using System.Collections;
using System;
public class MiniMap : MonoBehaviour
{
	public bool isOpen{ get; set; }
	public GUIText guiText;
	public GameObject mapEle_base_prefab;
	public GameObject mapEle_wall_prefab;
	public GameObject mapEle_start_prefab;
	Renderer[] mapRenderers;
	public float size;
	double  countTime=0;
	
	
	// Use this for initialization
	void Start ()
	{
		isOpen = false;
		//size = new Vector2 ();
		InitializeMap (_mapData);
		mapRenderers = GetComponentsInChildren<Renderer> ();
	}
	
	void InitializeMap (int[,] mapData)
	{
		//size=new Vector2(mapW*eleSize,mapH*eleSize);
		int mapW = mapData.GetLength (1);
		int mapH = mapData.GetLength (0);
		float eleSize = size;
		float w = size * mapW;
		float h = size * mapH;
		for (int i=0; i<mapH; i++)
			for (int j=0; j<mapW; j++) {
				Vector3 elePos = new Vector3 ((-w / 2) + j * eleSize * 1.07f, 0, (-h / 2) + i * eleSize * 1.07f);
				createMapEle (mapEle_base_prefab, elePos, new Vector3 (eleSize, eleSize * 0.05f, eleSize));
			
				int type = mapData [i, j];
			
				switch (type) {
				case 0://wall
					elePos = new Vector3 ((-w / 2) + j * eleSize * 1.07f, eleSize * 1.07f / 2f, (-h / 2) + i * eleSize * 1.07f);
					createMapEle (mapEle_wall_prefab, elePos, new Vector3 (eleSize, eleSize, eleSize));
					break;
				case 1:
					break;
				case 9://start
					elePos = new Vector3 ((-w / 2) + j * eleSize * 1.07f, eleSize * 1.07f / 2f, (-h / 2) + i * eleSize * 1.07f);
					createMapEle (mapEle_start_prefab, elePos, new Vector3 (eleSize, eleSize, eleSize));
					break;
				case -1:
					break;
				}
			
				//mapEle.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
			}	
	}
	
	void createMapEle (GameObject prefab, Vector3 pos, Vector3 scale)
	{
		GameObject mapEle_base = GameObject.Instantiate (prefab) as GameObject;
		mapEle_base.transform.parent = this.transform;
		mapEle_base.transform.localPosition = pos;
		mapEle_base.transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (Renderer r in mapRenderers)
			r.enabled = isOpen;
		if(isOpen){
			countTime += Time.deltaTime;
		}
	}
	
	void OnGUI ()
	{
		if (isOpen) {
			showOpenTime();
		}else{
			guiText.text = "M : 開啟地圖";
		}
	}
	
	void showOpenTime ()
	{
		double  t=Math.Round(countTime,3);
		guiText.text = "已開啟地圖:" + t.ToString () + "秒";
		//testGUI.guiText.text = Random.Range(0,100).ToString();
	}
	
	int[,] _mapData = new int[,] {
		{0,0,0,0,0,0,0,0,0},
		{0,9,1,1,1,1,1,1,0},
		{0,0,0,0,0,0,0,1,0},
		{0,1,1,1,0,1,1,1,0},
		{0,1,0,0,0,1,0,0,0},
		{0,1,1,1,1,1,0,1,0},
		{0,1,0,0,0,0,0,1,0},
		{0,1,1,1,1,1,1,1,0},
		{0,0,0,0,0,0,0,0,0}
	};
	
	
}
