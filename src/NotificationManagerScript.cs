using System;
using UnityEngine;

[Serializable]
public class NotificationManagerScript : MonoBehaviour
{
	public Transform NotificationSpawnPoint;

	public Transform NotificationParent;

	public GameObject Notification;

	public int NotificationsSpawned;

	public virtual void Update()
	{
		float y = Mathf.Lerp(this.NotificationParent.localPosition.y, -0.049f * (float)this.NotificationsSpawned, Time.deltaTime * (float)10);
		Vector3 localPosition = this.NotificationParent.localPosition;
		float num = localPosition.y = y;
		Vector3 vector = this.NotificationParent.localPosition = localPosition;
	}

	public virtual void DisplayNotification(string Type)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Notification);
		NotificationScript notificationScript = (NotificationScript)gameObject.GetComponent(typeof(NotificationScript));
		gameObject.transform.parent = this.NotificationParent;
		gameObject.transform.localPosition = new Vector3((float)0, 0.60275f + 0.049f * (float)this.NotificationsSpawned, (float)0);
		gameObject.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		notificationScript.NotificationManager = this;
		if (Type == "Bloody")
		{
			notificationScript.Label.text = "Visibly Bloody";
		}
		else if (Type == "Body")
		{
			notificationScript.Label.text = "Near Body";
		}
		else if (Type == "Insane")
		{
			notificationScript.Label.text = "Visibly Insane";
		}
		else if (Type == "Armed")
		{
			notificationScript.Label.text = "Visibly Armed";
		}
		this.NotificationsSpawned++;
		notificationScript.ID = this.NotificationsSpawned;
	}

	public virtual void Main()
	{
	}
}
