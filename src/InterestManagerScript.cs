using System;
using UnityEngine;

public class InterestManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public Transform[] Clubs;

	public Transform DelinquentZone;

	public Transform Library;

	public Transform Kitten;

	private void Update()
	{
		if (this.Yandere.Follower != null)
		{
			int studentID = this.Yandere.Follower.StudentID;
			for (int i = 1; i < 11; i++)
			{
				if (!ConversationGlobals.GetTopicLearnedByStudent(i, studentID) && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[i].position) < 5f)
				{
					if (!ConversationGlobals.GetTopicDiscovered(i))
					{
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						ConversationGlobals.SetTopicDiscovered(i, true);
					}
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					ConversationGlobals.SetTopicLearnedByStudent(i, studentID, true);
				}
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(11, studentID) && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[11].position) < 5f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(11))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(11, true);
					ConversationGlobals.SetTopicDiscovered(12, true);
					ConversationGlobals.SetTopicDiscovered(13, true);
					ConversationGlobals.SetTopicDiscovered(14, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(11, studentID, true);
				ConversationGlobals.SetTopicLearnedByStudent(12, studentID, true);
				ConversationGlobals.SetTopicLearnedByStudent(13, studentID, true);
				ConversationGlobals.SetTopicLearnedByStudent(14, studentID, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(15, studentID) && Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(15))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(15, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(15, studentID, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(16, studentID) && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[6].position) < 5f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(16))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(16, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(16, studentID, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(17, studentID) && Vector3.Distance(this.Yandere.Follower.transform.position, this.DelinquentZone.position) < 5f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(17))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(17, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(17, studentID, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(18, studentID) && Vector3.Distance(this.Yandere.Follower.transform.position, this.Library.position) < 5f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(18))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(18, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(18, studentID, true);
			}
		}
	}
}
