using System;
using System.Collections;
using UnityEngine;

public class PhotoGalleryScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public TaskManagerScript TaskManager;

	public HomeCursorScript Cursor;

	public YandereScript Yandere;

	public GameObject MovingPhotograph;

	public GameObject LoadingScreen;

	public GameObject Photograph;

	public GameObject AdjustBox;

	public GameObject DeleteBox;

	public GameObject BackBox;

	public Transform CorkboardPanel;

	public Transform Destination;

	public Transform Highlight;

	public Transform Gallery;

	public UITexture[] Photographs;

	public UISprite[] Hearts;

	public UITexture ViewPhoto;

	public UILabel DeleteLabel;

	public UILabel ViewLabel;

	public Texture NoPhoto;

	public Vector2 PreviousPosition;

	public Vector2 MouseDelta;

	public bool Adjusting;

	public bool Corkboard;

	public bool Viewing;

	public bool Moving;

	public bool Reset;

	public int Column;

	public int Row;

	private void Start()
	{
		if (this.Cursor != null)
		{
			this.Cursor.gameObject.SetActive(false);
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!this.Adjusting)
		{
			if (!this.Viewing)
			{
				if (Input.GetButtonDown("A"))
				{
					int i = this.Column + (this.Row - 1) * 5;
					if (this.Photographs[i].mainTexture != this.NoPhoto)
					{
						this.ViewPhoto.mainTexture = this.Photographs[i].mainTexture;
						this.ViewPhoto.transform.position = this.Photographs[i].transform.position;
						this.ViewPhoto.transform.localScale = this.Photographs[i].transform.localScale;
						this.Destination.position = this.Photographs[i].transform.position;
						this.Viewing = true;
						if (this.Corkboard)
						{
							this.ViewLabel.text = "Place";
						}
						else
						{
							for (i = 1; i < 26; i++)
							{
								this.Hearts[i].gameObject.SetActive(false);
							}
						}
						this.DeleteBox.SetActive(false);
						this.AdjustBox.SetActive(false);
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.PauseScreen.MainMenu.SetActive(true);
					this.PauseScreen.Sideways = false;
					this.PauseScreen.PressedB = true;
					base.gameObject.SetActive(false);
				}
				if (Input.GetButtonDown("X"))
				{
					this.ViewPhoto.mainTexture = null;
					int num = this.Column + (this.Row - 1) * 5;
					if (this.Photographs[num].mainTexture != this.NoPhoto)
					{
						this.Photographs[num].mainTexture = this.NoPhoto;
						PlayerPrefs.SetInt("Photo_" + num.ToString(), 0);
						PlayerPrefs.SetInt("SenpaiPhoto_" + num.ToString(), 0);
						PlayerPrefs.SetInt("KittenPhoto_" + num.ToString(), 0);
						this.Hearts[num].gameObject.SetActive(false);
						this.TaskManager.UpdateTaskStatus();
					}
				}
				if (this.Corkboard)
				{
					if (Input.GetButtonDown("Y"))
					{
						this.DeleteLabel.text = "Remove";
						this.ViewLabel.text = "Select";
						this.AdjustBox.SetActive(false);
						this.Cursor.gameObject.SetActive(true);
						this.Adjusting = true;
					}
				}
				else if (this.AdjustBox.activeInHierarchy && Input.GetButtonDown("Y"))
				{
					int num2 = this.Column + (this.Row - 1) * 5;
					PlayerPrefs.SetInt("SenpaiPhoto_" + num2.ToString(), 0);
					this.Hearts[num2].gameObject.SetActive(false);
					this.AdjustBox.SetActive(false);
					this.Yandere.Sanity += 20f;
					this.Yandere.UpdateSanity();
				}
				if (this.InputManager.TappedRight)
				{
					this.Column++;
					if (this.Column > 5)
					{
						this.Column = 1;
					}
					this.Highlight.transform.localPosition = new Vector3(-450f + 150f * (float)this.Column, this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z);
					this.UpdateUseButton();
				}
				if (this.InputManager.TappedLeft)
				{
					this.Column--;
					if (this.Column < 1)
					{
						this.Column = 5;
					}
					this.Highlight.transform.localPosition = new Vector3(-450f + 150f * (float)this.Column, this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z);
					this.UpdateUseButton();
				}
				if (this.InputManager.TappedUp)
				{
					this.Row--;
					if (this.Row < 1)
					{
						this.Row = 5;
					}
					this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 225f - 75f * (float)this.Row, this.Highlight.transform.localPosition.z);
					this.UpdateUseButton();
				}
				if (this.InputManager.TappedDown)
				{
					this.Row++;
					if (this.Row > 5)
					{
						this.Row = 1;
					}
					this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, 225f - 75f * (float)this.Row, this.Highlight.transform.localPosition.z);
					this.UpdateUseButton();
				}
				this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3(1f, 1f, 1f), 0.166666672f);
				this.ViewPhoto.transform.position = Vector3.Lerp(this.ViewPhoto.transform.position, this.Destination.position, 0.166666672f);
				if (this.Corkboard)
				{
					this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 0f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
				}
			}
			else
			{
				this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, (!this.Corkboard) ? new Vector3(6.5f, 6.5f, 6.5f) : new Vector3(5.8f, 5.8f, 5.8f), 0.166666672f);
				this.ViewPhoto.transform.localPosition = Vector3.Lerp(this.ViewPhoto.transform.localPosition, (!this.Corkboard) ? new Vector3(0f, -30f, 0f) : Vector3.zero, 0.166666672f);
				if (Input.GetButtonDown("A") && this.Corkboard)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Photograph, base.transform.position, Quaternion.identity);
					gameObject.transform.parent = this.CorkboardPanel;
					gameObject.transform.localEulerAngles = Vector3.zero;
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					int num3 = this.Column + (this.Row - 1) * 5;
					gameObject.GetComponent<UITexture>().mainTexture = this.Photographs[num3].mainTexture;
					this.MovingPhotograph = gameObject;
					this.AdjustBox.SetActive(false);
					this.DeleteBox.SetActive(false);
					this.BackBox.SetActive(false);
					this.ViewLabel.text = "Place";
					this.Adjusting = true;
					this.Viewing = false;
					this.Moving = true;
				}
				if (Input.GetButtonDown("B"))
				{
					this.DeleteBox.SetActive(true);
					this.Viewing = false;
					if (this.Corkboard)
					{
						this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
						this.DeleteLabel.text = "Delete";
						this.ViewLabel.text = "View";
						this.AdjustBox.SetActive(true);
					}
					else
					{
						for (int j = 1; j < 26; j++)
						{
							if (PlayerPrefs.GetInt("SenpaiPhoto_" + j.ToString()) == 1)
							{
								this.Hearts[j].gameObject.SetActive(true);
								this.AdjustBox.SetActive(true);
							}
						}
					}
				}
			}
		}
		else
		{
			if (this.Corkboard)
			{
				this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 1000f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
			}
			this.MouseDelta = new Vector2(Input.mousePosition.x - this.PreviousPosition.x, Input.mousePosition.y - this.PreviousPosition.y);
			if (this.Moving)
			{
				if (Input.GetMouseButton(1))
				{
					this.MovingPhotograph.transform.localEulerAngles = new Vector3(this.MovingPhotograph.transform.localEulerAngles.x, this.MovingPhotograph.transform.localEulerAngles.y, this.MovingPhotograph.transform.localEulerAngles.z + this.MouseDelta.x);
				}
				else
				{
					this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x + this.MouseDelta.x * 8.66666f, this.MovingPhotograph.transform.localPosition.y + this.MouseDelta.y * 8.66666f);
				}
				if (Input.GetButton("LB"))
				{
					this.MovingPhotograph.transform.localEulerAngles = new Vector3(this.MovingPhotograph.transform.localEulerAngles.x, this.MovingPhotograph.transform.localEulerAngles.y, this.MovingPhotograph.transform.localEulerAngles.z + Time.deltaTime * 100f);
				}
				if (Input.GetButton("RB"))
				{
					this.MovingPhotograph.transform.localEulerAngles = new Vector3(this.MovingPhotograph.transform.localEulerAngles.x, this.MovingPhotograph.transform.localEulerAngles.y, this.MovingPhotograph.transform.localEulerAngles.z - Time.deltaTime * 100f);
				}
				this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x + Input.GetAxis("Horizontal") * 86.66666f, this.MovingPhotograph.transform.localPosition.y + Input.GetAxis("Vertical") * 86.66666f, this.MovingPhotograph.transform.localPosition.z);
				if (this.MovingPhotograph.transform.localPosition.x > 4150f)
				{
					this.MovingPhotograph.transform.localPosition = new Vector3(4150f, this.MovingPhotograph.transform.localPosition.y, this.MovingPhotograph.transform.localPosition.z);
				}
				if (this.MovingPhotograph.transform.localPosition.x < -4150f)
				{
					this.MovingPhotograph.transform.localPosition = new Vector3(-4150f, this.MovingPhotograph.transform.localPosition.y, this.MovingPhotograph.transform.localPosition.z);
				}
				if (this.MovingPhotograph.transform.localPosition.y > 2500f)
				{
					this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x, 2500f, this.MovingPhotograph.transform.localPosition.z);
				}
				if (this.MovingPhotograph.transform.localPosition.y < -2500f)
				{
					this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x, -2500f, this.MovingPhotograph.transform.localPosition.z);
				}
				if (Input.GetButtonDown("A"))
				{
					this.Cursor.transform.localPosition = this.MovingPhotograph.transform.localPosition;
					this.DeleteLabel.text = "Remove";
					this.ViewLabel.text = "Select";
					this.DeleteBox.SetActive(true);
					this.BackBox.SetActive(true);
					this.Cursor.gameObject.SetActive(true);
					this.Moving = false;
				}
			}
			else
			{
				this.Cursor.transform.localPosition = new Vector3(this.Cursor.transform.localPosition.x + this.MouseDelta.x * 8.66666f, this.Cursor.transform.localPosition.y + this.MouseDelta.y * 8.66666f, this.Cursor.transform.localPosition.z);
				this.Cursor.transform.localPosition = new Vector3(this.Cursor.transform.localPosition.x + Input.GetAxis("Horizontal") * 86.66666f, this.Cursor.transform.localPosition.y + Input.GetAxis("Vertical") * 86.66666f, this.Cursor.transform.localPosition.z);
				if (this.Cursor.transform.localPosition.x > 4788f)
				{
					this.Cursor.transform.localPosition = new Vector3(4788f, this.Cursor.transform.localPosition.y, this.Cursor.transform.localPosition.z);
				}
				if (this.Cursor.transform.localPosition.x < -4788f)
				{
					this.Cursor.transform.localPosition = new Vector3(-4788f, this.Cursor.transform.localPosition.y, this.Cursor.transform.localPosition.z);
				}
				if (this.Cursor.transform.localPosition.y > 3122f)
				{
					this.Cursor.transform.localPosition = new Vector3(this.Cursor.transform.localPosition.x, 3122f, this.Cursor.transform.localPosition.z);
				}
				if (this.Cursor.transform.localPosition.y < -3122f)
				{
					this.Cursor.transform.localPosition = new Vector3(this.Cursor.transform.localPosition.x, -3122f, this.Cursor.transform.localPosition.z);
				}
				if (Input.GetButtonDown("A") && this.Cursor.Photograph != null)
				{
					this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
					this.MovingPhotograph = this.Cursor.Photograph;
					this.Cursor.gameObject.SetActive(false);
					this.Moving = true;
				}
				if (Input.GetButtonDown("B"))
				{
					if (this.Cursor.Photograph != null)
					{
						this.Cursor.Photograph = null;
					}
					this.Cursor.transform.localPosition = new Vector3(0f, 0f, this.Cursor.transform.localPosition.z);
					this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
					this.DeleteLabel.text = "Delete";
					this.ViewLabel.text = "View";
					this.DeleteBox.SetActive(true);
					this.AdjustBox.SetActive(true);
					this.BackBox.SetActive(true);
					this.Cursor.gameObject.SetActive(false);
					this.Adjusting = false;
				}
				if (Input.GetButtonDown("X") && this.Cursor.Photograph != null)
				{
					this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
					UnityEngine.Object.Destroy(this.Cursor.Photograph);
				}
			}
		}
		this.PreviousPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}

	public IEnumerator GetPhotos()
	{
		if (!this.Corkboard)
		{
			for (int i = 1; i < 26; i++)
			{
				this.Hearts[i].gameObject.SetActive(false);
			}
		}
		for (int ID = 1; ID < 26; ID++)
		{
			if (PlayerPrefs.GetInt("Photo_" + ID.ToString()) == 1)
			{
				string path = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Photographs/Photo_",
					ID.ToString(),
					".png"
				});
				WWW www = new WWW(path);
				yield return www;
				if (www.error == null)
				{
					this.Photographs[ID].mainTexture = www.texture;
					if (!this.Corkboard && PlayerPrefs.GetInt("SenpaiPhoto_" + ID.ToString()) == 1)
					{
						this.Hearts[ID].gameObject.SetActive(true);
					}
				}
				else
				{
					PlayerPrefs.SetInt("Photo_" + ID.ToString(), 0);
				}
			}
		}
		this.LoadingScreen.SetActive(false);
		if (!this.Corkboard)
		{
			this.PauseScreen.Sideways = true;
		}
		this.UpdateUseButton();
		base.enabled = true;
		base.gameObject.SetActive(true);
		yield break;
	}

	private void UpdateUseButton()
	{
		if (!this.Corkboard)
		{
			int num = this.Column + (this.Row - 1) * 5;
			this.AdjustBox.SetActive(PlayerPrefs.GetInt("SenpaiPhoto_" + num.ToString()) == 1);
		}
	}
}
