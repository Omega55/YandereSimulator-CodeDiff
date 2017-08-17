using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SponsorScript : MonoBehaviour
{
	public GameObject[] Set;

	public UISprite Darkness;

	public float Timer;

	public int ID;

	private void Start()
	{
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		base.GetComponent<AudioSource>().Play();
	}

	private void Update()
	{
		this.Timer += Time.deltaTime * 1.33333337f;
		if (this.Timer < 6f)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime * 1.33333337f);
			if (this.Darkness.color.a < 0f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
				if (Input.anyKeyDown)
				{
					this.Timer = 6f;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime * 1.33333337f);
			if (this.Darkness.color.a >= 1f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
				this.Set[this.ID].SetActive(false);
				this.ID++;
				if (this.ID < this.Set.Length)
				{
					this.Set[this.ID].SetActive(true);
					this.Timer = 0f;
				}
				else
				{
					SceneManager.LoadScene("ChoiceScene");
				}
			}
		}
	}
}
