using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ChromaticAberrationEffect : MonoBehaviour {

	public float intensity = 0;
	public float zoom = 0.1f;
	private Material material;

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		material = new Material( Shader.Find("Hidden/ChromaticAbberrations") );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		if (intensity == 0) {
			Graphics.Blit (source, destination);
			return;
		}

		material.SetFloat("_Intensity", intensity);
		material.SetFloat("_Zoom", 1 + zoom);
		material.SetFloat("_RandRX", Random.Range(0.0f, 1.0f));
		material.SetFloat("_RandRY", Random.Range(0.0f, 1.0f));
		material.SetFloat("_RandGX", Random.Range(0.0f, 1.0f));
		material.SetFloat("_RandGY", Random.Range(0.0f, 1.0f));
		material.SetFloat("_RandBX", Random.Range(0.0f, 1.0f));
		material.SetFloat("_RandBY", Random.Range(0.0f, 1.0f));
		Graphics.Blit (source, destination, material);
	}
}
