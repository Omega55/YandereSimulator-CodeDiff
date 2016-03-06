using System;
using UnityEngine;

[Serializable]
public class ArmDetectorScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public SkullScript Skull;

	public UILabel DemonSubtitle;

	public UISprite Darkness;

	public Transform[] SpawnPoints;

	public GameObject[] ArmArray;

	public GameObject BloodProjector;

	public GameObject SmallDarkAura;

	public GameObject DemonArm;

	public bool SummonDemon;

	public float Timer;

	public int Phase;

	public int ArmsSpawned;

	public int Arms;

	public AudioClip DemonMusic;

	public AudioClip DemonLine;

	public ArmDetectorScript()
	{
		this.Phase = 1;
	}

	public virtual void Update()
	{
		for (int i = 1; i < this.ArmArray.Length; i++)
		{
			if (this.ArmArray[i] != null && this.ArmArray[i].transform.parent != null)
			{
				this.ArmArray[i] = null;
				if (i != this.ArmArray.Length - 1)
				{
					this.Shuffle(i);
				}
				this.Arms--;
			}
		}
		if (this.Arms > 9)
		{
			this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			this.SummonDemon = true;
			this.audio.Play();
			this.Arms = 0;
		}
		if (this.SummonDemon)
		{
			if (this.Phase == 1)
			{
				if (this.ArmArray[1] != null)
				{
					for (int i = 1; i < 11; i++)
					{
						if (this.ArmArray[i] != null)
						{
							UnityEngine.Object.Instantiate(this.SmallDarkAura, this.ArmArray[i].transform.position, Quaternion.identity);
							UnityEngine.Object.Destroy(this.ArmArray[i]);
						}
					}
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1)
				{
					this.Timer = (float)0;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, (float)0, Time.deltaTime);
				if (this.Darkness.color.a == (float)1)
				{
					PlayerPrefs.SetFloat("SchoolAtmosphere", (float)0);
					this.StudentManager.SetAtmosphere();
					this.Yandere.transform.eulerAngles = new Vector3((float)0, (float)180, (float)0);
					this.Yandere.transform.position = new Vector3((float)12, 0.1f, (float)26);
					this.DemonSubtitle.text = "...revenge...at last...";
					this.BloodProjector.active = true;
					int num2 = 0;
					Color color3 = this.DemonSubtitle.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.DemonSubtitle.color = color3;
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					this.audio.clip = this.DemonLine;
					this.audio.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range((float)-10, 10f), UnityEngine.Random.Range((float)-10, 10f), UnityEngine.Random.Range((float)-10, 10f));
				float a2 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)1, Time.deltaTime);
				Color color5 = this.DemonSubtitle.color;
				float num4 = color5.a = a2;
				Color color6 = this.DemonSubtitle.color = color5;
				if (this.DemonSubtitle.color.a == (float)1 && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range((float)-10, 10f), UnityEngine.Random.Range((float)-10, 10f), UnityEngine.Random.Range((float)-10, 10f));
				float a3 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)0, Time.deltaTime);
				Color color7 = this.DemonSubtitle.color;
				float num5 = color7.a = a3;
				Color color8 = this.DemonSubtitle.color = color7;
				if (this.DemonSubtitle.color.a == (float)0)
				{
					this.audio.clip = this.DemonMusic;
					this.audio.loop = true;
					this.audio.Play();
					this.DemonSubtitle.text = string.Empty;
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				float a4 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color9 = this.Darkness.color;
				float num6 = color9.a = a4;
				Color color10 = this.Darkness.color = color9;
				if (this.Darkness.color.a == (float)0)
				{
					this.Yandere.Character.animation.CrossFade("f02_demonSummon_00");
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)this.ArmsSpawned)
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.DemonArm, this.SpawnPoints[this.ArmsSpawned].position, Quaternion.identity);
					gameObject.transform.parent = this.Yandere.transform;
					gameObject.transform.LookAt(this.Yandere.transform);
					float y = gameObject.transform.localEulerAngles.y + (float)180;
					Vector3 localEulerAngles = gameObject.transform.localEulerAngles;
					float num7 = localEulerAngles.y = y;
					Vector3 vector = gameObject.transform.localEulerAngles = localEulerAngles;
					this.ArmsSpawned++;
					if (this.ArmsSpawned % 2 == 1)
					{
						((DemonArmScript)gameObject.GetComponent(typeof(DemonArmScript))).IdleAnim = "DemonArmIdleOld";
					}
					else
					{
						((DemonArmScript)gameObject.GetComponent(typeof(DemonArmScript))).IdleAnim = "DemonArmIdle";
					}
				}
				if (this.ArmsSpawned == 10)
				{
					this.Yandere.CanMove = true;
					this.Yandere.IdleAnim = "f02_demonIdle_00";
					this.Yandere.WalkAnim = "f02_demonWalk_00";
					this.Yandere.RunAnim = "f02_demonRun_00";
					this.Yandere.Demonic = true;
					this.SummonDemon = false;
				}
			}
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.transform.parent == null && (PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript)) != null && ((PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript))).BodyPart && ((BodyPartScript)other.gameObject.GetComponent(typeof(BodyPartScript))).Sacrifice && (other.gameObject.name == "FemaleRightArm(Clone)" || other.gameObject.name == "FemaleLeftArm(Clone)" || other.gameObject.name == "MaleRightArm(Clone)" || other.gameObject.name == "MaleLeftArm(Clone)" || other.gameObject.name == "SacrificialArm(Clone)"))
		{
			bool flag = true;
			for (int i = 1; i < 11; i++)
			{
				if (this.ArmArray[i] == other.gameObject)
				{
					flag = false;
				}
			}
			if (flag)
			{
				this.Arms++;
				this.ArmArray[this.Arms] = other.gameObject;
			}
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if ((PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript)) != null && ((PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript))).BodyPart && ((BodyPartScript)other.gameObject.GetComponent(typeof(BodyPartScript))).Sacrifice && (other.gameObject.name == "FemaleRightArm(Clone)" || other.gameObject.name == "FemaleLeftArm(Clone)" || other.gameObject.name == "MaleRightArm(Clone)" || other.gameObject.name == "MaleLeftArm(Clone)" || other.gameObject.name == "SacrificialArm(Clone)"))
		{
			this.Arms--;
		}
	}

	public virtual void Shuffle(int Start)
	{
		for (int i = Start; i < this.ArmArray.Length - 1; i++)
		{
			this.ArmArray[i] = this.ArmArray[i + 1];
		}
	}

	public virtual void Main()
	{
	}
}
