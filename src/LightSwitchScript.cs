using System;
using UnityEngine;

[Serializable]
public class LightSwitchScript : MonoBehaviour
{
	public ToiletEventScript ToiletEvent;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform ElectrocutionSpot;

	public GameObject BathroomLight;

	public GameObject Electricity;

	public Rigidbody Panel;

	public Transform Wires;

	public AudioClip[] ReactionClips;

	public string[] ReactionTexts;

	public AudioClip[] Flick;

	public float SubtitleTimer;

	public float FlickerTimer;

	public int ReactionID;

	public bool Flicker;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (this.Flicker)
		{
			this.FlickerTimer += Time.deltaTime;
			if (this.FlickerTimer > 0.1f)
			{
				this.FlickerTimer = (float)0;
				if (!this.BathroomLight.active)
				{
					this.BathroomLight.active = true;
				}
				else
				{
					this.BathroomLight.active = false;
				}
			}
		}
		if (!this.Panel.useGravity)
		{
			if (this.Yandere.Armed)
			{
				if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 6)
				{
					this.Prompt.HideButton[3] = false;
				}
				else
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (this.BathroomLight.active)
			{
				this.Prompt.Label[0].text = "     " + "Turn On";
				this.BathroomLight.active = false;
				this.audio.clip = this.Flick[1];
				this.audio.Play();
				if (this.ToiletEvent.EventActive && (this.ToiletEvent.EventPhase == 2 || this.ToiletEvent.EventPhase == 3))
				{
					this.ReactionID = UnityEngine.Random.Range(1, 4);
					this.ToiletEvent.PlayClip(this.ReactionClips[this.ReactionID], this.ToiletEvent.EventStudent.transform.position);
					this.ToiletEvent.EventSubtitle.text = this.ReactionTexts[this.ReactionID];
					this.SubtitleTimer += Time.deltaTime;
				}
			}
			else
			{
				this.Prompt.Label[0].text = "     " + "Turn Off";
				this.BathroomLight.active = true;
				this.audio.clip = this.Flick[0];
				this.audio.Play();
			}
		}
		if (this.SubtitleTimer > (float)0)
		{
			this.SubtitleTimer += Time.deltaTime;
			if (this.SubtitleTimer > (float)3)
			{
				this.ToiletEvent.EventSubtitle.text = string.Empty;
				this.SubtitleTimer = (float)0;
			}
		}
		if (this.Prompt.Circle[3].fillAmount <= (float)0)
		{
			this.Prompt.HideButton[3] = true;
			int num = 1;
			Vector3 localScale = this.Wires.localScale;
			float num2 = localScale.z = (float)num;
			Vector3 vector = this.Wires.localScale = localScale;
			this.Panel.useGravity = true;
			this.Panel.AddForce((float)0, (float)0, (float)10);
		}
	}

	public virtual void Main()
	{
	}
}
