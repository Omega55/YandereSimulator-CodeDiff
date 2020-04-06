using System;
using UnityEngine;

public class OsanaJokeScript : MonoBehaviour
{
	public ConstantRandomRotation[] Rotation;

	public GameObject BloodSplatterEffect;

	public AudioClip BloodSplatterSFX;

	public AudioClip VictoryMusic;

	public AudioSource Jukebox;

	public Transform Head;

	public UILabel Label;

	public bool Advance;

	public float Timer;

	public int ID;

	private void Update()
	{
		if (this.Advance)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 3f)
			{
				this.Label.text = "Congratulations, you eliminated Osana!";
				if (!this.Jukebox.isPlaying)
				{
					this.Jukebox.clip = this.VictoryMusic;
					this.Jukebox.Play();
				}
			}
			else if (this.Timer > 14f)
			{
				Application.Quit();
			}
		}
		else if (Input.GetKeyDown("f"))
		{
			this.Rotation[0].enabled = false;
			this.Rotation[1].enabled = false;
			this.Rotation[2].enabled = false;
			this.Rotation[3].enabled = false;
			this.Rotation[4].enabled = false;
			this.Rotation[5].enabled = false;
			this.Rotation[6].enabled = false;
			this.Rotation[7].enabled = false;
			UnityEngine.Object.Instantiate<GameObject>(this.BloodSplatterEffect, this.Head.position, Quaternion.identity);
			this.Head.localScale = new Vector3(0f, 0f, 0f);
			this.Jukebox.clip = this.BloodSplatterSFX;
			this.Jukebox.Play();
			this.Label.text = string.Empty;
			this.Advance = true;
		}
	}
}
