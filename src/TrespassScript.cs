using System;
using UnityEngine;

[Serializable]
public class TrespassScript : MonoBehaviour
{
	public GameObject YandereObject;

	public YandereScript Yandere;

	public bool HideNotification;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			this.YandereObject = other.gameObject;
			this.Yandere = (YandereScript)other.gameObject.GetComponent(typeof(YandereScript));
			if (this.Yandere != null)
			{
				if (!this.Yandere.Trespassing)
				{
					this.Yandere.NotificationManager.DisplayNotification("Intrude");
				}
				this.Yandere.Trespassing = true;
			}
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (this.Yandere != null && other.gameObject == this.YandereObject)
		{
			this.Yandere.Trespassing = false;
		}
	}

	public virtual void Main()
	{
	}
}
