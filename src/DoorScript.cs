using System;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	public Transform RelativeCharacter;

	public HideColliderScript HideCollider;

	public StudentScript Student;

	public YandereScript Yandere;

	public BucketScript Bucket;

	public PromptScript Prompt;

	public float[] ClosedPositions;

	public float[] OpenPositions;

	public Transform[] Doors;

	public Texture[] Plates;

	public UILabel[] Labels;

	public float[] OriginX;

	public bool CanSetBucket;

	public bool HidingSpot;

	public bool BucketSet;

	public bool Swinging;

	public bool Locked;

	public bool North;

	public bool Open;

	public bool Near;

	public float ShiftNorth = -0.1f;

	public float ShiftSouth = 0.1f;

	public float Rotation;

	public float Timer;

	public float TrapSwing = 12.15f;

	public float Swing = 150f;

	public Renderer Sign;

	public string RoomName = string.Empty;

	public string Facing = string.Empty;

	public int RoomID;

	public int Club;

	private void Start()
	{
		this.TrapSwing = 12.15f;
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		if (this.Swinging)
		{
			this.OriginX[0] = this.Doors[0].transform.localPosition.z;
			if (this.OriginX.Length > 1)
			{
				this.OriginX[1] = this.Doors[1].transform.localPosition.z;
			}
		}
		if (this.Labels.Length > 0)
		{
			this.Labels[0].text = this.RoomName;
			this.Labels[1].text = this.RoomName;
			this.UpdatePlate();
		}
		if (this.Club != 0 && PlayerPrefs.GetInt("Club_" + this.Club.ToString() + "_Closed") == 1)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 1f)
		{
			if (!this.Near)
			{
				this.TopicCheck();
				this.Yandere.Location.Label.text = this.RoomName;
				this.Yandere.Location.Show = true;
				this.Near = true;
			}
		}
		else if (this.Near)
		{
			this.Yandere.Location.Show = false;
			this.Near = false;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.CanSetBucket)
			{
				if (!this.Open)
				{
					this.OpenDoor();
				}
				else
				{
					this.CloseDoor();
				}
			}
			else
			{
				this.Bucket = this.Yandere.PickUp.Bucket;
				this.Yandere.EmptyHands();
				this.Bucket.transform.parent = base.transform;
				this.Bucket.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				this.Bucket.Trap = true;
				this.Bucket.Prompt.Hide();
				this.Bucket.Prompt.enabled = false;
				this.CheckDirection();
				if (this.North)
				{
					this.Bucket.transform.localPosition = new Vector3(0f, 2.25f, 0.2975f);
				}
				else
				{
					this.Bucket.transform.localPosition = new Vector3(0f, 2.25f, -0.2975f);
				}
				this.Bucket.GetComponent<Rigidbody>().isKinematic = true;
				this.Bucket.GetComponent<Rigidbody>().useGravity = false;
				this.CanSetBucket = false;
				this.BucketSet = true;
				this.Open = false;
				this.Timer = 0f;
				this.Prompt.enabled = false;
				this.Prompt.Hide();
			}
		}
		if (this.Timer < 2f)
		{
			this.Timer += Time.deltaTime;
			if (this.BucketSet)
			{
				for (int i = 0; i < this.Doors.Length; i++)
				{
					Transform transform = this.Doors[i];
					transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, this.OriginX[i] + ((!this.North) ? this.ShiftNorth : this.ShiftSouth), Time.deltaTime * 3.6f));
					this.Rotation = Mathf.Lerp(this.Rotation, (!this.North) ? this.TrapSwing : (-this.TrapSwing), Time.deltaTime * 3.6f);
					transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (i != 0) ? (-this.Rotation) : this.Rotation, transform.localEulerAngles.z);
				}
			}
			else if (!this.Open)
			{
				for (int j = 0; j < this.Doors.Length; j++)
				{
					Transform transform2 = this.Doors[j];
					if (!this.Swinging)
					{
						transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, this.ClosedPositions[j], Time.deltaTime * 3.6f), transform2.localPosition.y, transform2.localPosition.z);
					}
					else
					{
						this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 3.6f);
						transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, this.OriginX[j], Time.deltaTime * 3.6f));
						transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, (j != 0) ? (-this.Rotation) : this.Rotation, transform2.localEulerAngles.z);
					}
				}
			}
			else
			{
				for (int k = 0; k < this.Doors.Length; k++)
				{
					Transform transform3 = this.Doors[k];
					if (!this.Swinging)
					{
						transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, this.OpenPositions[k], Time.deltaTime * 3.6f), transform3.localPosition.y, transform3.localPosition.z);
					}
					else
					{
						transform3.localPosition = new Vector3(transform3.localPosition.x, transform3.localPosition.y, Mathf.Lerp(transform3.localPosition.z, this.OriginX[k] + ((!this.North) ? this.ShiftSouth : this.ShiftNorth), Time.deltaTime * 3.6f));
						this.Rotation = Mathf.Lerp(this.Rotation, (!this.North) ? (-this.Swing) : this.Swing, Time.deltaTime * 3.6f);
						transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, (k != 0) ? (-this.Rotation) : this.Rotation, transform3.localEulerAngles.z);
					}
				}
			}
		}
		else if (this.Locked && this.Prompt.Circle[0].fillAmount < 1f)
		{
			this.Prompt.Label[0].text = "     Locked";
			this.Prompt.Circle[0].fillAmount = 1f;
		}
		if (this.Swinging)
		{
			if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Bucket != null)
				{
					if (this.Yandere.PickUp.GetComponent<BucketScript>().Full)
					{
						this.Prompt.Label[0].text = "     Set Trap";
						this.CanSetBucket = true;
					}
					else if (this.CanSetBucket)
					{
						this.CanSetBucket = false;
						this.UpdateLabel();
					}
				}
				else if (this.CanSetBucket)
				{
					this.CanSetBucket = false;
					this.UpdateLabel();
				}
			}
			else if (this.CanSetBucket)
			{
				this.CanSetBucket = false;
				this.UpdateLabel();
			}
		}
	}

	public void OpenDoor()
	{
		this.Open = true;
		this.Timer = 0f;
		this.UpdateLabel();
		if (this.HidingSpot)
		{
			UnityEngine.Object.Destroy(this.HideCollider.GetComponent<BoxCollider>());
		}
		this.CheckDirection();
		if (this.BucketSet)
		{
			this.Bucket.GetComponent<Rigidbody>().isKinematic = false;
			this.Bucket.GetComponent<Rigidbody>().useGravity = true;
			this.Bucket.Prompt.enabled = true;
			this.Bucket.Full = false;
			this.Bucket.Fly = true;
			this.Prompt.enabled = true;
			this.BucketSet = false;
		}
	}

	private void LockDoor()
	{
		this.Open = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	private void CheckDirection()
	{
		this.North = false;
		this.RelativeCharacter = ((!(this.Student != null)) ? this.Yandere.transform : this.Student.transform);
		if (this.Facing == "North")
		{
			if (this.RelativeCharacter.position.z < base.transform.position.z)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "South")
		{
			if (this.RelativeCharacter.position.z > base.transform.position.z)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "East")
		{
			if (this.RelativeCharacter.position.x < base.transform.position.x)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "West" && this.RelativeCharacter.position.x > base.transform.position.x)
		{
			this.North = true;
		}
		this.Student = null;
	}

	public void CloseDoor()
	{
		this.Open = false;
		this.Timer = 0f;
		this.UpdateLabel();
		if (this.HidingSpot)
		{
			this.HideCollider.gameObject.AddComponent<BoxCollider>();
			BoxCollider component = this.HideCollider.GetComponent<BoxCollider>();
			component.size = new Vector3(component.size.x, component.size.y, 2f);
			component.isTrigger = true;
			this.HideCollider.MyCollider = component;
		}
	}

	private void UpdateLabel()
	{
		if (this.Open)
		{
			this.Prompt.Label[0].text = "     Close";
		}
		else
		{
			this.Prompt.Label[0].text = "     Open";
		}
	}

	private void UpdatePlate()
	{
		switch (this.RoomID)
		{
		case 1:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			break;
		case 2:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			break;
		case 3:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			break;
		case 4:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0f);
			break;
		case 5:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
			break;
		case 6:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
			break;
		case 7:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
			break;
		case 8:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
			break;
		case 9:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
			break;
		case 10:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			break;
		case 11:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
			break;
		case 12:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
			break;
		case 13:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
			break;
		case 14:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
			break;
		case 15:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
			break;
		case 16:
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
			break;
		case 17:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			break;
		case 18:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			break;
		case 19:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.25f);
			break;
		case 20:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0f);
			break;
		case 21:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
			break;
		case 22:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
			break;
		case 23:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
			break;
		case 24:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0f);
			break;
		case 25:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
			break;
		case 26:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			break;
		case 27:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
			break;
		case 28:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0f);
			break;
		case 29:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
			break;
		case 30:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
			break;
		case 31:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
			break;
		case 32:
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0f);
			break;
		case 33:
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.75f);
			break;
		case 34:
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2(0f, 0.5f);
			break;
		}
	}

	private void TopicCheck()
	{
		switch (this.RoomID)
		{
		case 3:
			if (PlayerPrefs.GetInt("Topic_12_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_12_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 13:
			if (PlayerPrefs.GetInt("Topic_21_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_21_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 15:
			if (PlayerPrefs.GetInt("Topic_16_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_16_Discovered", 1);
				PlayerPrefs.SetInt("Topic_17_Discovered", 1);
				PlayerPrefs.SetInt("Topic_18_Discovered", 1);
				PlayerPrefs.SetInt("Topic_19_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 26:
			if (PlayerPrefs.GetInt("Topic_1_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_1_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 27:
			if (PlayerPrefs.GetInt("Topic_2_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_2_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 28:
			if (PlayerPrefs.GetInt("Topic_3_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_3_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 29:
			if (PlayerPrefs.GetInt("Topic_4_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_4_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 30:
			if (PlayerPrefs.GetInt("Topic_5_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_5_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 31:
			if (PlayerPrefs.GetInt("Topic_6_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_6_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 32:
			if (PlayerPrefs.GetInt("Topic_7_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_7_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		case 34:
			if (PlayerPrefs.GetInt("Topic_8_Discovered") == 0)
			{
				PlayerPrefs.SetInt("Topic_8_Discovered", 1);
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
			}
			break;
		}
	}
}
