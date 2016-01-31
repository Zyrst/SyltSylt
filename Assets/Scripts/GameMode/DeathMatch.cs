using UnityEngine;
using System.Collections;

public class DeathMatch : GameMode {

    public GameObject[] maps;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init(int winCond, int players)
    {
        Instantiate(maps[Random.Range(0, maps.Length)]);
        WinCondition = winCond;
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

        if (Scores[player - 1] >= WinCondition)
        {
            //deklarera vinnare
            
        }
    }
}
