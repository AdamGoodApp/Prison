using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom }
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);

		if (myState == States.cell) {
			state_cell();
		}

		if (myState == States.sheets_0) {
			state_sheet0();
		}

		if (myState == States.mirror) {
			state_mirror();
		}

		if (myState == States.lock_0) {
			state_lock0();
		}

		check_key ();

	}

	private

	void check_key () {
		if (Input.GetKey (KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKey (KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKey (KeyCode.L)) {
			myState = States.lock_0;
		}
	}

	void state_cell () {
		text.text = "You wake up in a cell. Dazed and confused you look around your surroundings for something useful. " +
					"Upon further expection, you notice the cell is very bare. \n\n" +
					"Only three items are available for use: \n\n" +
					"(S)heets | (M)irror | (L)ock";
	}

	void state_sheet0 () {
		text.text = "I don't think this is the time to hit the hay just yet. \n\n" +
					"Only three items are available for use: \n\n" +
					"(S)heets | (M)irror | (L)ock";
	}

	void state_mirror () {
		text.text = "You apply pressure to the mirror.... Seems this prison was made in a rush. \n\n" +
					"After a bit of jiggling, the mirror comes loose!";
	}

	void state_lock0 () {
		text.text = "Just your standard issued prison lock. \n" +
					"Would of been nice to have the key.";
	}
}
