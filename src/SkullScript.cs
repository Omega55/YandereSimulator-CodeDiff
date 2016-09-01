using System;
using UnityEngine;

[Serializable]
public class SkullScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	public GameObject HeartbeatCamera;

	public GameObject RitualKnife;

	public GameObject DebugMenu;

	public GameObject DarkAura;

	public GameObject FPS;

	public GameObject HUD;

	public UISprite Darkness;

	public float Timer;

	public virtual void Start()
	{
		this.OriginalPosition = this.RitualKnife.transform.position;
		this.OriginalRotation = this.RitualKnife.transform.eulerAngles;
	}

	public virtual void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 8)
			{
				this.Prompt.enabled = true;
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.Weapon[this.Yandere.Equipped].Drop();
			this.Yandere.Weapon[this.Yandere.Equipped] = null;
			this.Yandere.Unequip();
			this.Yandere.DropTimer[this.Yandere.Equipped] = (float)0;
			this.RitualKnife.transform.position = this.OriginalPosition;
			this.RitualKnife.transform.eulerAngles = this.OriginalRotation;
			this.RitualKnife.rigidbody.useGravity = false;
			if (((WeaponScript)this.RitualKnife.GetComponent(typeof(WeaponScript))).Blood.enabled)
			{
				this.DebugMenu.active = false;
				this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.CanMove = false;
				UnityEngine.Object.Instantiate(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
				this.Timer += Time.deltaTime;
				this.Clock.StopTime = true;
			}
		}
		if (this.Timer > (float)0)
		{
			if (this.Yandere.transform.position.y < (float)1000)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)4)
				{
					this.Darkness.enabled = true;
					float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
					Color color = this.Darkness.color;
					float num = color.a = a;
					Color color2 = this.Darkness.color = color;
					if (this.Darkness.color.a == (float)1)
					{
						this.Yandere.transform.position = new Vector3((float)0, (float)2000, (float)0);
						this.Yandere.Character.active = true;
						this.Yandere.SetAnimationLayers();
						this.HeartbeatCamera.active = false;
						this.FPS.active = false;
						this.HUD.active = false;
					}
				}
				else if (this.Timer > (float)1)
				{
					this.Yandere.Character.active = false;
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, (float)0, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == (float)0)
				{
					float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
					Color color3 = this.Darkness.color;
					float num2 = color3.a = a2;
					Color color4 = this.Darkness.color = color3;
					if (this.Darkness.color.a == (float)0)
					{
						this.Yandere.CanMove = true;
						this.Timer = (float)0;
					}
				}
			}
		}
		if (this.Yandere.Egg)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
