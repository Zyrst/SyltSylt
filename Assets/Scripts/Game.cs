using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _spawnHandler;

    private static Game _instance = null;

    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Game(Clone)").GetComponent<Game>();
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
}
