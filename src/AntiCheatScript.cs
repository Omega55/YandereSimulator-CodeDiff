using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntiCheatScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public GameObject Jukebox;

	public bool Check;

	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (this.Check && !this.MyAudio.isPlaying)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YandereChan")
		{
			this.Jukebox.SetActive(false);
			this.Check = true;
			this.MyAudio.Play();
		}
	}
}
