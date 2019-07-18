using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmDetectorScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public DebugMenuScript DebugMenu;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public PoliceScript Police;

	public SkullScript Skull;

	public UILabel DemonSubtitle;

	public UISprite Darkness;

	public Transform LimbParent;

	public Transform[] SpawnPoints;

	public GameObject[] BodyArray;

	public GameObject[] ArmArray;

	public GameObject RiggedAccessory;

	public GameObject BloodProjector;

	public GameObject SmallDarkAura;

	public GameObject DemonDress;

	public GameObject RightFlame;

	public GameObject LeftFlame;

	public GameObject DemonArm;

	public bool SummonEmptyDemon;

	public bool SummonFlameDemon;

	public bool SummonDemon;

	public Mesh FlameDemonMesh;

	public int CorpsesCounted;

	public int ArmsSpawned;

	public int Sacrifices;

	public int Phase = 1;

	public int Bodies;

	public int Arms;

	public float Timer;

	public AudioClip FlameDemonLine;

	public AudioClip FlameActivate;

	public AudioClip DemonMusic;

	public AudioClip DemonLine;

	public AudioClip EmptyDemonLine;

	private void Start()
	{
		this.DemonDress.SetActive(false);
	}

	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.SummonDemon)
		{
			for (int i = 1; i < this.ArmArray.Length; i++)
			{
				if (this.ArmArray[i] != null && this.ArmArray[i].transform.parent != this.LimbParent)
				{
					this.ArmArray[i] = null;
					if (i != this.ArmArray.Length - 1)
					{
						this.Shuffle(i);
					}
					this.Arms--;
					Debug.Log("Decrement arm count?");
				}
			}
			if (this.Arms > 9)
			{
				this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
				this.Yandere.CanMove = false;
				this.SummonDemon = true;
				component.Play();
				this.Arms = 0;
			}
		}
		if (!this.SummonFlameDemon)
		{
			this.CorpsesCounted = 0;
			this.Sacrifices = 0;
			int num = 0;
			while (this.CorpsesCounted < this.Police.Corpses)
			{
				RagdollScript ragdollScript = this.Police.CorpseList[num];
				if (ragdollScript != null)
				{
					this.CorpsesCounted++;
					if (ragdollScript.Burned && ragdollScript.Sacrifice && !ragdollScript.Dragged && !ragdollScript.Carried)
					{
						this.Sacrifices++;
					}
				}
				num++;
			}
			if (this.Sacrifices > 4 && !this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
				this.Yandere.CanMove = false;
				this.SummonFlameDemon = true;
				component.Play();
			}
		}
		if (!this.SummonEmptyDemon && this.Bodies > 10 && !this.Yandere.Chased && this.Yandere.Chasers == 0)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			this.SummonEmptyDemon = true;
			component.Play();
		}
		if (this.SummonDemon)
		{
			if (this.Phase == 1)
			{
				if (this.ArmArray[1] != null)
				{
					for (int j = 1; j < 11; j++)
					{
						if (this.ArmArray[j] != null)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.SmallDarkAura, this.ArmArray[j].transform.position, Quaternion.identity);
							UnityEngine.Object.Destroy(this.ArmArray[j]);
						}
					}
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
				if (this.Darkness.color.a == 1f)
				{
					SchoolGlobals.SchoolAtmosphere = 0f;
					this.StudentManager.SetAtmosphere();
					this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					this.DemonSubtitle.text = "...revenge...at last...";
					this.BloodProjector.SetActive(true);
					this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					component.clip = this.DemonLine;
					component.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 0f)
				{
					component.clip = this.DemonMusic;
					component.loop = true;
					component.Play();
					this.DemonSubtitle.text = string.Empty;
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_demonSummon_00");
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)this.ArmsSpawned)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.DemonArm, this.SpawnPoints[this.ArmsSpawned].position, Quaternion.identity);
					gameObject.transform.parent = this.Yandere.transform;
					gameObject.transform.LookAt(this.Yandere.transform);
					gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 180f, gameObject.transform.localEulerAngles.z);
					this.ArmsSpawned++;
					gameObject.GetComponent<DemonArmScript>().IdleAnim = ((this.ArmsSpawned % 2 != 1) ? "DemonArmIdle" : "DemonArmIdleOld");
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
		if (this.SummonFlameDemon)
		{
			if (this.Phase == 1)
			{
				foreach (RagdollScript ragdollScript2 in this.Police.CorpseList)
				{
					if (ragdollScript2 != null && ragdollScript2.Burned && ragdollScript2.Sacrifice && !ragdollScript2.Dragged && !ragdollScript2.Carried)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.SmallDarkAura, ragdollScript2.Prompt.transform.position, Quaternion.identity);
						UnityEngine.Object.Destroy(ragdollScript2.gameObject);
						this.Yandere.NearBodies--;
						this.Police.Corpses--;
					}
				}
				this.Phase++;
			}
			else if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
				if (this.Darkness.color.a == 1f)
				{
					this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					this.DemonSubtitle.text = "You have proven your worth. Very well. I shall lend you my power.";
					this.DemonSubtitle.color = new Color(1f, 0f, 0f, 0f);
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					component.clip = this.FlameDemonLine;
					component.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 0f)
				{
					this.DemonDress.SetActive(true);
					this.Yandere.MyRenderer.sharedMesh = this.FlameDemonMesh;
					this.RiggedAccessory.SetActive(true);
					this.Yandere.FlameDemonic = true;
					this.Yandere.Stance.Current = StanceType.Standing;
					this.Yandere.Sanity = 100f;
					this.Yandere.MyRenderer.materials[0].mainTexture = this.Yandere.FaceTexture;
					this.Yandere.MyRenderer.materials[1].mainTexture = this.Yandere.NudePanties;
					this.Yandere.MyRenderer.materials[2].mainTexture = this.Yandere.NudePanties;
					this.DebugMenu.UpdateCensor();
					component.clip = this.DemonMusic;
					component.loop = true;
					component.Play();
					this.DemonSubtitle.text = string.Empty;
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_demonSummon_00");
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 5f)
				{
					component.PlayOneShot(this.FlameActivate);
					this.RightFlame.SetActive(true);
					this.LeftFlame.SetActive(true);
					this.Phase++;
				}
			}
			else if (this.Phase == 8)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 10f)
				{
					this.Yandere.CanMove = true;
					this.Yandere.IdleAnim = "f02_demonIdle_00";
					this.Yandere.WalkAnim = "f02_demonWalk_00";
					this.Yandere.RunAnim = "f02_demonRun_00";
					this.SummonFlameDemon = false;
				}
			}
		}
		if (this.SummonEmptyDemon)
		{
			if (this.Phase == 1)
			{
				if (this.BodyArray[1] != null)
				{
					for (int l = 1; l < 12; l++)
					{
						if (this.BodyArray[l] != null)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.SmallDarkAura, this.BodyArray[l].transform.position, Quaternion.identity);
							UnityEngine.Object.Destroy(this.BodyArray[l]);
						}
					}
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
				if (this.Darkness.color.a == 1f)
				{
					this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
					this.DemonSubtitle.text = "At last...it is time to reclaim our rightful place.";
					this.BloodProjector.SetActive(true);
					this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					component.clip = this.EmptyDemonLine;
					component.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					GameGlobals.EmptyDemon = true;
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Trigger collision!");
		if (other.transform.parent == this.LimbParent)
		{
			Debug.Log("The object is a child of LimbParent!");
			PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
			if (component != null)
			{
				Debug.Log("The object has a PickUpScript!");
				BodyPartScript bodyPart = component.BodyPart;
				if (bodyPart.Sacrifice)
				{
					Debug.Log("The object is a sacrifice!");
					if (bodyPart.Type == 3 || bodyPart.Type == 4)
					{
						Debug.Log("The object is an arm or a leg!");
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
							Debug.Log("Increment arm count!");
							this.Arms++;
							if (this.Arms < this.ArmArray.Length)
							{
								this.ArmArray[this.Arms] = other.gameObject;
							}
						}
					}
				}
			}
		}
		if (other.transform.parent != null && other.transform.parent.parent != null && other.transform.parent.parent.parent != null)
		{
			StudentScript component2 = other.transform.parent.parent.parent.gameObject.GetComponent<StudentScript>();
			if (component2 != null && component2.Ragdoll.Sacrifice && component2.Armband.activeInHierarchy)
			{
				bool flag2 = true;
				for (int j = 1; j < 11; j++)
				{
					if (this.BodyArray[j] == other.gameObject)
					{
						flag2 = false;
					}
				}
				if (flag2)
				{
					this.Bodies++;
					if (this.Bodies < this.BodyArray.Length)
					{
						this.BodyArray[this.Bodies] = other.gameObject;
					}
				}
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
		if (component != null && component.BodyPart)
		{
			BodyPartScript component2 = other.gameObject.GetComponent<BodyPartScript>();
			if (component2.Sacrifice && (other.gameObject.name == "FemaleRightArm(Clone)" || other.gameObject.name == "FemaleLeftArm(Clone)" || other.gameObject.name == "MaleRightArm(Clone)" || other.gameObject.name == "MaleLeftArm(Clone)" || other.gameObject.name == "SacrificialArm(Clone)"))
			{
				this.Arms--;
				Debug.Log("Decrement arm count again?");
			}
		}
		if (other.transform.parent != null && other.transform.parent.parent != null && other.transform.parent.parent.parent != null)
		{
			StudentScript component3 = other.transform.parent.parent.parent.gameObject.GetComponent<StudentScript>();
			if (component3 != null && component3.Ragdoll.Sacrifice && component3.Armband.activeInHierarchy)
			{
				this.Bodies--;
			}
		}
	}

	private void Shuffle(int Start)
	{
		for (int i = Start; i < this.ArmArray.Length - 1; i++)
		{
			this.ArmArray[i] = this.ArmArray[i + 1];
		}
	}

	private void ShuffleBodies(int Start)
	{
		for (int i = Start; i < this.BodyArray.Length - 1; i++)
		{
			this.BodyArray[i] = this.BodyArray[i + 1];
		}
	}
}
