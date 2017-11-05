using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStone : MonoBehaviour
{
	public Tile startingTile;

	DiceRoller theDiceRoller;
	Tile currentTile;

	void Start ()
	{
		theDiceRoller = GameObject.FindObjectOfType<DiceRoller> ();
	}

	void Update ()
	{
		
	}

	void OnMouseUp ()
	{
		
		Debug.Log ("Click!");

		if (!theDiceRoller.isDoneRolling) {
			return;
		}

		int spaceToMove = theDiceRoller.diceTotal;

		Tile finalTile = currentTile;

		for (int i = 0; i < spaceToMove; i++) {
			if (finalTile == null) {
				finalTile = startingTile;
			} else {
				if (finalTile.nextTiles == null || finalTile.nextTiles.Length == 0) {
					Debug.Log ("Score!");
					Destroy (gameObject);
					return;
				} else if (finalTile.nextTiles.Length > 1) {
					finalTile = finalTile.nextTiles [0];
				} else {
					finalTile = finalTile.nextTiles [0];
				}
			}
		}

		if (finalTile == null) {
			return;
		}

		transform.position = finalTile.transform.position;

		currentTile = finalTile;
	}

}
