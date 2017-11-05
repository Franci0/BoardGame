using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTotalDisplay : MonoBehaviour
{
	DiceRoller theDiceRoller;

	void Start ()
	{
		theDiceRoller = GameObject.FindObjectOfType<DiceRoller> ();
	}

	void Update ()
	{
		if (theDiceRoller.isDoneRolling) {
			GetComponent<Text> ().text = "= " + theDiceRoller.diceTotal;
		} else {
			GetComponent<Text> ().text = "= ?";
		}
	}
}
