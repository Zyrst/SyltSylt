using UnityEngine;
using System.Collections;

public class AudioSourcePrefabScript : MonoBehaviour {

	AudioSource source;

	void Start () {	
		source = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (!source.isPlaying)
			GameObject.Destroy(transform.gameObject);
	}
}
