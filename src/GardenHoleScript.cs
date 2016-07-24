using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GardenHoleScript : MonoBehaviour
{
	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public Collider MyCollider;

	public MeshFilter MyMesh;

	public GameObject Pile;

	public Mesh MoundMesh;

	public Mesh HoleMesh;

	public bool Bury;

	public bool Dug;

	public int ID;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("GardenGrave_" + this.ID + "_Occupied") == 1)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.enabled = false;
		}
	}

	public virtual void Update()
	{
		if (this.Yandere.transform.position.z < this.transform.position.z - 0.5f)
		{
			if (this.Yandere.Equipped > 0)
			{
				if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 10)
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
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			for (int i = 0; i < Extensions.get_length(this.Yandere.ArmedAnims); i++)
			{
				this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[i]].weight = (float)0;
			}
			this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.transform.position.x, this.Yandere.transform.position.y, this.transform.position.z) - this.Yandere.transform.position);
			this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DigSpot.eulerAngles;
			this.Yandere.RPGCamera.transform.position = this.Yandere.DigSpot.position;
			this.Yandere.Weapon[this.Yandere.Equipped].gameObject.active = false;
			this.Yandere.CharacterAnimation["f02_shovelBury_00"].time = (float)0;
			this.Yandere.CharacterAnimation["f02_shovelDig_00"].time = (float)0;
			this.Yandere.FloatingShovel.active = true;
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.CanMove = false;
			this.Yandere.DigPhase = 1;
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Dug)
			{
				this.Yandere.FloatingShovel.animation["Dig"].time = (float)0;
				this.Yandere.FloatingShovel.animation.Play("Dig");
				this.Yandere.Character.animation.Play("f02_shovelDig_00");
				this.Yandere.Digging = true;
				this.Prompt.Label[0].text = "     " + "Fill";
				this.MyCollider.isTrigger = true;
				this.MyMesh.mesh = this.HoleMesh;
				this.Pile.active = true;
				this.Dug = true;
			}
			else
			{
				this.Yandere.FloatingShovel.animation["Bury"].time = (float)0;
				this.Yandere.FloatingShovel.animation.Play("Bury");
				this.Yandere.Character.animation.Play("f02_shovelBury_00");
				this.Yandere.Burying = true;
				this.Prompt.Label[0].text = "     " + "Dig";
				this.MyCollider.isTrigger = false;
				this.MyMesh.mesh = this.MoundMesh;
				this.Pile.active = false;
				this.Dug = false;
			}
			if (this.Bury)
			{
				this.Yandere.Police.Corpses = this.Yandere.Police.Corpses - 1;
				if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
				{
					this.Yandere.Police.MurderScene = false;
				}
				if (this.Yandere.Police.Corpses == 0)
				{
					this.Yandere.Police.MurderScene = false;
				}
				this.Corpse.Remove();
				PlayerPrefs.SetInt("GardenGrave_" + this.ID + "_Occupied", 1);
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.enabled = false;
			}
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     " + "Bury";
			this.Corpse = (RagdollScript)other.transform.root.gameObject.GetComponent(typeof(RagdollScript));
			this.Bury = true;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     " + "Fill";
			this.Corpse = null;
			this.Bury = false;
		}
	}

	public virtual void Main()
	{
	}
}
