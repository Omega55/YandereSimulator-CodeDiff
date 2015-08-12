using System;
using UnityEngine;

[Serializable]
public class TapePlayerScript : MonoBehaviour
{
	public TapePlayerMenuScript TapePlayerMenu;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform RWButton;

	public Transform FFButton;

	public Camera TapePlayerCamera;

	public Transform[] Rolls;

	public GameObject Tape;

	public bool FastForward;

	public bool Rewind;

	public bool Spin;

	public float SpinSpeed;

	public virtual void Start()
	{
		this.Tape.active = false;
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.HeartCamera.enabled = false;
			this.TapePlayerCamera.enabled = true;
			this.TapePlayerMenu.UpdateLabels();
			this.TapePlayerMenu.Show = true;
			this.Yandere.CanMove = false;
			this.Yandere.HUD.alpha = (float)0;
			Time.timeScale = (float)0;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "EXIT";
			this.PromptBar.Label[4].text = "CHOOSE";
			this.TapePlayerMenu.CheckSelection();
			this.PromptBar.Show = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Spin)
		{
			float y = this.Rolls[0].localEulerAngles.y + 6f * this.SpinSpeed;
			Vector3 localEulerAngles = this.Rolls[0].localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.Rolls[0].localEulerAngles = localEulerAngles;
			float y2 = this.Rolls[1].localEulerAngles.y + 6f * this.SpinSpeed;
			Vector3 localEulerAngles2 = this.Rolls[1].localEulerAngles;
			float num2 = localEulerAngles2.y = y2;
			Vector3 vector2 = this.Rolls[1].localEulerAngles = localEulerAngles2;
		}
		if (this.FastForward)
		{
			float x = Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 6.25f, 1.66666663f);
			Vector3 localEulerAngles3 = this.FFButton.localEulerAngles;
			float num3 = localEulerAngles3.x = x;
			Vector3 vector3 = this.FFButton.localEulerAngles = localEulerAngles3;
			this.SpinSpeed = (float)2;
		}
		else
		{
			float x2 = Mathf.MoveTowards(this.FFButton.localEulerAngles.x, (float)0, 1.66666663f);
			Vector3 localEulerAngles4 = this.FFButton.localEulerAngles;
			float num4 = localEulerAngles4.x = x2;
			Vector3 vector4 = this.FFButton.localEulerAngles = localEulerAngles4;
			this.SpinSpeed = (float)1;
		}
		if (this.Rewind)
		{
			float x3 = Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 6.25f, 1.66666663f);
			Vector3 localEulerAngles5 = this.RWButton.localEulerAngles;
			float num5 = localEulerAngles5.x = x3;
			Vector3 vector5 = this.RWButton.localEulerAngles = localEulerAngles5;
			this.SpinSpeed = (float)-2;
		}
		else
		{
			float x4 = Mathf.MoveTowards(this.RWButton.localEulerAngles.x, (float)0, 1.66666663f);
			Vector3 localEulerAngles6 = this.RWButton.localEulerAngles;
			float num6 = localEulerAngles6.x = x4;
			Vector3 vector6 = this.RWButton.localEulerAngles = localEulerAngles6;
		}
	}

	public virtual void Main()
	{
	}
}
