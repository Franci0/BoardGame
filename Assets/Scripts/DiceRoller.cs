using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
	public int[] diceValues;
	public int diceTotal;

	void Start ()
	{
		diceValues = new int[4];
	}

	void Update ()
	{
		
	}

	public void RollTheDice ()
	{
		diceTotal = 0;
		for (int i = 0; i < diceValues.Length; i++) {
			diceValues [i] = Random.Range (0, 2);
			diceTotal += diceValues [i];
			Debug.Log ("Rolled " + diceValues [i] + "(" + diceTotal + ")");
		}
	}
}
