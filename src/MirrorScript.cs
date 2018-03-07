using System;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string[] Personas;

	public string[] Idles;

	public string[] Walks;

	public int ID;

	public int Limit;

	private void Start()
	{
		this.Limit = this.Idles.Length - 1;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.ID++;
			if (this.ID == this.Limit)
			{
				this.ID = 0;
			}
			this.UpdatePersona();
		}
		else if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.ID--;
			if (this.ID < 0)
			{
				this.ID = this.Limit - 1;
			}
			this.UpdatePersona();
		}
	}

	private void UpdatePersona()
	{
		if (!this.Prompt.Yandere.Carrying)
		{
			this.Prompt.Yandere.NotificationManager.PersonaName = this.Personas[this.ID];
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Persona);
			this.Prompt.Yandere.IdleAnim = this.Idles[this.ID];
			this.Prompt.Yandere.WalkAnim = this.Walks[this.ID];
			this.Prompt.Yandere.UpdatePersona(this.ID);
		}
		this.Prompt.Yandere.OriginalIdleAnim = this.Idles[this.ID];
		this.Prompt.Yandere.OriginalWalkAnim = this.Walks[this.ID];
		this.Prompt.Yandere.StudentManager.UpdatePerception();
	}
}
