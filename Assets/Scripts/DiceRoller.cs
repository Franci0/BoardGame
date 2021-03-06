﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
	
	public Sprite[] diceImageOne;
	public Sprite[] diceImageZero;
	public int[] diceValues;

	StateManager stateManager;

	void Start ()
	{
		diceValues = new int[4];
		stateManager = FindObjectOfType<StateManager> ();
	}

	void Update ()
	{
		
	}

	public void RollTheDice ()
	{
		if (stateManager.isDoneRolling) {
			return;
		}

		stateManager.diceTotal = 0;
		for (int i = 0; i < diceValues.Length; i++) {
			diceValues [i] = Random.Range (0, 2);
			stateManager.diceTotal += diceValues [i];

			if (diceValues [i] == 0) {
				transform.GetChild (i).GetComponent<Image> ().sprite = diceImageZero [Random.Range (0, diceImageZero.Length)];
			} else {
				transform.GetChild (i).GetComponent<Image> ().sprite = diceImageOne [Random.Range (0, diceImageOne.Length)];
			}
		}
		stateManager.isDoneRolling = true;

		//Debug.Log ("Rolled " + diceTotal);
	}
}
