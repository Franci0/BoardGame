using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTotalDisplay : MonoBehaviour
{
	StateManager stateManager;

	void Start ()
	{
		stateManager = FindObjectOfType<StateManager> ();
	}

	void Update ()
	{
		if (stateManager.isDoneRolling) {
			GetComponent<Text> ().text = "= " + stateManager.diceTotal;
		} else {
			GetComponent<Text> ().text = "= ?";
		}
	}
}
