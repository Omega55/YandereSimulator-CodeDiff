using System;
using UnityEngine;

public class GardeningClubMemberScript : MonoBehaviour
{
	public PickpocketMinigameScript PickpocketMinigame;

	public DetectionMarkerScript DetectionMarker;

	public CameraEffectsScript CameraEffects;

	public CabinetDoorScript CabinetDoor;

	public ReputationScript Reputation;

	public SubtitleScript Subtitle;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public DoorScript ShedDoor;

	public AIPath Pathfinding;

	public UIPanel PickpocketPanel;

	public UISprite TimeBar;

	public Transform PickpocketSpot;

	public Transform Destination;

	public GameObject Marker;

	public GameObject Key;

	public bool Leader;

	public bool Angry;

	public string IdleAnim = string.Empty;

	public string WalkAnim = string.Empty;

	public float Timer;

	public int Phase = 1;

	public int ID = 1;

	public GardeningClubMemberScript ClubLeader;

	public Camera VisionCone;

	public Transform Eyes;

	public float Alarm;

	private void Start()
	{
		Animation component = base.GetComponent<Animation>();
		component["f02_angryFace_00"].layer = 2;
		component.Play("f02_angryFace_00");
		component["f02_angryFace_00"].weight = 0f;
		if (!this.Leader && GameObject.Find("DetectionCamera") != null)
		{
			this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
			this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
			this.DetectionMarker.Target = base.transform;
		}
	}

	private void Update()
	{
		if (!this.Angry)
		{
			if (this.Phase == 1)
			{
				while (Vector3.Distance(base.transform.position, this.Destination.position) < 1f)
				{
					if (this.ID == 1)
					{
						this.Destination.position = new Vector3(UnityEngine.Random.Range(-60.75f, -73.25f), this.Destination.position.y, UnityEngine.Random.Range(-14.25f, 14.25f));
					}
					else
					{
						this.Destination.position = new Vector3(-25.5f + UnityEngine.Random.Range(-2.5f, 2.5f), this.Destination.position.y, -11f + UnityEngine.Random.Range(-4f, 4f));
					}
				}
				base.GetComponent<Animation>().CrossFade(this.WalkAnim);
				this.Pathfinding.enabled = true;
				if (this.Leader)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.PickpocketPanel.enabled = false;
				}
				this.Phase++;
			}
			else if (this.Pathfinding.enabled)
			{
				if (Vector3.Distance(base.transform.position, this.Destination.position) < 1f)
				{
					base.GetComponent<Animation>().CrossFade(this.IdleAnim);
					this.Pathfinding.enabled = false;
					if (this.Leader)
					{
						this.PickpocketPanel.enabled = true;
						this.Prompt.enabled = true;
					}
				}
			}
			else
			{
				this.Timer += Time.deltaTime;
				if (this.Leader)
				{
					this.TimeBar.fillAmount = 1f - this.Timer / base.GetComponent<Animation>()[this.IdleAnim].length;
				}
				if (this.Timer > base.GetComponent<Animation>()[this.IdleAnim].length)
				{
					if (this.Leader && this.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
					{
						this.PickpocketMinigame.End();
						this.Punish();
					}
					this.Timer = 0f;
					this.Phase = 1;
				}
			}
			if (this.Leader)
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
					this.PickpocketMinigame.Show = true;
					this.PickpocketMinigame.ID = this.ID;
					this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_pickpocketing_00");
					this.Yandere.Pickpocketing = true;
					this.Yandere.CanMove = false;
				}
				if (this.PickpocketMinigame.ID == this.ID)
				{
					if (this.PickpocketMinigame.Success)
					{
						this.PickpocketMinigame.Success = false;
						this.PickpocketMinigame.ID = 0;
						if (this.ID == 1)
						{
							this.ShedDoor.Prompt.Label[0].text = "     Open";
							this.ShedDoor.Locked = false;
							this.Yandere.Inventory.ShedKey = true;
						}
						else
						{
							this.CabinetDoor.Prompt.Label[0].text = "     Open";
							this.CabinetDoor.Locked = false;
							this.Yandere.Inventory.CabinetKey = true;
						}
						this.Prompt.gameObject.SetActive(false);
						this.Key.SetActive(false);
					}
					if (this.PickpocketMinigame.Failure)
					{
						this.PickpocketMinigame.Failure = false;
						this.PickpocketMinigame.ID = 0;
						this.Punish();
					}
				}
			}
			else
			{
				this.LookForYandere();
			}
		}
		else
		{
			Quaternion b = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 10f * Time.deltaTime);
			this.Timer += Time.deltaTime;
			if (this.Timer > 10f)
			{
				base.GetComponent<Animation>()["f02_angryFace_00"].weight = 0f;
				this.Angry = false;
				this.Timer = 0f;
			}
			else if (this.Timer > 1f && this.Phase == 0)
			{
				this.Subtitle.UpdateLabel("Pickpocket Reaction", 0, 8f);
				this.Phase++;
			}
		}
	}

	private void Punish()
	{
		Animation component = base.GetComponent<Animation>();
		component["f02_angryFace_00"].weight = 1f;
		component.CrossFade("idle_01");
		this.Reputation.PendingRep -= 10f;
		this.CameraEffects.Alarm();
		this.Angry = true;
		this.Phase = 0;
		this.Timer = 0f;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.PickpocketPanel.enabled = false;
	}

	private void LookForYandere()
	{
		float num = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
		if (num < this.VisionCone.farClipPlane)
		{
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
			if (GeometryUtility.TestPlanesAABB(planes, this.Yandere.GetComponent<Collider>().bounds))
			{
				Debug.DrawLine(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
				Vector3 end = new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z);
				RaycastHit raycastHit;
				if (Physics.Linecast(this.Eyes.transform.position, end, out raycastHit))
				{
					if (raycastHit.collider.gameObject == this.Yandere.gameObject)
					{
						if (this.Yandere.Pickpocketing)
						{
							if (!this.ClubLeader.Angry)
							{
								this.Alarm = Mathf.MoveTowards(this.Alarm, 100f, Time.deltaTime * (100f / num));
								if (this.Alarm == 100f)
								{
									this.PickpocketMinigame.End();
									this.ClubLeader.Punish();
								}
							}
							else
							{
								this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
							}
						}
						else
						{
							this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
						}
					}
					else
					{
						this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
					}
				}
				else
				{
					this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
				}
			}
			else
			{
				this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime * 100f);
			}
		}
		this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, this.Alarm / 100f, this.DetectionMarker.Tex.transform.localScale.z);
		if (this.Alarm > 0f)
		{
			if (!this.DetectionMarker.Tex.enabled)
			{
				this.DetectionMarker.Tex.enabled = true;
			}
			this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
		}
		else if (this.DetectionMarker.Tex.color.a != 0f)
		{
			this.DetectionMarker.Tex.enabled = false;
			this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
		}
	}
}
