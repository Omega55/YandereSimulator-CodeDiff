using System;
using UnityEngine;

[Serializable]
public class DumpsterLidScript : MonoBehaviour
{
	public Transform GarbageDebris;

	public Transform Hinge;

	public GameObject FallChecker;

	public GameObject Corpse;

	public PromptScript Prompt;

	public float DisposalSpot;

	public float Rotation;

	public bool Fill;

	public bool Open;

	public virtual void Start()
	{
		this.FallChecker.active = false;
		this.Prompt.HideButton[3] = true;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Open)
			{
				this.Open = true;
			}
			else
			{
				this.Open = false;
			}
		}
		if (!this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
			this.Prompt.HideButton[3] = true;
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)-115, Time.deltaTime * (float)10);
			if (this.Corpse != null)
			{
				if (this.Prompt.Yandere.PickUp != null)
				{
					if (this.Prompt.Yandere.PickUp.Garbage)
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
			else
			{
				this.Prompt.HideButton[3] = true;
			}
			if (this.Prompt.Circle[3].fillAmount <= (float)0)
			{
				UnityEngine.Object.Destroy(this.Prompt.Yandere.PickUp.gameObject);
				this.Prompt.Circle[3].fillAmount = (float)1;
				this.Prompt.HideButton[3] = false;
				this.Fill = true;
			}
			if (this.transform.position.x > this.DisposalSpot - 0.05f && this.transform.position.x < this.DisposalSpot + 0.05f)
			{
				if (this.Prompt.Yandere.RoofPush)
				{
					this.FallChecker.active = true;
				}
				else
				{
					this.FallChecker.active = false;
				}
			}
			else
			{
				this.FallChecker.active = false;
			}
		}
		this.Hinge.localEulerAngles = new Vector3(this.Rotation, (float)0, (float)0);
		if (this.Fill)
		{
			float y = Mathf.Lerp(this.GarbageDebris.localPosition.y, (float)1, Time.deltaTime * (float)10);
			Vector3 localPosition = this.GarbageDebris.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.GarbageDebris.localPosition = localPosition;
			if (this.GarbageDebris.localPosition.y > 0.99f)
			{
				this.Prompt.Yandere.Police.SuicideScene = false;
				this.Prompt.Yandere.Police.Suicide = false;
				this.Prompt.Yandere.Police.HiddenCorpses = this.Prompt.Yandere.Police.HiddenCorpses - 1;
				this.Prompt.Yandere.Police.Corpses = this.Prompt.Yandere.Police.Corpses - 1;
				int num2 = 1;
				Vector3 localPosition2 = this.GarbageDebris.localPosition;
				float num3 = localPosition2.y = (float)num2;
				Vector3 vector2 = this.GarbageDebris.localPosition = localPosition2;
				UnityEngine.Object.Destroy(this.Corpse);
				this.Fill = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
