using System;
using UnityEngine;

[Serializable]
public class NotificationScript : MonoBehaviour
{
	public NotificationManagerScript NotificationManager;

	public UIPanel Panel;

	public UILabel Label;

	public bool Display;

	public float Timer;

	public int ID;

	public virtual void Update()
	{
		if (!this.Display)
		{
			if (this.NotificationManager.NotificationsSpawned > this.ID + 2)
			{
				this.Panel.alpha = this.Panel.alpha - Time.deltaTime * (float)3;
			}
			else
			{
				this.Panel.alpha = this.Panel.alpha - Time.deltaTime;
			}
			if (this.Panel.alpha <= (float)0)
			{
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)4)
			{
				this.Display = false;
			}
			if (this.NotificationManager.NotificationsSpawned > this.ID + 2)
			{
				this.Display = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
