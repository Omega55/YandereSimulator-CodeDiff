using System;
using UnityEngine;

[Serializable]
public class TrespassScript : MonoBehaviour
{
	public YandereScript Yandere;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			this.Yandere = (YandereScript)other.gameObject.GetComponent(typeof(YandereScript));
			if (this.Yandere != null)
			{
				if (!this.Yandere.Trespassing)
				{
					this.Yandere.NotificationManager.DisplayNotification("Trespass");
				}
				this.Yandere.Trespassing = true;
			}
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
		}
		if (this.Yandere != null)
		{
			this.Yandere.Trespassing = false;
		}
	}

	public virtual void Main()
	{
	}
}
