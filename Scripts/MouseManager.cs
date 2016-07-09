using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {
	public Tile selectedTile;
	public Camera cam;
	public GameObject TilesManager;
	public LayerMask myLayerMask;
	Tile lastTile = null ;
	public Material standardTileMat;
	public Material HighlightedTileMat;
	int i = 0;
	Tile GetHoverTile(){         //melyik hatszög felett van az egér?
		Ray ray;
		Tile theTile = null;
		RaycastHit hitInfo;
		Tiles tilesScript = TilesManager.GetComponent<Tiles> ();
		ray = cam.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hitInfo,  100f,myLayerMask)){       
			
	

		for (int y = 0; y < tilesScript.MapY; y++) {    // megvan a raycast, de nem tudjuk, melyik "adattároló tile"-hoz tartozik
			for (int x = 0; x < tilesScript.MapX; x++) { 
					
					if(hitInfo.transform.parent.parent.gameObject == tilesScript.allTiles[x,y].TileGO){
						theTile = tilesScript.allTiles [x, y];
						//Debug.Log ("Found tileX: " + theTile.TileX + "tileY: " + theTile.TileY);
						return theTile;
					}
  
	            }
		   }

	    }
		return theTile;
	}

	void HighlightTile(Tile t){ 
		if (t != null){
			t.TileGO.transform.localScale = new Vector3 (1, 2, 1);
		}
	}
	void HighlightNeighbours(Tile source) {
		MeshRenderer mr;
		Debug.Log ("sourcetile: " + source.TileGO.name);
		i = 0;
		foreach (Tile ti in source.neighbours) {
			
			if (ti != source) {
				ti.TileGO.transform.GetChild (0).GetComponentInChildren<MeshRenderer> ().material = HighlightedTileMat;

			} else {
				source.neighbours [i] = null;
			}
			i++;
		}
	}
		void DehighlightNeighbours(Tile source) {
		i = 0;
			Debug.Log("sourcetile: "+source.TileGO.name);
			foreach (Tile ti in source.neighbours){

				if (ti != null) {
				if (ti != source) {
					ti.TileGO.transform.GetChild (0).GetComponentInChildren<MeshRenderer> ().material = standardTileMat;

				} else {
					source.neighbours [i] = null;
				}
			}
	}
	}

	void DehighlightTile(Tile t){ 
		if (t != null && t.TileGO != null){
		t.TileGO.transform.localScale = new Vector3 (1, 1, 1);
	}
	}
	void Update(){

		if (Input.GetMouseButtonDown (1)) {
			

			if (lastTile != null) {
				DehighlightNeighbours (lastTile);
			}
				lastTile = GetHoverTile ();
				HighlightNeighbours (lastTile);

		}
	}
}
