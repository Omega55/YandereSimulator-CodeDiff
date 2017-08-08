using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunScript : MonoBehaviour
{
	public TypewriterEffect Typewriter;

	public GameObject Controls;

	public GameObject Skip;

	public Texture[] Portraits;

	public string[] Lines;

	public UITexture Girl;

	public UILabel Label;

	public float OutroTimer;

	public float Timer;

	public int ID;

	public float R = 1f;

	public float G = 1f;

	public float B = 1f;

	private void Start()
	{
		if (SceneManager.GetActiveScene().name == "MoreFunScene")
		{
			this.G = 0f;
			this.B = 0f;
			this.Label.color = new Color(this.R, this.G, this.B, 1f);
			this.Skip.SetActive(false);
		}
		this.Controls.SetActive(false);
		this.Label.text = this.Lines[this.ID];
		this.Label.gameObject.SetActive(false);
		this.Girl.color = new Color(this.R, this.G, this.B, 0f);
	}

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 3f)
		{
			if (!this.Typewriter.mActive)
			{
				this.Controls.SetActive(true);
			}
		}
		else if (this.Timer > 2f)
		{
			this.Label.gameObject.SetActive(true);
		}
		else if (this.Timer > 1f)
		{
			this.Girl.color = new Color(this.R, this.G, this.B, Mathf.MoveTowards(this.Girl.color.a, 1f, Time.deltaTime));
		}
		if (this.Controls.activeInHierarchy)
		{
			if (Input.GetButtonDown("B"))
			{
				if (this.Skip.activeInHierarchy)
				{
					this.ID = 19;
					this.Skip.SetActive(false);
					this.Girl.mainTexture = this.Portraits[this.ID];
					this.Typewriter.ResetToBeginning();
					this.Typewriter.mLabel.text = this.Lines[this.ID];
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				if (this.ID < this.Lines.Length - 1)
				{
					if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
					{
						this.Typewriter.Finish();
					}
					else
					{
						this.ID++;
						if (this.ID == 19)
						{
							this.Skip.SetActive(false);
						}
						this.Girl.mainTexture = this.Portraits[this.ID];
						this.Typewriter.ResetToBeginning();
						this.Typewriter.mLabel.text = this.Lines[this.ID];
					}
				}
				else
				{
					Application.Quit();
				}
			}
		}
	}
}
