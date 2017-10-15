using System;
using System.Collections;
using UnityEngine;

public class PhotoGalleryScript : MonoBehaviour
{
	[SerializeField]
	private InputManagerScript InputManager;

	[SerializeField]
	private PauseScreenScript PauseScreen;

	[SerializeField]
	private TaskManagerScript TaskManager;

	public PromptBarScript PromptBar;

	[SerializeField]
	private HomeCursorScript Cursor;

	[SerializeField]
	private YandereScript Yandere;

	[SerializeField]
	private GameObject MovingPhotograph;

	public GameObject LoadingScreen;

	[SerializeField]
	private GameObject Photograph;

	[SerializeField]
	private Transform CorkboardPanel;

	[SerializeField]
	private Transform Destination;

	[SerializeField]
	private Transform Highlight;

	[SerializeField]
	private Transform Gallery;

	[SerializeField]
	private UITexture[] Photographs;

	[SerializeField]
	private UISprite[] Hearts;

	[SerializeField]
	private UITexture ViewPhoto;

	[SerializeField]
	private Texture NoPhoto;

	[SerializeField]
	private Vector2 PreviousPosition;

	[SerializeField]
	private Vector2 MouseDelta;

	public bool Adjusting;

	[SerializeField]
	private bool CanAdjust;

	[SerializeField]
	private bool Corkboard;

	public bool Viewing;

	[SerializeField]
	private bool Moving;

	[SerializeField]
	private bool Reset;

	[SerializeField]
	private int Column;

	[SerializeField]
	private int Row;

	private const float MaxPhotoX = 4150f;

	private const float MaxPhotoY = 2500f;

	private const float MaxCursorX = 4788f;

	private const float MaxCursorY = 3122f;

	private const float CorkboardAspectRatio = 1.53363228f;

	private void Start()
	{
		if (this.Cursor != null)
		{
			this.Cursor.gameObject.SetActive(false);
			base.enabled = false;
		}
	}

	private int CurrentIndex
	{
		get
		{
			return this.Column + (this.Row - 1) * 5;
		}
	}

	private float LerpSpeed
	{
		get
		{
			return Time.unscaledDeltaTime * 10f;
		}
	}

	private float HighlightX
	{
		get
		{
			return -450f + 150f * (float)this.Column;
		}
	}

	private float HighlightY
	{
		get
		{
			return 225f - 75f * (float)this.Row;
		}
	}

	private float MovingPhotoXPercent
	{
		get
		{
			float num = -4150f;
			float num2 = 4150f;
			return (this.MovingPhotograph.transform.localPosition.x - num) / (num2 - num);
		}
		set
		{
			this.MovingPhotograph.transform.localPosition = new Vector3(-4150f + 2f * (4150f * Mathf.Clamp01(value)), this.MovingPhotograph.transform.localPosition.y, this.MovingPhotograph.transform.localPosition.z);
		}
	}

