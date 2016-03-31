using System;
using UnityEngine;

[Serializable]
public class CutsceneManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public PromptBarScript PromptBar;

	public PortalScript Portal;

	public UISprite Darkness;

	public UILabel Subtitle;

	public AudioClip[] Voice;

	public string[] Text;

	public int Phase;

	public int Line;

	public CutsceneManagerScript()
	{
		this.Phase = 1;
		this.Line = 1;
	}

	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a == (float)1)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Subtitle.text = this.Text[this.Line];
			this.audio.clip = this.Voice[this.Line];
			this.audio.Play();
			this.Phase++;
		}
		else if (this.Phase == 3)
		{
			if (!this.audio.isPlaying || Input.GetButtonDown("A"))
			{
				if (this.Line < 2)
				{
					this.Phase--;
					this.Line++;
				}
				else
				{
					this.Subtitle.text = string.Empty;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 4)
		{
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
			Color color3 = this.Darkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
			if (this.Darkness.color.a == (float)0)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (this.StudentManager.Students[7] != null)
			{
				UnityEngine.Object.Destroy(this.StudentManager.Students[7].gameObject);
			}
			PlayerPrefs.SetInt("Student_7_Expelled", 1);
			this.PromptBar.ClearButtons();
			this.PromptBar.Show = false;
			this.Portal.Proceed = true;
			this.active = false;
		}
	}

	public virtual void Main()
	{
	}
}
