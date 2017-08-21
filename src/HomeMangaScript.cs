using System;
using UnityEngine;

public class HomeMangaScript : MonoBehaviour
{
	private static readonly string[] SeductionStrings = new string[]
	{
		"Innocent",
		"Flirty",
		"Charming",
		"Sensual",
		"Seductive",
		"Succubus"
	};

	private static readonly string[] NumbnessStrings = new string[]
	{
		"Stoic",
		"Somber",
		"Detatched",
		"Unemotional",
		"Desensitized",
		"Dead Inside"
	};

	private static readonly string[] EnlightenmentStrings = new string[]
	{
		"Asleep",
		"Awoken",
		"Mindful",
		"Informed",
		"Eyes Open",
		"Omniscient"
	};

	public InputManagerScript InputManager;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public HomeDarknessScript Darkness;

	private GameObject NewManga;

	public GameObject ReadButtonGroup;

	public GameObject MysteryManga;

	public GameObject AreYouSure;

	public GameObject MangaGroup;

	public GameObject[] MangaList;

	public UILabel MangaNameLabel;

	public UILabel MangaDescLabel;

	public UILabel MangaBuffLabel;

	public UILabel RequiredLabel;

	public UILabel CurrentLabel;

	public UILabel ButtonLabel;

	public Transform MangaParent;

	public bool DestinationReached;

	public float TargetRotation;

	public float Rotation;

	public int TotalManga;

	public int Selected;

	public string Title = string.Empty;

	public GameObject[] MangaModels;

	public string[] MangaNames;

	public string[] MangaDescs;

	public string[] MangaBuffs;

