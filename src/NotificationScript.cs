using System;
using UnityEngine;

public class NotificationScript : MonoBehaviour
{
	public NotificationManagerScript NotificationManager;

	public UISprite[] Icon;

	public UIPanel Panel;

	public UILabel Label;

	public bool Display;

	public float Timer;

	public int ID;

	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.Icon[0].color = new Color(1f, 1f, 1f, 1f);
			this.Icon[1].color = new Color(1f, 1f, 1f, 1f);
			this.Label.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	private void Update()
	{
		if (!this.Display)
		{
			this.Panel.alpha -= Time.deltaTime * ((this.NotificationManager.NotificationsSpawned <= this.ID + 2) ? 1f : 3f);
			if (this.Panel.alpha <= 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 4f)
			{
				this.Display = false;
			}
			if (this.NotificationManager.NotificationsSpawned > this.ID + 2)
			{
				this.Display = false;
			}
		}
	}
}
