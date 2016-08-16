using System;
using UnityEngine;

[Serializable]
public class ShoeRemovalScript : MonoBehaviour
{
	public StudentScript Student;

	public Vector3 RightShoePosition;

	public Vector3 LeftShoePosition;

	public Transform RightCurrentShoe;

	public Transform LeftCurrentShoe;

	public Transform RightCasualShoe;

	public Transform LeftCasualShoe;

	public Transform RightSchoolShoe;

	public Transform LeftSchoolShoe;

	public Transform RightNewShoe;

	public Transform LeftNewShoe;

	public Transform RightFoot;

	public Transform LeftFoot;

	public Transform RightHand;

	public Transform LeftHand;

	public Transform ShoeParent;

	public Transform Locker;

	public GameObject NewPairOfShoes;

	public GameObject Character;

	public string[] LockerAnims;

	public Texture OutdoorShoes;

	public Texture IndoorShoes;

	public Texture TargetShoes;

	public Texture Socks;

	public Renderer MyRenderer;

	public bool RemovingCasual;

	public bool Male;

	public int Height;

	public int Phase;

	public float X;

	public float Y;

	public float Z;

	public string RemoveCasualAnim;

	public string RemoveSchoolAnim;

	public string RemovalAnim;

	public ShoeRemovalScript()
	{
		this.RemovingCasual = true;
		this.Phase = 1;
		this.RemoveCasualAnim = string.Empty;
		this.RemoveSchoolAnim = string.Empty;
		this.RemovalAnim = string.Empty;
	}

	public virtual void Start()
	{
		if (this.Locker == null)
		{
			this.GetHeight(this.Student.StudentID);
			this.Locker = this.Student.StudentManager.Lockers.List[this.Student.StudentID];
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.NewPairOfShoes, this.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.Locker;
			gameObject.transform.localEulerAngles = new Vector3((float)0, (float)-180, (float)0);
			if (!this.Male)
			{
				gameObject.transform.localPosition = new Vector3((float)0, -0.29f + 0.3f * (float)this.Height, 0.05f);
			}
			else
			{
				gameObject.transform.localPosition = new Vector3((float)0, -0.29f + 0.3f * (float)this.Height, 0.04f);
			}
			this.LeftSchoolShoe = gameObject.transform.GetChild(0);
			this.RightSchoolShoe = gameObject.transform.GetChild(1);
			this.RemovalAnim = this.RemoveCasualAnim;
			this.RightCurrentShoe = this.RightCasualShoe;
			this.LeftCurrentShoe = this.LeftCasualShoe;
			this.RightCasualShoe.active = true;
			this.LeftCasualShoe.active = true;
			this.RightNewShoe = this.RightSchoolShoe;
			this.LeftNewShoe = this.LeftSchoolShoe;
			this.ShoeParent = gameObject.transform;
			this.TargetShoes = this.IndoorShoes;
			this.RightShoePosition = this.RightCurrentShoe.localPosition;
			this.LeftShoePosition = this.LeftCurrentShoe.localPosition;
			this.RightCurrentShoe.localScale = new Vector3(1.111113f, (float)1, 1.111113f);
			this.LeftCurrentShoe.localScale = new Vector3(1.111113f, (float)1, 1.111113f);
			this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
			this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
			this.Socks = this.Student.Cosmetic.SocksTexture;
			if (!this.Male)
			{
				this.MyRenderer.materials[0].mainTexture = this.Socks;
				this.MyRenderer.materials[1].mainTexture = this.Socks;
			}
			else
			{
				this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
			}
			this.TargetShoes = this.IndoorShoes;
			this.Locker.gameObject.animation.Play(this.LockerAnims[this.Height]);
			this.Character.animation.cullingType = AnimationCullingType.AlwaysAnimate;
			this.Character.animation.Play(this.RemovalAnim);
		}
	}

