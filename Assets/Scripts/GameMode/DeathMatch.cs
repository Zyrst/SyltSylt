using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class DeathMatch : GameMode {

    public GameObject[] maps;
    public Text[] scores;
    public GameObject[] boxes;
    public GameObject Fade;
    GameObject currentMap;
    private bool winner = false;

    private AudioSource srz;
    public AudioClip[] musics;
	// Use this for initialization
	void Start () {
        srz = AudioManager.instance.PlayMusic(musics[0], false);
	}
	
	// Update is called once per frame
	void Update () {
	   for(int i = 0; i < PlayerCount; i++)
       {
           scores[i].text = Scores[i].ToString();
       }

        if(Input.GetButton("Enter" + 1) && winner)
        {
            Done();
        }

        if(!srz.isPlaying)
        {
            srz = AudioManager.instance.PlayMusic(musics[1], true);
        }
	}

    public void Init(int winCond, int players)
    {
        currentMap = Instantiate(maps[Random.Range(0, maps.Length)]);
        WinCondition = winCond;
        PlayerCount = players;
        Scores = new int[PlayerCount];
        for(int i = 0; i < PlayerCount; i++)
        {
            Scores[i] = 0;
            scores[i].gameObject.SetActive(true);
            boxes[i].SetActive(true);
        }

        
    }

    public void AddScore(int player, int amount)
    {
        Scores[player - 1] += amount;
        Debug.Log(Scores[player - 1]);

        if (Scores[player - 1] >= WinCondition)
        {
            //deklarera vinnare
            winner = true;
            Fade.SetActive(true);
            srz = AudioManager.instance.PlayMusic(musics[2], false);
            Fade.GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "Winner").text = "Player " + player.ToString() + " Wins!";
        }
    }

    public void Done()
    {
        Instantiate(Game.Instance.MainMenu);
        foreach (GameObject go in Game.Instance._players)
        {
            Destroy(go);
        }

        Game.Instance._players.Clear();

        Destroy(currentMap);
        Game.Instance.GetComponent<SpawnHandlerScript>().FixingTHingsFuck();
        
        Destroy(this.gameObject);
    }
}
