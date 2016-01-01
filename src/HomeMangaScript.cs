using System;
using UnityEngine;

[Serializable]
public class HomeMangaScript : MonoBehaviour
{
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

	public string Title;

	private int ID;

	public GameObject[] MangaModels;

	public string[] MangaNames;

	public string[] MangaDescs;

	public string[] MangaBuffs;

	public HomeMangaScript()
	{
		this.Title = string.Empty;
	}

	public virtual void Start()
	{
		this.UpdateCurrentLabel();
		while (this.ID < this.TotalManga)
		{
			if (PlayerPrefs.GetInt("Manga_" + (this.ID + 1) + "_Collected") == 1)
			{
				this.NewManga = (GameObject)UnityEngine.Object.Instantiate(this.MangaModels[this.ID], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (float)1), Quaternion.identity);
			}
			else
			{
				this.NewManga = (GameObject)UnityEngine.Object.Instantiate(this.MysteryManga, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (float)1), Quaternion.identity);
			}
			this.NewManga.transform.parent = this.MangaParent;
			((HomeMangaBookScript)this.NewManga.GetComponent(typeof(HomeMangaBookScript))).Manga = this;
			((HomeMangaBookScript)this.NewManga.GetComponent(typeof(HomeMangaBookScript))).ID = this.ID;
			this.NewManga.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
			float y = this.MangaParent.transform.localEulerAngles.y + (float)(360 / this.TotalManga);
			Vector3 localEulerAngles = this.MangaParent.transform.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.MangaParent.transform.localEulerAngles = localEulerAngles;
			this.MangaList[this.ID] = this.NewManga;
			this.ID++;
		}
		int num2 = 0;
		Vector3 localEulerAngles2 = this.MangaParent.transform.localEulerAngles;
		float num3 = localEulerAngles2.y = (float)num2;
		Vector3 vector2 = this.MangaParent.transform.localEulerAngles = localEulerAngles2;
		float z = 1.8f;
		Vector3 localPosition = this.MangaParent.transform.localPosition;
		float num4 = localPosition.z = z;
		Vector3 vector3 = this.MangaParent.transform.localPosition = localPosition;
		this.UpdateMangaLabels();
		this.MangaParent.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.MangaParent.gameObject.active = false;
	}

	public virtual void Update()
	{
		if (this.HomeWindow.Show)
		{
			if (!this.AreYouSure.active)
			{
				this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.MangaParent.gameObject.active = true;
				if (this.InputManager.TappedRight)
				{
					this.DestinationReached = false;
					this.TargetRotation += (float)(360 / this.TotalManga);
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
					this.TargetRotation -= (float)(360 / this.TotalManga);
					this.Selected--;
					if (this.Selected < 0)
					{
						this.Selected = this.TotalManga - 1;
					}
					this.UpdateMangaLabels();
					this.UpdateCurrentLabel();
				}
				this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * (float)10);
				float rotation = this.Rotation;
				Vector3 localEulerAngles = this.MangaParent.localEulerAngles;
				float num = localEulerAngles.y = rotation;
				Vector3 vector = this.MangaParent.localEulerAngles = localEulerAngles;
				if (Input.GetButtonDown("A") && this.ReadButtonGroup.active)
				{
					this.MangaGroup.active = false;
					this.AreYouSure.active = true;
				}
				if (Input.GetKeyDown("s"))
				{
					PlayerPrefs.SetInt("Seduction", PlayerPrefs.GetInt("Seduction") + 1);
					PlayerPrefs.SetInt("Numbness", PlayerPrefs.GetInt("Numbness") + 1);
					PlayerPrefs.SetInt("Enlightenment", PlayerPrefs.GetInt("Enlightenment") + 1);
					if (PlayerPrefs.GetInt("Seduction") > 5)
					{
						PlayerPrefs.SetInt("Seduction", 0);
						PlayerPrefs.SetInt("Numbness", 0);
						PlayerPrefs.SetInt("Enlightenment", 0);
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
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected < 5)
					{
						PlayerPrefs.SetInt("Seduction", PlayerPrefs.GetInt("Seduction") + 1);
					}
					else if (this.Selected < 10)
					{
						PlayerPrefs.SetInt("Numbness", PlayerPrefs.GetInt("Numbness") + 1);
					}
					else
					{
						PlayerPrefs.SetInt("Enlightenment", PlayerPrefs.GetInt("Enlightenment") + 1);
					}
					PlayerPrefs.SetInt("Late", 1);
					this.AreYouSure.active = false;
					this.Darkness.FadeOut = true;
				}
				if (Input.GetButtonDown("B"))
				{
					this.MangaGroup.active = true;
					this.AreYouSure.active = false;
				}
			}
		}
		else
		{
			this.MangaParent.localScale = Vector3.Lerp(this.MangaParent.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			if (this.MangaParent.localScale.x < 0.01f)
			{
				this.MangaParent.gameObject.active = false;
			}
		}
	}

	public virtual void UpdateMangaLabels()
	{
		if (this.Selected < 5)
		{
			if (PlayerPrefs.GetInt("Seduction") != this.Selected)
			{
				this.ReadButtonGroup.active = false;
			}
			else
			{
				this.ReadButtonGroup.active = true;
			}
			if (PlayerPrefs.GetInt("Manga_" + (this.Selected + 1) + "_Collected") == 1)
			{
				if (PlayerPrefs.GetInt("Seduction") > this.Selected)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Seduction Level: " + this.Selected;
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.active = false;
			}
		}
		else if (this.Selected < 10)
		{
			if (PlayerPrefs.GetInt("Numbness") != this.Selected - 5)
			{
				this.ReadButtonGroup.active = false;
			}
			else
			{
				this.ReadButtonGroup.active = true;
			}
			if (PlayerPrefs.GetInt("Manga_" + (this.Selected + 1) + "_Collected") == 1)
			{
				if (PlayerPrefs.GetInt("Numbness") > this.Selected - 5)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Numbness Level: " + (this.Selected - 5);
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.active = false;
			}
		}
		else
		{
			if (PlayerPrefs.GetInt("Enlightenment") != this.Selected - 10)
			{
				this.ReadButtonGroup.active = false;
			}
			else
			{
				this.ReadButtonGroup.active = true;
			}
			if (PlayerPrefs.GetInt("Manga_" + (this.Selected + 1) + "_Collected") == 1)
			{
				if (PlayerPrefs.GetInt("Enlightenment") > this.Selected - 10)
				{
					this.RequiredLabel.text = "You have already read this manga.";
				}
				else
				{
					this.RequiredLabel.text = "Required Enlightenment Level: " + (this.Selected - 10);
				}
			}
			else
			{
				this.RequiredLabel.text = "You have not yet collected this manga.";
				this.ReadButtonGroup.active = false;
			}
		}
		if (PlayerPrefs.GetInt("Manga_" + (this.Selected + 1) + "_Collected") == 1)
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

	public virtual void UpdateCurrentLabel()
	{
		if (this.Selected < 5)
		{
			if (PlayerPrefs.GetInt("Seduction") == 0)
			{
				this.Title = "Innocent";
			}
			else if (PlayerPrefs.GetInt("Seduction") == 1)
			{
				this.Title = "Flirty";
			}
			else if (PlayerPrefs.GetInt("Seduction") == 2)
			{
				this.Title = "Charming";
			}
			else if (PlayerPrefs.GetInt("Seduction") == 3)
			{
				this.Title = "Sensual";
			}
			else if (PlayerPrefs.GetInt("Seduction") == 4)
			{
				this.Title = "Seductive";
			}
			else if (PlayerPrefs.GetInt("Seduction") == 5)
			{
				this.Title = "Succubus";
			}
			this.CurrentLabel.text = "Current Seduction Level: " + PlayerPrefs.GetInt("Seduction") + " (" + this.Title + ")";
		}
		else if (this.Selected < 10)
		{
			if (PlayerPrefs.GetInt("Numbness") == 0)
			{
				this.Title = "Stoic";
			}
			else if (PlayerPrefs.GetInt("Numbness") == 1)
			{
				this.Title = "Somber";
			}
			else if (PlayerPrefs.GetInt("Numbness") == 2)
			{
				this.Title = "Detatched";
			}
			else if (PlayerPrefs.GetInt("Numbness") == 3)
			{
				this.Title = "Unemotional";
			}
			else if (PlayerPrefs.GetInt("Numbness") == 4)
			{
				this.Title = "Desensitized";
			}
			else if (PlayerPrefs.GetInt("Numbness") == 5)
			{
				this.Title = "Dead Inside";
			}
			this.CurrentLabel.text = "Current Numbness Level: " + PlayerPrefs.GetInt("Numbness") + " (" + this.Title + ")";
		}
		else
		{
			if (PlayerPrefs.GetInt("Enlightenment") == 0)
			{
				this.Title = "Asleep";
			}
			else if (PlayerPrefs.GetInt("Enlightenment") == 1)
			{
				this.Title = "Awoken";
			}
			else if (PlayerPrefs.GetInt("Enlightenment") == 2)
			{
				this.Title = "Mindful";
			}
			else if (PlayerPrefs.GetInt("Enlightenment") == 3)
			{
				this.Title = "Informed";
			}
			else if (PlayerPrefs.GetInt("Enlightenment") == 4)
			{
				this.Title = "Eyes Open";
			}
			else if (PlayerPrefs.GetInt("Enlightenment") == 5)
			{
				this.Title = "Omniscient";
			}
			this.CurrentLabel.text = "Current Enlightenment Level: " + PlayerPrefs.GetInt("Enlightenment") + " (" + this.Title + ")";
		}
	}

	public virtual void Main()
	{
	}
}
