using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class MapGeneralization : MonoBehaviour {

	private const int M_SIZE = 11;
	enum Dir {UP=0, DOWN=1, LEFT=2, RIGHT=3, NONE=4};
	private const int CANDIDATE_ROAD = 5; // 可以開通的NODE
	private const int ROAD = 7; // 已經開通的NODE
	private const int WALL = 6; // 牆 (不可以走的NODE)
	private const int DEADEND = 8; // 死路
	
	int[,] maze = new int[M_SIZE, M_SIZE];
	Vector2 StartPos = new Vector2(2, 2);
	
	// Initialization
	void IniMaze()
	{
		for(int i=0; i<M_SIZE; i++)
		{
			for(int j=0; j<M_SIZE; j++)
			{
				// in the maze
				if(i>=2 && i<=M_SIZE-3 && j>=2 && j<=M_SIZE-3)
				{
					if(i%2==0 && j%2==0)
					{
						// 標記出可以開通的NODE
						maze[i,j] = CANDIDATE_ROAD;
					}
					else
						maze[i,j] = WALL;
				}
				else
				{
					// wall
					maze[i,j] = WALL;
				}
			}
		}
	}
	
	// Ouput
	void OutputMaze()
	{
		FileStream fs = new FileStream("C:\\Users\\annie\\Documents\\GitHub\\3DAnimationAndGame\\unity_game\\RandomMaze.txt", FileMode.Create);
		StreamWriter sw = new StreamWriter(fs);
		
		for(int i=1; i<M_SIZE-1; i++)
		{
			for(int j=1; j<M_SIZE-1; j++)
			{
				maze[i,j] = maze[i,j] - 6;
				
				// 若為起點，則標記為9
				if(i==(int)StartPos.x && j==(int)StartPos.y)
				{
					sw.Write("9" + " ");
				}
				// 避免每一列的尾端有空白字元
				else if(j != M_SIZE-2)
					sw.Write(maze[i,j].ToString() + " ");
				else
					sw.Write(maze[i,j].ToString());
			}
			//避免最後多了一個換行符號
			if(i != M_SIZE-2)
				sw.Write('\n');
		}
		
		sw.Flush();
		sw.Close();
		fs.Close();
		
	}
	
	int FindNextNode(int x, int y)
	{
		bool[] direction = new bool[4];
		bool isDeadRoad = true;
		
		Random.seed = System.Guid.NewGuid().GetHashCode();
		int index = Random.Range(0, 4);
	
		for(int i=0; i<4; i++)
		{
			direction[i] = false;
		}
	
		// up, down, left, right
		if(maze[x-2, y] == CANDIDATE_ROAD)
		{
			direction[(int)Dir.UP] = true;
			isDeadRoad = false;
		}
		if(maze[x+2, y] == CANDIDATE_ROAD)
		{
			direction[(int)Dir.DOWN] = true;
			isDeadRoad = false;
		}
		if(maze[x, y-2] == CANDIDATE_ROAD)
		{
			direction[(int)Dir.LEFT] = true;
			isDeadRoad = false;
		}
		if(maze[x, y+2] == CANDIDATE_ROAD)
		{
			direction[(int)Dir.RIGHT] = true;
			isDeadRoad = false;
		}
	
		
		if(isDeadRoad)
		{
			//maze[x][y] = DEADEND;
			return (int)Dir.NONE;
		}
	
		
		while(true)
		{
			if(direction[index] == true)
				return index;
			
			index = Random.Range(0, 4);
		}
	}
	
	void Traversal(int x, int y)
	{
		int nextNode = -1;
	
		// visited
		maze[x,y] = ROAD;
	
		nextNode = FindNextNode(x,y);
	
		// 當不是死路
		while(nextNode != (int)Dir.NONE)
		{
			switch(nextNode)
			{
			case (int)Dir.UP:
				maze[x-1, y] = ROAD;
				Traversal(x-2, y);
				break;
	
			case (int)Dir.DOWN:
				maze[x+1, y] = ROAD;
				Traversal(x+2, y);
				break;
	
			case (int)Dir.LEFT:
				maze[x, y-1] = ROAD;
				Traversal(x, y-2);
				break;
	
			case (int)Dir.RIGHT:
				maze[x, y+1] = ROAD;
				Traversal(x, y+2);
				break;
	
			default:
				break;
			}
			nextNode = FindNextNode(x,y);
		}
	
	}
	
	
	
	
	// Use this for initialization
	void Start ()
	{
		IniMaze();
		Traversal((int)StartPos.x, (int)StartPos.y);
		OutputMaze();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
