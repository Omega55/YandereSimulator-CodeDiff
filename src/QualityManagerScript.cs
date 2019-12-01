using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class QualityManagerScript : MonoBehaviour
{
	public AntialiasingAsPostEffect PostAliasing;

	public StudentManagerScript StudentManager;

	public PostProcessingBehaviour Obscurance;

	public SettingsScript Settings;

	public NemesisScript Nemesis;

	public YandereScript Yandere;

	public Bloom BloomEffect;

	public Light Sun;

	public ParticleSystem EastRomanceBlossoms;

	public ParticleSystem WestRomanceBlossoms;

	public ParticleSystem CorridorBlossoms;

	public ParticleSystem PlazaBlossoms;

	public ParticleSystem MythBlossoms;

	public ParticleSystem[] Fountains;

	public ParticleSystem[] Steam;

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

	public bool DoNothing;

	private static readonly int[] FPSValues = new int[]
	{
		int.MaxValue,
		30,
		60,
		120
	};

	public static readonly string[] FPSStrings = new string[]
	{
		"Unlimited",
		"30",
		"60",
		"120"
	};

	public void Start()
	{
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			this.DoNothing = true;
		}
		if (!this.DoNothing)
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
			if (OptionGlobals.DisableFarAnimations == 0)
			{
				OptionGlobals.DisableFarAnimations = 5;
			}
			if (OptionGlobals.Sensitivity == 0)
			{
				OptionGlobals.Sensitivity = 3;
			}
			this.ToggleRun();
			this.UpdateFog();
			this.UpdateAnims();
			this.UpdateBloom();
			this.UpdateShadows();
			this.UpdateFPSIndex();
			this.UpdateParticles();
			this.UpdateObscurance();
			this.UpdatePostAliasing();
			this.UpdateDrawDistance();
			this.UpdateLowDetailStudents();
			this.Settings.ToggleBackground();
			if (!OptionGlobals.DepthOfField)
			{
				this.ToggleExperiment();
			}
		}
	}

	public void UpdateParticles()
	{
		if (OptionGlobals.ParticleCount > 3)
		{
			OptionGlobals.ParticleCount = 1;
		}
		else if (OptionGlobals.ParticleCount < 1)
		{
			OptionGlobals.ParticleCount = 3;
		}
		if (!this.DoNothing)
		{
			ParticleSystem.EmissionModule emission = this.EastRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission2 = this.WestRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission3 = this.CorridorBlossoms.emission;
			ParticleSystem.EmissionModule emission4 = this.PlazaBlossoms.emission;
			ParticleSystem.EmissionModule emission5 = this.MythBlossoms.emission;
			ParticleSystem.EmissionModule emission6 = this.Steam[1].emission;
			ParticleSystem.EmissionModule emission7 = this.Steam[2].emission;
			ParticleSystem.EmissionModule emission8 = this.Fountains[1].emission;
			ParticleSystem.EmissionModule emission9 = this.Fountains[2].emission;
			ParticleSystem.EmissionModule emission10 = this.Fountains[3].emission;
			emission.enabled = true;
			emission2.enabled = true;
			emission3.enabled = true;
			emission4.enabled = true;
			emission5.enabled = true;
			emission6.enabled = true;
			emission7.enabled = true;
			emission8.enabled = true;
			emission9.enabled = true;
			emission10.enabled = true;
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
				emission10.rateOverTime = 100f;
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
				emission10.rateOverTime = 10f;
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
				emission10.enabled = false;
			}
		}
	}

	public void UpdateOutlines()
	{
		if (!this.DoNothing)
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
						studentScript.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
						studentScript.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
						if (studentScript.Club == ClubType.Bully)
						{
							studentScript.Cosmetic.Bookbag.GetComponent<Renderer>().material.shader = this.NewHairShader;
							studentScript.Cosmetic.LeftWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
							studentScript.Cosmetic.RightWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
							studentScript.Cosmetic.HoodieRenderer.GetComponent<Renderer>().material.shader = this.NewHairShader;
						}
						if (studentScript.StudentID == 87)
						{
							studentScript.Cosmetic.ScarfRenderer.material.shader = this.NewHairShader;
						}
						else if (studentScript.StudentID == 90)
						{
							if (studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory] != null)
							{
								studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
							}
							if (studentScript.MyRenderer.materials.Length == 4)
							{
								studentScript.MyRenderer.materials[3].shader = this.NewBodyShader;
							}
						}
					}
					else
					{
						studentScript.MyRenderer.materials[0].shader = this.NewHairShader;
						studentScript.MyRenderer.materials[1].shader = this.NewHairShader;
						studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
					}
					studentScript.Armband.GetComponent<Renderer>().material.shader = this.NewHairShader;
					if (!studentScript.Male)
					{
						if (!studentScript.Teacher)
						{
							if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
							{
								if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
								{
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
								}
								else
								{
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.NewHairShader;
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.NewHairShader;
								}
							}
							if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
							{
								studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
							}
						}
						else
						{
							if (studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
							{
								studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
							}
							if (studentScript.Cosmetic.Accessory > 0)
							{
							}
						}
					}
					else
					{
						if (studentScript.Cosmetic.Hairstyle > 0)
						{
							if (studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
							}
							else
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.NewHairShader;
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.NewHairShader;
							}
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
					if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
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
			this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.NewBodyShader;
			this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.NewBodyShader;
			this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.NewBodyShader;
			this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.NewHairShader;
		}
	}

	public void UpdatePostAliasing()
	{
		if (!this.DoNothing)
		{
			this.PostAliasing.enabled = !OptionGlobals.DisablePostAliasing;
		}
	}

	public void UpdateBloom()
	{
		if (!this.DoNothing)
		{
			this.BloomEffect.enabled = !OptionGlobals.DisableBloom;
		}
	}

	public void UpdateLowDetailStudents()
	{
		if (OptionGlobals.LowDetailStudents > 10)
		{
			OptionGlobals.LowDetailStudents = 0;
		}
		else if (OptionGlobals.LowDetailStudents < 0)
		{
			OptionGlobals.LowDetailStudents = 10;
		}
		if (!this.DoNothing)
		{
			this.StudentManager.LowDetailThreshold = OptionGlobals.LowDetailStudents * 10;
			bool flag = (float)this.StudentManager.LowDetailThreshold > 0f;
			for (int i = 1; i < 101; i++)
			{
				if (this.StudentManager.Students[i] != null)
				{
					this.StudentManager.Students[i].LowPoly.enabled = flag;
					if (!flag && this.StudentManager.Students[i].LowPoly.MyMesh.enabled)
					{
						this.StudentManager.Students[i].LowPoly.MyMesh.enabled = false;
						this.StudentManager.Students[i].MyRenderer.enabled = true;
					}
				}
			}
		}
	}

	public void UpdateAnims()
	{
		if (OptionGlobals.DisableFarAnimations > 20)
		{
			OptionGlobals.DisableFarAnimations = 0;
		}
		else if (OptionGlobals.DisableFarAnimations < 0)
		{
			OptionGlobals.DisableFarAnimations = 20;
		}
		if (!this.DoNothing)
		{
			this.StudentManager.FarAnimThreshold = OptionGlobals.DisableFarAnimations * 5;
			if ((float)this.StudentManager.FarAnimThreshold > 0f)
			{
				this.StudentManager.DisableFarAnims = true;
			}
			else
			{
				this.StudentManager.DisableFarAnims = false;
			}
		}
	}

	public void UpdateDrawDistance()
	{
		if (OptionGlobals.DrawDistance > OptionGlobals.DrawDistanceLimit)
		{
			OptionGlobals.DrawDistance = 10;
		}
		else if (OptionGlobals.DrawDistance < 1)
		{
			OptionGlobals.DrawDistance = OptionGlobals.DrawDistanceLimit;
		}
		if (!this.DoNothing)
		{
			Camera.main.farClipPlane = (float)OptionGlobals.DrawDistance;
			RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
			this.Yandere.Smartphone.farClipPlane = (float)OptionGlobals.DrawDistance;
		}
	}

	public void UpdateFog()
	{
		if (!this.DoNothing)
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
	}

	public void UpdateShadows()
	{
		if (!this.DoNothing)
		{
			this.Sun.shadows = ((!OptionGlobals.EnableShadows) ? LightShadows.None : LightShadows.Soft);
		}
	}

	public void ToggleRun()
	{
		if (!this.DoNothing)
		{
			this.Yandere.ToggleRun = OptionGlobals.ToggleRun;
		}
	}

	public void UpdateFPSIndex()
	{
		if (OptionGlobals.FPSIndex < 0)
		{
			OptionGlobals.FPSIndex = QualityManagerScript.FPSValues.Length - 1;
		}
		else if (OptionGlobals.FPSIndex >= QualityManagerScript.FPSValues.Length)
		{
			OptionGlobals.FPSIndex = 0;
		}
		Application.targetFrameRate = QualityManagerScript.FPSValues[OptionGlobals.FPSIndex];
	}

	public void ToggleExperiment()
	{
		if (!this.DoNothing)
		{
			if (!this.ExperimentalBloomAndLensFlares.enabled)
			{
				this.ExperimentalBloomAndLensFlares.enabled = true;
				this.ExperimentalDepthOfField34.enabled = false;
				this.ExperimentalSSAOEffect.enabled = false;
				this.BloomEffect.enabled = true;
			}
			else
			{
				this.ExperimentalBloomAndLensFlares.enabled = false;
				this.ExperimentalDepthOfField34.enabled = false;
				this.ExperimentalSSAOEffect.enabled = false;
				this.BloomEffect.enabled = false;
			}
		}
	}

	public void RimLight()
	{
		if (!this.DoNothing)
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
									if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
									{
										studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
										this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
									}
									else
									{
										studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.ToonOutlineRimLight;
										studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.ToonOutlineRimLight;
										this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
										this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
									}
								}
								if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
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
								if (studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
								{
									studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
									this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
								}
								else
								{
									studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.ToonOutlineRimLight;
									studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.ToonOutlineRimLight;
									this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
									this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
								}
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
						if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
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
	}

	public void UpdateObscurance()
	{
		if (!this.DoNothing)
		{
			this.Obscurance.enabled = !OptionGlobals.DisableObscurance;
		}
	}

	public void AdjustRimLight(Material mat)
	{
		if (!this.DoNothing)
		{
			mat.SetFloat("_RimLightIntensity", 5f);
			mat.SetFloat("_RimCrisp", 0.5f);
			mat.SetFloat("_RimAdditive", 0.5f);
		}
	}
}
