using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
	
	public Sprite[] diceImageOne;
	public Sprite[] diceImageZero;
	public int[] diceValues;
	public int diceTotal;
	public bool doneRolling = false;

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

			if (diceValues [i] == 0) {
				transform.GetChild (i).GetComponent<Image> ().sprite = diceImageZero [Random.Range (0, diceImageZero.Length)];
			} else {
				transform.GetChild (i).GetComponent<Image> ().sprite = diceImageOne [Random.Range (0, diceImageOne.Length)];
			}
		}
		doneRolling = true;

		//Debug.Log ("Rolled " + diceTotal);
	}

	public void NewTurn ()
	{
		doneRolling = false;
	}
}