	private float MovingPhotoYPercent
	{
		get
		{
			float num = -2500f;
			float num2 = 2500f;
			return (this.MovingPhotograph.transform.localPosition.y - num) / (num2 - num);
		}
		set
		{
			this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x, -2500f + 2f * (2500f * Mathf.Clamp01(value)), this.MovingPhotograph.transform.localPosition.z);
		}
	}

	private float MovingPhotoRotation
	{
		get
		{
			return this.MovingPhotograph.transform.localEulerAngles.z;
		}
		set
		{
			this.MovingPhotograph.transform.localEulerAngles = new Vector3(this.MovingPhotograph.transform.localEulerAngles.x, this.MovingPhotograph.transform.localEulerAngles.y, value);
		}
	}

	private float CursorXPercent
	{
		get
		{
			float num = -4788f;
			float num2 = 4788f;
			return (this.Cursor.transform.localPosition.x - num) / (num2 - num);
		}
		set
		{
			this.Cursor.transform.localPosition = new Vector3(-4788f + 2f * (4788f * Mathf.Clamp01(value)), this.Cursor.transform.localPosition.y, this.Cursor.transform.localPosition.z);
		}
	}

	private float CursorYPercent
	{
		get
		{
			float num = -3122f;
			float num2 = 3122f;
			return (this.Cursor.transform.localPosition.y - num) / (num2 - num);
		}
		set
		{
			this.Cursor.transform.localPosition = new Vector3(this.Cursor.transform.localPosition.x, -3122f + 2f * (3122f * Mathf.Clamp01(value)), this.Cursor.transform.localPosition.z);
		}
	}

	private void UpdatePhotoSelection()
	{
		if (Input.GetButtonDown("A"))
		{
			UITexture uitexture = this.Photographs[this.CurrentIndex];
			if (uitexture.mainTexture != this.NoPhoto)
			{
				this.ViewPhoto.mainTexture = uitexture.mainTexture;
				this.ViewPhoto.transform.position = uitexture.transform.position;
				this.ViewPhoto.transform.localScale = uitexture.transform.localScale;
				this.Destination.position = uitexture.transform.position;
				this.Viewing = true;
				if (!this.Corkboard)
				{
					for (int i = 1; i < 26; i++)
					{
						this.Hearts[i].gameObject.SetActive(false);
					}
				}
				this.CanAdjust = false;
			}
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("X"))
		{
			this.ViewPhoto.mainTexture = null;
			int currentIndex = this.CurrentIndex;
			if (this.Photographs[currentIndex].mainTexture != this.NoPhoto)
			{
				this.Photographs[currentIndex].mainTexture = this.NoPhoto;
				PlayerGlobals.SetPhoto(currentIndex, false);
				PlayerGlobals.SetSenpaiPhoto(currentIndex, false);
				TaskGlobals.SetKittenPhoto(currentIndex, false);
				this.Hearts[currentIndex].gameObject.SetActive(false);
				this.TaskManager.UpdateTaskStatus();
			}
			this.UpdateButtonPrompts();
		}
		if (this.Corkboard)
		{
			if (Input.GetButtonDown("Y"))
			{
				this.CanAdjust = false;
				this.Cursor.gameObject.SetActive(true);
				this.Adjusting = true;
				this.UpdateButtonPrompts();
			}
		}
		else if (this.CanAdjust && Input.GetButtonDown("Y"))
		{
			int currentIndex2 = this.CurrentIndex;
			PlayerGlobals.SetSenpaiPhoto(currentIndex2, false);
			this.Hearts[currentIndex2].gameObject.SetActive(false);
			this.CanAdjust = false;
			this.Yandere.Sanity += 20f;
			this.UpdateButtonPrompts();
		}
		if (this.InputManager.TappedRight)
		{
			this.Column = ((this.Column >= 5) ? 1 : (this.Column + 1));
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column = ((this.Column <= 1) ? 5 : (this.Column - 1));
		}
		if (this.InputManager.TappedUp)
		{
			this.Row = ((this.Row <= 1) ? 5 : (this.Row - 1));
		}
		if (this.InputManager.TappedDown)
		{
			this.Row = ((this.Row >= 5) ? 1 : (this.Row + 1));
		}
		bool flag = this.InputManager.TappedRight || this.InputManager.TappedLeft;
		bool flag2 = this.InputManager.TappedUp || this.InputManager.TappedDown;
		if (flag || flag2)
		{
			this.Highlight.transform.localPosition = new Vector3(this.HighlightX, this.HighlightY, this.Highlight.transform.localPosition.z);
			this.UpdateButtonPrompts();
		}
		this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3(1f, 1f, 1f), this.LerpSpeed);
		this.ViewPhoto.transform.position = Vector3.Lerp(this.ViewPhoto.transform.position, this.Destination.position, this.LerpSpeed);
		if (this.Corkboard)
		{
			this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 0f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
		}
	}

	private void UpdatePhotoViewing()
	{
		this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, (!this.Corkboard) ? new Vector3(6.5f, 6.5f, 6.5f) : new Vector3(5.8f, 5.8f, 5.8f), this.LerpSpeed);
		this.ViewPhoto.transform.localPosition = Vector3.Lerp(this.ViewPhoto.transform.localPosition, Vector3.zero, this.LerpSpeed);
		bool flag = this.Corkboard && Input.GetButtonDown("A");
		if (flag)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Photograph, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.CorkboardPanel;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.GetComponent<UITexture>().mainTexture = this.Photographs[this.CurrentIndex].mainTexture;
			this.MovingPhotograph = gameObject;
			this.CanAdjust = false;
			this.Adjusting = true;
			this.Viewing = false;
			this.Moving = true;
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("B"))
		{
			this.Viewing = false;
			if (this.Corkboard)
			{
				this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
				this.CanAdjust = true;
			}
			else
			{
				for (int i = 1; i < 26; i++)
				{
					if (PlayerGlobals.GetSenpaiPhoto(i))
					{
						this.Hearts[i].gameObject.SetActive(true);
						this.CanAdjust = true;
					}
				}
			}
			this.UpdateButtonPrompts();
		}
	}

	private void UpdateCorkboardPhoto()
	{
		if (Input.GetMouseButton(1))
		{
			this.MovingPhotoRotation += this.MouseDelta.x;
		}
		else
		{
			this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x + this.MouseDelta.x * 8.66666f, this.MovingPhotograph.transform.localPosition.y + this.MouseDelta.y * 8.66666f, 0f);
		}
		if (Input.GetButton("LB"))
		{
			this.MovingPhotoRotation += Time.deltaTime * 100f;
		}
		if (Input.GetButton("RB"))
		{
			this.MovingPhotoRotation -= Time.deltaTime * 100f;
		}
		Vector2 vector = new Vector2(this.MovingPhotograph.transform.localPosition.x, this.MovingPhotograph.transform.localPosition.y);
		Vector2 vector2 = new Vector2(Input.GetAxis("Horizontal") * 86.66666f, Input.GetAxis("Vertical") * 86.66666f);
		this.MovingPhotograph.transform.localPosition = new Vector3(Mathf.Clamp(vector.x + vector2.x, -4150f, 4150f), Mathf.Clamp(vector.y + vector2.y, -2500f, 2500f), this.MovingPhotograph.transform.localPosition.z);
		if (Input.GetButtonDown("A"))
		{
			this.Cursor.transform.localPosition = this.MovingPhotograph.transform.localPosition;
			this.Cursor.gameObject.SetActive(true);
			this.Moving = false;
			this.UpdateButtonPrompts();
		}
	}

	private void UpdateCorkboardCursor()
	{
		Vector2 vector = new Vector2(this.Cursor.transform.localPosition.x, this.Cursor.transform.localPosition.y);
		Vector2 vector2 = new Vector2(this.MouseDelta.x * 8.66666f + Input.GetAxis("Horizontal") * 86.66666f, this.MouseDelta.y * 8.66666f + Input.GetAxis("Vertical") * 86.66666f);
		this.Cursor.transform.localPosition = new Vector3(Mathf.Clamp(vector.x + vector2.x, -4788f, 4788f), Mathf.Clamp(vector.y + vector2.y, -3122f, 3122f), this.Cursor.transform.localPosition.z);
		if (Input.GetButtonDown("A") && this.Cursor.Photograph != null)
		{
			this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
			this.MovingPhotograph = this.Cursor.Photograph;
			this.Cursor.gameObject.SetActive(false);
			this.Moving = true;
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Cursor.Photograph != null)
			{
				this.Cursor.Photograph = null;
			}
			this.Cursor.transform.localPosition = new Vector3(0f, 0f, this.Cursor.transform.localPosition.z);
			this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
			this.CanAdjust = true;
			this.Cursor.gameObject.SetActive(false);
			this.Adjusting = false;
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("X") && this.Cursor.Photograph != null)
		{
			this.Cursor.Highlight.transform.position = new Vector3(this.Cursor.Highlight.transform.position.x, 100f, this.Cursor.Highlight.transform.position.z);
			UnityEngine.Object.Destroy(this.Cursor.Photograph);
			this.Cursor.Photograph = null;
			this.UpdateButtonPrompts();
		}
	}

	private void Update()
	{
		if (!this.Adjusting)
		{
			if (!this.Viewing)
			{
				this.UpdatePhotoSelection();
			}
			else
			{
				this.UpdatePhotoViewing();
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
				this.UpdateCorkboardPhoto();
			}
			else
			{
				this.UpdateCorkboardCursor();
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
			if (PlayerGlobals.GetPhoto(ID))
			{
				string path = Application.streamingAssetsPath + "/Photographs/Photo_" + ID.ToString() + ".png";
				WWW www = new WWW(path);
				yield return www;
				if (www.error == null)
				{
					this.Photographs[ID].mainTexture = www.texture;
					if (!this.Corkboard && PlayerGlobals.GetSenpaiPhoto(ID))
					{
						this.Hearts[ID].gameObject.SetActive(true);
					}
				}
				else
				{
					PlayerGlobals.SetPhoto(ID, false);
				}
			}
		}
		this.LoadingScreen.SetActive(false);
		if (!this.Corkboard)
		{
			this.PauseScreen.Sideways = true;
		}
		this.UpdateButtonPrompts();
		base.enabled = true;
		base.gameObject.SetActive(true);
		yield break;
	}

	public void UpdateButtonPrompts()
	{
		if (this.Moving)
		{
			this.PromptBar.Label[0].text = "Place";
			this.PromptBar.Label[1].text = string.Empty;
			this.PromptBar.Label[2].text = string.Empty;
			this.PromptBar.Label[4].text = "Move";
			this.PromptBar.Label[5].text = "Move";
		}
		else if (this.Adjusting)
		{
			if (this.Cursor.Photograph != null)
			{
				this.PromptBar.Label[0].text = "Adjust";
				this.PromptBar.Label[2].text = "Remove";
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.Label[2].text = string.Empty;
			}
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.Label[3].text = string.Empty;
			this.PromptBar.Label[4].text = "Move";
			this.PromptBar.Label[5].text = "Move";
		}
		else if (!this.Viewing)
		{
			int currentIndex = this.CurrentIndex;
			if (this.Photographs[currentIndex].mainTexture != this.NoPhoto)
			{
				this.PromptBar.Label[0].text = "View";
				this.PromptBar.Label[2].text = "Delete";
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.Label[2].text = string.Empty;
			}
			if (!this.Corkboard)
			{
				this.PromptBar.Label[3].text = ((!PlayerGlobals.GetSenpaiPhoto(currentIndex)) ? string.Empty : "Use");
			}
			else
			{
				this.PromptBar.Label[3].text = "Corkboard";
			}
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.Label[5].text = "Choose";
		}
		else
		{
			if (this.Corkboard)
			{
				this.PromptBar.Label[0].text = "Place";
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
			}
			this.PromptBar.Label[2].text = string.Empty;
			this.PromptBar.Label[3].text = string.Empty;
			this.PromptBar.Label[4].text = string.Empty;
			this.PromptBar.Label[5].text = string.Empty;
		}
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
	}
}
