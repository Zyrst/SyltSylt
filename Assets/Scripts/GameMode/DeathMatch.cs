using UnityEngine;
using System.Collections;

public class DeathMatch : GameMode {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init(int rounds, int players)
    {
        Rounds = rounds;
        PlayerCount = players;
        Scores = new int[PlayerCount];
        for(int i = 0; i < PlayerCount; i++)
        {
            Scores[i] = 0;
        }
    }

    public void AddScore(int player, int amount)
    {
        Scores[player - 1] += amount;
        Debug.Log(Scores[player - 1]);
    }
}
