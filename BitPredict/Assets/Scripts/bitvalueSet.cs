using UnityEngine;
using System.Collections;

public class bitvalueSet : MonoBehaviour {
	public int bitvalue;
	public int playerchoice, aichoice;
	public int score = 0;
	// Use this for initialization
	void Start () {
		bitvalue = Random.Range (0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerchoice == bitvalue) {
			score = score + 100;
		} else {
		}

		if (aichoice == bitvalue) {
			score = score + 100;
		} else {
		}
	}
}
