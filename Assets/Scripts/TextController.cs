using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	public float letterPause = .05f;

	private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom }
	private States myState;

	string[] goatText;
	int currentlyDisplayingText = 0;

	// Use this for initialization
	void Start () {
		myState = States.cell;
		goatText = new string[] {"You wake up in a cell. Dazed and confused you look around your surroundings for something useful. " +
			"Upon further expection, you notice the cell is very bare. \n\n" +
			"Only three items are available for use: \n\n" +
			"(S)heets | (M)irror | (L)ock"};
		StartAnimationText ();
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);

		if (myState == States.cell) {
			state_cell();
		} else if (myState == States.sheets_0) {
			state_sheet0();
		} else if (myState == States.mirror) {
			state_mirror();
		} else if (myState == States.lock_0) {
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
		
	}

	void state_sheet0 () {
		goatText = new string[] {"I don't think this is the time to hit the hay just yet. \n\n" +
					"Only three items are available for use: \n\n" +
			"(S)heets | (M)irror | (L)ock"};
		StartAnimationText ();
	}

	void state_mirror () {
		text.text = "You apply pressure to the mirror.... Seems this prison was made in a rush. \n\n" +
					"After a bit of jiggling, the mirror comes loose! \n\n" +
					"Only two items are available for use: \n\n" +
					"(S)heets | (L)ock";
	}

	void state_lock0 () {
		text.text = "Just your standard issued prison lock. \n" +
					"Would of been nice to have the key. \n\n" +
					"Only three items are available for use: \n\n" +
					"(S)heets | (M)irror | (L)ock";
	}

	void StartAnimationText () {
		StartCoroutine(AnimateText());
		PlayAudio ();
	}

	public void SkipToNextText(){
		StopAllCoroutines();
		currentlyDisplayingText++;
		//If we've reached the end of the array, do anything you want. I just restart the example text
		if (currentlyDisplayingText>goatText.Length) {
			currentlyDisplayingText=0;
		}
		StartCoroutine(AnimateText());
	}

	IEnumerator AnimateText(){
		for (int i = 0; i < (goatText[currentlyDisplayingText].Length+1); i++)
		{
			text.text = goatText[currentlyDisplayingText].Substring(0, i);
			yield return new WaitForSeconds(letterPause);
		}
		AudioSource audio = GetComponent<AudioSource>();
		audio.Stop ();
	}

	void PlayAudio() {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}


}
