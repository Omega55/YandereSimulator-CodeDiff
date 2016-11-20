using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PhotoGalleryScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $GetPhotos$3039 : GenericGenerator<WWW>
	{
		internal PhotoGalleryScript $self_$3044;

		public $GetPhotos$3039(PhotoGalleryScript self_)
		{
			this.$self_$3044 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new PhotoGalleryScript.$GetPhotos$3039.$(this.$self_$3044);
		}
	}

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

	public virtual void Start()
	{
		if (this.Cursor != null)
		{
			this.Cursor.active = false;
			this.enabled = false;
		}
	}

	public virtual void Update()
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
								this.Hearts[i].active = false;
							}
						}
						this.DeleteBox.active = false;
						this.AdjustBox.active = false;
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.PauseScreen.MainMenu.active = true;
					this.PauseScreen.Sideways = false;
					this.PauseScreen.PressedB = true;
					this.gameObject.active = false;
				}
				if (Input.GetButtonDown("X"))
				{
					this.ViewPhoto.mainTexture = null;
					int i = this.Column + (this.Row - 1) * 5;
					if (this.Photographs[i].mainTexture != this.NoPhoto)
					{
						this.Photographs[i].mainTexture = this.NoPhoto;
						PlayerPrefs.SetInt("Photo_" + i, 0);
						PlayerPrefs.SetInt("SenpaiPhoto_" + i, 0);
						PlayerPrefs.SetInt("KittenPhoto_" + i, 0);
						this.Hearts[i].active = false;
						this.TaskManager.UpdateTaskStatus();
					}
				}
				if (this.Corkboard)
				{
					if (Input.GetButtonDown("Y"))
					{
						this.DeleteLabel.text = "Remove";
						this.ViewLabel.text = "Select";
						this.AdjustBox.active = false;
						this.Cursor.active = true;
						this.Adjusting = true;
					}
				}
				else if (this.AdjustBox.active && Input.GetButtonDown("Y"))
				{
					int i = this.Column + (this.Row - 1) * 5;
					PlayerPrefs.SetInt("SenpaiPhoto_" + i, 0);
					this.Hearts[i].active = false;
					this.AdjustBox.active = false;
					this.Yandere.Sanity = this.Yandere.Sanity + (float)20;
					this.Yandere.UpdateSanity();
				}
				if (this.InputManager.TappedRight)
				{
					this.Column++;
					if (this.Column > 5)
					{
						this.Column = 1;
					}
					int num = -450 + 150 * this.Column;
					Vector3 localPosition = this.Highlight.transform.localPosition;
					float num2 = localPosition.x = (float)num;
					Vector3 vector = this.Highlight.transform.localPosition = localPosition;
					this.UpdateUseButton();
				}
				if (this.InputManager.TappedLeft)
				{
					this.Column--;
					if (this.Column < 1)
					{
						this.Column = 5;
					}
					int num3 = -450 + 150 * this.Column;
					Vector3 localPosition2 = this.Highlight.transform.localPosition;
					float num4 = localPosition2.x = (float)num3;
					Vector3 vector2 = this.Highlight.transform.localPosition = localPosition2;
					this.UpdateUseButton();
				}
				if (this.InputManager.TappedUp)
				{
					this.Row--;
					if (this.Row < 1)
					{
						this.Row = 5;
					}
					int num5 = 225 - 75 * this.Row;
					Vector3 localPosition3 = this.Highlight.transform.localPosition;
					float num6 = localPosition3.y = (float)num5;
					Vector3 vector3 = this.Highlight.transform.localPosition = localPosition3;
					this.UpdateUseButton();
				}
				if (this.InputManager.TappedDown)
				{
					this.Row++;
					if (this.Row > 5)
					{
						this.Row = 1;
					}
					int num7 = 225 - 75 * this.Row;
					Vector3 localPosition4 = this.Highlight.transform.localPosition;
					float num8 = localPosition4.y = (float)num7;
					Vector3 vector4 = this.Highlight.transform.localPosition = localPosition4;
					this.UpdateUseButton();
				}
				this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3((float)1, (float)1, (float)1), 0.166666672f);
				this.ViewPhoto.transform.position = Vector3.Lerp(this.ViewPhoto.transform.position, this.Destination.position, 0.166666672f);
				if (this.Corkboard)
				{
					float y = Mathf.Lerp(this.Gallery.transform.localPosition.y, (float)0, Time.deltaTime * (float)10);
					Vector3 localPosition5 = this.Gallery.transform.localPosition;
					float num9 = localPosition5.y = y;
					Vector3 vector5 = this.Gallery.transform.localPosition = localPosition5;
				}
			}
			else
			{
				if (!this.Corkboard)
				{
					this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3(6.5f, 6.5f, 6.5f), 0.166666672f);
				}
				else
				{
					this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3(5.8f, 5.8f, 5.8f), 0.166666672f);
				}
				if (!this.Corkboard)
				{
					this.ViewPhoto.transform.localPosition = Vector3.Lerp(this.ViewPhoto.transform.localPosition, new Vector3((float)0, (float)-30, (float)0), 0.166666672f);
				}
				else
				{
					this.ViewPhoto.transform.localPosition = Vector3.Lerp(this.ViewPhoto.transform.localPosition, new Vector3((float)0, (float)0, (float)0), 0.166666672f);
				}
				if (Input.GetButtonDown("A") && this.Corkboard)
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Photograph, this.transform.position, Quaternion.identity);
					gameObject.transform.parent = this.CorkboardPanel;
					gameObject.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					gameObject.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
					gameObject.transform.localScale = new Vector3((float)1, (float)1, (float)1);
					int i = this.Column + (this.Row - 1) * 5;
					((UITexture)gameObject.GetComponent(typeof(UITexture))).mainTexture = this.Photographs[i].mainTexture;
					this.MovingPhotograph = gameObject;
					this.AdjustBox.active = false;
					this.DeleteBox.active = false;
					this.BackBox.active = false;
					this.ViewLabel.text = "Place";
					this.Adjusting = true;
					this.Viewing = false;
					this.Moving = true;
				}
				if (Input.GetButtonDown("B"))
				{
					this.DeleteBox.active = true;
					this.Viewing = false;
					if (this.Corkboard)
					{
						int num10 = 100;
						Vector3 position = this.Cursor.Highlight.transform.position;
						float num11 = position.y = (float)num10;
						Vector3 vector6 = this.Cursor.Highlight.transform.position = position;
						this.DeleteLabel.text = "Delete";
						this.ViewLabel.text = "View";
						this.AdjustBox.active = true;
					}
					else
					{
						for (int i = 1; i < 26; i++)
						{
							if (PlayerPrefs.GetInt("SenpaiPhoto_" + i) == 1)
							{
								this.Hearts[i].active = true;
								this.AdjustBox.active = true;
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
				float y2 = Mathf.Lerp(this.Gallery.transform.localPosition.y, (float)1000, Time.deltaTime * (float)10);
				Vector3 localPosition6 = this.Gallery.transform.localPosition;
				float num12 = localPosition6.y = y2;
				Vector3 vector7 = this.Gallery.transform.localPosition = localPosition6;
			}
			this.MouseDelta = Input.mousePosition - this.PreviousPosition;
			if (this.Moving)
			{
				if (Input.GetMouseButton(1))
				{
					float z = this.MovingPhotograph.transform.localEulerAngles.z + this.MouseDelta.x;
					Vector3 localEulerAngles = this.MovingPhotograph.transform.localEulerAngles;
					float num13 = localEulerAngles.z = z;
					Vector3 vector8 = this.MovingPhotograph.transform.localEulerAngles = localEulerAngles;
				}
				else
				{
					float x = this.MovingPhotograph.transform.localPosition.x + this.MouseDelta.x * 8.66666f;
					Vector3 localPosition7 = this.MovingPhotograph.transform.localPosition;
					float num14 = localPosition7.x = x;
					Vector3 vector9 = this.MovingPhotograph.transform.localPosition = localPosition7;
					float y3 = this.MovingPhotograph.transform.localPosition.y + this.MouseDelta.y * 8.66666f;
					Vector3 localPosition8 = this.MovingPhotograph.transform.localPosition;
					float num15 = localPosition8.y = y3;
					Vector3 vector10 = this.MovingPhotograph.transform.localPosition = localPosition8;
				}
				if (Input.GetButton("LB"))
				{
					float z2 = this.MovingPhotograph.transform.localEulerAngles.z + Time.deltaTime * (float)100;
					Vector3 localEulerAngles2 = this.MovingPhotograph.transform.localEulerAngles;
					float num16 = localEulerAngles2.z = z2;
					Vector3 vector11 = this.MovingPhotograph.transform.localEulerAngles = localEulerAngles2;
				}
				if (Input.GetButton("RB"))
				{
					float z3 = this.MovingPhotograph.transform.localEulerAngles.z - Time.deltaTime * (float)100;
					Vector3 localEulerAngles3 = this.MovingPhotograph.transform.localEulerAngles;
					float num17 = localEulerAngles3.z = z3;
					Vector3 vector12 = this.MovingPhotograph.transform.localEulerAngles = localEulerAngles3;
				}
				float x2 = this.MovingPhotograph.transform.localPosition.x + Input.GetAxis("Horizontal") * 86.66666f;
				Vector3 localPosition9 = this.MovingPhotograph.transform.localPosition;
				float num18 = localPosition9.x = x2;
				Vector3 vector13 = this.MovingPhotograph.transform.localPosition = localPosition9;
				float y4 = this.MovingPhotograph.transform.localPosition.y + Input.GetAxis("Vertical") * 86.66666f;
				Vector3 localPosition10 = this.MovingPhotograph.transform.localPosition;
				float num19 = localPosition10.y = y4;
				Vector3 vector14 = this.MovingPhotograph.transform.localPosition = localPosition10;
				if (this.MovingPhotograph.transform.localPosition.x > (float)4150)
				{
					int num20 = 4150;
					Vector3 localPosition11 = this.MovingPhotograph.transform.localPosition;
					float num21 = localPosition11.x = (float)num20;
					Vector3 vector15 = this.MovingPhotograph.transform.localPosition = localPosition11;
				}
				if (this.MovingPhotograph.transform.localPosition.x < (float)-4150)
				{
					int num22 = -4150;
					Vector3 localPosition12 = this.MovingPhotograph.transform.localPosition;
					float num23 = localPosition12.x = (float)num22;
					Vector3 vector16 = this.MovingPhotograph.transform.localPosition = localPosition12;
				}
				if (this.MovingPhotograph.transform.localPosition.y > (float)2500)
				{
					int num24 = 2500;
					Vector3 localPosition13 = this.MovingPhotograph.transform.localPosition;
					float num25 = localPosition13.y = (float)num24;
					Vector3 vector17 = this.MovingPhotograph.transform.localPosition = localPosition13;
				}
				if (this.MovingPhotograph.transform.localPosition.y < (float)-2500)
				{
					int num26 = -2500;
					Vector3 localPosition14 = this.MovingPhotograph.transform.localPosition;
					float num27 = localPosition14.y = (float)num26;
					Vector3 vector18 = this.MovingPhotograph.transform.localPosition = localPosition14;
				}
				if (Input.GetButtonDown("A"))
				{
					this.Cursor.transform.localPosition = this.MovingPhotograph.transform.localPosition;
					this.DeleteLabel.text = "Remove";
					this.ViewLabel.text = "Select";
					this.DeleteBox.active = true;
					this.BackBox.active = true;
					this.Cursor.active = true;
					this.Moving = false;
				}
			}
			else
			{
				float x3 = this.Cursor.transform.localPosition.x + this.MouseDelta.x * 8.66666f;
				Vector3 localPosition15 = this.Cursor.transform.localPosition;
				float num28 = localPosition15.x = x3;
				Vector3 vector19 = this.Cursor.transform.localPosition = localPosition15;
				float y5 = this.Cursor.transform.localPosition.y + this.MouseDelta.y * 8.66666f;
				Vector3 localPosition16 = this.Cursor.transform.localPosition;
				float num29 = localPosition16.y = y5;
				Vector3 vector20 = this.Cursor.transform.localPosition = localPosition16;
				float x4 = this.Cursor.transform.localPosition.x + Input.GetAxis("Horizontal") * 86.66666f;
				Vector3 localPosition17 = this.Cursor.transform.localPosition;
				float num30 = localPosition17.x = x4;
				Vector3 vector21 = this.Cursor.transform.localPosition = localPosition17;
				float y6 = this.Cursor.transform.localPosition.y + Input.GetAxis("Vertical") * 86.66666f;
				Vector3 localPosition18 = this.Cursor.transform.localPosition;
				float num31 = localPosition18.y = y6;
				Vector3 vector22 = this.Cursor.transform.localPosition = localPosition18;
				if (this.Cursor.transform.localPosition.x > (float)4788)
				{
					int num32 = 4788;
					Vector3 localPosition19 = this.Cursor.transform.localPosition;
					float num33 = localPosition19.x = (float)num32;
					Vector3 vector23 = this.Cursor.transform.localPosition = localPosition19;
				}
				if (this.Cursor.transform.localPosition.x < (float)-4788)
				{
					int num34 = -4788;
					Vector3 localPosition20 = this.Cursor.transform.localPosition;
					float num35 = localPosition20.x = (float)num34;
					Vector3 vector24 = this.Cursor.transform.localPosition = localPosition20;
				}
				if (this.Cursor.transform.localPosition.y > (float)3122)
				{
					int num36 = 3122;
					Vector3 localPosition21 = this.Cursor.transform.localPosition;
					float num37 = localPosition21.y = (float)num36;
					Vector3 vector25 = this.Cursor.transform.localPosition = localPosition21;
				}
				if (this.Cursor.transform.localPosition.y < (float)-3122)
				{
					int num38 = -3122;
					Vector3 localPosition22 = this.Cursor.transform.localPosition;
					float num39 = localPosition22.y = (float)num38;
					Vector3 vector26 = this.Cursor.transform.localPosition = localPosition22;
				}
				if (Input.GetButtonDown("A") && this.Cursor.Photograph != null)
				{
					int num40 = 100;
					Vector3 position2 = this.Cursor.Highlight.transform.position;
					float num41 = position2.y = (float)num40;
					Vector3 vector27 = this.Cursor.Highlight.transform.position = position2;
					this.MovingPhotograph = this.Cursor.Photograph;
					this.Cursor.active = false;
					this.Moving = true;
				}
				if (Input.GetButtonDown("B"))
				{
					if (this.Cursor.Photograph != null)
					{
						this.Cursor.Photograph = null;
					}
					int num42 = 0;
					Vector3 localPosition23 = this.Cursor.transform.localPosition;
					float num43 = localPosition23.x = (float)num42;
					Vector3 vector28 = this.Cursor.transform.localPosition = localPosition23;
					int num44 = 0;
					Vector3 localPosition24 = this.Cursor.transform.localPosition;
					float num45 = localPosition24.y = (float)num44;
					Vector3 vector29 = this.Cursor.transform.localPosition = localPosition24;
					int num46 = 100;
					Vector3 position3 = this.Cursor.Highlight.transform.position;
					float num47 = position3.y = (float)num46;
					Vector3 vector30 = this.Cursor.Highlight.transform.position = position3;
					this.DeleteLabel.text = "Delete";
					this.ViewLabel.text = "View";
					this.DeleteBox.active = true;
					this.AdjustBox.active = true;
					this.BackBox.active = true;
					this.Cursor.active = false;
					this.Adjusting = false;
				}
				if (Input.GetButtonDown("X") && this.Cursor.Photograph != null)
				{
					int num48 = 100;
					Vector3 position4 = this.Cursor.Highlight.transform.position;
					float num49 = position4.y = (float)num48;
					Vector3 vector31 = this.Cursor.Highlight.transform.position = position4;
					UnityEngine.Object.Destroy(this.Cursor.Photograph);
				}
			}
		}
		this.PreviousPosition = Input.mousePosition;
	}

	public virtual IEnumerator GetPhotos()
	{
		return new PhotoGalleryScript.$GetPhotos$3039(this).GetEnumerator();
	}

	public virtual void UpdateUseButton()
	{
		if (!this.Corkboard)
		{
			int num = this.Column + (this.Row - 1) * 5;
			if (PlayerPrefs.GetInt("SenpaiPhoto_" + num) == 1)
			{
				this.AdjustBox.active = true;
			}
			else
			{
				this.AdjustBox.active = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
