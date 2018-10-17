using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeWindowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public DialogueWheelScript DialogueWheel;

	public InputManagerScript InputManager;

	public StudentScript SparringPartner;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public WeaponScript Baton;

	public Transform[] KneelSpot;

	public Transform[] SparSpot;

	public string[] Difficulties;

	public Texture[] AlbumCovers;

	public UITexture[] Texture;

	public UILabel[] Label;

	public Transform Highlight;

	public GameObject Window;

	public UISprite Darkness;

	public int ClubID;

	public int ID = 1;

	public ClubType Club;

	public bool PlayedRhythmMinigame;

	public bool ButtonUp;

	public bool FadeOut;

	public bool FadeIn;

	public float Timer;

	private void Start()
	{
		this.Window.SetActive(false);
	}

	private void Update()
	{
		if (this.Window.activeInHierarchy)
		{
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.ID++;
				this.UpdateHighlight();
			}
			if (this.ButtonUp)
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.Texture[this.ID].color.r == 1f)
					{
						this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
						this.Yandere.TargetStudent.TalkTimer = 100f;
						this.Yandere.TargetStudent.ClubPhase = 2;
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Window.SetActive(false);
						this.ButtonUp = false;
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
					this.Yandere.TargetStudent.TalkTimer = 100f;
					this.Yandere.TargetStudent.ClubPhase = 3;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Window.SetActive(false);
					this.ButtonUp = false;
				}
			}
			else if (Input.GetButtonUp("A"))
			{
				this.ButtonUp = true;
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.enabled = true;
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				if (this.DialogueWheel.ClubLeader)
				{
					this.DialogueWheel.End();
				}
				if (this.Club == ClubType.LightMusic)
				{
					if (!this.PlayedRhythmMinigame)
					{
						for (int i = 52; i < 56; i++)
						{
							this.StudentManager.Students[i].transform.position = this.StudentManager.Clubs.List[i].position;
							this.StudentManager.Students[i].EmptyHands();
						}
						Physics.SyncTransforms();
						PlayerPrefs.SetFloat("TempReputation", this.StudentManager.Reputation.Reputation);
						this.PlayedRhythmMinigame = true;
						this.FadeOut = false;
						this.FadeIn = true;
						SceneManager.LoadScene("RhythmMinigameScene", LoadSceneMode.Additive);
						foreach (GameObject gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
						{
							gameObject.SetActive(false);
						}
					}
				}
				else if (this.Club == ClubType.MartialArts && this.Yandere.CanMove)
				{
					this.StudentManager.CombatMinigame.Practice = true;
					this.StudentManager.Students[46].CharacterAnimation.CrossFade(this.StudentManager.Students[46].IdleAnim);
					this.StudentManager.Students[46].transform.eulerAngles = new Vector3(0f, 0f, 0f);
					this.StudentManager.Students[46].Pathfinding.canSearch = false;
					this.StudentManager.Students[46].Pathfinding.canMove = false;
					this.StudentManager.Students[46].Distracted = true;
					this.StudentManager.Students[46].enabled = false;
					this.StudentManager.Students[46].Routine = false;
					this.StudentManager.Students[46].Hearts.Stop();
					for (int k = 1; k < 5; k++)
					{
						if (this.StudentManager.Students[46 + k] != null)
						{
							this.StudentManager.Students[46 + k].transform.position = this.KneelSpot[k].position;
							this.StudentManager.Students[46 + k].transform.eulerAngles = this.KneelSpot[k].eulerAngles;
							this.StudentManager.Students[46 + k].Pathfinding.canSearch = false;
							this.StudentManager.Students[46 + k].Pathfinding.canMove = false;
							this.StudentManager.Students[46 + k].Distracted = true;
							this.StudentManager.Students[46 + k].enabled = false;
							this.StudentManager.Students[46 + k].Routine = false;
							if (this.StudentManager.Students[46 + k].Male)
							{
								this.StudentManager.Students[46 + k].CharacterAnimation.CrossFade("sit_04");
							}
							else
							{
								this.StudentManager.Students[46 + k].CharacterAnimation.CrossFade("f02_sit_05");
							}
						}
					}
					this.Yandere.transform.eulerAngles = this.SparSpot[1].eulerAngles;
					this.Yandere.transform.position = this.SparSpot[1].position;
					this.Yandere.CanMove = false;
					this.SparringPartner = this.StudentManager.Students[this.ClubID - this.ID];
					this.SparringPartner.CharacterAnimation.CrossFade(this.SparringPartner.IdleAnim);
					this.SparringPartner.transform.eulerAngles = this.SparSpot[2].eulerAngles;
					this.SparringPartner.transform.position = this.SparSpot[2].position;
					this.SparringPartner.MyWeapon = this.Baton;
					this.SparringPartner.MyWeapon.transform.parent = this.SparringPartner.WeaponBagParent;
					this.SparringPartner.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					this.SparringPartner.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.SparringPartner.MyWeapon.GetComponent<Rigidbody>().useGravity = false;
					this.SparringPartner.MyWeapon.FingerprintID = this.SparringPartner.StudentID;
					this.SparringPartner.MyWeapon.MyCollider.enabled = false;
					Physics.SyncTransforms();
					this.FadeOut = false;
					this.FadeIn = true;
				}
			}
		}
		if (this.FadeIn)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Darkness.color.a == 0f)
			{
				if (this.Club == ClubType.LightMusic)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.Yandere.SetAnimationLayers();
						this.StudentManager.UpdateAllAnimLayers();
						this.StudentManager.Reputation.PendingRep += PlayerPrefs.GetFloat("TempReputation");
						PlayerPrefs.SetFloat("TempReputation", 0f);
						this.FadeIn = false;
						this.Timer = 0f;
					}
				}
				else if (this.Club == ClubType.MartialArts)
				{
					this.SparringPartner.Pathfinding.canSearch = false;
					this.SparringPartner.Pathfinding.canMove = false;
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						if (this.ID == 1)
						{
							this.StudentManager.CombatMinigame.Difficulty = 0.5f;
						}
						else if (this.ID == 2)
						{
							this.StudentManager.CombatMinigame.Difficulty = 0.75f;
						}
						else if (this.ID == 3)
						{
							this.StudentManager.CombatMinigame.Difficulty = 1f;
						}
						else if (this.ID == 4)
						{
							this.StudentManager.CombatMinigame.Difficulty = 1.5f;
						}
						else if (this.ID == 5)
						{
							this.StudentManager.CombatMinigame.Difficulty = 2f;
						}
						this.StudentManager.Students[this.ClubID - this.ID].Threatened = true;
						this.StudentManager.Students[this.ClubID - this.ID].Alarmed = true;
						this.StudentManager.Students[this.ClubID - this.ID].enabled = true;
						this.FadeIn = false;
						this.Timer = 0f;
					}
				}
			}
		}
	}

	public void Finish()
	{
		for (int i = 1; i < 6; i++)
		{
			if (this.StudentManager.Students[45 + i] != null)
			{
				this.StudentManager.Students[45 + i].Pathfinding.canSearch = true;
				this.StudentManager.Students[45 + i].Pathfinding.canMove = true;
				this.StudentManager.Students[45 + i].Distracted = false;
				this.StudentManager.Students[45 + i].enabled = true;
				this.StudentManager.Students[45 + i].Routine = true;
			}
		}
	}

	public void UpdateWindow()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Confirm";
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.Label[4].text = "Choose";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		if (this.Club == ClubType.LightMusic)
		{
			this.Texture[1].mainTexture = this.AlbumCovers[1];
			this.Texture[2].mainTexture = this.AlbumCovers[2];
			this.Texture[3].mainTexture = this.AlbumCovers[3];
			this.Texture[4].mainTexture = this.AlbumCovers[4];
			this.Texture[5].mainTexture = this.AlbumCovers[5];
			this.Label[1].text = "Panther\n" + this.Difficulties[1];
			this.Label[2].text = "?????\n" + this.Difficulties[2];
			this.Label[3].text = "?????\n" + this.Difficulties[3];
			this.Label[4].text = "?????\n" + this.Difficulties[4];
			this.Label[5].text = "?????\n" + this.Difficulties[5];
			this.Texture[2].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Texture[3].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Texture[4].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Texture[5].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.Label[2].color = new Color(0f, 0f, 0f, 0.5f);
			this.Label[3].color = new Color(0f, 0f, 0f, 0.5f);
			this.Label[4].color = new Color(0f, 0f, 0f, 0.5f);
			this.Label[5].color = new Color(0f, 0f, 0f, 0.5f);
		}
		else if (this.Club == ClubType.MartialArts)
		{
			this.ClubID = 51;
			while (this.ID < 6)
			{
				string url = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits/Student_",
					(this.ClubID - this.ID).ToString(),
					".png"
				});
				WWW www = new WWW(url);
				this.Texture[this.ID].mainTexture = www.texture;
				this.Label[this.ID].text = this.StudentManager.JSON.Students[this.ClubID - this.ID].Name + "\n" + this.Difficulties[this.ID];
				if (this.StudentManager.Students[this.ClubID - this.ID] != null)
				{
					if (!this.StudentManager.Students[this.ClubID - this.ID].Routine)
					{
						Debug.Log("A student is not doing their routine.");
						this.Texture[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
						this.Label[this.ID].color = new Color(0f, 0f, 0f, 0.5f);
					}
					else
					{
						this.Texture[this.ID].color = new Color(1f, 1f, 1f, 1f);
						this.Label[this.ID].color = new Color(0f, 0f, 0f, 1f);
					}
				}
				else
				{
					this.Texture[this.ID].color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.Label[this.ID].color = new Color(0f, 0f, 0f, 0.5f);
				}
				this.ID++;
			}
			this.Texture[5].color = new Color(1f, 1f, 1f, 1f);
			this.Label[5].color = new Color(0f, 0f, 0f, 1f);
			this.ID = 1;
		}
		this.Window.SetActive(true);
		this.UpdateHighlight();
	}

	public void UpdateHighlight()
	{
		if (this.ID < 1)
		{
			this.ID = 5;
		}
		else if (this.ID > 5)
		{
			this.ID = 1;
		}
		this.Highlight.localPosition = new Vector3(0f, (float)(660 - 220 * this.ID), 0f);
	}
}
