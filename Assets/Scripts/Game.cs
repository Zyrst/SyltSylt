using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    public GameObject _player;
    public GameObject[] _gameModes;
    public int PlayerCount = 0;
    private static Game _instance = null;

    private List<GameObject> _players = new List<GameObject>();

    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Game").GetComponent<Game>();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }
    }

	// Use this for initialization
	void Start () {

       // SpawnNewPlayers(3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void StartMatch(int playerCount)
    {
        PlayerCount = playerCount;
        Debug.Log(playerCount);
        GameObject go = GameObject.Instantiate(_gameModes[0]);
        go.GetComponent<DeathMatch>().Init(5, PlayerCount);
    }
    public void SpawnNewPlayers(int numberOfPlayers_)
    {
        for (int i = 0; i < numberOfPlayers_; i++)
        {
            PlayerCount++;
            GameObject player = Instantiate(_player);
            player.GetComponent<Player>().Create(PlayerCount);
            _players.Add(player);

            GetComponent<SpawnHandlerScript>().Spawn(_players[PlayerCount - 1]);
        }
    }
}
