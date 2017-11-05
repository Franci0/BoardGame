using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStone : MonoBehaviour
{
	public Tile startingTile;

	DiceRoller theDiceRoller;
	Tile currentTile;
	Vector3 targetPosition;
	Vector3 velocity = Vector3.zero;
	float smoothTime = 0.25f;
	float smoothTimeVertical = 0.1f;
	float smoothDistance = 0.01f;
	float smoothHeight = 0.5f;
	Tile[] moveQueue;
	int moveQueueIndex;
	bool scoreMe = false;

	void Start ()
	{
		theDiceRoller = GameObject.FindObjectOfType<DiceRoller> ();
		targetPosition = transform.position;
	}

	void Update ()
	{
		if (Vector3.Distance (
			    new Vector3 (transform.position.x, targetPosition.y, transform.position.z), 
			    targetPosition) < smoothDistance) {
			if (moveQueue != null && moveQueueIndex == moveQueue.Length && transform.position.y > smoothDistance) {
				transform.position = Vector3.SmoothDamp (
					transform.position, 
					new Vector3 (transform.position.x, 0, transform.position.z), 
					ref velocity, 
					smoothTimeVertical);
			} else {
				AdvanceMoveQueue ();
			}
		} else if (transform.position.y < smoothHeight - smoothDistance) {
			transform.position = Vector3.SmoothDamp (
				transform.position, 
				new Vector3 (transform.position.x, smoothHeight, transform.position.z), 
				ref velocity, 
				smoothTimeVertical);
		} else {
			transform.position = Vector3.SmoothDamp (
				transform.position, 
				new Vector3 (targetPosition.x, smoothHeight, targetPosition.z), 
				ref velocity, 
				smoothTime);
		}
	}

	void AdvanceMoveQueue ()
	{
		if (moveQueue != null && moveQueueIndex < moveQueue.Length) {
			Tile nextTile = moveQueue [moveQueueIndex];
			if (nextTile == null) {
				SetNewTargetPosition (nextTile.transform.position + Vector3.right * 100f);
			} else {
				SetNewTargetPosition (nextTile.transform.position);
				moveQueueIndex++;
			}
		}
	}

	void SetNewTargetPosition (Vector3 pos)
	{
		targetPosition = pos;
		velocity = Vector3.zero;
	}

	void OnMouseUp ()
	{
		
		Debug.Log ("Click!");

		if (!theDiceRoller.isDoneRolling) {
			return;
		}

		int spaceToMove = theDiceRoller.diceTotal;
		if (spaceToMove == 0) {
			return;
		}
		moveQueue = new Tile[spaceToMove];
		Tile finalTile = currentTile;

		for (int i = 0; i < spaceToMove; i++) {
			if (finalTile == null && !scoreMe) {
				finalTile = startingTile;
			} else {
				if (finalTile.nextTiles == null || finalTile.nextTiles.Length == 0) {
					//Destroy (gameObject);
					//return;
					scoreMe = true;
					finalTile = null;
				} else if (finalTile.nextTiles.Length > 1) {
					finalTile = finalTile.nextTiles [0];
				} else {
					finalTile = finalTile.nextTiles [0];
				}
			}
			moveQueue [i] = finalTile;
		}
		moveQueueIndex = 0;
		currentTile = finalTile;
	}

}
