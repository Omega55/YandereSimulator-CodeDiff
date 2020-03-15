using System;
using UnityEngine;

public class RivalPhoneScript : MonoBehaviour
{
	public DoorGapScript StolenPhoneDropoff;

	public Renderer MyRenderer;

	public PromptScript Prompt;

	public bool LewdPhotos;

	public bool Stolen;

	public int StudentID;

	public Vector3 OriginalPosition;

	public Quaternion OriginalRotation;

	public Transform OriginalParent;

	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
	}

	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.StudentID == this.Prompt.Yandere.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(1) == 4)
			{
				SchemeGlobals.SetSchemeStage(1, 5);
				this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
			}
			this.Prompt.Yandere.RivalPhoneTexture = this.MyRenderer.material.mainTexture;
			this.Prompt.Yandere.Inventory.RivalPhone = true;
			this.Prompt.enabled = false;
			base.enabled = false;
			this.StolenPhoneDropoff.Prompt.enabled = true;
			this.StolenPhoneDropoff.Phase = 1;
			this.StolenPhoneDropoff.Timer = 0f;
			this.StolenPhoneDropoff.Prompt.Label[0].text = "     Provide Stolen Phone";
			base.gameObject.SetActive(false);
			this.Stolen = true;
		}
	}

	public void ReturnToOrigin()
	{
		base.transform.parent = this.OriginalParent;
		base.transform.localPosition = this.OriginalPosition;
		base.transform.localRotation = this.OriginalRotation;
		base.gameObject.SetActive(false);
		this.Prompt.enabled = true;
		this.LewdPhotos = false;
		this.Stolen = false;
		base.enabled = true;
	}
}
