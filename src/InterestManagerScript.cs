using System;
using UnityEngine;

[Serializable]
public class InterestManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public Transform MartialArts;

	public Transform OccultClub;

	public Transform VideoGames;

	public Transform Kitten;

	public virtual void Update()
	{
		if (this.Yandere.Follower != null && this.Yandere.Follower.StudentID == 7)
		{
			if (PlayerPrefs.GetInt("Topic_3_Student_7_Learned") == 0 && Vector3.Distance(this.Yandere.Follower.transform.position, this.OccultClub.position) < (float)5)
			{
				if (PlayerPrefs.GetInt("Topic_3_Discovered") == 0)
				{
					this.Yandere.NotificationManager.DisplayNotification("Topic");
					PlayerPrefs.SetInt("Topic_3_Discovered", 1);
				}
				this.Yandere.NotificationManager.DisplayNotification("Opinion");
				PlayerPrefs.SetInt("Topic_3_Student_7_Learned", 1);
			}
			if (PlayerPrefs.GetInt("Topic_14_Student_7_Learned") == 0 && this.StudentManager.Students[22] != null && this.StudentManager.Students[25] != null && this.StudentManager.Students[22].Actions[this.StudentManager.Students[22].Phase] == 8 && this.StudentManager.Students[22].DistanceToDestination < (float)1 && this.StudentManager.Students[24].Actions[this.StudentManager.Students[24].Phase] == 8 && this.StudentManager.Students[24].DistanceToDestination < (float)1 && Vector3.Distance(this.Yandere.Follower.transform.position, this.MartialArts.position) < (float)5)
			{
				if (PlayerPrefs.GetInt("Topic_14_Discovered") == 0)
				{
					this.Yandere.NotificationManager.DisplayNotification("Topic");
					PlayerPrefs.SetInt("Topic_14_Discovered", 1);
				}
				this.Yandere.NotificationManager.DisplayNotification("Opinion");
				PlayerPrefs.SetInt("Topic_14_Student_7_Learned", 1);
			}
			if (PlayerPrefs.GetInt("Topic_16_Student_7_Learned") == 0 && this.StudentManager.Students[22] != null && this.StudentManager.Students[25] != null && this.VideoGames.gameObject.active && Vector3.Distance(this.Yandere.Follower.transform.position, this.VideoGames.position) < 2.5f)
			{
				if (PlayerPrefs.GetInt("Topic_16_Discovered") == 0)
				{
					this.Yandere.NotificationManager.DisplayNotification("Topic");
					PlayerPrefs.SetInt("Topic_16_Discovered", 1);
				}
				this.Yandere.NotificationManager.DisplayNotification("Opinion");
				PlayerPrefs.SetInt("Topic_16_Student_7_Learned", 1);
			}
			if (PlayerPrefs.GetInt("Topic_20_Student_7_Learned") == 0 && Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5f)
			{
				if (PlayerPrefs.GetInt("Topic_20_Discovered") == 0)
				{
					this.Yandere.NotificationManager.DisplayNotification("Topic");
					PlayerPrefs.SetInt("Topic_20_Discovered", 1);
				}
				this.Yandere.NotificationManager.DisplayNotification("Opinion");
				PlayerPrefs.SetInt("Topic_20_Student_7_Learned", 1);
			}
		}
	}

	public virtual void Main()
	{
	}
}
