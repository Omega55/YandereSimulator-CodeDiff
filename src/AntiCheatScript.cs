using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntiCheatScript : MonoBehaviour
{
	public GameObject Jukebox;

	public bool Check;

	private void Update()
	{
		if (this.Check && !base.GetComponent<AudioSource>().isPlaying)
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
			base.GetComponent<AudioSource>().Play();
		}
	}
}
