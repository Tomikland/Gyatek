using UnityEngine;
using System.Collections;
using System;



[System.Serializable]
public class Tile {
	public int TileX;
	public int TileY;
	public GameObject TileGO;
	public string teststring = "nemjo";
	public GameObject MyTileCity;

	[NonSerialized]
	public Tile[] neighbours = new Tile[6];




	public Tile (int x, int y,GameObject tGO){
		TileX = x;
		TileY = y;
		TileGO = tGO;

	}

	public Tile (Tile nN,Tile nNE,Tile nSE,Tile nS,Tile nSW,Tile nNW){   //óra járása szerint
		neighbours[0] =nN;
		neighbours[1] =nNE;
		neighbours[2] =nSE;
		neighbours[3] =nS;
		neighbours[4] =nSW;
		neighbours[5] =nNW;
	}
}
