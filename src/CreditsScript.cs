using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CreditsScript : MonoBehaviour
{
	public Transform SpawnPoint;

	public Transform Panel;

	private GameObject NewCreditsLabel;

	public GameObject SmallCreditsLabel;

	public GameObject BigCreditsLabel;

	public UISprite Darkness;

	public string[] Lines;

	public int[] Sizes;

	public int ID;

	public float TimerLimit;

	public float Timer;

	public bool FadeOut;

	public bool Begin;

	public virtual void Update()
	{
		if (!this.audio.isPlaying)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				this.audio.Play();
				this.Timer = (float)0;
			}
		}
		if (this.audio.time > 1.5f)
		{
			if (this.Timer == (float)0)
			{
				if (this.Sizes[this.ID] == 1)
				{
					this.NewCreditsLabel = (GameObject)UnityEngine.Object.Instantiate(this.SmallCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
					this.TimerLimit = (float)1;
				}
				else
				{
					this.NewCreditsLabel = (GameObject)UnityEngine.Object.Instantiate(this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
					this.TimerLimit = (float)this.Sizes[this.ID];
				}
				this.NewCreditsLabel.transform.parent = this.Panel;
				this.NewCreditsLabel.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				((UILabel)this.NewCreditsLabel.GetComponent(typeof(UILabel))).text = this.Lines[this.ID];
				this.ID++;
				if (this.ID > Extensions.get_length(this.Sizes) - 1)
				{
					this.ID = 0;
				}
			}
			this.Timer = Mathf.MoveTowards(this.Timer, this.TimerLimit, Time.deltaTime);
			if (this.Timer >= this.TimerLimit)
			{
				this.Timer = (float)0;
			}
		}
		if (this.audio.time > (float)117)
		{
			this.audio.volume = this.audio.volume - Time.deltaTime;
		}
		if (Input.GetButtonDown("B") || this.audio.volume == (float)0)
		{
			this.FadeOut = true;
		}
		if (this.FadeOut)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			this.audio.volume = this.audio.volume - Time.deltaTime;
			if (this.Darkness.color.a == (float)1)
			{
				Application.LoadLevel("TitleScene");
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= (float)1;
			this.audio.pitch = Time.timeScale;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += (float)1;
			this.audio.pitch = Time.timeScale;
		}
	}

	public virtual void Main()
	{
	}
}
