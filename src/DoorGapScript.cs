using System;
using UnityEngine;

[Serializable]
public class DoorGapScript : MonoBehaviour
{
	public AnswerSheetScript AnswerSheet;

	public SchemesScript Schemes;

	public PromptScript Prompt;

	public Transform[] Papers;

	public float Timer;

	public int Phase;

	public DoorGapScript()
	{
		this.Phase = 1;
	}

	public virtual void Start()
	{
		this.Papers[1].active = false;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			if (this.Phase == 1)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Papers[1].gameObject.active = true;
				PlayerPrefs.SetInt("Scheme_5_Stage", 3);
				this.Schemes.UpdateInstructions();
				this.audio.Play();
			}
			else
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Yandere.Inventory.DuplicateSheet = true;
				this.Papers[2].gameObject.active = false;
				this.AnswerSheet.Prompt.enabled = true;
				PlayerPrefs.SetInt("Scheme_5_Stage", 4);
				this.Schemes.UpdateInstructions();
			}
			this.Phase++;
		}
		if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)4)
			{
				this.Prompt.Label[0].text = "     " + "Pick Up Sheets";
				this.Prompt.enabled = true;
				this.Phase = 2;
			}
			else if (this.Timer > (float)3)
			{
				float z = Mathf.Lerp(this.Papers[2].localPosition.z, -0.166f, Time.deltaTime * (float)10);
				Vector3 localPosition = this.Papers[2].localPosition;
				float num = localPosition.z = z;
				Vector3 vector = this.Papers[2].localPosition = localPosition;
			}
			else if (this.Timer > (float)1)
			{
				float z2 = Mathf.Lerp(this.Papers[1].localPosition.z, 0.166f, Time.deltaTime * (float)10);
				Vector3 localPosition2 = this.Papers[1].localPosition;
				float num2 = localPosition2.z = z2;
				Vector3 vector2 = this.Papers[1].localPosition = localPosition2;
			}
		}
	}

	public virtual void Main()
	{
	}
}
