using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _player;
    public GameObject[] _gameModes;
    public int PlayerCount = 0;
    private static Game _instance = null;

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
}