	private void Start()
	{
		this.UpdateCurrentLabel();
		for (int i = 0; i < this.TotalManga; i++)
		{
			if (Globals.GetMangaCollected(i + 1))
			{
				this.NewManga = UnityEngine.Object.Instantiate<GameObject>(this.MangaModels[i], new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - 1f), Quaternion.identity);
			}
			else
			{
				this.NewManga = UnityEngine.Object.Instantiate<GameObject>(this.MysteryManga, new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - 1f), Quaternion.identity);
			}
			this.NewManga.transform.parent = this.MangaParent;
			this.NewManga.GetComponent<HomeMangaBookScript>().Manga = this;
			this.NewManga.GetComponent<HomeMangaBookScript>().ID = i;
			this.NewManga.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
			this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, this.MangaParent.transform.localEulerAngles.y + 360f / (float)this.TotalManga, this.MangaParent.transform.localEulerAngles.z);
			this.MangaList[i] = this.NewManga;
		}
		this.MangaParent.transform.localEulerAngles = new Vector3(this.MangaParent.transform.localEulerAngles.x, 0f, this.MangaParent.transform.localEulerAngles.z);
		this.MangaParent.transform.localPosition = new Vector3(this.MangaParent.transform.localPosition.x, this.MangaParent.transform.localPosition.y, 1.8f);
		this.UpdateMangaLabels();
		this.MangaParent.transform.localScale = Vector3.zero;
		this.MangaParent.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (this.HomeWindow.Show)
		{
			if (!this.AreYouSure.activeInHierarchy)
			{
				this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.MangaParent.gameObject.SetActive(true);
				if (this.InputManager.TappedRight)
				{
					this.DestinationReached = false;
					this.TargetRotation += 360f / (float)this.TotalManga;
					this.Selected++;
					if (this.Selected > this.TotalManga - 1)
					{
						this.Selected = 0;
					}
					this.UpdateMangaLabels();
					this.UpdateCurrentLabel();
				}
				if (this.InputManager.TappedLeft)
				{
					this.DestinationReached = false;
					this.TargetRotation -= 360f / (float)this.TotalManga;
					this.Selected--;
					if (this.Selected < 0)
					{
						this.Selected = this.TotalManga - 1;
					}
					this.UpdateMangaLabels();
					this.UpdateCurrentLabel();
				}
				this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * 10f);
				this.MangaParent.localEulerAngles = new Vector3(this.MangaParent.localEulerAngles.x, this.Rotation, this.MangaParent.localEulerAngles.z);
				if (Input.GetButtonDown("A") && this.ReadButtonGroup.activeInHierarchy)
				{
					this.MangaGroup.SetActive(false);
					this.AreYouSure.SetActive(true);
				}
				if (Input.GetKeyDown("s"))
				{
					Globals.Seduction++;
					Globals.Numbness++;
					Globals.Enlightenment++;
					if (Globals.Seduction > 5)
					{
						Globals.Seduction = 0;
						Globals.Numbness = 0;
						Globals.Enlightenment = 0;
					}
					this.UpdateCurrentLabel();
					this.UpdateMangaLabels();
				}
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeYandere.CanMove = true;
					this.HomeWindow.Show = false;
				}
				if (Input.GetKeyDown("space"))
				{
					for (int i = 0; i < this.TotalManga; i++)
					{
						Globals.SetMangaCollected(i + 1, true);
					}
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected < 5)
					{
						Globals.Seduction++;
					}
					else if (this.Selected < 10)
					{
						Globals.Numbness++;
					}
					else
					{
						Globals.Enlightenment++;
					}
					Globals.LateForSchool = true;
					this.AreYouSure.SetActive(false);
					this.Darkness.FadeOut = true;
				}
				if (Input.GetButtonDown("B"))
				{
					this.MangaGroup.SetActive(true);
					this.AreYouSure.SetActive(false);
				}
			}
		}
		else
		{
			this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, Vector3.zero, Time.deltaTime * 10f);
			if (this.MangaParent.localScale.x < 0.01f)
			{
				this.MangaParent.gameObject.SetActive(false);
			}
		}
	}

	private void UpdateMangaLabels()
	{
		if (this.Selected < 5)
		{
			this.ReadButtonGroup.SetActive(Globals.Seduction == this.Selected);
			if (Globals.GetMangaCollected(this.Selected + 1))
			{
				if (Globals.Seduction > this.Selected)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Seduction Level: " + this.Selected.ToString();
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.SetActive(false);
			}
		}
		else if (this.Selected < 10)
		{
			this.ReadButtonGroup.SetActive(Globals.Numbness == this.Selected - 5);
			if (Globals.GetMangaCollected(this.Selected + 1))
			{
				if (Globals.Numbness > this.Selected - 5)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Numbness Level: " + (this.Selected - 5).ToString();
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.SetActive(false);
			}
		}
		else
		{
			this.ReadButtonGroup.SetActive(Globals.Enlightenment == this.Selected - 10);
			if (Globals.GetMangaCollected(this.Selected + 1))
			{
				if (Globals.Enlightenment > this.Selected - 10)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Enlightenment Level: " + (this.Selected - 10).ToString();
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.SetActive(false);
			}
		}
		if (Globals.GetMangaCollected(this.Selected + 1))
		{
			this.MangaNameLabel.text = this.MangaNames[this.Selected];
			this.MangaDescLabel.text = this.MangaDescs[this.Selected];
			this.MangaBuffLabel.text = this.MangaBuffs[this.Selected];
		}
		else
		{
			this.MangaNameLabel.text = "?????";
			this.MangaDescLabel.text = "?????";
			this.MangaBuffLabel.text = "?????";
		}
	}

	private void UpdateCurrentLabel()
	{
		if (this.Selected < 5)
		{
			this.Title = HomeMangaScript.SeductionStrings[Globals.Seduction];
			this.CurrentLabel.text = string.Concat(new string[]
			{
				"Current Seduction Level: ",
				Globals.Seduction.ToString(),
				" (",
				this.Title,
				")"
			});
		}
		else if (this.Selected < 10)
		{
			this.Title = HomeMangaScript.NumbnessStrings[Globals.Numbness];
			this.CurrentLabel.text = string.Concat(new string[]
			{
				"Current Numbness Level: ",
				Globals.Numbness.ToString(),
				" (",
				this.Title,
				")"
			});
		}
		else
		{
			this.Title = HomeMangaScript.EnlightenmentStrings[Globals.Enlightenment];
			this.CurrentLabel.text = string.Concat(new string[]
			{
				"Current Enlightenment Level: ",
				Globals.Enlightenment.ToString(),
				" (",
				this.Title,
				")"
			});
		}
	}
}
