using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class QualityManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public AntialiasingAsPostEffect PostAliasing;

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

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("ParticleCount") == 0)
		{
			PlayerPrefs.SetInt("ParticleCount", 3);
		}
		if (PlayerPrefs.GetInt("DrawDistance") == 0)
		{
			PlayerPrefs.SetInt("DrawDistance", 350);
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

	public virtual void UpdateParticles()
	{
		if (PlayerPrefs.GetInt("ParticleCount") == 4)
		{
			PlayerPrefs.SetInt("ParticleCount", 1);
		}
		else if (PlayerPrefs.GetInt("ParticleCount") == 0)
		{
			PlayerPrefs.SetInt("ParticleCount", 3);
		}
		this.EastRomanceBlossoms.enableEmission = true;
		this.WestRomanceBlossoms.enableEmission = true;
		this.CorridorBlossoms.enableEmission = true;
		this.PlazaBlossoms.enableEmission = true;
		this.MythBlossoms.enableEmission = true;
		this.Steam.enableEmission = true;
		this.Fountains[1].enableEmission = true;
		this.Fountains[2].enableEmission = true;
		this.Fountains[3].enableEmission = true;
		if (PlayerPrefs.GetInt("ParticleCount") == 3)
		{
			this.EastRomanceBlossoms.emissionRate = (float)100;
			this.WestRomanceBlossoms.emissionRate = (float)100;
			this.CorridorBlossoms.emissionRate = (float)1000;
			this.PlazaBlossoms.emissionRate = (float)400;
			this.MythBlossoms.emissionRate = (float)100;
			this.Steam.emissionRate = (float)100;
			this.Fountains[1].emissionRate = (float)100;
			this.Fountains[2].emissionRate = (float)100;
			this.Fountains[3].emissionRate = (float)100;
		}
		else if (PlayerPrefs.GetInt("ParticleCount") == 2)
		{
			this.EastRomanceBlossoms.emissionRate = (float)10;
			this.WestRomanceBlossoms.emissionRate = (float)10;
			this.CorridorBlossoms.emissionRate = (float)100;
			this.PlazaBlossoms.emissionRate = (float)40;
			this.MythBlossoms.emissionRate = (float)10;
			this.Steam.emissionRate = (float)10;
			this.Fountains[1].emissionRate = (float)10;
			this.Fountains[2].emissionRate = (float)10;
			this.Fountains[3].emissionRate = (float)10;
		}
		else if (PlayerPrefs.GetInt("ParticleCount") == 1)
		{
			this.EastRomanceBlossoms.enableEmission = false;
			this.WestRomanceBlossoms.enableEmission = false;
			this.CorridorBlossoms.enableEmission = false;
			this.PlazaBlossoms.enableEmission = false;
			this.MythBlossoms.enableEmission = false;
			this.Steam.enableEmission = false;
			this.Fountains[1].enableEmission = false;
			this.Fountains[2].enableEmission = false;
			this.Fountains[3].enableEmission = false;
		}
	}

	public virtual void UpdateOutlines()
	{
		for (int i = 1; i < Extensions.get_length(this.StudentManager.Students); i++)
		{
			if (this.StudentManager.Students[i] != null)
			{
				if (PlayerPrefs.GetInt("DisableOutlines") == 1)
				{
					this.NewHairShader = this.Toon;
					this.NewBodyShader = this.ToonOverlay;
				}
				else
				{
					this.NewHairShader = this.ToonOutline;
					this.NewBodyShader = this.ToonOutlineOverlay;
				}
				if (!this.StudentManager.Students[i].Male)
				{
					this.StudentManager.Students[i].MyRenderer.materials[0].shader = this.NewBodyShader;
					this.StudentManager.Students[i].MyRenderer.materials[1].shader = this.NewBodyShader;
					this.StudentManager.Students[i].MyRenderer.materials[2].shader = this.NewBodyShader;
				}
				else
				{
					this.StudentManager.Students[i].MyRenderer.materials[0].shader = this.NewHairShader;
					this.StudentManager.Students[i].MyRenderer.materials[1].shader = this.NewHairShader;
					this.StudentManager.Students[i].MyRenderer.materials[2].shader = this.NewBodyShader;
				}
				if (!this.StudentManager.Students[i].Male)
				{
					if (!this.StudentManager.Students[i].Teacher)
					{
						this.StudentManager.Students[i].Cosmetic.FemaleHairRenderers[this.StudentManager.Students[i].Cosmetic.Hairstyle].material.shader = this.NewHairShader;
						if (this.StudentManager.Students[i].Cosmetic.Accessory > 0)
						{
							((Renderer)this.StudentManager.Students[i].Cosmetic.FemaleAccessories[this.StudentManager.Students[i].Cosmetic.Accessory].GetComponent(typeof(Renderer))).material.shader = this.NewHairShader;
						}
					}
					else
					{
						this.StudentManager.Students[i].Cosmetic.TeacherHairRenderers[this.StudentManager.Students[i].Cosmetic.Hairstyle].material.shader = this.NewHairShader;
						if (this.StudentManager.Students[i].Cosmetic.Accessory > 0)
						{
							((Renderer)this.StudentManager.Students[i].Cosmetic.TeacherAccessories[this.StudentManager.Students[i].Cosmetic.Accessory].GetComponent(typeof(Renderer))).material.shader = this.NewHairShader;
						}
					}
				}
				else
				{
					if (this.StudentManager.Students[i].Cosmetic.Hairstyle > 0)
					{
						this.StudentManager.Students[i].Cosmetic.MaleHairRenderers[this.StudentManager.Students[i].Cosmetic.Hairstyle].material.shader = this.NewHairShader;
					}
					if (this.StudentManager.Students[i].Cosmetic.Accessory > 0)
					{
						Renderer renderer = (Renderer)this.StudentManager.Students[i].Cosmetic.MaleAccessories[this.StudentManager.Students[i].Cosmetic.Accessory].GetComponent(typeof(Renderer));
						if (renderer != null)
						{
							renderer.material.shader = this.NewHairShader;
						}
					}
				}
				if (!this.StudentManager.Students[i].Teacher && this.StudentManager.Students[i].Cosmetic.Club > 0 && this.StudentManager.Students[i].Cosmetic.ClubAccessories[this.StudentManager.Students[i].Cosmetic.Club] != null)
				{
					Renderer renderer2 = (Renderer)this.StudentManager.Students[i].Cosmetic.ClubAccessories[this.StudentManager.Students[i].Cosmetic.Club].GetComponent(typeof(Renderer));
					if (renderer2 != null)
					{
						renderer2.material.shader = this.NewHairShader;
					}
				}
			}
		}
		this.Yandere.MyRenderer.materials[0].shader = this.NewBodyShader;
		this.Yandere.MyRenderer.materials[1].shader = this.NewBodyShader;
		this.Yandere.MyRenderer.materials[2].shader = this.NewBodyShader;
		for (int i = 1; i < Extensions.get_length(this.Yandere.Hairstyles); i++)
		{
			Renderer renderer3 = (Renderer)this.Yandere.Hairstyles[i].GetComponent(typeof(Renderer));
			if (renderer3 != null)
			{
				this.YandereHairRenderer.material.shader = this.NewHairShader;
				renderer3.material.shader = this.NewHairShader;
			}
		}
	}

	public virtual void UpdatePostAliasing()
	{
		if (PlayerPrefs.GetInt("DisablePostAliasing") == 1)
		{
			this.PostAliasing.enabled = false;
		}
		else
		{
			this.PostAliasing.enabled = true;
		}
	}

	public virtual void UpdateBloom()
	{
		if (PlayerPrefs.GetInt("DisableBloom") == 1)
		{
			this.BloomEffect.enabled = false;
		}
		else
		{
			this.BloomEffect.enabled = true;
		}
	}

	public virtual void UpdateLowDetailStudents()
	{
		if (PlayerPrefs.GetInt("LowDetailStudents") == 11)
		{
			PlayerPrefs.SetInt("LowDetailStudents", 0);
		}
		else if (PlayerPrefs.GetInt("LowDetailStudents") == -1)
		{
			PlayerPrefs.SetInt("LowDetailStudents", 10);
		}
		this.StudentManager.LowDetailThreshold = PlayerPrefs.GetInt("LowDetailStudents") * 10;
	}

	public virtual void UpdateDrawDistance()
	{
		if (PlayerPrefs.GetInt("DrawDistance") == 360)
		{
			PlayerPrefs.SetInt("DrawDistance", 10);
		}
		else if (PlayerPrefs.GetInt("DrawDistance") == 0)
		{
			PlayerPrefs.SetInt("DrawDistance", 350);
		}
		Camera.main.farClipPlane = (float)PlayerPrefs.GetInt("DrawDistance");
		RenderSettings.fogEndDistance = (float)PlayerPrefs.GetInt("DrawDistance");
	}

	public virtual void UpdateFog()
	{
		if (PlayerPrefs.GetInt("Fog") == 0)
		{
			this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.fogMode = FogMode.Exponential;
		}
		else
		{
			this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogEndDistance = (float)PlayerPrefs.GetInt("DrawDistance");
		}
	}

	public virtual void UpdateShadows()
	{
		if (PlayerPrefs.GetInt("DisableShadows") == 1)
		{
			this.Sun.shadows = LightShadows.None;
		}
		else
		{
			this.Sun.shadows = LightShadows.Soft;
		}
	}

	public virtual void UpdateAnims()
	{
		if (PlayerPrefs.GetInt("DisableFarAnimations") == 1)
		{
			this.StudentManager.DisableFarAnims = true;
		}
		else
		{
			this.StudentManager.DisableFarAnims = false;
		}
	}

	public virtual void Main()
	{
	}
}
