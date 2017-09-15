using System;
using UnityEngine;

public class AudioSoftwareScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Quaternion targetRotation;

	public Collider ChairCollider;

	public UILabel EventSubtitle;

	public GameObject Screen;

	public Transform SitSpot;

	public bool ConversationRecorded;

	public bool AudioDoctored;

	public bool Editing;

	public float Timer;

	private void Start()
	{
		this.Screen.SetActive(false);
	}

	private void Update()
	{
		if (this.ConversationRecorded && this.Yandere.Inventory.RivalPhone)
		{
			if (!this.Prompt.enabled)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_01");
			this.Yandere.MyController.radius = 0.1f;
			this.Yandere.CanMove = false;
			base.GetComponent<AudioSource>().Play();
			this.ChairCollider.enabled = false;
			this.Screen.SetActive(true);
			this.Editing = true;
		}
		if (this.Editing)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Screen.transform.position.x, this.Yandere.transform.position.y, this.Screen.transform.position.z) - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(this.SitSpot.position);
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.EventSubtitle.text = "Okay, how 'bout that boy from class 3-2? What do you think of him?";
			}
			if (this.Timer > 7f)
			{
				this.EventSubtitle.text = "He's just my childhood friend.";
			}
			if (this.Timer > 9f)
			{
				this.EventSubtitle.text = "Is he your boyfriend?";
			}
			if (this.Timer > 11f)
			{
				this.EventSubtitle.text = "What? HIM? Ugh, no way! That guy's a total creep! I wouldn't date him if he was the last man alive on earth! He can go jump off a cliff for all I care!";
			}
			if (this.Timer > 22f)
			{
				this.Yandere.MyController.radius = 0.2f;
				this.Yandere.CanMove = true;
				this.ChairCollider.enabled = false;
				this.EventSubtitle.text = string.Empty;
				this.Screen.SetActive(false);
				this.AudioDoctored = true;
				this.Editing = false;
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				base.enabled = false;
			}
		}
	}
}
