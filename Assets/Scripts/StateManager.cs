using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

	public int currentPlayerId = 0;
	public int diceTotal;
	public int numberOfPlayers = 2;
	public bool isDoneRolling = false;
	public bool isDoneClicking = false;
	public bool isDoneAnimating = false;

	void Start ()
	{
		
	}

	void Update ()
	{
		if (isDoneClicking && isDoneRolling && isDoneAnimating) {
			Debug.Log ("Turn Done!");
			NewTurn ();
		}
	}

	public void NewTurn ()
	{
		isDoneRolling = false;
		isDoneClicking = false;
		isDoneAnimating = false;
		currentPlayerId = (currentPlayerId + 1) % numberOfPlayers;
	}
}
