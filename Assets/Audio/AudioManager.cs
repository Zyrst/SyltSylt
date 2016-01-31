using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
	public enum Tag {
		AutoRifleShot,
		Dies,
		Explosion,
		GrenadeLauncher,
		GrenadeShot,
		GrenadeLand,
		Jump,
		LazerShot,
		MinePlace,
		OutOfAmmo,
		PickupAutoRifle,
		PickupGranadeLauncher,
		PickupLazer,
		PickupMine,
		TakeDamage,
		Announcer
	}	

	[System.Serializable]
	public class Pair {
		public AudioClip audio;
		public Tag tag;
	}

	public static AudioManager instance;

	public GameObject audioSourcePrefab;
	public Pair[] all;

	private Dictionary<Tag, List<AudioClip>> dict = new Dictionary<Tag, List<AudioClip>>();

    

	void Start () {
		instance = this;
		instance.init();
	}

	private void init() {
		foreach (Pair p in all) {
			Debug.Log(p.tag.ToString());

			if (!dict.ContainsKey(p.tag))
				dict.Add(p.tag, new List<AudioClip>());

			p.audio.LoadAudioData();
			dict[p.tag].Add(p.audio);
		}
	}

	void Update () {
	}

	public void PlaySound(Tag tag) {
		
		if (!dict.ContainsKey(tag))
			return;

		GameObject prefab = Instantiate(audioSourcePrefab);
		prefab.GetComponent<AudioSource>().clip = dict[tag][Random.Range(0, dict[tag].Count - 1)];
		prefab.GetComponent<AudioSource>().Play();
	}

    GameObject asd;

    public AudioSource PlayMusic(AudioClip clipzter, bool loop)
    {
        if (asd != null)
            GameObject.Destroy(asd);

        asd = Instantiate(audioSourcePrefab);
        asd.GetComponent<AudioSource>().clip = clipzter;
        asd.GetComponent<AudioSource>().loop = loop;
        asd.GetComponent<AudioSource>().Play();
        return asd.GetComponent<AudioSource>();
    }
}
