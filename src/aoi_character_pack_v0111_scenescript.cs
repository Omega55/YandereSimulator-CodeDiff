using System;
using System.Collections;
using System.IO;
using System.Xml;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class aoi_character_pack_v0111_scenescript : MonoBehaviour
{
	public GameObject animTest;

	public aoi_character_pack_v0111_viewscript viewCam;

	public GUISkin guiSkin;

	public string boneName;

	public Rect camGuiRootRect;

	public Rect camGuiBodyRect;

	public Rect animSpeedGuiBodyRect;

	public Rect textGuiBodyRect;

	public Rect modelBodyRect;

	public string FBXListFile;

	public string AnimationListFile;

	public string TitleTextFile;

	public bool guiOn;

	private string viewerResourcesPath;

	private string settingsPath;

	private string materialsPath;

	private int curBG;

	private int curAnim;

	private int curModel;

	private float curLOD;

	private string curModelName;

	private string curAnimName;

	private string curBgName;

	private float animSpeed;

	private string[] animationList;

	private string[] modelList;

	private string[] backGroundList;

	private string[] lodList;

	private string[] lodTextList;

	private GameObject obj;

	private GameObject loaded;

	private SkinnedMeshRenderer SM;

	private TextAsset txt;

	private bool CamModeRote;

	private bool CamModeMove;

	private bool CamModeZoom;

	private bool CamModeFix;

	private int CamMode;

	private string titleText;

	private XmlDocument xDoc;

	private XmlNodeList xNodeList;

	private Material faceMat_L;

	private Material faceMat_M;

	private Vector3 scale;

	public aoi_character_pack_v0111_scenescript()
	{
		this.boneName = "Hips";
		this.camGuiRootRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.camGuiBodyRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.animSpeedGuiBodyRect = new Rect((float)770, (float)520, (float)170, (float)150);
		this.textGuiBodyRect = new Rect((float)20, (float)510, (float)300, (float)70);
		this.modelBodyRect = new Rect((float)20, (float)40, (float)300, (float)500);
		this.FBXListFile = "fbx_list";
		this.AnimationListFile = "animation_list";
		this.TitleTextFile = "title_text";
		this.guiOn = true;
		this.viewerResourcesPath = "Aoi_v0111";
		this.settingsPath = this.viewerResourcesPath + "/Viewer Settings";
		this.materialsPath = this.viewerResourcesPath + "/Viewer Materials";
		this.curBG = 1;
		this.curAnim = 1;
		this.curModel = 1;
		this.curModelName = string.Empty;
		this.curAnimName = string.Empty;
		this.curBgName = string.Empty;
		this.animSpeed = (float)1;
		this.lodList = new string[]
		{
			"_h",
			"_m",
			"_l"
		};
		this.lodTextList = new string[]
		{
			"Hi",
			"Mid",
			"Low"
		};
		this.CamModeRote = true;
		this.CamModeFix = true;
		this.titleText = string.Empty;
	}

	public virtual void Start()
	{
		this.viewCam = (aoi_character_pack_v0111_viewscript)GameObject.Find("Main Camera").GetComponent("aoi_character_pack_v0111_viewscript");
		this.faceMat_L = (Material)Resources.Load(this.materialsPath + "f02_face_l", typeof(Material));
		this.faceMat_M = (Material)Resources.Load(this.materialsPath + "f02_face_m", typeof(Material));
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/background_list", typeof(TextAsset));
		this.backGroundList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/" + this.FBXListFile, typeof(TextAsset));
		this.modelList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/" + this.AnimationListFile, typeof(TextAsset));
		this.animationList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/" + this.TitleTextFile, typeof(TextAsset));
		this.titleText = this.txt.text;
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/fbx_ctrl", typeof(TextAsset));
		this.xDoc = new XmlDocument();
		this.xDoc.LoadXml(this.txt.text);
		this.SetInitBackGround();
		this.SetInitModel();
		this.SetInitMotion();
		this.SetAnimationSpeed(this.animSpeed);
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			this.SetNextModel(-1);
		}
		if (Input.GetKeyDown("2"))
		{
			this.SetNextModel(1);
		}
		if (Input.GetKeyDown("q"))
		{
			this.SetNextMotion(-1);
		}
		if (Input.GetKeyDown("w"))
		{
			this.SetNextMotion(1);
		}
		if (Input.GetKeyDown("a"))
		{
			this.SetNextBackGround(-1);
		}
		if (Input.GetKeyDown("s"))
		{
			this.SetNextBackGround(1);
		}
		if (Input.GetKeyDown("z"))
		{
			this.SetNextLOD(-1);
		}
		if (Input.GetKeyDown("x"))
		{
			this.SetNextLOD(1);
		}
	}

	public virtual void OnGUI()
	{
		if (this.guiOn)
		{
			if (this.guiSkin)
			{
				GUI.skin = this.guiSkin;
			}
			this.scale.x = (float)Screen.width / 960f;
			this.scale.y = (float)Screen.height / 600f;
			this.scale.x = (float)1;
			this.scale.y = (float)1;
			this.scale.z = 1f;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, this.scale);
			GUI.Label(new Rect((float)20, (float)20, (float)500, (float)50), this.titleText, "Title");
			GUILayout.BeginArea(this.modelBodyRect);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextModel(-1);
			}
			GUILayout.Label(string.Empty, "Costume", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextModel(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space((float)20);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextMotion(-1);
			}
			GUILayout.Label(string.Empty, "Anim", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextMotion(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space((float)20);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextBackGround(-1);
			}
			GUILayout.Label(string.Empty, "BG", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextBackGround(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space((float)20);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextLOD(-1);
			}
			GUILayout.Label(string.Empty, "LOD", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextLOD(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUILayout.BeginArea(this.animSpeedGuiBodyRect);
			GUILayout.FlexibleSpace();
			float num = GUILayout.HorizontalSlider(this.animSpeed, (float)0, (float)2, new GUILayoutOption[0]);
			if (this.animSpeed != num)
			{
				this.animSpeed = num;
				this.SetAnimationSpeed(this.animSpeed);
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.FlexibleSpace();
			string text = "Animation Speed : " + string.Format("{0:F1}", this.animSpeed);
			GUILayout.Box(text, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
			GUI.Label(this.camGuiRootRect, string.Empty, "CamBG");
			GUILayout.BeginArea(this.camGuiBodyRect);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			bool flag = default(bool);
			flag = GUILayout.Toggle(this.CamMode == 0, string.Empty, "Rote", new GUILayoutOption[0]);
			if (this.CamMode != 0 && flag)
			{
				this.CamMode = 0;
				this.viewCam.ModeRote();
			}
			GUILayout.FlexibleSpace();
			flag = GUILayout.Toggle(this.CamMode == 1, string.Empty, "Move", new GUILayoutOption[0]);
			if (this.CamMode != 1 && flag)
			{
				this.CamMode = 1;
				this.viewCam.ModeMove();
			}
			GUILayout.FlexibleSpace();
			flag = GUILayout.Toggle(this.CamMode == 2, string.Empty, "Zoom", new GUILayoutOption[0]);
			if (this.CamMode != 2 && flag)
			{
				this.CamMode = 2;
				this.viewCam.ModeZoom();
			}
			GUILayout.FlexibleSpace();
			flag = GUILayout.Toggle(this.CamModeFix, string.Empty, "Fix", new GUILayoutOption[0]);
			if (this.CamModeFix != flag)
			{
				this.CamModeFix = flag;
				this.viewCam.FixTarget(this.CamModeFix);
			}
			GUILayout.FlexibleSpace();
			if (GUILayout.Button(string.Empty, "Reset", new GUILayoutOption[0]))
			{
				this.viewCam.Reset();
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			string text2 = string.Empty;
			text2 += "Costume : " + (this.curModel + 1) + " / " + Extensions.get_length(this.modelList) + " : " + this.curModelName + "\n";
			text2 += "Animation : " + (this.curAnim + 1) + " / " + Extensions.get_length(this.animationList) + " : " + this.curAnimName + "\n";
			text2 += "BackGround : " + (this.curBG + 1) + " / " + Extensions.get_length(this.backGroundList) + " : " + this.curBgName + "\n";
			text2 += "Quality : " + this.lodTextList[(int)this.curLOD] + "\n";
			GUI.Box(this.textGuiBodyRect, text2);
		}
	}

	public virtual void SetInitModel()
	{
		this.curModel = 0;
		this.ModelChange(this.modelList[this.curModel] + this.lodList[(int)this.curLOD]);
	}

	public virtual void SetNextModel(int _add)
	{
		this.curModel += _add;
		if (this.modelList.Length <= this.curModel)
		{
			this.curModel = 0;
		}
		else if (this.curModel < 0)
		{
			this.curModel = this.modelList.Length - 1;
		}
		this.ModelChange(this.modelList[this.curModel] + this.lodList[(int)this.curLOD]);
	}

	public virtual void SetNextLOD(int _add)
	{
		this.curLOD += (float)_add;
		if ((float)this.lodList.Length <= this.curLOD)
		{
			this.curLOD = (float)0;
		}
		else if (this.curLOD < (float)0)
		{
			this.curLOD = (float)(this.lodList.Length - 1);
		}
		this.ModelChange(this.modelList[this.curModel] + this.lodList[(int)this.curLOD]);
	}

	public virtual void ModelChange(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("ModelChange : " + _name);
			this.curModelName = Path.GetFileNameWithoutExtension(_name);
			GameObject original = (GameObject)Resources.Load(_name, typeof(GameObject));
			UnityEngine.Object.Destroy(this.obj);
			Debug.Log(_name);
			this.obj = (((GameObject)UnityEngine.Object.Instantiate(original)) as GameObject);
			this.SM = (((SkinnedMeshRenderer)this.obj.GetComponentInChildren(typeof(SkinnedMeshRenderer))) as SkinnedMeshRenderer);
			this.SM.quality = SkinQuality.Bone4;
			this.SM.updateWhenOffscreen = true;
			int num = 0;
			int i = 0;
			Material[] sharedMaterials = this.SM.renderer.sharedMaterials;
			int length = sharedMaterials.Length;
			while (i < length)
			{
				if (sharedMaterials[i].name == "face02_M")
				{
					this.SM.renderer.materials[num] = this.faceMat_M;
				}
				else if (sharedMaterials[i].name == "face02_L")
				{
					this.SM.renderer.materials[num] = this.faceMat_L;
				}
				num++;
				i++;
			}
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.animTest.animation);
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
				this.obj.animation.AddClip(animationState.clip, animationState.name);
				UnityRuntimeServices.Update(enumerator, animationState);
			}
			this.viewCam.ModelTarget(this.GetBone(this.obj, this.boneName));
			this.SetAnimation(string.Empty + this.animationList[this.curAnim]);
			this.SetAnimationSpeed(this.animSpeed);
		}
	}

	public virtual void SetAnimationSpeed(float _speed)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.obj.animation);
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
			animationState.speed = _speed;
			UnityRuntimeServices.Update(enumerator, animationState);
		}
	}

	public virtual void SetInitMotion()
	{
		this.curAnim = 0;
		this.SetAnimation(this.animationList[this.curAnim]);
		this.SetAnimationSpeed(this.animSpeed);
	}

	public virtual void SetNextMotion(int _add)
	{
		this.curAnim += _add;
		if (Extensions.get_length(this.animationList) <= this.curAnim)
		{
			this.curAnim = 0;
		}
		else if (this.curAnim < 0)
		{
			this.curAnim = Extensions.get_length(this.animationList) - 1;
		}
		this.SetAnimation(this.animationList[this.curAnim]);
		this.SetAnimationSpeed(this.animSpeed);
	}

	public virtual void SetAnimation(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("SetAnimation : " + _name);
			this.curAnimName = string.Empty + _name;
			this.obj.animation.Play(this.curAnimName);
			this.SetFixedFbx(this.xDoc, this.obj, this.curModelName, this.curAnimName, (int)this.curLOD);
		}
	}

	public virtual void SetInitBackGround()
	{
		this.curBG = 0;
		this.SetBackGround(this.backGroundList[this.curBG]);
	}

	public virtual void SetNextBackGround(int _add)
	{
		this.curBG += _add;
		if (Extensions.get_length(this.backGroundList) <= this.curBG)
		{
			this.curBG = 0;
		}
		else if (this.curBG < 0)
		{
			this.curBG = Extensions.get_length(this.backGroundList) - 1;
		}
		this.SetBackGround(this.backGroundList[this.curBG]);
	}

	public virtual void SetBackGround(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("SetBackGround : " + _name);
			this.curBgName = Path.GetFileNameWithoutExtension(_name);
			Texture2D mainTexture = (Texture2D)Resources.Load(_name, typeof(Texture2D));
			GameObject gameObject = GameObject.Find("BillBoard") as GameObject;
			gameObject.renderer.material.mainTexture = mainTexture;
		}
	}

	public virtual Transform GetBone(GameObject _obj, string _bone)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = ((SkinnedMeshRenderer)_obj.GetComponentInChildren(typeof(SkinnedMeshRenderer))) as SkinnedMeshRenderer;
		if (skinnedMeshRenderer)
		{
			int i = 0;
			Transform[] bones = skinnedMeshRenderer.bones;
			int length = bones.Length;
			while (i < length)
			{
				if (bones[i].name == _bone)
				{
					return bones[i];
				}
				i++;
			}
		}
		return null;
	}

	public virtual void SetFixedFbx(XmlDocument _xDoc, GameObject _obj, string _model, string _anim, int _lod)
	{
		if (!RuntimeServices.EqualityOperator(_xDoc, null))
		{
			if (!(_obj == null))
			{
				string xpath = "Root/Texture[@Lod=''or@Lod='" + _lod + "'][Info[@Model=''or@Model='" + _model + "'][@Ani=''or@Ani='" + _anim + "']]";
				XmlNode xmlNode = _xDoc.SelectSingleNode(xpath);
				if (xmlNode != null)
				{
					string innerText = xmlNode.Attributes["Material"].InnerText;
					string innerText2 = xmlNode.Attributes["Property"].InnerText;
					string innerText3 = xmlNode.Attributes["File"].InnerText;
					MonoBehaviour.print("Change Texture To " + innerText + " : " + innerText2 + " : " + innerText3);
					int i = 0;
					Material[] sharedMaterials = this.SM.renderer.sharedMaterials;
					int length = sharedMaterials.Length;
					while (i < length)
					{
						if (sharedMaterials[i] && sharedMaterials[i].name == innerText)
						{
							Texture2D texture = (Texture2D)Resources.Load(innerText3, typeof(Texture2D));
							sharedMaterials[i].SetTexture(innerText2, texture);
						}
						i++;
					}
				}
				xpath = "Root/Animation[@Lod=''or@Lod='" + _lod + "'][Info[@Model=''or@Model='" + _model + "'][@Ani=''or@Ani='" + _anim + "']]";
				XmlNode xmlNode2 = _xDoc.SelectSingleNode(xpath);
				if (xmlNode2 != null)
				{
					string innerText4 = xmlNode2.Attributes["File"].InnerText;
					this.curAnimName = innerText4;
					MonoBehaviour.print("Change Animation To " + this.curAnimName);
					_obj.animation.Play(this.curAnimName);
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