	public virtual void Update()
	{
		if (!this.Student.DiscCheck && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Splashed)
		{
			this.Student.MoveTowardsTarget(this.Student.CurrentDestination.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Student.CurrentDestination.rotation, (float)10 * Time.deltaTime);
			if (this.Phase == 1)
			{
				if (this.Character.animation[this.RemovalAnim].time >= 1.1f)
				{
					this.ShoeParent.parent = this.LeftHand;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Character.animation[this.RemovalAnim].time >= (float)2)
				{
					this.ShoeParent.parent = this.Locker;
					this.X = this.ShoeParent.localEulerAngles.x;
					this.Y = this.ShoeParent.localEulerAngles.y;
					this.Z = this.ShoeParent.localEulerAngles.z;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.X = Mathf.MoveTowards(this.X, (float)0, Time.deltaTime * (float)360);
				this.Y = Mathf.MoveTowards(this.Y, 186.878f, Time.deltaTime * (float)360);
				this.Z = Mathf.MoveTowards(this.Z, (float)0, Time.deltaTime * (float)360);
				this.ShoeParent.localEulerAngles = new Vector3(this.X, this.Y, this.Z);
				this.ShoeParent.localPosition = Vector3.MoveTowards(this.ShoeParent.localPosition, new Vector3(0.272f, (float)0, 0.552f), Time.deltaTime);
				if (this.ShoeParent.localPosition.y == (float)0)
				{
					this.ShoeParent.localPosition = new Vector3(0.272f, (float)0, 0.552f);
					this.ShoeParent.localEulerAngles = new Vector3((float)0, 186.878f, (float)0);
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Character.animation[this.RemovalAnim].time >= 3.4f)
				{
					this.RightCurrentShoe.parent = null;
					float y = 0.05f;
					Vector3 position = this.RightCurrentShoe.position;
					float num = position.y = y;
					Vector3 vector = this.RightCurrentShoe.position = position;
					int num2 = 0;
					Vector3 localEulerAngles = this.RightCurrentShoe.localEulerAngles;
					float num3 = localEulerAngles.x = (float)num2;
					Vector3 vector2 = this.RightCurrentShoe.localEulerAngles = localEulerAngles;
					int num4 = 0;
					Vector3 localEulerAngles2 = this.RightCurrentShoe.localEulerAngles;
					float num5 = localEulerAngles2.z = (float)num4;
					Vector3 vector3 = this.RightCurrentShoe.localEulerAngles = localEulerAngles2;
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Character.animation[this.RemovalAnim].time >= 4.4f)
				{
					this.LeftCurrentShoe.parent = null;
					float y2 = 0.05f;
					Vector3 position2 = this.LeftCurrentShoe.position;
					float num6 = position2.y = y2;
					Vector3 vector4 = this.LeftCurrentShoe.position = position2;
					int num7 = 0;
					Vector3 localEulerAngles3 = this.LeftCurrentShoe.localEulerAngles;
					float num8 = localEulerAngles3.x = (float)num7;
					Vector3 vector5 = this.LeftCurrentShoe.localEulerAngles = localEulerAngles3;
					int num9 = 0;
					Vector3 localEulerAngles4 = this.LeftCurrentShoe.localEulerAngles;
					float num10 = localEulerAngles4.z = (float)num9;
					Vector3 vector6 = this.LeftCurrentShoe.localEulerAngles = localEulerAngles4;
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				if (this.Character.animation[this.RemovalAnim].time >= 5.6f)
				{
					this.LeftNewShoe.parent = this.LeftFoot;
					this.LeftNewShoe.localPosition = this.LeftShoePosition;
					this.LeftNewShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				if (this.Character.animation[this.RemovalAnim].time >= 6.8f)
				{
					if (!this.Male)
					{
						this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
						this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
					}
					else
					{
						this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
					}
					this.RightNewShoe.parent = this.RightFoot;
					this.RightNewShoe.localPosition = this.RightShoePosition;
					this.RightNewShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.RightNewShoe.gameObject.active = false;
					this.LeftNewShoe.gameObject.active = false;
					this.Phase++;
				}
			}
			else if (this.Phase == 8)
			{
				if (this.Character.animation[this.RemovalAnim].time >= 7.6f)
				{
					this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
					this.RightCurrentShoe.parent = this.ShoeParent;
					this.LeftCurrentShoe.parent = this.ShoeParent;
					this.ShoeParent.parent = this.RightHand;
					this.Phase++;
				}
			}
			else if (this.Phase == 9)
			{
				if (this.Character.animation[this.RemovalAnim].time >= 8.5f)
				{
					this.ShoeParent.parent = this.Locker;
					if (this.TargetShoes == this.IndoorShoes)
					{
						this.ShoeParent.localPosition = new Vector3((float)0, -0.14f + 0.3f * (float)this.Height, -0.01f);
					}
					else
					{
						this.ShoeParent.localPosition = new Vector3((float)0, -0.29f + 0.3f * (float)this.Height, -0.01f);
					}
					this.ShoeParent.localEulerAngles = new Vector3((float)0, (float)180, (float)0);
					this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, (float)0);
					this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, (float)0);
					this.RightCurrentShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.LeftCurrentShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
					this.Phase++;
				}
			}
			else if (this.Phase == 10 && this.Character.animation[this.RemovalAnim].time >= this.Character.animation[this.RemovalAnim].length)
			{
				this.Student.Routine = true;
				this.enabled = false;
				if (!this.Student.Indoors)
				{
					this.Character.animation.cullingType = AnimationCullingType.BasedOnRenderers;
					this.Student.Indoors = true;
					this.Student.CanTalk = true;
				}
				else
				{
					this.Student.CurrentDestination = this.Student.StudentManager.Hangouts.List[0];
					this.Student.Pathfinding.target = this.Student.StudentManager.Hangouts.List[0];
					this.Student.CanTalk = false;
					this.enabled = false;
				}
			}
		}
		else
		{
			this.PutOnShoes();
			this.Student.Routine = false;
		}
	}

	public virtual void LateUpdate()
	{
		if (this.Phase < 7)
		{
			this.RightFoot.localScale = new Vector3(0.9f, (float)1, 0.9f);
			this.LeftFoot.localScale = new Vector3(0.9f, (float)1, 0.9f);
		}
	}

	public virtual void PutOnShoes()
	{
		this.Locker.gameObject.animation[this.LockerAnims[this.Height]].time = this.Locker.gameObject.animation[this.LockerAnims[this.Height]].length;
		this.ShoeParent.parent = this.LeftHand;
		this.ShoeParent.parent = this.Locker;
		this.ShoeParent.localPosition = new Vector3(0.272f, (float)0, 0.552f);
		this.ShoeParent.localEulerAngles = new Vector3((float)0, 186.878f, (float)0);
		this.RightCurrentShoe.parent = null;
		float y = 0.05f;
		Vector3 position = this.RightCurrentShoe.position;
		float num = position.y = y;
		Vector3 vector = this.RightCurrentShoe.position = position;
		int num2 = 0;
		Vector3 localEulerAngles = this.RightCurrentShoe.localEulerAngles;
		float num3 = localEulerAngles.x = (float)num2;
		Vector3 vector2 = this.RightCurrentShoe.localEulerAngles = localEulerAngles;
		int num4 = 0;
		Vector3 localEulerAngles2 = this.RightCurrentShoe.localEulerAngles;
		float num5 = localEulerAngles2.z = (float)num4;
		Vector3 vector3 = this.RightCurrentShoe.localEulerAngles = localEulerAngles2;
		this.LeftCurrentShoe.parent = null;
		float y2 = 0.05f;
		Vector3 position2 = this.LeftCurrentShoe.position;
		float num6 = position2.y = y2;
		Vector3 vector4 = this.LeftCurrentShoe.position = position2;
		int num7 = 0;
		Vector3 localEulerAngles3 = this.LeftCurrentShoe.localEulerAngles;
		float num8 = localEulerAngles3.x = (float)num7;
		Vector3 vector5 = this.LeftCurrentShoe.localEulerAngles = localEulerAngles3;
		int num9 = 0;
		Vector3 localEulerAngles4 = this.LeftCurrentShoe.localEulerAngles;
		float num10 = localEulerAngles4.z = (float)num9;
		Vector3 vector6 = this.LeftCurrentShoe.localEulerAngles = localEulerAngles4;
		this.LeftNewShoe.parent = this.LeftFoot;
		this.LeftNewShoe.localPosition = this.LeftShoePosition;
		this.LeftNewShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
			this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
		}
		else
		{
			this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
		}
		this.RightNewShoe.parent = this.RightFoot;
		this.RightNewShoe.localPosition = this.RightShoePosition;
		this.RightNewShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.RightNewShoe.gameObject.active = false;
		this.LeftNewShoe.gameObject.active = false;
		this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
		this.RightCurrentShoe.parent = this.ShoeParent;
		this.LeftCurrentShoe.parent = this.ShoeParent;
		this.ShoeParent.parent = this.RightHand;
		this.ShoeParent.parent = this.Locker;
		if (this.TargetShoes == this.IndoorShoes)
		{
			this.ShoeParent.localPosition = new Vector3((float)0, -0.14f + 0.3f * (float)this.Height, -0.01f);
		}
		else
		{
			this.ShoeParent.localPosition = new Vector3((float)0, -0.29f + 0.3f * (float)this.Height, -0.01f);
		}
		this.ShoeParent.localEulerAngles = new Vector3((float)0, (float)180, (float)0);
		this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, (float)0);
		this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, (float)0);
		this.RightCurrentShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.LeftCurrentShoe.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
		this.Student.Indoors = true;
		this.Student.CanTalk = true;
		this.enabled = false;
		this.Character.animation.cullingType = AnimationCullingType.BasedOnRenderers;
	}

	public virtual void UpdateShoes()
	{
		this.Student.Indoors = true;
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.IndoorShoes;
			this.MyRenderer.materials[1].mainTexture = this.IndoorShoes;
		}
		else
		{
			this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.IndoorShoes;
		}
	}

	public virtual void LeavingSchool()
	{
		this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
		this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
		this.Socks = this.Student.Cosmetic.SocksTexture;
		this.RemovalAnim = this.RemoveSchoolAnim;
		this.Locker.gameObject.animation[this.LockerAnims[this.Height]].time = (float)0;
		this.Locker.gameObject.animation.Play(this.LockerAnims[this.Height]);
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.Socks;
			this.MyRenderer.materials[1].mainTexture = this.Socks;
		}
		else
		{
			this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
		}
		this.Character.animation.Play(this.RemovalAnim);
		this.RightNewShoe.gameObject.active = true;
		this.LeftNewShoe.gameObject.active = true;
		this.RightCurrentShoe = this.RightSchoolShoe;
		this.LeftCurrentShoe = this.LeftSchoolShoe;
		this.RightNewShoe = this.RightCasualShoe;
		this.LeftNewShoe = this.LeftCasualShoe;
		this.TargetShoes = this.OutdoorShoes;
		this.Phase = 1;
		this.RightFoot.localScale = new Vector3(0.9f, (float)1, 0.9f);
		this.LeftFoot.localScale = new Vector3(0.9f, (float)1, 0.9f);
		this.RightCurrentShoe.localScale = new Vector3(1.111113f, (float)1, 1.111113f);
		this.LeftCurrentShoe.localScale = new Vector3(1.111113f, (float)1, 1.111113f);
	}

	public virtual void GetHeight(int StudentID)
	{
		this.Height = 6;
		while (StudentID > 0)
		{
			this.Height--;
			StudentID--;
			if (this.Height == 0)
			{
				this.Height = 5;
			}
		}
		if (this.Student.StudentID == 7)
		{
			this.Height = 5;
		}
		this.RemoveCasualAnim = this.RemoveCasualAnim + this.Height + "_00";
		this.RemoveSchoolAnim = this.RemoveSchoolAnim + this.Height + "_01";
	}

	public virtual void Main()
	{
	}
}
