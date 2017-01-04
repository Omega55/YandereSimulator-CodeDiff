using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public virtual void Start()
	{
		this.Controls.active = false;
		int num = 0;
		Color color = this.Girl.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Girl.color = color;
		this.Label.text = this.Lines[this.ID];
		this.Label.gameObject.active = false;
	}

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)3)
		{
			if (!this.Typewriter.mActive)
			{
				this.Controls.active = true;
			}
		}
		else if (this.Timer > (float)2)
		{
			this.Label.gameObject.active = true;
		}
		else if (this.Timer > (float)1)
		{
			float a = Mathf.MoveTowards(this.Girl.color.a, (float)1, Time.deltaTime);
			Color color = this.Girl.color;
			float num = color.a = a;
			Color color2 = this.Girl.color = color;
		}
		if (this.Controls.active)
		{
			if (Input.GetButtonDown("B"))
			{
				if (this.Skip.active)
				{
					this.ID = 19;
					this.Skip.active = false;
					this.Girl.mainTexture = this.Portraits[this.ID];
					this.Typewriter.ResetToBeginning();
					this.Typewriter.mLabel.text = this.Lines[this.ID];
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				if (this.ID < Extensions.get_length(this.Lines) - 1)
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
							this.Skip.active = false;
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

	public virtual void Main()
	{
	}
}
