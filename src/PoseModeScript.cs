using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
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

	public bool ChoosingBodyRegion;

	public bool ChoosingAction;

	public bool ChoosingBone;

	public bool Customizing;

	public bool Animating;

	public bool Placing;

	public bool Posing;

	public bool Show;

	public int Selected;

	public int Region;

	public int AnimID;

	public int Degree;

	public int Offset;

	public int Limit;

	public int Value;

	public string[] AnimationArray;

	public PoseModeScript()
	{
		this.ChoosingAction = true;
		this.ChoosingBone = true;
		this.Selected = 1;
		this.Region = 1;
		this.AnimID = 1;
		this.Degree = 1;
	}

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Panel.enabled = false;
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
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
				if (Input.GetButtonDown("A"))
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
						this.Marker.enableEmission = true;
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
				}
				if (Input.GetButtonDown("B"))
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Yandere.CanMove = true;
					this.Show = false;
					this.Selected = 1;
					this.UpdateHighlight();
				}
			}
			else if (this.ChoosingBodyRegion)
			{
				if (Input.GetButtonDown("A") && this.OptionLabels[this.Selected].color.a == (float)1)
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
				if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey("right") || Input.GetKey("left"))
				{
					this.CalculateValue();
					if (this.Selected == 1)
					{
						float x = this.Bone.localPosition.x + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f;
						Vector3 localPosition = this.Bone.localPosition;
						float num = localPosition.x = x;
						Vector3 vector = this.Bone.localPosition = localPosition;
					}
					else if (this.Selected == 2)
					{
						float y = this.Bone.localPosition.y + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f;
						Vector3 localPosition2 = this.Bone.localPosition;
						float num2 = localPosition2.y = y;
						Vector3 vector2 = this.Bone.localPosition = localPosition2;
					}
					else if (this.Selected == 3)
					{
						float z = this.Bone.localPosition.z + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f;
						Vector3 localPosition3 = this.Bone.localPosition;
						float num3 = localPosition3.z = z;
						Vector3 vector3 = this.Bone.localPosition = localPosition3;
					}
					else if (this.Selected == 4)
					{
						this.Bone.Rotate(Vector3.right * Time.deltaTime * (float)this.Value * (float)this.Degree * 36f);
					}
					else if (this.Selected == 5)
					{
						this.Bone.Rotate(Vector3.up * Time.deltaTime * (float)this.Value * (float)this.Degree * 36f);
					}
					else if (this.Selected == 6)
					{
						this.Bone.Rotate(Vector3.forward * Time.deltaTime * (float)this.Value * (float)this.Degree * 36f);
					}
					else if (this.Selected == 7)
					{
						float x2 = this.Bone.localScale.x + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f;
						Vector3 localScale = this.Bone.localScale;
						float num4 = localScale.x = x2;
						Vector3 vector4 = this.Bone.localScale = localScale;
					}
					else if (this.Selected == 8)
					{
						float y2 = this.Bone.localScale.y + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f;
						Vector3 localScale2 = this.Bone.localScale;
						float num5 = localScale2.y = y2;
						Vector3 vector5 = this.Bone.localScale = localScale2;
					}
					else if (this.Selected == 9)
					{
						float z2 = this.Bone.localScale.z + Time.deltaTime * (float)this.Value * (float)this.Degree * 0.1f;
						Vector3 localScale3 = this.Bone.localScale;
						float num6 = localScale3.z = z2;
						Vector3 vector6 = this.Bone.localScale = localScale3;
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
						this.Student.Cosmetic.Hairstyle = this.Student.Cosmetic.Hairstyle + 1;
						if (!this.Student.Male)
						{
							if (this.Student.Cosmetic.Hairstyle == Extensions.get_length(this.Student.Cosmetic.FemaleHair))
							{
								this.Student.Cosmetic.Hairstyle = 1;
							}
						}
						else if (this.Student.Cosmetic.Hairstyle == Extensions.get_length(this.Student.Cosmetic.MaleHair))
						{
							this.Student.Cosmetic.Hairstyle = 1;
						}
						this.Student.Cosmetic.Start();
						this.UpdateLabels();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Student.Cosmetic.Hairstyle = this.Student.Cosmetic.Hairstyle - 1;
						if (this.Student.Cosmetic.Hairstyle == 0)
						{
							if (!this.Student.Male)
							{
								this.Student.Cosmetic.Hairstyle = Extensions.get_length(this.Student.Cosmetic.FemaleHair) - 1;
							}
							else
							{
								this.Student.Cosmetic.Hairstyle = Extensions.get_length(this.Student.Cosmetic.MaleHair) - 1;
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
						this.Student.Cosmetic.Accessory = this.Student.Cosmetic.Accessory + 1;
						if (!this.Student.Male)
						{
							if (this.Student.Cosmetic.Accessory == Extensions.get_length(this.Student.Cosmetic.FemaleAccessories))
							{
								this.Student.Cosmetic.Accessory = 0;
							}
						}
						else if (this.Student.Cosmetic.Accessory == Extensions.get_length(this.Student.Cosmetic.MaleAccessories))
						{
							this.Student.Cosmetic.Accessory = 0;
						}
						this.Student.Cosmetic.Start();
						this.UpdateLabels();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Student.Cosmetic.Accessory = this.Student.Cosmetic.Accessory - 1;
						if (this.Student.Cosmetic.Accessory < 0)
						{
							if (!this.Student.Male)
							{
								this.Student.Cosmetic.Accessory = Extensions.get_length(this.Student.Cosmetic.FemaleAccessories) - 1;
							}
							else
							{
								this.Student.Cosmetic.Accessory = Extensions.get_length(this.Student.Cosmetic.MaleAccessories) - 1;
							}
						}
						this.Student.Cosmetic.Start();
						this.UpdateLabels();
					}
				}
				else if (this.Selected == 3)
				{
					if (!this.Student.Male)
					{
						if (this.InputManager.TappedRight)
						{
							this.Student.Schoolwear = this.Student.Schoolwear + 1;
							if (this.Student.Schoolwear > 3)
							{
								this.Student.Schoolwear = 1;
							}
							this.Student.ChangeSchoolwear();
							this.UpdateLabels();
						}
						if (this.InputManager.TappedLeft)
						{
							this.Student.Schoolwear = this.Student.Schoolwear + 1;
							if (this.Student.Schoolwear < 1)
							{
								this.Student.Schoolwear = 3;
							}
							this.Student.ChangeSchoolwear();
							this.UpdateLabels();
						}
					}
				}
				else if (this.Selected == 7)
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
				else if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey("right") || Input.GetKey("left"))
				{
					this.CalculateValue();
					if (this.Selected == 4)
					{
						float r = this.Student.Cosmetic.HairRenderer.material.color.r + (float)this.Degree * 0.003921569f * (float)this.Value;
						Color color = this.Student.Cosmetic.HairRenderer.material.color;
						float num7 = color.r = r;
						Color color2 = this.Student.Cosmetic.HairRenderer.material.color = color;
					}
					else if (this.Selected == 5)
					{
						float g = this.Student.Cosmetic.HairRenderer.material.color.g + (float)this.Degree * 0.003921569f * (float)this.Value;
						Color color3 = this.Student.Cosmetic.HairRenderer.material.color;
						float num8 = color3.g = g;
						Color color4 = this.Student.Cosmetic.HairRenderer.material.color = color3;
					}
					else if (this.Selected == 6)
					{
						float b = this.Student.Cosmetic.HairRenderer.material.color.b + (float)this.Degree * 0.003921569f * (float)this.Value;
						Color color5 = this.Student.Cosmetic.HairRenderer.material.color;
						float num9 = color5.b = b;
						Color color6 = this.Student.Cosmetic.HairRenderer.material.color = color5;
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
		}
		else
		{
			if (this.transform.localScale.x > 0.1f)
			{
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			}
			else if (this.Panel.enabled)
			{
				this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
				this.Panel.enabled = false;
			}
			if (this.Placing && Input.GetButtonDown("A"))
			{
				this.Student.transform.position = this.Marker.transform.position;
				this.Marker.enableEmission = false;
				this.Placing = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
			}
		}
	}

	public virtual void UpdateHighlight()
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
		int num = 350 - this.Selected * 50;
		Vector3 localPosition = this.Highlight.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.localPosition = localPosition;
	}

	public virtual void UpdateLabels()
	{
		for (int i = 1; i < Extensions.get_length(this.OptionLabels); i++)
		{
			float a = 1f;
			Color color = this.OptionLabels[i].color;
			float num = color.a = a;
			Color color2 = this.OptionLabels[i].color = color;
			this.OptionLabels[i].text = string.Empty;
		}
		this.Warning.active = false;
		if (this.ChoosingAction)
		{
			this.Warning.active = true;
			this.HeaderLabel.text = "Choose Action";
			this.OptionLabels[1].text = "Pose";
			this.OptionLabels[2].text = "Re-Position";
			this.OptionLabels[3].text = "Customize Appearance";
			this.OptionLabels[4].text = "Perform Animation";
			this.OptionLabels[5].text = "Stop Animation";
			this.Limit = 5;
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
			if (!this.Student.Male)
			{
				float a2 = 1f;
				Color color3 = this.OptionLabels[10].color;
				float num2 = color3.a = a2;
				Color color4 = this.OptionLabels[10].color = color3;
			}
			else
			{
				float a3 = 0.5f;
				Color color5 = this.OptionLabels[10].color;
				float num3 = color5.a = a3;
				Color color6 = this.OptionLabels[10].color = color5;
			}
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
			this.OptionLabels[10].text = "Degree of Change: " + this.Degree;
			this.OptionLabels[11].text = "Reset";
			this.Limit = 11;
		}
		else if (this.Customizing)
		{
			this.HeaderLabel.text = "Customize";
			this.OptionLabels[1].text = "Hairstyle: " + this.Student.Cosmetic.Hairstyle;
			this.OptionLabels[2].text = "Accessory: " + this.Student.Cosmetic.Accessory;
			this.OptionLabels[3].text = "Clothing: " + this.Student.Schoolwear;
			this.OptionLabels[4].text = "Hair R: " + this.Student.Cosmetic.HairRenderer.material.color.r * (float)255;
			this.OptionLabels[5].text = "Hair G: " + this.Student.Cosmetic.HairRenderer.material.color.g * (float)255;
			this.OptionLabels[6].text = "Hair B: " + this.Student.Cosmetic.HairRenderer.material.color.b * (float)255;
			this.OptionLabels[7].text = "Degree of Change: " + this.Degree;
			this.Limit = 7;
			if (!this.Student.Male)
			{
				float a4 = 1f;
				Color color7 = this.OptionLabels[3].color;
				float num4 = color7.a = a4;
				Color color8 = this.OptionLabels[3].color = color7;
			}
			else
			{
				float a5 = 0.5f;
				Color color9 = this.OptionLabels[3].color;
				float num5 = color9.a = a5;
				Color color10 = this.OptionLabels[3].color = color9;
			}
		}
		else if (this.Animating)
		{
			this.HeaderLabel.text = "Choose Animation";
			this.OptionLabels[1].text = "(" + (1 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[1 + this.Offset];
			this.OptionLabels[2].text = "(" + (2 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[2 + this.Offset];
			this.OptionLabels[3].text = "(" + (3 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[3 + this.Offset];
			this.OptionLabels[4].text = "(" + (4 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[4 + this.Offset];
			this.OptionLabels[5].text = "(" + (5 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[5 + this.Offset];
			this.OptionLabels[6].text = "(" + (6 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[6 + this.Offset];
			this.OptionLabels[7].text = "(" + (7 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[7 + this.Offset];
			this.OptionLabels[8].text = "(" + (8 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[8 + this.Offset];
			this.OptionLabels[9].text = "(" + (9 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[9 + this.Offset];
			this.OptionLabels[10].text = "(" + (10 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[10 + this.Offset];
			this.OptionLabels[11].text = "(" + (11 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[11 + this.Offset];
			this.OptionLabels[12].text = "(" + (12 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[12 + this.Offset];
			this.OptionLabels[13].text = "(" + (13 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[13 + this.Offset];
			this.OptionLabels[14].text = "(" + (14 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[14 + this.Offset];
			this.OptionLabels[15].text = "(" + (15 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[15 + this.Offset];
			this.OptionLabels[16].text = "(" + (16 + this.Offset) + "/" + this.AnimID + ") " + this.AnimationArray[16 + this.Offset];
			this.Limit = 16;
		}
	}

	public virtual void RememberPose()
	{
		PlayerPrefs.SetFloat("Position X", this.Bone.localPosition.x);
		PlayerPrefs.SetFloat("Position Y", this.Bone.localPosition.y);
		PlayerPrefs.SetFloat("Position Z", this.Bone.localPosition.z);
		PlayerPrefs.SetFloat("Rotation X", this.Bone.localEulerAngles.x);
		PlayerPrefs.SetFloat("Rotation Y", this.Bone.localEulerAngles.y);
		PlayerPrefs.SetFloat("Rotation Z", this.Bone.localEulerAngles.z);
		PlayerPrefs.SetFloat("Scale X", this.Bone.localScale.x);
		PlayerPrefs.SetFloat("Scale Y", this.Bone.localScale.y);
		PlayerPrefs.SetFloat("Scale Z", this.Bone.localScale.z);
	}

	public virtual void ResetPose()
	{
		float @float = PlayerPrefs.GetFloat("Position X");
		Vector3 localPosition = this.Bone.localPosition;
		float num = localPosition.x = @float;
		Vector3 vector = this.Bone.localPosition = localPosition;
		float float2 = PlayerPrefs.GetFloat("Position Y");
		Vector3 localPosition2 = this.Bone.localPosition;
		float num2 = localPosition2.y = float2;
		Vector3 vector2 = this.Bone.localPosition = localPosition2;
		float float3 = PlayerPrefs.GetFloat("Position Z");
		Vector3 localPosition3 = this.Bone.localPosition;
		float num3 = localPosition3.z = float3;
		Vector3 vector3 = this.Bone.localPosition = localPosition3;
		float float4 = PlayerPrefs.GetFloat("Rotation X");
		Vector3 localEulerAngles = this.Bone.localEulerAngles;
		float num4 = localEulerAngles.x = float4;
		Vector3 vector4 = this.Bone.localEulerAngles = localEulerAngles;
		float float5 = PlayerPrefs.GetFloat("Rotation Y");
		Vector3 localEulerAngles2 = this.Bone.localEulerAngles;
		float num5 = localEulerAngles2.y = float5;
		Vector3 vector5 = this.Bone.localEulerAngles = localEulerAngles2;
		float float6 = PlayerPrefs.GetFloat("Rotation Z");
		Vector3 localEulerAngles3 = this.Bone.localEulerAngles;
		float num6 = localEulerAngles3.z = float6;
		Vector3 vector6 = this.Bone.localEulerAngles = localEulerAngles3;
		float float7 = PlayerPrefs.GetFloat("Scale X");
		Vector3 localScale = this.Bone.localScale;
		float num7 = localScale.x = float7;
		Vector3 vector7 = this.Bone.localScale = localScale;
		float float8 = PlayerPrefs.GetFloat("Scale Y");
		Vector3 localScale2 = this.Bone.localScale;
		float num8 = localScale2.y = float8;
		Vector3 vector8 = this.Bone.localScale = localScale2;
		float float9 = PlayerPrefs.GetFloat("Scale Z");
		Vector3 localScale3 = this.Bone.localScale;
		float num9 = localScale3.z = float9;
		Vector3 vector9 = this.Bone.localScale = localScale3;
	}

	public virtual void CapColors()
	{
		if (this.Student.Cosmetic.HairRenderer.material.color.r < (float)0)
		{
			int num = 0;
			Color color = this.Student.Cosmetic.HairRenderer.material.color;
			float num2 = color.r = (float)num;
			Color color2 = this.Student.Cosmetic.HairRenderer.material.color = color;
		}
		if (this.Student.Cosmetic.HairRenderer.material.color.g < (float)0)
		{
			int num3 = 0;
			Color color3 = this.Student.Cosmetic.HairRenderer.material.color;
			float num4 = color3.g = (float)num3;
			Color color4 = this.Student.Cosmetic.HairRenderer.material.color = color3;
		}
		if (this.Student.Cosmetic.HairRenderer.material.color.b < (float)0)
		{
			int num5 = 0;
			Color color5 = this.Student.Cosmetic.HairRenderer.material.color;
			float num6 = color5.b = (float)num5;
			Color color6 = this.Student.Cosmetic.HairRenderer.material.color = color5;
		}
		if (this.Student.Cosmetic.HairRenderer.material.color.r > (float)1)
		{
			int num7 = 1;
			Color color7 = this.Student.Cosmetic.HairRenderer.material.color;
			float num8 = color7.r = (float)num7;
			Color color8 = this.Student.Cosmetic.HairRenderer.material.color = color7;
		}
		if (this.Student.Cosmetic.HairRenderer.material.color.g > (float)1)
		{
			int num9 = 1;
			Color color9 = this.Student.Cosmetic.HairRenderer.material.color;
			float num10 = color9.g = (float)num9;
			Color color10 = this.Student.Cosmetic.HairRenderer.material.color = color9;
		}
		if (this.Student.Cosmetic.HairRenderer.material.color.b > (float)1)
		{
			int num11 = 1;
			Color color11 = this.Student.Cosmetic.HairRenderer.material.color;
			float num12 = color11.b = (float)num11;
			Color color12 = this.Student.Cosmetic.HairRenderer.material.color = color11;
		}
	}

	public virtual void CreateAnimationArray()
	{
		this.AnimID = 1;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.Student.CharacterAnimation);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			object obj3;
			object obj2 = obj3 = obj;
			if (!(obj2 is AnimationState))
			{
				obj3 = RuntimeServices.Coerce(obj2, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj3;
			this.AnimationArray[this.AnimID] = animationState.name;
			UnityRuntimeServices.Update(enumerator, animationState);
			this.AnimID++;
		}
		this.AnimID--;
	}

	public virtual void CalculateValue()
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
		else if (Input.GetKey("right"))
		{
			this.Value = 1;
		}
		else
		{
			this.Value = -1;
		}
	}

	public virtual void Main()
	{
	}
}
