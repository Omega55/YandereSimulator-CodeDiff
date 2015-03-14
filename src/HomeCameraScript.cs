using System;
using UnityEngine;

[Serializable]
public class HomeCameraScript : MonoBehaviour
{
	public HomeWindowScript[] HomeWindows;

	public HomeYandereScript HomeYandere;

	public HomePantyChangerScript HomePantyChanger;

	public HomeSenpaiShrineScript HomeSenpaiShrine;

	public HomeCorkboardScript HomeCorkboard;

	public HomeSchoolScript HomeSchool;

	public GameObject CorkboardLabel;

	public GameObject LoadingScreen;

	public Transform Destination;

	public Transform Target;

	public Transform Focus;

	public Transform[] Destinations;

	public Transform[] Targets;

	public ColorCorrectionCurves ColorCorrection;

	public DepthOfFieldScatter DepthOfField;

	public CameraMotionBlur MotionBlur;

	public NoiseAndGrain NoiseGrain;

	public Tonemapping Tonemap;

	public Vignetting Vignette;

	public Bloom BloomEffect;

	public SSAOEffect SSAO;

	public int TargetID;

	public int ID;

	public virtual void Start()
	{
		this.Focus.position = this.Target.position;
		this.transform.position = this.Destination.position;
	}

	public virtual void LateUpdate()
	{
		this.Focus.position = Vector3.Lerp(this.Focus.position, this.Target.position, Time.deltaTime * (float)10);
		this.transform.position = Vector3.Lerp(this.transform.position, this.Destination.position, Time.deltaTime * (float)10);
		this.transform.LookAt(this.Focus.position);
		if (Input.GetButtonDown("A") && this.HomeYandere.CanMove && this.ID != 0)
		{
			this.Destination = this.Destinations[this.ID];
			this.HomeWindows[this.ID].Show = true;
			this.HomeYandere.CanMove = false;
			this.Target = this.Targets[this.ID];
			if (this.ID == 1)
			{
				this.HomeSchool.enabled = true;
			}
			else if (this.ID == 2)
			{
				this.CorkboardLabel.active = false;
				this.HomeCorkboard.enabled = true;
				this.LoadingScreen.active = true;
				this.HomeYandere.active = false;
				this.DisableEffects();
			}
			else if (this.ID == 3)
			{
				this.HomeSenpaiShrine.enabled = true;
			}
			else if (this.ID == 4)
			{
				this.HomePantyChanger.enabled = true;
			}
		}
		if (Input.GetKeyDown("0"))
		{
			if (this.SSAO.enabled)
			{
				this.DisableEffects();
			}
			else
			{
				this.EnableEffects();
			}
		}
		if (Input.GetKeyDown("`"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public virtual void DisableEffects()
	{
		this.ColorCorrection.enabled = false;
		this.DepthOfField.enabled = false;
		this.BloomEffect.enabled = false;
		this.MotionBlur.enabled = false;
		this.NoiseGrain.enabled = false;
		this.Vignette.enabled = false;
		this.Tonemap.enabled = false;
		this.SSAO.enabled = false;
	}

	public virtual void EnableEffects()
	{
		this.ColorCorrection.enabled = true;
		this.DepthOfField.enabled = true;
		this.BloomEffect.enabled = true;
		this.MotionBlur.enabled = true;
		this.NoiseGrain.enabled = true;
		this.Vignette.enabled = true;
		this.Tonemap.enabled = true;
		this.SSAO.enabled = true;
	}

	public virtual void Main()
	{
	}
}
