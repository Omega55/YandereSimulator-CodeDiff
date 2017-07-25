using System;
using UnityEngine;

public class RingEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventOver;

	public float EventTime = 13.1f;

	public int EventPhase = 1;

	public Vector3 OriginalPosition;

	public Vector3 HoldingPosition;

	public Vector3 HoldingRotation;

	public float CurrentClipLength;

	public float Timer;

	public PromptScript RingPrompt;

	public Collider RingCollider;

	private void Start()
	{
		this.HoldingPosition = new Vector3(0.0075f, -0.0355f, 0.0175f);
		this.HoldingRotation = new Vector3(15f, -70f, -135f);
	}

	private void Update()
	{
		if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[17];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					if (this.EventStudent.Cosmetic.FemaleAccessories[3].activeInHierarchy)
					{
						if (PlayerPrefs.GetInt("Scheme_2_Stage") < 100)
						{
							this.RingPrompt = this.EventStudent.Cosmetic.FemaleAccessories[3].GetComponent<PromptScript>();
							this.RingCollider = this.EventStudent.Cosmetic.FemaleAccessories[3].GetComponent<BoxCollider>();
							this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
							this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
							this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
							this.EventStudent.Obstacle.checkTime = 99f;
							this.EventStudent.InEvent = true;
							this.EventStudent.Private = true;
							this.EventStudent.Prompt.Hide();
							this.EventActive = true;
							if (this.EventStudent.Following)
							{
								this.EventStudent.Pathfinding.canMove = true;
								this.EventStudent.Pathfinding.speed = 1f;
								this.EventStudent.Following = false;
								this.EventStudent.Routine = true;
								this.Yandere.Followers--;
								this.EventStudent.Subtitle.UpdateLabel("Stop Follow Apology", 0, 3f);
								this.EventStudent.Prompt.Label[0].text = "     Talk";
							}
						}
						else
						{
							base.enabled = false;
						}
					}
					else
					{
						base.enabled = false;
					}
				}
				else
				{
					base.enabled = false;
				}
			}
		}
		if (this.EventActive)
		{
			if (this.EventStudent.DistanceToDestination < 0.5f)
			{
				this.EventStudent.Pathfinding.canSearch = false;
				this.EventStudent.Pathfinding.canMove = false;
			}
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || this.EventStudent.Dead)
			{
				this.EndEvent();
			}
			else if (!this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					this.Timer += Time.deltaTime;
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[0]);
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[0]].length)
					{
						this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.EatAnim);
						this.EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
						this.EventStudent.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
						this.EventStudent.Chopsticks[0].SetActive(true);
						this.EventStudent.Chopsticks[1].SetActive(true);
						this.EventStudent.Bento.SetActive(true);
						this.EventStudent.Lid.SetActive(false);
						this.RingCollider.enabled = true;
						this.EventPhase++;
						this.Timer = 0f;
					}
					else if (this.Timer > 4f)
					{
						if (this.EventStudent.Cosmetic.FemaleAccessories[3] != null)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = null;
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.position = new Vector3(-2.712f, 12.47f, -31.136f);
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.eulerAngles = new Vector3(-20f, 180f, 0f);
						}
					}
					else if (this.Timer > 2.5f)
					{
						this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = this.EventStudent.RightHand;
						this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition = this.HoldingPosition;
						this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localEulerAngles = this.HoldingRotation;
					}
				}
				else if (this.EventPhase == 3)
				{
					if (this.Clock.HourTime > 13.375f)
					{
						this.EventStudent.Bento.SetActive(false);
						this.EventStudent.Chopsticks[0].SetActive(false);
						this.EventStudent.Chopsticks[1].SetActive(false);
						if (this.RingCollider != null)
						{
							this.RingCollider.enabled = false;
						}
						if (this.RingPrompt != null)
						{
							this.RingPrompt.Hide();
							this.RingPrompt.enabled = false;
						}
						this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[0]].time = this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[0]].length;
						this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[0]].speed = -1f;
						this.EventStudent.Character.GetComponent<Animation>().CrossFade((!(this.EventStudent.Cosmetic.FemaleAccessories[3] != null)) ? this.EventAnim[1] : this.EventAnim[0]);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					this.Timer += Time.deltaTime;
					if (this.EventStudent.Cosmetic.FemaleAccessories[3] != null)
					{
						if (this.Timer > 2f)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = this.EventStudent.RightHand;
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition = this.HoldingPosition;
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localEulerAngles = this.HoldingRotation;
						}
						if (this.Timer > 3f)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = this.EventStudent.LeftMiddleFinger;
							this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition = this.OriginalPosition;
							this.RingCollider.enabled = false;
						}
						if (this.Timer > 5f)
						{
							this.EndEvent();
						}
					}
					else if (this.Timer > 1.5f && this.Yandere.transform.position.z < 0f)
					{
						this.EventSubtitle.text = this.EventSpeech[0];
						this.PlayClip(this.EventClip[0], this.EventStudent.transform.position + Vector3.up);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 5)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 9.5f)
					{
						this.EndEvent();
					}
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num < 11f)
				{
					if (num < 10f)
					{
						float num2 = Mathf.Abs((num - 10f) * 0.2f);
						if (num2 < 0f)
						{
							num2 = 0f;
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
					}
					else
					{
						this.EventSubtitle.transform.localScale = Vector3.zero;
					}
				}
			}
		}
	}

	private void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		this.CurrentClipLength = clip.length;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = 5f;
		audioSource.maxDistance = 10f;
		audioSource.spatialBlend = 1f;
		this.VoiceClip = gameObject;
	}

	private void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
			}
			this.EventStudent.Pathfinding.speed = 1f;
			this.EventStudent.TargetDistance = 1f;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents();
		}
		this.EventActive = false;
		base.enabled = false;
	}

	public void ReturnRing()
	{
		if (this.EventStudent.Cosmetic.FemaleAccessories[3] != null)
		{
			this.EventStudent.Cosmetic.FemaleAccessories[3].transform.parent = this.EventStudent.LeftMiddleFinger;
			this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition = this.OriginalPosition;
			this.RingCollider.enabled = false;
			this.RingPrompt.Hide();
			this.RingPrompt.enabled = false;
		}
	}
}
