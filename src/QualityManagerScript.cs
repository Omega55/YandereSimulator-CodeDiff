﻿using System;
using UnityEngine;

public class QualityManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public AntialiasingAsPostEffect PostAliasing;

	public NemesisScript Nemesis;

	public YandereScript Yandere;

	public Bloom BloomEffect;

	public Light Sun;

	public ParticleSystem EastRomanceBlossoms;

	public ParticleSystem WestRomanceBlossoms;

	public ParticleSystem CorridorBlossoms;

	public ParticleSystem PlazaBlossoms;

	public ParticleSystem MythBlossoms;

	public ParticleSystem Steam;

	public ParticleSystem[] Fountains;

	public Renderer YandereHairRenderer;

	public Shader NewBodyShader;

	public Shader NewHairShader;

	public Shader Toon;

	public Shader ToonOutline;

	public Shader ToonOverlay;

	public Shader ToonOutlineOverlay;

	public Shader ToonOutlineRimLight;

	public BloomAndLensFlares ExperimentalBloomAndLensFlares;

	public DepthOfField34 ExperimentalDepthOfField34;

	public SSAOEffect ExperimentalSSAOEffect;

	public bool RimLightActive;

	private void Start()
	{
		DepthOfField34[] components = Camera.main.GetComponents<DepthOfField34>();
		this.ExperimentalDepthOfField34 = components[1];
		this.ToggleExperiment();
		if (OptionGlobals.ParticleCount == 0)
		{
			OptionGlobals.ParticleCount = 3;
		}
		if (OptionGlobals.DrawDistance == 0)
		{
			OptionGlobals.DrawDistanceLimit = 350;
			OptionGlobals.DrawDistance = 350;
		}
		this.UpdateFog();
		this.UpdateAnims();
		this.UpdateBloom();
		this.UpdateShadows();
		this.UpdateParticles();
		this.UpdatePostAliasing();
		this.UpdateDrawDistance();
		this.UpdateLowDetailStudents();
	}

	public void UpdateParticles()
	{
		if (OptionGlobals.ParticleCount == 4)
		{
			OptionGlobals.ParticleCount = 1;
		}
		else if (OptionGlobals.ParticleCount == 0)
		{
			OptionGlobals.ParticleCount = 3;
		}
		ParticleSystem.EmissionModule emission = this.EastRomanceBlossoms.emission;
		ParticleSystem.EmissionModule emission2 = this.WestRomanceBlossoms.emission;
		ParticleSystem.EmissionModule emission3 = this.CorridorBlossoms.emission;
		ParticleSystem.EmissionModule emission4 = this.PlazaBlossoms.emission;
		ParticleSystem.EmissionModule emission5 = this.MythBlossoms.emission;
		ParticleSystem.EmissionModule emission6 = this.Steam.emission;
		ParticleSystem.EmissionModule emission7 = this.Fountains[1].emission;
		ParticleSystem.EmissionModule emission8 = this.Fountains[2].emission;
		ParticleSystem.EmissionModule emission9 = this.Fountains[3].emission;
		emission.enabled = true;
		emission2.enabled = true;
		emission3.enabled = true;
		emission4.enabled = true;
		emission5.enabled = true;
		emission6.enabled = true;
		emission7.enabled = true;
		emission8.enabled = true;
		emission9.enabled = true;
		if (OptionGlobals.ParticleCount == 3)
		{
			emission.rateOverTime = 100f;
			emission2.rateOverTime = 100f;
			emission3.rateOverTime = 1000f;
			emission4.rateOverTime = 400f;
			emission5.rateOverTime = 100f;
			emission6.rateOverTime = 100f;
			emission7.rateOverTime = 100f;
			emission8.rateOverTime = 100f;
			emission9.rateOverTime = 100f;
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			emission.rateOverTime = 10f;
			emission2.rateOverTime = 10f;
			emission3.rateOverTime = 100f;
			emission4.rateOverTime = 40f;
			emission5.rateOverTime = 10f;
			emission6.rateOverTime = 10f;
			emission7.rateOverTime = 10f;
			emission8.rateOverTime = 10f;
			emission9.rateOverTime = 10f;
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			emission.enabled = false;
			emission2.enabled = false;
			emission3.enabled = false;
			emission4.enabled = false;
			emission5.enabled = false;
			emission6.enabled = false;
			emission7.enabled = false;
			emission8.enabled = false;
			emission9.enabled = false;
		}
	}

	public void UpdateOutlines()
	{
		for (int i = 1; i < this.StudentManager.Students.Length; i++)
		{
			StudentScript studentScript = this.StudentManager.Students[i];
			if (studentScript != null && studentScript.gameObject.activeInHierarchy)
			{
				if (OptionGlobals.DisableOutlines)
				{
					this.NewHairShader = this.Toon;
					this.NewBodyShader = this.ToonOverlay;
				}
				else
				{
					this.NewHairShader = this.ToonOutline;
					this.NewBodyShader = this.ToonOutlineOverlay;
				}
				if (!studentScript.Male)
				{
					studentScript.MyRenderer.materials[0].shader = this.NewBodyShader;
					studentScript.MyRenderer.materials[1].shader = this.NewBodyShader;
					studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
				}
				else
				{
					studentScript.MyRenderer.materials[0].shader = this.NewHairShader;
					studentScript.MyRenderer.materials[1].shader = this.NewHairShader;
					studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
				}
				if (!studentScript.Male)
				{
					if (!studentScript.Teacher)
					{
						if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
						{
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
						}
						if (studentScript.Cosmetic.Accessory > 0)
						{
							studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
						}
					}
					else
					{
						studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
						if (studentScript.Cosmetic.Accessory > 0)
						{
						}
					}
				}
				else
				{
					if (studentScript.Cosmetic.Hairstyle > 0)
					{
						studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
					}
					if (studentScript.Cosmetic.Accessory > 0)
					{
						Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
						if (component != null)
						{
							component.material.shader = this.NewHairShader;
						}
					}
				}
				if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
				{
					Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
					if (component2 != null)
					{
						component2.material.shader = this.NewHairShader;
					}
				}
			}
		}
		this.Yandere.MyRenderer.materials[0].shader = this.NewBodyShader;
		this.Yandere.MyRenderer.materials[1].shader = this.NewBodyShader;
		this.Yandere.MyRenderer.materials[2].shader = this.NewBodyShader;
		for (int j = 1; j < this.Yandere.Hairstyles.Length; j++)
		{
			Renderer component3 = this.Yandere.Hairstyles[j].GetComponent<Renderer>();
			if (component3 != null)
			{
				this.YandereHairRenderer.material.shader = this.NewHairShader;
				component3.material.shader = this.NewHairShader;
			}
		}
		this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.NewHairShader;
		this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.NewHairShader;
		this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.NewHairShader;
		this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.NewHairShader;
	}

	public void UpdatePostAliasing()
	{
		this.PostAliasing.enabled = !OptionGlobals.DisablePostAliasing;
	}

	public void UpdateBloom()
	{
		this.BloomEffect.enabled = !OptionGlobals.DisableBloom;
	}

	public void UpdateLowDetailStudents()
	{
		if (OptionGlobals.LowDetailStudents == 11)
		{
			OptionGlobals.LowDetailStudents = 0;
		}
		else if (OptionGlobals.LowDetailStudents == -1)
		{
			OptionGlobals.LowDetailStudents = 10;
		}
		this.StudentManager.LowDetailThreshold = OptionGlobals.LowDetailStudents * 10;
	}

	public void UpdateDrawDistance()
	{
		if (OptionGlobals.DrawDistance > OptionGlobals.DrawDistanceLimit)
		{
			OptionGlobals.DrawDistance = 10;
		}
		else if (OptionGlobals.DrawDistance == 0)
		{
			OptionGlobals.DrawDistance = OptionGlobals.DrawDistanceLimit;
		}
		Camera.main.farClipPlane = (float)OptionGlobals.DrawDistance;
		RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
		this.Yandere.Smartphone.farClipPlane = (float)OptionGlobals.DrawDistance;
	}

	public void UpdateFog()
	{
		if (!OptionGlobals.Fog)
		{
			this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.fogMode = FogMode.Exponential;
		}
		else
		{
			this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
		}
	}

	public void UpdateShadows()
	{
		this.Sun.shadows = ((!OptionGlobals.DisableShadows) ? LightShadows.Soft : LightShadows.None);
	}

	public void UpdateAnims()
	{
		this.StudentManager.DisableFarAnims = OptionGlobals.DisableFarAnimations;
	}

	public void ToggleExperiment()
	{
		if (!this.ExperimentalSSAOEffect.enabled)
		{
			this.ExperimentalBloomAndLensFlares.enabled = true;
			this.ExperimentalDepthOfField34.enabled = true;
			this.ExperimentalSSAOEffect.enabled = true;
			this.BloomEffect.enabled = false;
		}
		else
		{
			this.ExperimentalBloomAndLensFlares.enabled = false;
			this.ExperimentalDepthOfField34.enabled = false;
			this.ExperimentalSSAOEffect.enabled = false;
		}
	}

	public void RimLight()
	{
		if (!this.RimLightActive)
		{
			this.RimLightActive = true;
			for (int i = 1; i < this.StudentManager.Students.Length; i++)
			{
				StudentScript studentScript = this.StudentManager.Students[i];
				if (studentScript != null && studentScript.gameObject.activeInHierarchy)
				{
					this.NewHairShader = this.ToonOutlineRimLight;
					this.NewBodyShader = this.ToonOutlineRimLight;
					studentScript.MyRenderer.materials[0].shader = this.ToonOutlineRimLight;
					studentScript.MyRenderer.materials[1].shader = this.ToonOutlineRimLight;
					studentScript.MyRenderer.materials[2].shader = this.ToonOutlineRimLight;
					this.AdjustRimLight(studentScript.MyRenderer.materials[0]);
					this.AdjustRimLight(studentScript.MyRenderer.materials[1]);
					this.AdjustRimLight(studentScript.MyRenderer.materials[2]);
					if (!studentScript.Male)
					{
						if (!studentScript.Teacher)
						{
							if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
							{
								studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
								this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
							}
							if (studentScript.Cosmetic.Accessory > 0)
							{
								studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.ToonOutlineRimLight;
								this.AdjustRimLight(studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material);
							}
						}
						else
						{
							studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
							this.AdjustRimLight(studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material);
						}
					}
					else
					{
						if (studentScript.Cosmetic.Hairstyle > 0)
						{
							studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
							this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
						}
						if (studentScript.Cosmetic.Accessory > 0)
						{
							Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
							if (component != null)
							{
								component.material.shader = this.ToonOutlineRimLight;
								this.AdjustRimLight(component.material);
							}
						}
					}
					if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
					{
						Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
						if (component2 != null)
						{
							component2.material.shader = this.ToonOutlineRimLight;
							this.AdjustRimLight(component2.material);
						}
					}
				}
			}
			this.Yandere.MyRenderer.materials[0].shader = this.ToonOutlineRimLight;
			this.Yandere.MyRenderer.materials[1].shader = this.ToonOutlineRimLight;
			this.Yandere.MyRenderer.materials[2].shader = this.ToonOutlineRimLight;
			this.AdjustRimLight(this.Yandere.MyRenderer.materials[0]);
			this.AdjustRimLight(this.Yandere.MyRenderer.materials[1]);
			this.AdjustRimLight(this.Yandere.MyRenderer.materials[2]);
			for (int j = 1; j < this.Yandere.Hairstyles.Length; j++)
			{
				Renderer component3 = this.Yandere.Hairstyles[j].GetComponent<Renderer>();
				if (component3 != null)
				{
					this.YandereHairRenderer.material.shader = this.ToonOutlineRimLight;
					component3.material.shader = this.ToonOutlineRimLight;
					this.AdjustRimLight(this.YandereHairRenderer.material);
					this.AdjustRimLight(component3.material);
				}
			}
			this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.ToonOutlineRimLight;
			this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.ToonOutlineRimLight;
			this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.ToonOutlineRimLight;
			this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.ToonOutlineRimLight;
			this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[0]);
			this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[1]);
			this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[2]);
			this.AdjustRimLight(this.Nemesis.NemesisHair.GetComponent<Renderer>().material);
		}
		else
		{
			this.RimLightActive = false;
			this.UpdateOutlines();
		}
	}

	public void AdjustRimLight(Material mat)
	{
		mat.SetFloat("_RimLightIntensity", 5f);
		mat.SetFloat("_RimCrisp", 0.5f);
		mat.SetFloat("_RimAdditive", 0.5f);
	}
}
