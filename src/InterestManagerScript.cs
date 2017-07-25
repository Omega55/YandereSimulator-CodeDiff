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
			if (PlayerPrefs.GetInt("Topic_3_Student_7_Learned") == 0 && Vector3.Distance(this.Yandere.Follower.transform.position, this.OccultClub.position) < 5f)
			{
				if (PlayerPrefs.GetInt("Topic_3_Discovered") == 0)
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					PlayerPrefs.SetInt("Topic_3_Discovered", 1);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				PlayerPrefs.SetInt("Topic_3_Student_7_Learned", 1);
			}
			if (PlayerPrefs.GetInt("Topic_14_Student_7_Learned") == 0)
			{
				StudentScript studentScript = this.StudentManager.Students[22];
				StudentScript studentScript2 = this.StudentManager.Students[24];
				StudentScript x = this.StudentManager.Students[25];
				if (studentScript != null && x != null && studentScript.Actions[studentScript.Phase] == StudentActionType.ClubAction && studentScript.DistanceToDestination < 1f && studentScript2.Actions[studentScript2.Phase] == StudentActionType.ClubAction && studentScript2.DistanceToDestination < 1f && Vector3.Distance(this.Yandere.Follower.transform.position, this.MartialArts.position) < 5f)
				{
					if (PlayerPrefs.GetInt("Topic_14_Discovered") == 0)
					{
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						PlayerPrefs.SetInt("Topic_14_Discovered", 1);
					}
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					PlayerPrefs.SetInt("Topic_14_Student_7_Learned", 1);
				}
			}
			if (PlayerPrefs.GetInt("Topic_16_Student_7_Learned") == 0)
			{
				StudentScript x2 = this.StudentManager.Students[22];
				StudentScript x3 = this.StudentManager.Students[25];
				if (x2 != null && x3 != null && this.VideoGames.gameObject.activeInHierarchy && Vector3.Distance(this.Yandere.Follower.transform.position, this.VideoGames.position) < 2.5f)
				{
					if (PlayerPrefs.GetInt("Topic_16_Discovered") == 0)
					{
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
						PlayerPrefs.SetInt("Topic_16_Discovered", 1);
					}
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					PlayerPrefs.SetInt("Topic_16_Student_7_Learned", 1);
				}
			}
			if (PlayerPrefs.GetInt("Topic_20_Student_7_Learned") == 0 && Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5f)
			{
				if (PlayerPrefs.GetInt("Topic_20_Discovered") == 0)
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					PlayerPrefs.SetInt("Topic_20_Discovered", 1);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				PlayerPrefs.SetInt("Topic_20_Student_7_Learned", 1);
			}
		}
	}
}
