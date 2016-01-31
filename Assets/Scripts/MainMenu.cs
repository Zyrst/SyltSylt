using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject[] texts;
    public GameObject play;
    public GameObject dank;
    private int count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(play.activeInHierarchy)
        {
            if (Input.GetButton("Enter1") && !texts[0].activeInHierarchy)
            {
                texts[0].SetActive(true);
                count++;
            }
            if (Input.GetButton("Enter2") && !texts[1].activeInHierarchy)
            {
                texts[1].SetActive(true);
                count++;
            }
            if (Input.GetButton("Enter3") && !texts[2].activeInHierarchy)
            {
                texts[2].SetActive(true);
                count++;
            }
            if (Input.GetButton("Enter4") && !texts[3].activeInHierarchy)
            {
                texts[3].SetActive(true);
                count++;
            }

        }
	}


    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        //do stuff
        play.SetActive(true);
    }

    public void ActiveMatch()
    {
        Game.Instance.StartMatch(count);
        gameObject.SetActive(false);
    }

    public void Dank()
    {
        
       switch(dank.activeInHierarchy)
       {
           case true :
               dank.SetActive(false);
               break;
           case false:
               dank.SetActive(true);
               break;
       }
    }
}
