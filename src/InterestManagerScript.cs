using System;
using UnityEngine;

public class InterestManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public Transform MartialArts;

	public Transform OccultClub;

	public Transform VideoGames;

	public Transform Kitten;

	private void Update()
	{
		if (this.Yandere.Follower != null && this.Yandere.Follower.StudentID == 7)
		{
			if (!ConversationGlobals.GetTopicLearnedByStudent(3, 7) && Vector3.Distance(this.Yandere.Follower.transform.position, this.OccultClub.position) < 5f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(3))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(3, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(3, 7, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(14, 7))
			{
				StudentScript studentScript = this.StudentManager.Students[22];
				StudentScript studentScript2 = this.StudentManager.Students[24];
				StudentScript x = this.StudentManager.Students[25];
				if (studentScript != null && x != null && studentScript.Actions[studentScript.Phase] == StudentActionType.ClubAction && studentScript.DistanceToDestination < 1f && studentScript2.Actions[studentScript2.Phase] == StudentActionType.ClubAction && studentScript2.DistanceToDestination < 1f && Vector3.Distance(this.Yandere.Follower.transform.position, this.MartialArts.position) < 5f)
				{
					if (!ConversationGlobals.GetTopicDiscovered(14))
					{
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						ConversationGlobals.SetTopicDiscovered(14, true);
					}
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					ConversationGlobals.SetTopicLearnedByStudent(14, 7, true);
				}
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(16, 7))
			{
				StudentScript x2 = this.StudentManager.Students[22];
				StudentScript x3 = this.StudentManager.Students[25];
				if (x2 != null && x3 != null && this.VideoGames.gameObject.activeInHierarchy && Vector3.Distance(this.Yandere.Follower.transform.position, this.VideoGames.position) < 2.5f)
				{
					if (!ConversationGlobals.GetTopicDiscovered(16))
					{
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						ConversationGlobals.SetTopicDiscovered(16, true);
					}
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					ConversationGlobals.SetTopicLearnedByStudent(16, 7, true);
				}
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(20, 7) && Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5f)
			{
				if (!ConversationGlobals.GetTopicDiscovered(20))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(20, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(20, 7, true);
			}
		}
	}
}
