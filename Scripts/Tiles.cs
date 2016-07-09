using UnityEngine;
using System.Collections;

public class Tiles : MonoBehaviour {

	public int MapY = 50;
	public int MapX = 50;
	//float maxRandomHeight = 4;
	public Transform TilePrefab;


	public Tile[,] allTiles;

	void Awake () {

		allTiles = new Tile[MapY, MapX];
        GameObject tilego;
		float xOffset = 0.766f;
		float yOffset = 0.886f;
		//GameObject tileparent = gameObject;

	for (int y = 0; y < MapY; y++) {
			for (int x = 0; x < MapX; x++) {
				float yPos = y * yOffset;
				if( x % 2 == 1){
					yPos += yOffset/2;
					}


				tilego = (GameObject) Instantiate (TilePrefab.gameObject, new Vector3(x*xOffset, 0, yPos ),Quaternion.identity);
				tilego.name = "Tile_" + x +"_"+y;
				tilego.transform.SetParent(gameObject.transform);
				//tilego.transform.localScale = new Vector3 (1, Random.Range (1, maxRandomHeight), 1);
				allTiles [x, y] = new Tile (x, y, tilego);

			}
		}

		for (int y = 0; y < MapY; y++) {
			for (int x = 0; x < MapX; x++) {
				FeedTileNeighbours (allTiles [x, y]);
			}
		}
	}
	void FeedTileNeighbours(Tile source){
		source.neighbours = new Tile[6];
		int sourceX = source.TileX;
		int sourceY = source.TileY;
		Tile nN = null;Tile nNE = null;Tile nSE=null;Tile nS= null;Tile nSW=null;Tile nNW=null;

		if(sourceX %2 == 1){
		nN = allTiles [sourceX, Mathf.Clamp(sourceY + 1,0,MapY-1)];
		nNE = allTiles [ Mathf.Clamp(sourceX + 1,0,MapX-1),  Mathf.Clamp(sourceY + 1,0 ,MapY-1)];
		nSE = allTiles[ Mathf.Clamp(sourceX+1,0,MapX-1),sourceY];
		nS = allTiles [sourceX,  Mathf.Clamp(sourceY - 1,0,MapY-1)];
		nSW = allTiles [ Mathf.Clamp(sourceX - 1,0, MapX-1), sourceY];
		nNW = allTiles [ Mathf.Clamp(sourceX - 1,0,MapX-1),  Mathf.Clamp(sourceY + 1,0,MapY-1)];
		}
		if (sourceX % 2 == 0) {
			nN = allTiles [sourceX, Mathf.Clamp(sourceY + 1,0,MapY-1)];
			nNE = allTiles [ Mathf.Clamp(sourceX + 1,0,MapX-1),  Mathf.Clamp(sourceY ,0 ,MapY-1)];
			nSE = allTiles[ Mathf.Clamp(sourceX+1,0,MapX-1),Mathf.Clamp(sourceY-1,0, MapY-1)];
			nS = allTiles [sourceX,  Mathf.Clamp(sourceY - 1,0,MapY-1)];
			nSW = allTiles [ Mathf.Clamp(sourceX - 1,0, MapX-1),Mathf.Clamp(sourceY-1,0, MapY-1)];
			nNW = allTiles [ Mathf.Clamp(sourceX - 1,0,MapX-1),  Mathf.Clamp(sourceY ,0,MapY-1)];
		}
		source.neighbours[0] =nN;
		source.neighbours[1] =nNE;
		source.neighbours[2] =nSE;
		source.neighbours[3] =nS;
		source.neighbours[4] =nSW;
		source.neighbours[5] =nNW;   

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}