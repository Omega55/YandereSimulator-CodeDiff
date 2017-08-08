using System;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public AudioClip FlameDemonVoice;

	public AudioClip FlameActivation;

	public GameObject HeartbeatCamera;

	public GameObject RitualKnife;

	public GameObject DebugMenu;

	public GameObject DarkAura;

	public GameObject FPS;

	public GameObject HUD;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	public UISprite Darkness;

	public float FlameTimer;

	public float Timer;

	private void Start()
	{
		this.OriginalPosition = this.RitualKnife.transform.position;
		this.OriginalRotation = this.RitualKnife.transform.eulerAngles;
	}

	private void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 8)
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
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Prompt.Circle[0].fillAmount <= 0f)
		{
			this.Yandere.EquippedWeapon.Drop();
			this.Yandere.EquippedWeapon = null;
			this.Yandere.Unequip();
			this.Yandere.DropTimer[this.Yandere.Equipped] = 0f;
			this.RitualKnife.transform.position = this.OriginalPosition;
			this.RitualKnife.transform.eulerAngles = this.OriginalRotation;
			this.RitualKnife.GetComponent<Rigidbody>().useGravity = false;
			if (this.RitualKnife.GetComponent<WeaponScript>().Heated && !this.RitualKnife.GetComponent<WeaponScript>().Flaming)
			{
				component.clip = this.FlameDemonVoice;
				component.Play();
				this.FlameTimer = 10f;
				this.RitualKnife.GetComponent<WeaponScript>().Prompt.Hide();
				this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = false;
			}
			else if (this.RitualKnife.GetComponent<WeaponScript>().Blood.enabled)
			{
				this.DebugMenu.SetActive(false);
				this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
				this.Yandere.CanMove = false;
				UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
				this.Timer += Time.deltaTime;
				this.Clock.StopTime = true;
			}
		}
		if (this.FlameTimer > 0f)
		{
			this.FlameTimer = Mathf.MoveTowards(this.FlameTimer, 0f, Time.deltaTime);
			if (this.FlameTimer == 0f)
			{
				this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = true;
				this.RitualKnife.GetComponent<WeaponScript>().FireEffect.Play();
				this.RitualKnife.GetComponent<WeaponScript>().FireAudio.Play();
				this.RitualKnife.GetComponent<WeaponScript>().Flaming = true;
				this.Prompt.enabled = true;
				component.clip = this.FlameActivation;
				component.Play();
			}
		}
		if (this.Timer > 0f)
		{
			if (this.Yandere.transform.position.y < 1000f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Darkness.enabled = true;
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
					if (this.Darkness.color.a == 1f)
					{
						this.Yandere.transform.position = new Vector3(0f, 2000f, 0f);
						this.Yandere.Character.SetActive(true);
						this.Yandere.SetAnimationLayers();
						this.HeartbeatCamera.SetActive(false);
						this.FPS.SetActive(false);
						this.HUD.SetActive(false);
					}
				}
				else if (this.Timer > 1f)
				{
					this.Yandere.Character.SetActive(false);
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == 0f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Darkness.color.a == 0f)
					{
						this.Yandere.CanMove = true;
						this.Timer = 0f;
					}
				}
			}
		}
		if (this.Yandere.Egg)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
