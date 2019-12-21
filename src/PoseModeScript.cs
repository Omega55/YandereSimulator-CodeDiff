﻿using System;
using System.Collections;
using UnityEngine;

public class PoseModeScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public ParticleSystem Marker;

	public StudentScript Student;

	public YandereScript Yandere;

	public UIPanel Panel;

	public UILabel[] OptionLabels;

	public UILabel HeaderLabel;

	public Transform Highlight;

	public Transform Bone;

	public GameObject Warning;

	public Camera PoseModeCamera;

	public bool ChoosingBodyRegion;

	public bool ChoosingAction = true;

	public bool ChoosingBone = true;

	public bool SavingLoading;

	public bool Customizing;

	public bool EditingFace;

	public bool Animating;

	public bool Placing;

	public bool Posing;

	public bool Show;

	public int SaveSlot = 1;

	public int Selected = 1;

	public int Region = 1;

	public int AnimID = 1;

	public int Degree = 1;

	public int Offset;

	public int Limit;

	public int Value;

	public string[] StockingNames;

	public int StockingID;

	public string[] AnimationArray;

	private void Start()
	{
		this.PoseModeCamera.gameObject.SetActive(false);
		base.transform.localScale = Vector3.zero;
		this.Panel.enabled = false;
	}

	private void Update()
	{
		if (this.Show)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Selected++;
				this.UpdateHighlight();
			}
			if (this.ChoosingAction)
			{
				if (Input.GetButtonDown("A") && this.OptionLabels[this.Selected].color.a == 1f)
				{
					this.ChoosingAction = false;
					if (this.Selected == 1)
					{
						this.ChoosingBodyRegion = true;
						this.UpdateLabels();
					}
					else if (this.Selected == 2)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Place";
						this.PromptBar.UpdateButtons();
						this.Marker.emission.enabled = true;
						this.Marker.Play();
						this.Yandere.CanMove = true;
						this.ChoosingAction = true;
						this.Placing = true;
						this.Show = false;
						this.Selected = 1;
						this.UpdateHighlight();
					}
					else if (this.Selected == 3)
					{
						this.Customizing = true;
						this.UpdateLabels();
						this.Selected = 1;
						this.UpdateHighlight();
					}
					else if (this.Selected == 4)
					{
						this.PromptBar.Label[2].text = "Page Down";
						this.PromptBar.Label[3].text = "Page Up";
						this.PromptBar.UpdateButtons();
						this.CreateAnimationArray();
						this.Animating = true;
						this.UpdateLabels();
						this.Selected = 1;
						this.UpdateHighlight();
					}
					else if (this.Selected == 5)
					{
						this.Student.CharacterAnimation.Stop();
						this.ChoosingAction = true;
					}
					else if (this.Selected == 6)
					{
						this.PoseModeCamera.gameObject.SetActive(true);
						this.PoseModeCamera.transform.parent = this.Student.Head;
						this.PoseModeCamera.transform.localPosition = new Vector3(0f, 0f, 0.5f);
						this.PoseModeCamera.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.PromptBar.Label[2].text = "Set to 0";
						this.PromptBar.Label[3].text = "Set to 100";
						this.PromptBar.UpdateButtons();
						this.EditingFace = true;
						this.UpdateLabels();
						this.Selected = 1;
						this.UpdateHighlight();
					}
					else if (this.Selected == 7)
					{
						this.SavingLoading = true;
						this.UpdateLabels();
						this.Selected = 1;
						this.UpdateHighlight();
					}
					else if (this.Selected == 8)
					{
						this.Student.MyController.enabled = true;
						this.Student.Pathfinding.canSearch = true;
						this.Student.Pathfinding.canMove = true;
						this.Student.Posing = false;
						this.Student.Stop = false;
						this.Exit();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.Exit();
				}
			}
			else if (this.ChoosingBodyRegion)
			{
				if (Input.GetButtonDown("A") && this.OptionLabels[this.Selected].color.a == 1f)
				{
					this.ChoosingBodyRegion = false;
					if (this.Selected == 1)
					{
						this.Bone = this.Student.transform;
						this.RememberPose();
						this.Posing = true;
						this.UpdateLabels();
					}
					else
					{
						this.ChoosingBone = true;
						this.Region = this.Selected;
						this.UpdateLabels();
						this.Selected = 1;
						this.UpdateHighlight();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.ChoosingBodyRegion = false;
					this.ChoosingAction = true;
					this.Region = 1;
					this.UpdateLabels();
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
			else if (this.ChoosingBone)
			{
				if (Input.GetButtonDown("A"))
				{
					this.ChoosingBone = false;
					this.Posing = true;
					if (this.Region == 2)
					{
						this.Bone = this.Student.BoneSets.BoneSet1[this.Selected];
					}
					else if (this.Region == 3)
					{
						this.Bone = this.Student.BoneSets.BoneSet2[this.Selected];
					}
					else if (this.Region == 4)
					{
						this.Bone = this.Student.BoneSets.BoneSet3[this.Selected];
					}
					else if (this.Region == 5)
					{
						this.Bone = this.Student.BoneSets.BoneSet4[this.Selected];
					}
					else if (this.Region == 6)
					{
						this.Bone = this.Student.BoneSets.BoneSet5[this.Selected];
					}
					else if (this.Region == 7)
					{
						this.Bone = this.Student.BoneSets.BoneSet6[this.Selected];
					}
					else if (this.Region == 8)
					{
						this.Bone = this.Student.BoneSets.BoneSet7[this.Selected];
					}
					else if (this.Region == 9)
					{
						this.Bone = this.Student.BoneSets.BoneSet8[this.Selected];
					}
					else if (this.Region == 10)
					{
						this.Bone = this.Student.BoneSets.BoneSet9[this.Selected];
					}
					this.RememberPose();
					this.UpdateLabels();
				}
				if (Input.GetButtonDown("B"))
				{
					this.ChoosingBodyRegion = true;
					this.ChoosingBone = false;
					this.Region = 1;
					this.UpdateLabels();
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
			else if (this.Posing)
			{
				if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
				{
					this.CalculateValue();
					if (this.Selected == 1)
					{
						this.Bone.localPosition = new Vector3(this.Bone.localPosition.x + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f, this.Bone.localPosition.y, this.Bone.localPosition.z);
					}
					else if (this.Selected == 2)
					{
						this.Bone.localPosition = new Vector3(this.Bone.localPosition.x, this.Bone.localPosition.y + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f, this.Bone.localPosition.z);
					}
					else if (this.Selected == 3)
					{
						this.Bone.localPosition = new Vector3(this.Bone.localPosition.x, this.Bone.localPosition.y, this.Bone.localPosition.z + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f);
					}
					else if (this.Selected == 4)
					{
						this.Bone.Rotate(Vector3.right * (Time.deltaTime * (float)this.Value * (float)this.Degree * 36f));
					}
					else if (this.Selected == 5)
					{
						this.Bone.Rotate(Vector3.up * (Time.deltaTime * (float)this.Value * (float)this.Degree * 36f));
					}
					else if (this.Selected == 6)
					{
						this.Bone.Rotate(Vector3.forward * (Time.deltaTime * (float)this.Value * (float)this.Degree * 36f));
					}
					else if (this.Selected == 7)
					{
						this.Bone.localScale = new Vector3(this.Bone.localScale.x + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f, this.Bone.localScale.y, this.Bone.localScale.z);
					}
					else if (this.Selected == 8)
					{
						this.Bone.localScale = new Vector3(this.Bone.localScale.x, this.Bone.localScale.y + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f, this.Bone.localScale.z);
					}
					else if (this.Selected == 9)
					{
						this.Bone.localScale = new Vector3(this.Bone.localScale.x, this.Bone.localScale.y, this.Bone.localScale.z + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f);
					}
				}
				if (this.Selected == 10)
				{
					if (this.InputManager.TappedRight)
					{
						if (this.Degree < 10)
						{
							this.Degree++;
						}
						this.UpdateLabels();
					}
					else if (this.InputManager.TappedLeft)
					{
						if (this.Degree > 1)
						{
							this.Degree--;
						}
						this.UpdateLabels();
					}
				}
				else if (this.Selected == 11 && Input.GetButtonDown("A"))
				{
					this.ResetPose();
				}
				if (Input.GetButtonDown("B"))
				{
					if (this.Region == 1)
					{
						this.ChoosingBodyRegion = true;
					}
					else
					{
						this.ChoosingBone = true;
					}
					this.Posing = false;
					this.UpdateLabels();
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
			else if (this.Customizing)
			{
				if (this.Selected == 1)
				{
					if (this.InputManager.TappedRight)
					{
						this.Student.Cosmetic.Direction = 1;
						this.Student.Cosmetic.Hairstyle++;
						if (this.Student.Cosmetic.Hairstyle == 20)
						{
							this.Student.Cosmetic.Hairstyle += 2;
						}
						if (!this.Student.Male)
						{
							if (!this.Student.Teacher)
							{
								if (this.Student.Cosmetic.Hairstyle == this.Student.Cosmetic.FemaleHair.Length)
								{
									this.Student.Cosmetic.Hairstyle = 1;
								}
							}
							else if (this.Student.Cosmetic.Hairstyle == this.Student.Cosmetic.TeacherHair.Length)
							{
								this.Student.Cosmetic.Hairstyle = 1;
							}
						}
						else if (this.Student.Cosmetic.Hairstyle == this.Student.Cosmetic.MaleHair.Length)
						{
							this.Student.Cosmetic.Hairstyle = 1;
						}
						this.Student.Cosmetic.Start();
						this.UpdateLabels();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Student.Cosmetic.Direction = -1;
						this.Student.Cosmetic.Hairstyle--;
						if (this.Student.Cosmetic.Hairstyle == 21)
						{
							this.Student.Cosmetic.Hairstyle -= 2;
						}
						if (this.Student.Cosmetic.Hairstyle == 0)
						{
							if (!this.Student.Male)
							{
								if (!this.Student.Teacher)
								{
									this.Student.Cosmetic.Hairstyle = this.Student.Cosmetic.FemaleHair.Length - 1;
								}
								else
								{
									this.Student.Cosmetic.Hairstyle = this.Student.Cosmetic.TeacherHair.Length - 1;
								}
							}
							else
							{
								this.Student.Cosmetic.Hairstyle = this.Student.Cosmetic.MaleHair.Length - 1;
							}
						}
						this.Student.Cosmetic.Start();
						this.UpdateLabels();
					}
				}
				else if (this.Selected == 2)
				{
					if (this.InputManager.TappedRight)
					{
						this.Student.Cosmetic.Accessory++;
						if (!this.Student.Male)
						{
							if (this.Student.Cosmetic.Accessory == this.Student.Cosmetic.FemaleAccessories.Length)
							{
								this.Student.Cosmetic.Accessory = 0;
							}
						}
						else if (this.Student.Cosmetic.Accessory == this.Student.Cosmetic.MaleAccessories.Length)
						{
							this.Student.Cosmetic.Accessory = 0;
						}
						this.Student.Cosmetic.Start();
						this.UpdateLabels();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Student.Cosmetic.Accessory--;
						if (this.Student.Cosmetic.Accessory < 0)
						{
							this.Student.Cosmetic.Accessory = ((!this.Student.Male) ? (this.Student.Cosmetic.FemaleAccessories.Length - 1) : (this.Student.Cosmetic.MaleAccessories.Length - 1));
						}
						this.Student.Cosmetic.Start();
						this.UpdateLabels();
					}
				}
				else if (this.Selected == 3)
				{
					if (this.InputManager.TappedRight)
					{
						this.Student.Schoolwear++;
						if (this.Student.Schoolwear > 3)
						{
							this.Student.Schoolwear = 1;
						}
						this.Student.ChangeSchoolwear();
						this.UpdateLabels();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Student.Schoolwear--;
						if (this.Student.Schoolwear < 1)
						{
							this.Student.Schoolwear = 3;
						}
						this.Student.ChangeSchoolwear();
						this.UpdateLabels();
					}
				}
				else if (this.Selected == 10)
				{
					if (this.InputManager.TappedRight)
					{
						if (this.Degree < 10)
						{
							this.Degree++;
						}
						this.UpdateLabels();
					}
					else if (this.InputManager.TappedLeft)
					{
						if (this.Degree > 1)
						{
							this.Degree--;
						}
						this.UpdateLabels();
					}
				}
				else if (this.Selected == 11)
				{
					if (!this.Student.Male)
					{
						if (this.InputManager.TappedRight)
						{
							this.StockingID++;
							if (this.StockingID == this.StockingNames.Length)
							{
								this.StockingID = 0;
							}
							this.Student.Cosmetic.Stockings = this.StockingNames[this.StockingID];
							base.StartCoroutine(this.Student.Cosmetic.PutOnStockings());
							this.UpdateLabels();
						}
						else if (this.InputManager.TappedLeft)
						{
							this.StockingID--;
							if (this.StockingID < 0)
							{
								this.StockingID = this.StockingNames.Length - 1;
							}
							this.Student.Cosmetic.Stockings = this.StockingNames[this.StockingID];
							base.StartCoroutine(this.Student.Cosmetic.PutOnStockings());
							this.UpdateLabels();
						}
					}
				}
				else if (this.Selected == 12)
				{
					if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
					{
						this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
						this.Student.LiquidProjector.enabled = !this.Student.LiquidProjector.enabled;
						this.UpdateLabels();
					}
				}
				else if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
				{
					this.CalculateValue();
					Material material = this.Student.Cosmetic.HairRenderer.material;
					Material material2 = this.Student.Cosmetic.RightEyeRenderer.material;
					if (this.Selected == 4)
					{
						material.color = new Color(material.color.r + (float)this.Degree * 0.003921569f * (float)this.Value, material.color.g, material.color.b, material.color.a);
					}
					else if (this.Selected == 5)
					{
						material.color = new Color(material.color.r, material.color.g + (float)this.Degree * 0.003921569f * (float)this.Value, material.color.b, material.color.a);
					}
					else if (this.Selected == 6)
					{
						material.color = new Color(material.color.r, material.color.g, material.color.b + (float)this.Degree * 0.003921569f * (float)this.Value, material.color.a);
					}
					else if (this.Selected == 7)
					{
						material2.color = new Color(material2.color.r + (float)this.Degree * 0.003921569f * (float)this.Value, material2.color.g, material2.color.b, material2.color.a);
					}
					else if (this.Selected == 8)
					{
						material2.color = new Color(material2.color.r, material2.color.g + (float)this.Degree * 0.003921569f * (float)this.Value, material2.color.b, material2.color.a);
					}
					else if (this.Selected == 9)
					{
						material2.color = new Color(material2.color.r, material2.color.g, material2.color.b + (float)this.Degree * 0.003921569f * (float)this.Value, material2.color.a);
					}
					this.CapColors();
					this.UpdateLabels();
				}
				if (Input.GetButtonDown("B"))
				{
					this.ChoosingAction = true;
					this.Customizing = false;
					this.UpdateLabels();
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
			else if (this.Animating)
			{
				if (Input.GetButtonDown("X"))
				{
					this.Offset += 16;
					this.UpdateHighlight();
				}
				if (Input.GetButtonDown("Y"))
				{
					this.Offset -= 16;
					this.UpdateHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					this.Student.CharacterAnimation.Stop();
					this.Student.CharacterAnimation.CrossFade(this.AnimationArray[this.Selected + this.Offset]);
				}
				if (Input.GetButtonDown("B"))
				{
					this.PromptBar.Label[2].text = string.Empty;
					this.PromptBar.Label[3].text = string.Empty;
					this.PromptBar.UpdateButtons();
					this.ChoosingAction = true;
					this.Animating = false;
					this.UpdateLabels();
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
			else if (this.EditingFace)
			{
				if (this.Selected == 18)
				{
					if (this.InputManager.TappedRight)
					{
						if (this.Degree < 10)
						{
							this.Degree++;
						}
						this.UpdateLabels();
					}
					else if (this.InputManager.TappedLeft)
					{
						if (this.Degree > 1)
						{
							this.Degree--;
						}
						this.UpdateLabels();
					}
				}
				else
				{
					if (this.InputManager.TappedRight)
					{
						this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) + (float)this.Degree);
						if (this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) > 100f)
						{
							this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 100f);
						}
						this.UpdateLabels();
					}
					else if (this.InputManager.TappedLeft)
					{
						this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) - (float)this.Degree);
						if (this.Student.MyRenderer.GetBlendShapeWeight(this.Selected - 1) < 0f)
						{
							this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 0f);
						}
						this.UpdateLabels();
					}
					if (Input.GetButtonDown("X"))
					{
						this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 0f);
						this.UpdateLabels();
					}
					if (Input.GetButtonDown("Y"))
					{
						this.Student.MyRenderer.SetBlendShapeWeight(this.Selected - 1, 100f);
						this.UpdateLabels();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.PromptBar.Label[2].text = string.Empty;
					this.PromptBar.Label[3].text = string.Empty;
					this.PromptBar.UpdateButtons();
					this.PoseModeCamera.gameObject.SetActive(false);
					this.ChoosingAction = true;
					this.EditingFace = false;
					this.UpdateLabels();
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
			else if (this.SavingLoading)
			{
				if (this.Selected == 1)
				{
					if (this.InputManager.TappedRight)
					{
						this.SaveSlot++;
						this.UpdateLabels();
					}
					else if (this.InputManager.TappedLeft)
					{
						if (this.SaveSlot > 1)
						{
							this.SaveSlot--;
						}
						this.UpdateLabels();
					}
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected == 2)
					{
						PoseSerializer.SerializePose(this.Student.Cosmetic, this.Student.transform, string.Empty + this.SaveSlot);
						this.Yandere.NotificationManager.CustomText = "Pose Saved!";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else if (this.Selected == 3)
					{
						Debug.Log("Our intention is to change the Cosmetic data for: " + this.Student.Name);
						PoseSerializer.DeserializePose(this.Student.Cosmetic, this.Student.transform, string.Empty + this.SaveSlot);
					}
				}
				if (Input.GetButtonDown("B"))
				{
					this.PromptBar.Label[2].text = string.Empty;
					this.PromptBar.Label[3].text = string.Empty;
					this.PromptBar.UpdateButtons();
					this.PoseModeCamera.gameObject.SetActive(false);
					this.ChoosingAction = true;
					this.SavingLoading = false;
					this.UpdateLabels();
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
		}
		else
		{
			if (base.transform.localScale.x > 0.1f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (this.Panel.enabled)
			{
				base.transform.localScale = Vector3.zero;
				this.Panel.enabled = false;
			}
			if (this.Placing && Input.GetButtonDown("A"))
			{
				this.Student.transform.position = this.Marker.transform.position;
				this.Marker.emission.enabled = false;
				this.Placing = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
		}
	}

	private void UpdateHighlight()
	{
		if (!this.Animating)
		{
			if (this.Selected > this.Limit)
			{
				this.Selected = 1;
			}
			else if (this.Selected < 1)
			{
				this.Selected = this.Limit;
			}
		}
		else
		{
			if (this.Selected > this.Limit)
			{
				this.Selected = this.Limit;
				this.Offset++;
			}
			else if (this.Selected < 1)
			{
				this.Selected = 1;
				this.Offset--;
			}
			if (this.Offset < 0)
			{
				this.Offset = this.AnimID - this.Limit;
				this.Selected = this.Limit;
			}
			else if (this.Offset > this.AnimID - this.Limit)
			{
				this.Offset = 0;
				this.Selected = 1;
			}
			this.UpdateLabels();
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 400f - (float)this.Selected * 50f, this.Highlight.localPosition.z);
	}

	public void UpdateLabels()
	{
		for (int i = 1; i < this.OptionLabels.Length; i++)
		{
			UILabel uilabel = this.OptionLabels[i];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 1f);
			uilabel.text = string.Empty;
		}
		this.Warning.SetActive(false);
		if (this.ChoosingAction)
		{
			this.Warning.SetActive(true);
			this.HeaderLabel.text = "Choose Action";
			this.OptionLabels[1].text = "Pose";
			this.OptionLabels[2].text = "Re-Position";
			this.OptionLabels[3].text = "Customize Appearance";
			this.OptionLabels[4].text = "Perform Animation";
			this.OptionLabels[5].text = "Stop Animation";
			this.OptionLabels[6].text = "Edit Face";
			this.OptionLabels[7].text = "Save/Load Pose";
			this.OptionLabels[8].text = "Release Student";
			this.Limit = 8;
			if (this.Student.Male)
			{
				this.OptionLabels[6].color = new Color(1f, 1f, 1f, 0.5f);
			}
		}
		else if (this.ChoosingBodyRegion)
		{
			this.HeaderLabel.text = "Choose Body Region";
			this.OptionLabels[1].text = "Root";
			this.OptionLabels[2].text = "Spine";
			this.OptionLabels[3].text = "Right Leg";
			this.OptionLabels[4].text = "Left Leg";
			this.OptionLabels[5].text = "Right Arm";
			this.OptionLabels[6].text = "Left Arm";
			this.OptionLabels[7].text = "Right Fingers";
			this.OptionLabels[8].text = "Left Fingers";
			this.OptionLabels[9].text = "Face";
			this.OptionLabels[10].text = "Female Only";
			this.Limit = 10;
			UILabel uilabel2 = this.OptionLabels[10];
			uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, (!this.Student.Male) ? 1f : 0.5f);
		}
		else if (this.ChoosingBone)
		{
			this.HeaderLabel.text = "Choose Bone";
			if (this.Region == 2)
			{
				this.OptionLabels[1].text = "Hips";
				this.OptionLabels[2].text = "Spine 1";
				this.OptionLabels[3].text = "Spine 2";
				this.OptionLabels[4].text = "Spine 3";
				this.OptionLabels[5].text = "Spine 4";
				this.OptionLabels[6].text = "Neck";
				this.OptionLabels[7].text = "Head";
				this.Limit = 7;
			}
			else if (this.Region == 3)
			{
				this.OptionLabels[1].text = "Right Leg";
				this.OptionLabels[2].text = "Right Knee";
				this.OptionLabels[3].text = "Right Foot";
				this.OptionLabels[4].text = "Right Toe";
				this.Limit = 4;
			}
			else if (this.Region == 4)
			{
				this.OptionLabels[1].text = "Left Leg";
				this.OptionLabels[2].text = "Left Knee";
				this.OptionLabels[3].text = "Left Foot";
				this.OptionLabels[4].text = "Left Toe";
				this.Limit = 4;
			}
			else if (this.Region == 5)
			{
				this.OptionLabels[1].text = "Right Clavicle";
				this.OptionLabels[2].text = "Right Arm";
				this.OptionLabels[3].text = "Right Elbow";
				this.OptionLabels[4].text = "Right Wrist";
				this.Limit = 4;
			}
			else if (this.Region == 6)
			{
				this.OptionLabels[1].text = "Left Clavicle";
				this.OptionLabels[2].text = "Left Arm";
				this.OptionLabels[3].text = "Left Elbow";
				this.OptionLabels[4].text = "Left Wrist";
				this.Limit = 4;
			}
			else if (this.Region == 7)
			{
				this.OptionLabels[1].text = "Right Pinky 1";
				this.OptionLabels[2].text = "Right Pinky 2";
				this.OptionLabels[3].text = "Right Pinky 3";
				this.OptionLabels[4].text = "Right Ring 1";
				this.OptionLabels[5].text = "Right Ring 2";
				this.OptionLabels[6].text = "Right Ring 3";
				this.OptionLabels[7].text = "Right Middle 1";
				this.OptionLabels[8].text = "Right Middle 2";
				this.OptionLabels[9].text = "Right Middle 3";
				this.OptionLabels[10].text = "Right Index 1";
				this.OptionLabels[11].text = "Right Index 2";
				this.OptionLabels[12].text = "Right Index 3";
				this.OptionLabels[13].text = "Right Thumb 1";
				this.OptionLabels[14].text = "Right Thumb 2";
				this.OptionLabels[15].text = "Right Thumb 3";
				this.Limit = 15;
			}
			else if (this.Region == 8)
			{
				this.OptionLabels[1].text = "Left Pinky 1";
				this.OptionLabels[2].text = "Left Pinky 2";
				this.OptionLabels[3].text = "Left Pinky 3";
				this.OptionLabels[4].text = "Left Ring 1";
				this.OptionLabels[5].text = "Left Ring 2";
				this.OptionLabels[6].text = "Left Ring 3";
				this.OptionLabels[7].text = "Left Middle 1";
				this.OptionLabels[8].text = "Left Middle 2";
				this.OptionLabels[9].text = "Left Middle 3";
				this.OptionLabels[10].text = "Left Index 1";
				this.OptionLabels[11].text = "Left Index 2";
				this.OptionLabels[12].text = "Left Index 3";
				this.OptionLabels[13].text = "Left Thumb 1";
				this.OptionLabels[14].text = "Left Thumb 2";
				this.OptionLabels[15].text = "Left Thumb 3";
				this.Limit = 15;
			}
			else if (this.Region == 9)
			{
				this.OptionLabels[1].text = "Right Eye";
				this.OptionLabels[2].text = "Left Eye";
				this.OptionLabels[3].text = "Right Eyebrow";
				this.OptionLabels[4].text = "Left Eyebrow";
				this.OptionLabels[5].text = "Jaw";
				this.Limit = 5;
			}
			else if (this.Region == 10)
			{
				this.OptionLabels[1].text = "Front Skirt 1";
				this.OptionLabels[2].text = "Front Skirt 2";
				this.OptionLabels[3].text = "Front Skirt 3";
				this.OptionLabels[4].text = "Back Skirt 1";
				this.OptionLabels[5].text = "Back Skirt 2";
				this.OptionLabels[6].text = "Back Skirt 3";
				this.OptionLabels[7].text = "Right Skirt 1";
				this.OptionLabels[8].text = "Right Skirt 2";
				this.OptionLabels[9].text = "Right Skirt 3";
				this.OptionLabels[10].text = "Left Skirt 1";
				this.OptionLabels[11].text = "Left Skirt 2";
				this.OptionLabels[12].text = "Left Skirt 3";
				this.OptionLabels[13].text = "Right Breast";
				this.OptionLabels[14].text = "Right Nipple";
				this.OptionLabels[15].text = "Left Breast";
				this.OptionLabels[16].text = "Left Nipple";
				this.Limit = 16;
			}
		}
		else if (this.Posing)
		{
			this.HeaderLabel.text = "Pose Bone";
			this.OptionLabels[1].text = "Position X";
			this.OptionLabels[2].text = "Position Y";
			this.OptionLabels[3].text = "Position Z";
			this.OptionLabels[4].text = "Rotation X";
			this.OptionLabels[5].text = "Rotation Y";
			this.OptionLabels[6].text = "Rotation Z";
			this.OptionLabels[7].text = "Scale X";
			this.OptionLabels[8].text = "Scale Y";
			this.OptionLabels[9].text = "Scale Z";
			this.OptionLabels[10].text = "Degree of Change: " + this.Degree.ToString();
			this.OptionLabels[11].text = "Reset";
			this.Limit = 11;
		}
		else if (this.Customizing)
		{
			this.HeaderLabel.text = "Customize";
			this.OptionLabels[1].text = "Hairstyle: " + this.Student.Cosmetic.Hairstyle.ToString();
			this.OptionLabels[2].text = "Accessory: " + this.Student.Cosmetic.Accessory.ToString();
			this.OptionLabels[3].text = "Clothing: " + this.Student.Schoolwear.ToString();
			this.OptionLabels[4].text = "Hair R: " + (this.Student.Cosmetic.HairRenderer.material.color.r * 255f).ToString();
			this.OptionLabels[5].text = "Hair G: " + (this.Student.Cosmetic.HairRenderer.material.color.g * 255f).ToString();
			this.OptionLabels[6].text = "Hair B: " + (this.Student.Cosmetic.HairRenderer.material.color.b * 255f).ToString();
			this.OptionLabels[7].text = "Eye R: " + (this.Student.Cosmetic.RightEyeRenderer.material.color.r * 255f).ToString();
			this.OptionLabels[8].text = "Eye G: " + (this.Student.Cosmetic.RightEyeRenderer.material.color.g * 255f).ToString();
			this.OptionLabels[9].text = "Eye B: " + (this.Student.Cosmetic.RightEyeRenderer.material.color.b * 255f).ToString();
			this.OptionLabels[10].text = "Degree of Change: " + this.Degree.ToString();
			this.OptionLabels[11].text = "Stockings: " + this.Student.Cosmetic.Stockings;
			this.OptionLabels[12].text = "Blood: " + this.Student.LiquidProjector.enabled;
			this.Limit = 12;
			UILabel uilabel3 = this.OptionLabels[3];
			UILabel uilabel4 = this.OptionLabels[11];
			if (!this.Student.Male)
			{
				uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 1f);
				uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 1f);
			}
			else
			{
				uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 0.5f);
			}
		}
		else if (this.Animating)
		{
			this.HeaderLabel.text = "Choose Animation";
			for (int j = 1; j < 19; j++)
			{
				this.OptionLabels[j].text = string.Concat(new string[]
				{
					"(",
					(j + this.Offset).ToString(),
					"/",
					this.AnimID.ToString(),
					") ",
					this.AnimationArray[j + this.Offset]
				});
			}
			this.Limit = 18;
		}
		else if (this.EditingFace)
		{
			this.HeaderLabel.text = "Edit Face";
			this.OptionLabels[1].text = "Smile Mouth (" + this.Student.MyRenderer.GetBlendShapeWeight(0) + ")";
			this.OptionLabels[2].text = "Angry Eyebrows (" + this.Student.MyRenderer.GetBlendShapeWeight(1) + ")";
			this.OptionLabels[3].text = "Open Mouth (" + this.Student.MyRenderer.GetBlendShapeWeight(2) + ")";
			this.OptionLabels[4].text = "Ear Size (" + this.Student.MyRenderer.GetBlendShapeWeight(3) + ")";
			this.OptionLabels[5].text = "Nose Size (" + this.Student.MyRenderer.GetBlendShapeWeight(4) + ")";
			this.OptionLabels[6].text = "Close Eyes (" + this.Student.MyRenderer.GetBlendShapeWeight(5) + ")";
			this.OptionLabels[7].text = "Sad Face (" + this.Student.MyRenderer.GetBlendShapeWeight(6) + ")";
			this.OptionLabels[8].text = "(Unavailable) (" + this.Student.MyRenderer.GetBlendShapeWeight(7) + ")";
			this.OptionLabels[9].text = "Thin Eyes (" + this.Student.MyRenderer.GetBlendShapeWeight(8) + ")";
			this.OptionLabels[10].text = "Round Eyes (" + this.Student.MyRenderer.GetBlendShapeWeight(9) + ")";
			this.OptionLabels[11].text = "Evil Face (" + this.Student.MyRenderer.GetBlendShapeWeight(10) + ")";
			this.OptionLabels[12].text = "Naughty Face (" + this.Student.MyRenderer.GetBlendShapeWeight(11) + ")";
			this.OptionLabels[13].text = "Gentle Face (" + this.Student.MyRenderer.GetBlendShapeWeight(12) + ")";
			this.OptionLabels[14].text = "Thick Body (" + this.Student.MyRenderer.GetBlendShapeWeight(13) + ")";
			this.OptionLabels[15].text = "Slim Body (" + this.Student.MyRenderer.GetBlendShapeWeight(14) + ")";
			this.OptionLabels[16].text = "Long Skirt (" + this.Student.MyRenderer.GetBlendShapeWeight(15) + ")";
			this.OptionLabels[17].text = "Short Skirt (" + this.Student.MyRenderer.GetBlendShapeWeight(16) + ")";
			this.OptionLabels[18].text = "Degree of Change: " + this.Degree.ToString();
			this.Limit = 18;
		}
		else if (this.SavingLoading)
		{
			this.HeaderLabel.text = "Save / Load";
			this.OptionLabels[1].text = "Save Slot: " + this.SaveSlot;
			this.OptionLabels[2].text = "Save";
			this.OptionLabels[3].text = "Load";
			this.Limit = 3;
		}
	}

	private void RememberPose()
	{
		PoseModeGlobals.PosePosition = this.Bone.localPosition;
		PoseModeGlobals.PoseRotation = this.Bone.localEulerAngles;
		PoseModeGlobals.PoseScale = this.Bone.localScale;
	}

	private void ResetPose()
	{
		this.Bone.localPosition = PoseModeGlobals.PosePosition;
		this.Bone.localEulerAngles = PoseModeGlobals.PoseRotation;
		this.Bone.localScale = PoseModeGlobals.PoseScale;
	}

	private void CapColors()
	{
		Material material = this.Student.Cosmetic.HairRenderer.material;
		if (material.color.r < 0f)
		{
			material.color = new Color(0f, material.color.g, material.color.b, material.color.a);
		}
		if (material.color.g < 0f)
		{
			material.color = new Color(material.color.r, 0f, material.color.b, material.color.a);
		}
		if (material.color.b < 0f)
		{
			material.color = new Color(material.color.r, material.color.g, 0f, material.color.a);
		}
		if (material.color.r > 1f)
		{
			material.color = new Color(1f, material.color.g, material.color.b, material.color.a);
		}
		if (material.color.g > 1f)
		{
			material.color = new Color(material.color.r, 1f, material.color.b, material.color.a);
		}
		if (material.color.b > 1f)
		{
			material.color = new Color(material.color.r, material.color.g, 1f, material.color.a);
		}
		Material material2 = this.Student.Cosmetic.RightEyeRenderer.material;
		if (material2.color.r < 0f)
		{
			material2.color = new Color(0f, material2.color.g, material2.color.b, material2.color.a);
		}
		if (material2.color.g < 0f)
		{
			material2.color = new Color(material2.color.r, 0f, material2.color.b, material2.color.a);
		}
		if (material2.color.b < 0f)
		{
			material2.color = new Color(material2.color.r, material2.color.g, 0f, material2.color.a);
		}
		if (material2.color.r > 1f)
		{
			material2.color = new Color(1f, material2.color.g, material2.color.b, material2.color.a);
		}
		if (material2.color.g > 1f)
		{
			material2.color = new Color(material2.color.r, 1f, material2.color.b, material2.color.a);
		}
		if (material2.color.b > 1f)
		{
			material2.color = new Color(material2.color.r, material2.color.g, 1f, material2.color.a);
		}
		this.Student.Cosmetic.LeftEyeRenderer.material.color = material2.color;
	}

	private void CreateAnimationArray()
	{
		this.AnimID = 1;
		IEnumerator enumerator = this.Student.CharacterAnimation.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				AnimationState animationState = (AnimationState)obj;
				this.AnimationArray[this.AnimID] = animationState.name;
				this.AnimID++;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		this.AnimID--;
	}

	private void CalculateValue()
	{
		if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f)
		{
			if (Input.GetAxis("Horizontal") > 0.5f)
			{
				this.Value = 1;
			}
			else
			{
				this.Value = -1;
			}
		}
		else if (Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f)
		{
			if (Input.GetAxis("DpadX") > 0.5f)
			{
				this.Value = 1;
			}
			else
			{
				this.Value = -1;
			}
		}
		else
		{
			this.Value = ((!Input.GetKey(KeyCode.RightArrow)) ? -1 : 1);
		}
	}

	private void Exit()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Yandere.CanMove = true;
		this.Show = false;
		this.Selected = 1;
		this.UpdateHighlight();
	}
}
