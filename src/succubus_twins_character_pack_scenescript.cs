using System;
using System.Collections;
using System.IO;
using System.Xml;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class succubus_twins_character_pack_scenescript : MonoBehaviour
{
	public GameObject animTest;

	public GUISkin guiSkin;

	public succubus_twins_character_pack_viewscript viewCam;

	public string boneName;

	public Rect camGuiRootRect;

	public Rect camGuiBodyRect;

	public Rect animSpeedGuiBodyRect;

	public Rect positionYGuiBodyRect;

	public Rect textGuiBodyRect;

	public Rect modelBodyRect;

	public string FBXListFile;

	public string AnimationListFile;

	public string ParticleListFile;

	public string ParticleAnimationListFile;

	public string FacialTexListFile;

	public string TitleTextFile;

	public bool guiOn;

	public string resourcesPath;

	public string facialMatName;

	private string viewerResourcesPath;

	private string viewerSettingPath;

	private string viewerMaterialPath;

	private string viewerBackGroundPath;

	public string texturePath;

	private int curBG;

	private int curAnim;

	private int curModel;

	private int curFacial;

	private int curMode;

	private float curLOD;

	private float curParticle;

	private float animSpeed;

	private string curModelName;

	private string curAnimName;

	private string curModeName;

	private string curBgName;

	private string curFacialName;

	private string curParticleName;

	private int facialCount;

	private float positionY;

	private string[] animationList;

	private string[] animationCommonList;

	private string[] facialTexList;

	private string[] particleAnimationList;

	private string[] particleList;

	private string[] modelList;

	private string[] modelListH;

	private string[] modelListM;

	private string[] modelListL;

	private string[] backGroundList;

	private string[] lodList;

	private string[] lodTextList;

	private string[] modeTextList;

	private GameObject obj;

	private GameObject loaded;

	private SkinnedMeshRenderer SM;

	private SkinnedMeshRenderer faceSM;

	private string faceObjName;

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

	private GameObject BGObject;

	private GameObject BGEff;

	private GameObject BGPlane;

	private Vector3 scale;

	private bool test;

	private bool ParticleMode;

	public succubus_twins_character_pack_scenescript()
	{
		this.boneName = "Hips";
		this.camGuiRootRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.camGuiBodyRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.animSpeedGuiBodyRect = new Rect((float)770, (float)520, (float)170, (float)150);
		this.positionYGuiBodyRect = new Rect((float)770, (float)520, (float)170, (float)150);
		this.textGuiBodyRect = new Rect((float)20, (float)510, (float)300, (float)70);
		this.modelBodyRect = new Rect((float)20, (float)40, (float)300, (float)500);
		this.FBXListFile = "fbx_list_a";
		this.AnimationListFile = "animation_list_a";
		this.ParticleListFile = "particle_list_a";
		this.ParticleAnimationListFile = "particle_animation_list_a";
		this.FacialTexListFile = "facial_texture_list_a";
		this.TitleTextFile = "title_text_a";
		this.guiOn = true;
		this.resourcesPath = "Arum";
		this.facialMatName = "succubus_a_face";
		this.viewerResourcesPath = "Succubus/";
		this.viewerSettingPath = this.viewerResourcesPath + "Viewer Settings";
		this.viewerMaterialPath = this.viewerResourcesPath + "Viewer Materials";
		this.viewerBackGroundPath = this.viewerResourcesPath + "Viewer BackGrounds";
		this.texturePath = "Arum/Textures";
		this.curBG = 1;
		this.curAnim = 1;
		this.curModel = 1;
		this.curFacial = 1;
		this.curMode = 1;
		this.curParticle = (float)1;
		this.animSpeed = (float)1;
		this.curModelName = string.Empty;
		this.curAnimName = string.Empty;
		this.curModeName = string.Empty;
		this.curBgName = string.Empty;
		this.curFacialName = string.Empty;
		this.curParticleName = string.Empty;
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
		this.modeTextList = new string[]
		{
			"AddPerticle",
			"Original"
		};
		this.CamModeRote = true;
		this.CamModeFix = true;
		this.titleText = string.Empty;
	}

	public virtual void Start()
	{
		this.viewCam = (succubus_twins_character_pack_viewscript)GameObject.Find("Main Camera").GetComponent("succubus_twins_character_pack_viewscript");
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/background_list", typeof(TextAsset));
		this.backGroundList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.FBXListFile, typeof(TextAsset));
		this.modelList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.ParticleListFile, typeof(TextAsset));
		this.particleList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.ParticleAnimationListFile, typeof(TextAsset));
		this.particleAnimationList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.AnimationListFile, typeof(TextAsset));
		this.animationCommonList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.FacialTexListFile, typeof(TextAsset));
		this.facialTexList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.TitleTextFile, typeof(TextAsset));
		this.titleText = this.txt.text;
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/fbx_ctrl", typeof(TextAsset));
		this.xDoc = new XmlDocument();
		this.xDoc.LoadXml(this.txt.text);
		if (this.resourcesPath == "Arum")
		{
			this.faceObjName = "succubus_a";
			this.faceMat_L = (Material)Resources.Load(this.viewerMaterialPath + "/succubus_a_face_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load(this.viewerMaterialPath + "/succubus_a_face_m", typeof(Material));
		}
		else if (this.resourcesPath == "Asphodel")
		{
			this.faceObjName = "succubus_b";
			this.faceMat_L = (Material)Resources.Load(this.viewerMaterialPath + "/succubus_b_face_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load(this.viewerMaterialPath + "/succubus_b_face_m", typeof(Material));
		}
		if (this.curMode == 0)
		{
			this.animationList = this.particleAnimationList;
		}
		else if (this.curMode == 1)
		{
			this.animationList = this.animationCommonList;
		}
		this.curModeName = this.modeTextList[this.curMode];
		this.BGObject = GameObject.Find("obj01_succubus_pedestal_00");
		this.BGEff = GameObject.Find("eff_obj01_00");
		this.BGPlane = GameObject.Find("Plane");
		this.SetInitBackGround();
		this.SetInitModel();
		this.SetInitMotion();
		this.SetAnimationSpeed(this.animSpeed);
		this.SetInitFacial();
		if (this.curMode == 0)
		{
			this.SetInitParticle();
		}
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
			if (this.curMode != 0 || this.curParticle != (float)4)
			{
			}
			this.scale.x = (float)Screen.width / 960f;
			this.scale.y = (float)Screen.height / 600f;
			this.scale.x = (float)1;
			this.scale.y = (float)1;
			this.scale.z = 1f;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, this.scale);
			GUI.Label(new Rect((float)20, (float)20, (float)500, (float)50), this.titleText, "Title");
			bool flag = default(bool);
			GUILayout.BeginArea(this.modelBodyRect);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			flag = GUILayout.Toggle(this.ParticleMode, string.Empty, "ParticleMode", new GUILayoutOption[0]);
			if (this.ParticleMode != flag)
			{
				this.ParticleMode = flag;
				if (this.curMode == 0)
				{
					this.SetNextMode(1);
				}
				else
				{
					this.SetNextMode(-1);
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.Space((float)20);
			if (this.curMode == 1)
			{
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
			}
			else if (this.curMode == 0)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
				{
					this.SetNextParticle(-1);
				}
				if (GUILayout.Button(string.Empty, "ParticleShot", new GUILayoutOption[0]))
				{
					this.particleExec();
				}
				if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
				{
					this.SetNextParticle(1);
				}
				GUILayout.EndHorizontal();
				GUILayout.Space((float)20);
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextFacial(-1);
			}
			GUILayout.Label(string.Empty, "Facial", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextFacial(1);
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
			if (this.curMode == 1)
			{
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
				GUILayout.BeginArea(this.positionYGuiBodyRect);
				GUILayout.FlexibleSpace();
				float num2 = GUILayout.HorizontalSlider(this.positionY, (float)0, (float)3, new GUILayoutOption[0]);
				if (this.positionY != num2)
				{
					this.positionY = num2;
					float y = this.positionY;
					Vector3 position = this.obj.transform.position;
					float num3 = position.y = y;
					Vector3 vector = this.obj.transform.position = position;
					this.viewCam.MouseLock(true);
				}
				else
				{
					this.viewCam.MouseLock(false);
				}
				GUILayout.FlexibleSpace();
				string text2 = "positionY : " + string.Format("{0:F1}", this.positionY);
				GUILayout.Box(text2, new GUILayoutOption[0]);
				GUILayout.FlexibleSpace();
				GUILayout.EndArea();
			}
			GUI.Label(this.camGuiRootRect, string.Empty, "CamBG");
			GUILayout.BeginArea(this.camGuiBodyRect);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
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
			string text3 = string.Empty;
			text3 += "Mode : " + this.curModeName + "\n";
			text3 += "Costume : " + (this.curModel + 1) + " / " + Extensions.get_length(this.modelList) + " : " + this.curModelName + "\n";
			if (this.curMode == 0)
			{
				text3 += "Particle  : " + (this.curAnim + 1) + " / " + Extensions.get_length(this.animationList) + " : " + this.curParticleName + "\n";
			}
			else
			{
				text3 += "Animation : " + (this.curAnim + 1) + " / " + Extensions.get_length(this.animationList) + " : " + this.curAnimName + "\n";
			}
			text3 += "Facial : " + (this.curFacial + 1) + " / " + this.facialCount + " : " + this.curFacialName + "\n";
			text3 += "BackGround : " + (this.curBG + 1) + " / " + Extensions.get_length(this.backGroundList) + " : " + this.curBgName + "\n";
			text3 += "Quality : " + this.lodTextList[(int)this.curLOD] + "\n";
			text3 += "Animation Speed : " + string.Format("{0:F2}", this.animSpeed);
			GUI.Box(this.textGuiBodyRect, text3);
		}
	}

	public virtual void SetNextMode(int _add)
	{
		this.curMode += _add;
		if (this.curMode > 1)
		{
			this.curMode = 0;
		}
		else if (this.curMode < 0)
		{
			this.curMode = 1;
		}
		UnityEngine.Object.Destroy(GameObject.Find("eff_succubus_seduced_00(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("seduce_particle_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle0m_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle4m_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle8m_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle20m_instance(Clone)"));
		if (this.curMode == 0)
		{
			this.animationList = this.particleAnimationList;
		}
		else if (this.curMode == 1)
		{
			this.animationList = this.animationCommonList;
		}
		this.curModeName = this.modeTextList[this.curMode];
		this.curAnim = 0;
		this.curParticle = (float)0;
		this.curLOD = (float)0;
		this.curParticleName = this.particleList[(int)this.curParticle];
		this.SetInitModel();
		this.SetInitMotion();
		this.SetAnimationSpeed(this.animSpeed);
		this.SetInitFacial();
		if (this.curMode == 0)
		{
			this.SetInitParticle();
		}
	}

	public virtual void SetInitParticle()
	{
		if (this.curMode == 0)
		{
			if (this.resourcesPath == "Arum")
			{
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_a_magic4m>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_a_magic8m>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_a_magic20m>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_a_materialization>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_a_seduce>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_a_seduced>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_a_damage>();
			}
			else if (this.resourcesPath == "Asphodel")
			{
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_b_magic4m>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_b_magic8m>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_b_magic20m>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_b_materialization>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_b_seduce>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_b_seduced>();
				this.obj.AddComponent<succubus_twins_character_pack_viewer_succubus_b_damage>();
			}
			this.SetParticle();
		}
	}

	public virtual void SetNextParticle(int _add)
	{
		this.curAnim += _add;
		this.curParticle += (float)_add;
		if (Extensions.get_length(this.animationList) <= this.curAnim)
		{
			this.curAnim = 0;
			this.curParticle = (float)0;
		}
		else if (this.curAnim < 0)
		{
			this.curAnim = Extensions.get_length(this.animationList) - 1;
			this.curParticle = (float)this.curAnim;
		}
		this.curParticleName = this.particleList[(int)this.curParticle];
		this.SetParticle();
	}

	public virtual void particleExec()
	{
		if (this.resourcesPath == "Arum")
		{
			float num = this.curParticle;
			if (num == (float)0)
			{
				((succubus_twins_character_pack_viewer_succubus_a_magic4m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic4m))).setParticle();
			}
			else if (num == (float)1)
			{
				((succubus_twins_character_pack_viewer_succubus_a_magic8m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic8m))).setParticle();
			}
			else if (num == (float)2)
			{
				((succubus_twins_character_pack_viewer_succubus_a_magic20m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic20m))).setParticle();
			}
			else if (num == (float)3)
			{
				((succubus_twins_character_pack_viewer_succubus_a_damage)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_damage))).setParticle();
			}
			else if (num != (float)4)
			{
				if (num == (float)5)
				{
					((succubus_twins_character_pack_viewer_succubus_a_seduce)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_seduce))).setParticle();
				}
				else if (num == (float)6)
				{
					((succubus_twins_character_pack_viewer_succubus_a_materialization)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_materialization))).setParticle();
				}
			}
		}
		else if (this.resourcesPath == "Asphodel")
		{
			float num2 = this.curParticle;
			if (num2 == (float)0)
			{
				((succubus_twins_character_pack_viewer_succubus_b_magic4m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic4m))).setParticle();
			}
			else if (num2 == (float)1)
			{
				((succubus_twins_character_pack_viewer_succubus_b_magic8m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic8m))).setParticle();
			}
			else if (num2 == (float)2)
			{
				((succubus_twins_character_pack_viewer_succubus_b_magic20m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic20m))).setParticle();
			}
			else if (num2 == (float)3)
			{
				((succubus_twins_character_pack_viewer_succubus_b_damage)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_damage))).setParticle();
			}
			else if (num2 != (float)4)
			{
				if (num2 == (float)5)
				{
					((succubus_twins_character_pack_viewer_succubus_b_seduce)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_seduce))).setParticle();
				}
				else if (num2 == (float)6)
				{
					((succubus_twins_character_pack_viewer_succubus_b_materialization)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_materialization))).setParticle();
				}
			}
		}
	}

	public virtual void SetParticle()
	{
		if (this.resourcesPath == "Arum")
		{
			((succubus_twins_character_pack_viewer_succubus_a_magic4m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic4m))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_a_magic8m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic8m))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_a_magic20m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic20m))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_a_materialization)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_materialization))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_a_seduce)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_seduce))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_a_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_seduced))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_a_damage)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_damage))).enabled = false;
		}
		else if (this.resourcesPath == "Asphodel")
		{
			((succubus_twins_character_pack_viewer_succubus_b_magic4m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic4m))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_b_magic8m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic8m))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_b_magic20m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic20m))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_b_materialization)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_materialization))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_b_seduce)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_seduce))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_b_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_seduced))).enabled = false;
			((succubus_twins_character_pack_viewer_succubus_b_damage)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_damage))).enabled = false;
		}
		UnityEngine.Object.Destroy(GameObject.Find("eff_succubus_seduced_00(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("seduce_particle_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle0m_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle4m_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle8m_instance(Clone)"));
		UnityEngine.Object.Destroy(GameObject.Find("magic_particle20m_instance(Clone)"));
		if (this.resourcesPath == "Arum")
		{
			float num = this.curParticle;
			if (num == (float)0)
			{
				((succubus_twins_character_pack_viewer_succubus_a_magic4m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic4m))).enabled = true;
			}
			else if (num == (float)1)
			{
				((succubus_twins_character_pack_viewer_succubus_a_magic8m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic8m))).enabled = true;
			}
			else if (num == (float)2)
			{
				((succubus_twins_character_pack_viewer_succubus_a_magic20m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_magic20m))).enabled = true;
			}
			else if (num == (float)3)
			{
				((succubus_twins_character_pack_viewer_succubus_a_damage)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_damage))).enabled = true;
			}
			else if (num == (float)4)
			{
				((succubus_twins_character_pack_viewer_succubus_a_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_seduced))).enabled = true;
				((succubus_twins_character_pack_viewer_succubus_a_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_seduced))).time = (float)0;
				((succubus_twins_character_pack_viewer_succubus_a_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_seduced))).playFlg = true;
			}
			else if (num == (float)5)
			{
				((succubus_twins_character_pack_viewer_succubus_a_seduce)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_seduce))).enabled = true;
			}
			else if (num == (float)6)
			{
				((succubus_twins_character_pack_viewer_succubus_a_materialization)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_a_materialization))).enabled = true;
			}
		}
		else if (this.resourcesPath == "Asphodel")
		{
			float num2 = this.curParticle;
			if (num2 == (float)0)
			{
				((succubus_twins_character_pack_viewer_succubus_b_magic4m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic4m))).enabled = true;
			}
			else if (num2 == (float)1)
			{
				((succubus_twins_character_pack_viewer_succubus_b_magic8m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic8m))).enabled = true;
			}
			else if (num2 == (float)2)
			{
				((succubus_twins_character_pack_viewer_succubus_b_magic20m)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_magic20m))).enabled = true;
			}
			else if (num2 == (float)3)
			{
				((succubus_twins_character_pack_viewer_succubus_b_damage)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_damage))).enabled = true;
			}
			else if (num2 == (float)4)
			{
				((succubus_twins_character_pack_viewer_succubus_b_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_seduced))).enabled = true;
				((succubus_twins_character_pack_viewer_succubus_b_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_seduced))).time = (float)0;
				((succubus_twins_character_pack_viewer_succubus_b_seduced)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_seduced))).playFlg = true;
			}
			else if (num2 == (float)5)
			{
				((succubus_twins_character_pack_viewer_succubus_b_seduce)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_seduce))).enabled = true;
			}
			else if (num2 == (float)6)
			{
				((succubus_twins_character_pack_viewer_succubus_b_materialization)this.obj.GetComponent(typeof(succubus_twins_character_pack_viewer_succubus_b_materialization))).enabled = true;
			}
		}
		this.particleExec();
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
		this.SetInitParticle();
		if (this.curLOD == (float)0)
		{
			this.SetFacialBlendShape(this.curFacial);
		}
		else
		{
			this.SetFacialTex(this.curFacial);
		}
	}

	public virtual void ModelChange(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("ModelChange : " + _name);
			this.curModelName = Path.GetFileNameWithoutExtension(_name);
			GameObject original = (GameObject)Resources.Load(_name, typeof(GameObject));
			UnityEngine.Object.Destroy(this.obj);
			this.obj = (((GameObject)UnityEngine.Object.Instantiate(original)) as GameObject);
			this.SM = (((SkinnedMeshRenderer)this.obj.GetComponentInChildren(typeof(SkinnedMeshRenderer))) as SkinnedMeshRenderer);
			this.SM.quality = SkinQuality.Bone4;
			this.SM.updateWhenOffscreen = true;
			this.viewCam.ModelTarget(this.GetBone(this.obj, this.boneName));
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.animTest.GetComponent<Animation>());
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
				this.obj.GetComponent<Animation>().AddClip(animationState.clip, animationState.name);
				UnityRuntimeServices.Update(enumerator, animationState);
			}
			this.facialMaterialSet();
			this.SetAnimation(string.Empty + this.animationList[this.curAnim]);
			this.SetAnimationSpeed(this.animSpeed);
		}
	}

	public virtual void SetAnimationSpeed(float _speed)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.obj.GetComponent<Animation>());
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

	public virtual void SetInitFacial()
	{
		this.curFacial = 0;
		this.curFacialName = "Default";
		Mesh sharedMesh = ((SkinnedMeshRenderer)GameObject.Find(this.curModelName + "_face").GetComponent(typeof(SkinnedMeshRenderer))).sharedMesh;
		this.facialCount = sharedMesh.blendShapeCount + 1;
	}

	public virtual void SetFacialBlendShape(int _i)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)GameObject.Find(this.curModelName + "_face").GetComponent(typeof(SkinnedMeshRenderer));
		Mesh sharedMesh = ((SkinnedMeshRenderer)GameObject.Find(this.curModelName + "_face").GetComponent(typeof(SkinnedMeshRenderer))).sharedMesh;
		int num = this.facialCount - 1;
		int num2 = _i - 1;
		for (int i = 0; i < this.facialCount - 1; i++)
		{
			skinnedMeshRenderer.SetBlendShapeWeight(i, (float)0);
		}
		if (num2 >= 0)
		{
			this.curFacialName = sharedMesh.GetBlendShapeName(num2);
			skinnedMeshRenderer.SetBlendShapeWeight(num2, (float)100);
		}
		else
		{
			this.curFacialName = "default";
		}
	}

	public virtual void facialMaterialSet()
	{
		if (this.curLOD != (float)0)
		{
			string name = this.faceObjName + this.lodList[(int)this.curLOD] + "_face";
			int num = 0;
			GameObject gameObject = GameObject.Find(name);
			this.faceSM = (SkinnedMeshRenderer)gameObject.GetComponent(typeof(SkinnedMeshRenderer));
			int i = 0;
			Material[] sharedMaterials = this.faceSM.GetComponent<Renderer>().sharedMaterials;
			int length = sharedMaterials.Length;
			while (i < length)
			{
				if (sharedMaterials[i].name == this.facialMatName + "_m")
				{
					this.faceSM.GetComponent<Renderer>().materials[num] = this.faceMat_M;
				}
				else if (sharedMaterials[i].name == this.facialMatName + "_l")
				{
					this.faceSM.GetComponent<Renderer>().materials[num] = this.faceMat_L;
				}
				num++;
				i++;
			}
		}
	}

	public virtual void SetNextFacial(int _add)
	{
		this.curFacial += _add;
		if (this.facialCount <= this.curFacial)
		{
			this.curFacial = 0;
		}
		else if (this.curFacial < 0)
		{
			this.curFacial = this.facialCount - 1;
		}
		if (this.curLOD == (float)0)
		{
			this.SetFacialBlendShape(this.curFacial);
		}
		else
		{
			this.SetFacialTex(this.curFacial);
		}
	}

	public virtual void SetFacialTex(int _i)
	{
		this.facialMaterialSet();
		string path = this.texturePath + "/" + this.facialTexList[_i] + this.lodList[(int)this.curLOD];
		string b = this.facialMatName + this.lodList[(int)this.curLOD] + " (Instance)";
		Texture2D texture = (Texture2D)Resources.Load(path, typeof(Texture2D));
		this.curFacialName = this.facialTexList[_i];
		int i = 0;
		Material[] sharedMaterials = this.faceSM.GetComponent<Renderer>().sharedMaterials;
		int length = sharedMaterials.Length;
		while (i < length)
		{
			if (sharedMaterials[i] && sharedMaterials[i].name == b)
			{
				sharedMaterials[i].SetTexture("_MainTex", texture);
			}
			i++;
		}
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
			this.obj.GetComponent<Animation>().Play(this.curAnimName);
			this.SetFixedFbx(this.xDoc, this.obj, this.curModelName, this.curAnimName, (int)this.curLOD);
		}
	}

	public virtual void SetInitBackGround()
	{
		this.BGObject.SetActive(false);
		this.BGEff.SetActive(false);
		this.BGPlane.SetActive(false);
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
		GameObject gameObject = GameObject.Find("BillBoard") as GameObject;
		if (this.curBG == 0)
		{
			gameObject.GetComponent<Renderer>().material.mainTexture = (Texture2D)Resources.Load(this.viewerBackGroundPath + "/bg1", typeof(Texture2D));
			this.BGObject.SetActive(true);
			this.BGEff.SetActive(true);
			this.BGPlane.SetActive(false);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.mainTexture = (Texture2D)Resources.Load(this.viewerBackGroundPath + "/bg0", typeof(Texture2D));
			this.BGObject.SetActive(false);
			this.BGEff.SetActive(false);
			this.BGPlane.SetActive(true);
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
				string xpath = "Root/Animation[@Lod=''or@Lod='" + _lod + "'][Info[@Model=''or@Model='" + _model + "'][@Ani=''or@Ani='" + _anim + "']]";
				XmlNode xmlNode = _xDoc.SelectSingleNode(xpath);
				if (xmlNode != null)
				{
					string innerText = xmlNode.Attributes["File"].InnerText;
					this.curAnimName = innerText;
					MonoBehaviour.print("Change Animation To " + this.curAnimName);
					_obj.GetComponent<Animation>().Play(this.curAnimName);
				}
				Vector3 position = default(Vector3);
				Vector3 eulerAngles = default(Vector3);
				xpath = "Root/Position[@Ani=''or@Ani='" + _anim + "']";
				xmlNode = _xDoc.SelectSingleNode(xpath);
				if (xmlNode != null)
				{
					position.x = float.Parse(xmlNode.Attributes["PosX"].InnerText);
					position.y = float.Parse(xmlNode.Attributes["PosY"].InnerText);
					position.z = float.Parse(xmlNode.Attributes["PosZ"].InnerText);
					eulerAngles.x = float.Parse(xmlNode.Attributes["RotX"].InnerText);
					eulerAngles.y = float.Parse(xmlNode.Attributes["RotY"].InnerText);
					eulerAngles.z = float.Parse(xmlNode.Attributes["RotZ"].InnerText);
					this.obj.transform.position = position;
					this.obj.transform.eulerAngles = eulerAngles;
					this.positionY = position.y;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
