using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	TacticalUIHolder tui;
    //Use this for initialization
    void Start()
    {
		tui = GameObject.Find ("TacticalUIHolder").GetComponent<TacticalUIHolder> ();
	}

    // Update is called once per frame
	void Update()
	{
		
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			tui.tactical_cursor.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
		}
	}
		

}