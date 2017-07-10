using System;
using UnityEngine;

public class CutsceneManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public CounselorScript Counselor;

	public PromptBarScript PromptBar;

	public EndOfDayScript EndOfDay;

	public PortalScript Portal;

	public UISprite Darkness;

	public UILabel Subtitle;

	public AudioClip[] Voice;

	public string[] Text;

	public int Phase = 1;

	public int Line = 1;

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Phase == 1)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Subtitle.text = this.Text[this.Line];
			component.clip = this.Voice[this.Line];
			component.Play();
			this.Phase++;
		}
		else if (this.Phase == 3)
		{
			if (!component.isPlaying || Input.GetButtonDown("A"))
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
			this.EndOfDay.gameObject.SetActive(true);
			this.EndOfDay.Phase = 10;
			this.Counselor.LecturePhase = 5;
			this.Phase++;
		}
		else if (this.Phase == 6)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Darkness.color.a == 0f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			if (this.StudentManager.Students[7] != null)
			{
				UnityEngine.Object.Destroy(this.StudentManager.Students[7].gameObject);
			}
			this.PromptBar.ClearButtons();
			this.PromptBar.Show = false;
			this.Portal.Proceed = true;
			base.gameObject.SetActive(false);
		}
	}
}
