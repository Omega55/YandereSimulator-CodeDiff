using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
	public UISprite FadeOutDarkness;

	public UITexture LoveSickLogo;

	public UIPanel SkipPanel;

	public UISprite Darkness;

	public UISprite Circle;

	public UITexture Logo;

	public UILabel Label;

	public AudioSource Narration;

	public string[] Lines;

	public float[] Cue;

	public bool Narrating;

	public bool Musicing;

	public bool FadeOut;

	public float SkipTimer;

	public float Timer;

	public int ID;

	private void Start()
	{
		this.LoveSickCheck();
		this.Circle.fillAmount = 0f;
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Label.text = string.Empty;
		this.SkipTimer = 15f;
	}

	private void Update()
	{
		if (Input.GetButton("X"))
		{
			this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 1f, Time.deltaTime);
			this.SkipTimer = 15f;
			if (this.Circle.fillAmount == 1f)
			{
				this.FadeOut = true;
			}
			this.SkipPanel.alpha = 1f;
		}
		else
		{
			this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 0f, Time.deltaTime);
			this.SkipTimer -= Time.deltaTime;
			this.SkipPanel.alpha = this.SkipTimer / 10f;
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 1f && !this.Narrating)
		{
			this.Narration.Play();
			this.Narrating = true;
		}
		if (this.ID < this.Cue.Length && this.Narration.time > this.Cue[this.ID])
		{
			this.Label.text = this.Lines[this.ID];
			this.ID++;
		}
		if (this.FadeOut)
		{
			this.FadeOutDarkness.color = new Color(this.FadeOutDarkness.color.r, this.FadeOutDarkness.color.g, this.FadeOutDarkness.color.b, Mathf.MoveTowards(this.FadeOutDarkness.color.a, 1f, Time.deltaTime));
			this.Circle.fillAmount = 1f;
			this.Narration.volume = this.FadeOutDarkness.color.a;
			if (this.FadeOutDarkness.color.a == 1f)
			{
				SceneManager.LoadScene("PhoneScene");
			}
		}
		if (this.Narration.time > 39.75f && this.Narration.time < 73f)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 0.5f));
		}
		if (this.Narration.time > 73f && this.Narration.time < 105.5f)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
		}
		if (this.Narration.time > 105.5f && this.Narration.time < 134f)
		{
			this.Darkness.color = new Color(1f, 0f, 0f, 1f);
		}
		if (this.Narration.time > 134f && this.Narration.time < 147f)
		{
			this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		if (this.Narration.time > 147f && this.Narration.time < 152f)
		{
			this.Logo.transform.localScale = new Vector3(this.Logo.transform.localScale.x + Time.deltaTime * 0.1f, this.Logo.transform.localScale.y + Time.deltaTime * 0.1f, this.Logo.transform.localScale.z + Time.deltaTime * 0.1f);
			this.LoveSickLogo.transform.localScale = new Vector3(this.LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
			this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 1f);
			this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 1f);
		}
		if (this.Narration.time > 152f)
		{
			this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 0f);
			this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 0f);
		}
		if (this.Narration.time > 156f)
		{
			SceneManager.LoadScene("PhoneScene");
		}
	}

	private void LoveSickCheck()
	{
		if (GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
			foreach (GameObject gameObject in array)
			{
				UISprite component = gameObject.GetComponent<UISprite>();
				if (component != null)
				{
					component.color = new Color(1f, 0f, 0f, component.color.a);
				}
				UITexture component2 = gameObject.GetComponent<UITexture>();
				if (component2 != null)
				{
					component2.color = new Color(1f, 0f, 0f, component2.color.a);
				}
				UILabel component3 = gameObject.GetComponent<UILabel>();
				if (component3 != null && component3.color != Color.black)
				{
					component3.color = new Color(1f, 0f, 0f, component3.color.a);
				}
			}
			this.FadeOutDarkness.color = new Color(0f, 0f, 0f, 0f);
			this.LoveSickLogo.enabled = true;
			this.Logo.enabled = false;
		}
		else
		{
			this.LoveSickLogo.enabled = false;
		}
	}
}
