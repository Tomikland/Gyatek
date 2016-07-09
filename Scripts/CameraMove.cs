using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float scrollspeed = 20;
	public Vector3 movedir;
	float rotamt;
	public float ScrollAxis;
	// Use this for initialization
	void Start () {
		movedir = transform.position;
		//float mindis = transform.position.x + 5;
		//float maxdis = transform.position.x - 5;
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 xaxis = new Vector3 (1, 0, 0);
		ScrollAxis = Mathf.Lerp (0, Input.GetAxis ("Mouse ScrollWheel"), 0.9f)/2;

		rotamt = - ScrollAxis * 7;

		//Vector3 minpos = new Vector3 (-10, 0.5, -10);
		//Vector3 maxpos = new Vector3 (10, 6.8, 10);

		float mindis = -2f;
		float maxdis = 34f;
		movedir.x += Input.GetAxis ("Horizontal")* Time.deltaTime *(transform.position.y*2);
		movedir.x = Mathf.Clamp (movedir.x, mindis, maxdis);

		movedir.z += Input.GetAxis ("Vertical") *Time.deltaTime * (transform.position.y*2);
		movedir.z = Mathf.Clamp (movedir.z, mindis, maxdis);

		movedir.y = transform.position.y;	
		movedir.y += -ScrollAxis * Time.deltaTime* scrollspeed * (transform.position.y);
		movedir.y = Mathf.Clamp (movedir.y, 1.99f, 5.5f);

	

		transform.position = movedir;

		if (movedir.y > 2 && movedir.y < 5.5f) {
			transform.Rotate (xaxis, rotamt);
		}
	}
}
