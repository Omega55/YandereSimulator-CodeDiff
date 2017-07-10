using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
	public JsonScript JSON;

	public Transform SpawnPoint;

	public Transform Panel;

	private GameObject NewCreditsLabel;

	public GameObject SmallCreditsLabel;

	public GameObject BigCreditsLabel;

	public UISprite Darkness;

	public string[] Lines;

	public int[] Sizes;

	public int ID;

	public float SpeedUpFactor;

	public float TimerLimit;

	public float FadeTimer;

	public float Timer;

	public bool StopCredits;

	public bool FadeOut;

	public bool Begin;

	private void Start()
	{
		this.ID = 1;
		while (this.ID < this.Lines.Length)
		{
			this.Lines[this.ID] = this.JSON.CreditsNames[this.ID];
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.Sizes.Length)
		{
			this.Sizes[this.ID] = this.JSON.CreditsSizes[this.ID];
			this.ID++;
		}
		this.ID = 1;
	}

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.Begin)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Begin = true;
				component.Play();
				this.Timer = 0f;
			}
		}
		else
		{
			if (!this.StopCredits)
			{
				if (this.Timer == 0f)
				{
					if (this.Sizes[this.ID] == 1)
					{
						this.NewCreditsLabel = UnityEngine.Object.Instantiate<GameObject>(this.SmallCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
						this.TimerLimit = this.SpeedUpFactor;
					}
					else
					{
						this.NewCreditsLabel = UnityEngine.Object.Instantiate<GameObject>(this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
						this.TimerLimit = (float)this.Sizes[this.ID] * this.SpeedUpFactor;
					}
					this.NewCreditsLabel.transform.parent = this.Panel;
					this.NewCreditsLabel.transform.localScale = new Vector3(1f, 1f, 1f);
					this.NewCreditsLabel.GetComponent<UILabel>().text = this.Lines[this.ID];
					this.ID++;
					if (this.ID > this.Sizes.Length - 1)
					{
						this.StopCredits = true;
					}
				}
				this.Timer = Mathf.MoveTowards(this.Timer, this.TimerLimit, Time.deltaTime);
				if (this.Timer >= this.TimerLimit)
				{
					this.Timer = 0f;
				}
			}
			if (Input.GetButtonDown("B") || !component.isPlaying)
			{
				this.FadeOut = true;
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			component.volume -= Time.deltaTime;
			if (this.Darkness.color.a == 1f)
			{
				SceneManager.LoadScene("TitleScene");
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
			component.pitch = Time.timeScale;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
			component.pitch = Time.timeScale;
		}
	}
}
