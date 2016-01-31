using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _spawnHandler;
    public GameObject _player;
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
       PlayerCount = 1;
       GameObject player = Instantiate(_player);
       player.GetComponent<Player>().Create(1);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
