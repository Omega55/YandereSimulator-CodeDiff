using System;
using System.Collections;
using System.IO;
using System.Xml;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class taichi_v0100_scenescript : MonoBehaviour
{
	public GameObject animTest;

	public GUISkin guiSkin;

	public taichi_v0100_viewscript viewCam;

	public string boneName;

	public Rect camGuiRootRect;

	public Rect camGuiBodyRect;

	public Rect guiOnBodyRect;

	public Rect sliderTextBodyRect;

	public Rect sliderGuiBodyRect;

	public Rect textGuiBodyRect;

	public Rect modelBodyRect;

	public string FBXListFile;

	public string AnimationListFile;

	public string TitleTextFile;

	public bool guiOn;

	public Material facialMaterial_M_org;

	public Material facialMaterial_L_org;

	public string FacialTexListFile;

	public string ParticleListFile;

	public string ParticleAnimationListFile;

	public string facialMatName;

	private bool guiShowFlg;

	private string viewerResourcesPath;

	private string viewerSettingPath;

	private string viewerMaterialPath;

	private string viewerBackGroundPath;

	private string texturePath;

	private Hashtable functionList;

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

	private string[] backGroundList;

	private string[] stageTexList;

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

	private GameObject planeObj;

	private Vector2 oldMousePosition;

	private float popupWaitingTime;

	private float popupWaitingTimeNow;

	private Vector3 scale;

	private bool test;

	private bool ParticleMode;

	private int onSliderFlg;

	public taichi_v0100_scenescript()
	{
		this.boneName = "Hips";
		this.camGuiRootRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.camGuiBodyRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.guiOnBodyRect = new Rect((float)50, (float)75, (float)300, (float)70);
		this.sliderTextBodyRect = new Rect((float)0, (float)0, (float)0, (float)0);
		this.sliderGuiBodyRect = new Rect((float)0, (float)0, (float)0, (float)0);
		this.textGuiBodyRect = new Rect((float)20, (float)510, (float)300, (float)70);
		this.modelBodyRect = new Rect((float)20, (float)40, (float)300, (float)500);
		this.FBXListFile = "fbx_list_a";
		this.AnimationListFile = "animation_list_a";
		this.TitleTextFile = "title_text_a";
		this.guiOn = true;
		this.FacialTexListFile = "facial_texture_list_a";
		this.ParticleListFile = "particle_list_a";
		this.ParticleAnimationListFile = "particle_animation_list_a";
		this.facialMatName = "f01_face_00";
		this.viewerResourcesPath = "Taichi_v0100";
		this.viewerSettingPath = this.viewerResourcesPath + "/Viewer Settings";
		this.viewerMaterialPath = this.viewerResourcesPath + "/Viewer Materials";
		this.viewerBackGroundPath = this.viewerResourcesPath + "/Viewer BackGrounds";
		this.texturePath = this.viewerResourcesPath + "/Textures";
		this.functionList = new Hashtable();
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
		this.popupWaitingTime = (float)2;
	}

	public virtual void Start()
	{
		this.functionList["particle"] = false;
		this.functionList["facial"] = false;
		this.functionList["model"] = true;
		this.functionList["animation"] = true;
		this.functionList["background"] = true;
		this.functionList["lod"] = true;
		this.functionList["position_x"] = false;
		this.functionList["position_y"] = false;
		this.functionList["position_z"] = false;
		this.functionList["rotate"] = false;
		this.functionList["animation_speed"] = true;
		this.viewCam = (taichi_v0100_viewscript)GameObject.Find("Main Camera").GetComponent("taichi_v0100_viewscript");
		this.planeObj = (GameObject.Find("Plane") as GameObject);
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
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/stage_texture_list", typeof(TextAsset));
		this.stageTexList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		if (RuntimeServices.ToBool(this.functionList["particle"]))
		{
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
		}
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.AnimationListFile, typeof(TextAsset));
		this.animationCommonList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		if (RuntimeServices.ToBool(this.functionList["facial"]))
		{
			this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.FacialTexListFile, typeof(TextAsset));
			this.facialTexList = this.txt.text.Split(new string[]
			{
				"\r",
				"\n"
			}, StringSplitOptions.RemoveEmptyEntries);
		}
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/" + this.TitleTextFile, typeof(TextAsset));
		this.titleText = this.txt.text;
		this.txt = (TextAsset)Resources.Load(this.viewerSettingPath + "/fbx_ctrl", typeof(TextAsset));
		this.xDoc = new XmlDocument();
		this.xDoc.LoadXml(this.txt.text);
		this.faceMat_L = this.facialMaterial_L_org;
		this.faceMat_M = this.facialMaterial_M_org;
		if (this.curMode == 0)
		{
			this.animationList = this.particleAnimationList;
		}
		else if (this.curMode == 1)
		{
			this.animationList = this.animationCommonList;
		}
		this.curModeName = this.modeTextList[this.curMode];
		this.SetInitBackGround();
		this.SetInitModel();
		this.SetInitMotion();
		this.SetAnimationSpeed(this.animSpeed);
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
		if (this.guiSkin)
		{
			GUI.skin = this.guiSkin;
		}
		if (!this.guiOn)
		{
			GUILayout.BeginArea(this.guiOnBodyRect);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			bool flag = GUILayout.Toggle(this.guiOn, string.Empty, "GUIOn", new GUILayoutOption[0]);
			if (this.guiOn != flag)
			{
				this.guiOn = flag;
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			GUILayout.EndArea();
			this.popUp();
		}
		else
		{
			if (this.curMode != 0 || this.curParticle != (float)4)
			{
			}
			this.scale.x = (float)Screen.width / 960f;
			this.scale.y = (float)Screen.height / 600f;
			this.scale.x = (float)1;
			this.scale.y = (float)1;
			this.scale.z = 1f;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, this.scale);
			float num = (float)Screen.width;
			float num2 = (float)Screen.height;
			this.textGuiBodyRect.y = num2 - (this.textGuiBodyRect.height + (float)20);
			this.camGuiRootRect.x = num - this.camGuiRootRect.width * 0.9f;
			this.camGuiBodyRect.x = num - (this.camGuiBodyRect.width * 0.9f - (float)15);
			this.sliderTextBodyRect.x = num - (this.sliderTextBodyRect.width + (float)20);
			this.sliderTextBodyRect.y = num2 - (this.sliderTextBodyRect.height + (float)20);
			this.sliderGuiBodyRect.x = num - (this.sliderTextBodyRect.width + this.sliderGuiBodyRect.width + (float)25);
			this.sliderGuiBodyRect.y = num2 - (this.sliderGuiBodyRect.height + (float)20);
			GUI.Label(new Rect((float)20, (float)20, (float)500, (float)50), this.titleText, "Title");
			float pixels = (float)10;
			bool flag2 = default(bool);
			GUILayout.BeginArea(this.modelBodyRect);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			bool flag = GUILayout.Toggle(this.guiOn, string.Empty, "GUIOn", new GUILayoutOption[0]);
			if (this.guiOn != flag)
			{
				this.guiOn = flag;
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(pixels);
			if (RuntimeServices.ToBool(this.functionList["particle"]))
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				flag2 = GUILayout.Toggle(this.ParticleMode, string.Empty, "ParticleMode", new GUILayoutOption[0]);
				if (this.ParticleMode != flag2)
				{
					this.ParticleMode = flag2;
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
				GUILayout.Space(pixels);
			}
			else
			{
				float a = 0.5f;
				Color color = GUI.color;
				float num3 = color.a = a;
				Color color2 = GUI.color = color;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label(string.Empty, "ParticleMode", new GUILayoutOption[0]);
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a2 = 1f;
				Color color3 = GUI.color;
				float num4 = color3.a = a2;
				Color color4 = GUI.color = color3;
			}
			if (RuntimeServices.ToBool(this.functionList["model"]))
			{
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
				GUILayout.Space(pixels);
			}
			else
			{
				float a3 = 0.5f;
				Color color5 = GUI.color;
				float num5 = color5.a = a3;
				Color color6 = GUI.color = color5;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "Costume", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a4 = 1f;
				Color color7 = GUI.color;
				float num6 = color7.a = a4;
				Color color8 = GUI.color = color7;
			}
			if (RuntimeServices.ToBool(this.functionList["animation"]))
			{
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
					GUILayout.Space(pixels);
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
					GUILayout.Space(pixels);
				}
			}
			else
			{
				float a5 = 0.5f;
				Color color9 = GUI.color;
				float num7 = color9.a = a5;
				Color color10 = GUI.color = color9;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "Anim", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a6 = 1f;
				Color color11 = GUI.color;
				float num8 = color11.a = a6;
				Color color12 = GUI.color = color11;
			}
			if (RuntimeServices.ToBool(this.functionList["facial"]))
			{
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
				GUILayout.Space(pixels);
			}
			else
			{
				float a7 = 0.5f;
				Color color13 = GUI.color;
				float num9 = color13.a = a7;
				Color color14 = GUI.color = color13;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "Facial", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a8 = 1f;
				Color color15 = GUI.color;
				float num10 = color15.a = a8;
				Color color16 = GUI.color = color15;
			}
			if (RuntimeServices.ToBool(this.functionList["background"]))
			{
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
				GUILayout.Space(pixels);
			}
			else
			{
				float a9 = 0.5f;
				Color color17 = GUI.color;
				float num11 = color17.a = a9;
				Color color18 = GUI.color = color17;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "BG", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a10 = 1f;
				Color color19 = GUI.color;
				float num12 = color19.a = a10;
				Color color20 = GUI.color = color19;
			}
			if (RuntimeServices.ToBool(this.functionList["lod"]))
			{
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
			}
			else
			{
				float a11 = 0.5f;
				Color color21 = GUI.color;
				float num13 = color21.a = a11;
				Color color22 = GUI.color = color21;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "LOD", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGlayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a12 = 1f;
				Color color23 = GUI.color;
				float num14 = color23.a = a12;
				Color color24 = GUI.color = color23;
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUILayout.BeginArea(this.sliderTextBodyRect);
			GUILayout.FlexibleSpace();
			if (RuntimeServices.ToBool(this.functionList["position_x"]))
			{
				float a13 = 1f;
				Color color25 = GUI.color;
				float num15 = color25.a = a13;
				Color color26 = GUI.color = color25;
			}
			else
			{
				float a14 = 0.4f;
				Color color27 = GUI.color;
				float num16 = color27.a = a14;
				Color color28 = GUI.color = color27;
			}
			string text = "Position X : " + string.Format("{0:F1}", this.obj.transform.position.x);
			GUILayout.Box(text, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (RuntimeServices.ToBool(this.functionList["position_y"]))
			{
				float a15 = 1f;
				Color color29 = GUI.color;
				float num17 = color29.a = a15;
				Color color30 = GUI.color = color29;
			}
			else
			{
				float a16 = 0.4f;
				Color color31 = GUI.color;
				float num18 = color31.a = a16;
				Color color32 = GUI.color = color31;
			}
			string text2 = "Position Y : " + string.Format("{0:F1}", this.obj.transform.position.y);
			GUILayout.Box(text2, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (RuntimeServices.ToBool(this.functionList["position_z"]))
			{
				float a17 = 1f;
				Color color33 = GUI.color;
				float num19 = color33.a = a17;
				Color color34 = GUI.color = color33;
			}
			else
			{
				float a18 = 0.4f;
				Color color35 = GUI.color;
				float num20 = color35.a = a18;
				Color color36 = GUI.color = color35;
			}
			string text3 = "Position Z : " + string.Format("{0:F1}", this.obj.transform.position.z);
			GUILayout.Box(text3, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (RuntimeServices.ToBool(this.functionList["rotate_y"]))
			{
				float a19 = 1f;
				Color color37 = GUI.color;
				float num21 = color37.a = a19;
				Color color38 = GUI.color = color37;
			}
			else
			{
				float a20 = 0.4f;
				Color color39 = GUI.color;
				float num22 = color39.a = a20;
				Color color40 = GUI.color = color39;
			}
			string text4 = "Rotate : " + string.Format("{0:F1}", this.obj.transform.eulerAngles.y);
			GUILayout.Box(text4, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			if (RuntimeServices.ToBool(this.functionList["animation_speed"]))
			{
				float a21 = 1f;
				Color color41 = GUI.color;
				float num23 = color41.a = a21;
				Color color42 = GUI.color = color41;
			}
			else
			{
				float a22 = 0.4f;
				Color color43 = GUI.color;
				float num24 = color43.a = a22;
				Color color44 = GUI.color = color43;
			}
			string text5 = "Animation\nSpeed : " + string.Format("{0:F1}", this.animSpeed);
			GUILayout.Box(text5, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
			GUILayout.BeginArea(this.sliderGuiBodyRect);
			if (RuntimeServices.ToBool(this.functionList["position_x"]))
			{
				if (this.onSliderFlg == 1)
				{
					float a23 = 1f;
					Color color45 = GUI.color;
					float num25 = color45.a = a23;
					Color color46 = GUI.color = color45;
				}
				else
				{
					float a24 = 0.4f;
					Color color47 = GUI.color;
					float num26 = color47.a = a24;
					Color color48 = GUI.color = color47;
				}
				float num27 = GUILayout.HorizontalSlider(this.obj.transform.position.x, (float)1, (float)-1, new GUILayoutOption[0]);
				if (this.obj.transform.position.x != num27)
				{
					float x = num27;
					Vector3 position = this.obj.transform.position;
					float num28 = position.x = x;
					Vector3 vector = this.obj.transform.position = position;
					this.viewCam.MouseLock(true);
				}
				else
				{
					this.viewCam.MouseLock(false);
				}
				GUILayout.Space((float)0);
			}
			else
			{
				float a25 = 0.4f;
				Color color49 = GUI.color;
				float num29 = color49.a = a25;
				Color color50 = GUI.color = color49;
				GUILayout.HorizontalSlider(this.obj.transform.position.x, (float)0, (float)0, new GUILayoutOption[0]);
				GUILayout.Space((float)0);
			}
			if (RuntimeServices.ToBool(this.functionList["position_y"]))
			{
				if (this.onSliderFlg == 2)
				{
					float a26 = 1f;
					Color color51 = GUI.color;
					float num30 = color51.a = a26;
					Color color52 = GUI.color = color51;
				}
				else
				{
					float a27 = 0.4f;
					Color color53 = GUI.color;
					float num31 = color53.a = a27;
					Color color54 = GUI.color = color53;
				}
				float num32 = GUILayout.HorizontalSlider(this.obj.transform.position.y, (float)0, (float)3, new GUILayoutOption[0]);
				if (this.obj.transform.position.y != num32)
				{
					float y = num32;
					Vector3 position2 = this.obj.transform.position;
					float num33 = position2.y = y;
					Vector3 vector2 = this.obj.transform.position = position2;
					this.viewCam.MouseLock(true);
				}
				else
				{
					this.viewCam.MouseLock(false);
				}
				GUILayout.Space((float)0);
			}
			else
			{
				float a28 = 0.4f;
				Color color55 = GUI.color;
				float num34 = color55.a = a28;
				Color color56 = GUI.color = color55;
				GUILayout.HorizontalSlider(this.obj.transform.position.y, (float)0, (float)0, new GUILayoutOption[0]);
				GUILayout.Space((float)0);
			}
			if (RuntimeServices.ToBool(this.functionList["position_z"]))
			{
				if (this.onSliderFlg == 3)
				{
					float a29 = 1f;
					Color color57 = GUI.color;
					float num35 = color57.a = a29;
					Color color58 = GUI.color = color57;
				}
				else
				{
					float a30 = 0.4f;
					Color color59 = GUI.color;
					float num36 = color59.a = a30;
					Color color60 = GUI.color = color59;
				}
				float num37 = GUILayout.HorizontalSlider(this.obj.transform.position.z, (float)1, (float)-1, new GUILayoutOption[0]);
				if (this.obj.transform.position.z != num37)
				{
					float z = num37;
					Vector3 position3 = this.obj.transform.position;
					float num38 = position3.z = z;
					Vector3 vector3 = this.obj.transform.position = position3;
					this.viewCam.MouseLock(true);
				}
				else
				{
					this.viewCam.MouseLock(false);
				}
				GUILayout.Space((float)0);
			}
			else
			{
				float a31 = 0.4f;
				Color color61 = GUI.color;
				float num39 = color61.a = a31;
				Color color62 = GUI.color = color61;
				GUILayout.HorizontalSlider(this.obj.transform.position.z, (float)0, (float)0, new GUILayoutOption[0]);
				GUILayout.Space((float)0);
			}
			if (RuntimeServices.ToBool(this.functionList["rotate"]))
			{
				if (this.onSliderFlg == 4)
				{
					float a32 = 1f;
					Color color63 = GUI.color;
					float num40 = color63.a = a32;
					Color color64 = GUI.color = color63;
				}
				else
				{
					float a33 = 0.4f;
					Color color65 = GUI.color;
					float num41 = color65.a = a33;
					Color color66 = GUI.color = color65;
				}
				float num42 = GUILayout.HorizontalSlider(this.obj.transform.eulerAngles.y, (float)0, 359.9f, new GUILayoutOption[0]);
				if (this.obj.transform.eulerAngles.y != num42)
				{
					float y2 = num42;
					Vector3 eulerAngles = this.obj.transform.eulerAngles;
					float num43 = eulerAngles.y = y2;
					Vector3 vector4 = this.obj.transform.eulerAngles = eulerAngles;
					this.viewCam.MouseLock(true);
				}
				else
				{
					this.viewCam.MouseLock(false);
				}
				GUILayout.Space((float)5);
			}
			else
			{
				float a34 = 0.4f;
				Color color67 = GUI.color;
				float num44 = color67.a = a34;
				Color color68 = GUI.color = color67;
				GUILayout.HorizontalSlider(this.obj.transform.eulerAngles.y, (float)0, (float)0, new GUILayoutOption[0]);
				GUILayout.Space((float)5);
			}
			if (RuntimeServices.ToBool(this.functionList["animation_speed"]))
			{
				if (this.onSliderFlg == 5)
				{
					float a35 = 1f;
					Color color69 = GUI.color;
					float num45 = color69.a = a35;
					Color color70 = GUI.color = color69;
				}
				else
				{
					float a36 = 0.4f;
					Color color71 = GUI.color;
					float num46 = color71.a = a36;
					Color color72 = GUI.color = color71;
				}
				float a37 = 1f;
				Color color73 = GUI.color;
				float num47 = color73.a = a37;
				Color color74 = GUI.color = color73;
				float num48 = GUILayout.HorizontalSlider(this.animSpeed, (float)0, (float)2, new GUILayoutOption[0]);
				if (this.animSpeed != num48)
				{
					this.animSpeed = num48;
					this.SetAnimationSpeed(this.animSpeed);
					this.viewCam.MouseLock(true);
				}
				else
				{
					this.viewCam.MouseLock(false);
				}
			}
			else
			{
				float a38 = 0.4f;
				Color color75 = GUI.color;
				float num49 = color75.a = a38;
				Color color76 = GUI.color = color75;
				GUILayout.HorizontalSlider(this.animSpeed, (float)0, (float)0, new GUILayoutOption[0]);
			}
			GUILayout.EndArea();
			float a39 = 1f;
			Color color77 = GUI.color;
			float num50 = color77.a = a39;
			Color color78 = GUI.color = color77;
			GUI.Label(this.camGuiRootRect, string.Empty, "CamBG");
			GUILayout.BeginArea(this.camGuiBodyRect);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			flag2 = GUILayout.Toggle(this.CamMode == 0, string.Empty, "Rote", new GUILayoutOption[0]);
			if (this.CamMode != 0 && flag2)
			{
				this.CamMode = 0;
				this.viewCam.ModeRote();
			}
			GUILayout.FlexibleSpace();
			flag2 = GUILayout.Toggle(this.CamMode == 1, string.Empty, "Move", new GUILayoutOption[0]);
			if (this.CamMode != 1 && flag2)
			{
				this.CamMode = 1;
				this.viewCam.ModeMove();
			}
			GUILayout.FlexibleSpace();
			flag2 = GUILayout.Toggle(this.CamMode == 2, string.Empty, "Zoom", new GUILayoutOption[0]);
			if (this.CamMode != 2 && flag2)
			{
				this.CamMode = 2;
				this.viewCam.ModeZoom();
			}
			GUILayout.FlexibleSpace();
			this.CamModeFix = this.viewCam.isFixTarget;
			flag2 = GUILayout.Toggle(this.CamModeFix, string.Empty, "Fix", new GUILayoutOption[0]);
			if (this.CamModeFix != flag2)
			{
				this.CamModeFix = flag2;
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
			string text6 = string.Empty;
			if (RuntimeServices.ToBool(this.functionList["particle"]))
			{
				text6 += "Mode : " + this.curModeName + "\n";
			}
			if (RuntimeServices.ToBool(this.functionList["model"]))
			{
				text6 += "Costume : " + (this.curModel + 1) + " / " + Extensions.get_length(this.modelList) + " : " + this.curModelName + "\n";
			}
			if (RuntimeServices.ToBool(this.functionList["animation"]))
			{
				if (this.curMode == 0)
				{
					text6 += "Particle  : " + (this.curAnim + 1) + " / " + Extensions.get_length(this.animationList) + " : " + this.curParticleName + "\n";
				}
				else
				{
					text6 += "Animation : " + (this.curAnim + 1) + " / " + Extensions.get_length(this.animationList) + " : " + this.curAnimName + "\n";
				}
			}
			if (RuntimeServices.ToBool(this.functionList["facial"]))
			{
				text6 += "Facial : " + (this.curFacial + 1) + " / " + this.facialCount + " : " + this.curFacialName + "\n";
			}
			if (RuntimeServices.ToBool(this.functionList["background"]))
			{
				text6 += "BackGround : " + (this.curBG + 1) + " / " + Extensions.get_length(this.backGroundList) + " : " + this.curBgName + "\n";
			}
			if (RuntimeServices.ToBool(this.functionList["lod"]))
			{
				text6 += "Quality : " + this.lodTextList[(int)this.curLOD] + "\n";
			}
			text6 += "Animation Speed : " + string.Format("{0:F2}", this.animSpeed);
			GUI.Box(this.textGuiBodyRect, text6);
			this.popUp();
		}
	}

	public virtual void popUp()
	{
		if (Input.GetMouseButton(0))
		{
			this.popupWaitingTimeNow = (float)0;
		}
		if (this.oldMousePosition == Input.mousePosition)
		{
			this.popupWaitingTimeNow += Time.deltaTime;
		}
		else
		{
			this.popupWaitingTimeNow = (float)0;
		}
		this.oldMousePosition = Input.mousePosition;
		if (this.popupWaitingTime <= this.popupWaitingTimeNow)
		{
			float num = (float)Screen.width;
			float num2 = (float)Screen.height;
			int num3 = 17;
			Vector2[] array = new Vector2[num3];
			Vector2[] array2 = new Vector2[num3];
			Rect[] array3 = new Rect[num3];
			string[] array4 = new string[num3];
			float num4 = (float)60;
			float num5 = (float)20;
			float num6 = num2 - num4;
			float num7 = 50f;
			float num8 = (float)100;
			float num9 = (float)12;
			float x = 0f;
			float num10 = 0f;
			float x2 = 0f;
			float num11 = 0f;
			float top = 0f;
			float num12 = 0f;
			if (this.guiOn)
			{
				num11 = num6;
				num10 = num6 - num7;
				x2 = num8 + num5;
				x = num5;
				top = num2 - num11;
				num12 = num8 + num5 + (float)10;
				array[0] = new Vector2(x, num10);
				array2[0] = new Vector2(x2, num11);
				array3[0] = new Rect(num12 - (float)20, top, (float)120, (float)23);
				array4[0] = "GUI On/Off.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[1] = new Vector2(x, num10);
				array2[1] = new Vector2(x2, num11);
				array3[1] = new Rect(num12 - (float)20, top, (float)120, (float)23);
				array4[1] = "Mode Change.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[2] = new Vector2(x, num10);
				array2[2] = new Vector2(x2, num11);
				array3[2] = new Rect(num12, top, (float)120, (float)23);
				array4[2] = "Model Change.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[3] = new Vector2(x, num10);
				array2[3] = new Vector2(x2, num11);
				array3[3] = new Rect(num12, top, (float)120, (float)23);
				array4[3] = "Motion Change.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[4] = new Vector2(x, num10);
				array2[4] = new Vector2(x2, num11);
				array3[4] = new Rect(num12, top, (float)120, (float)23);
				array4[4] = "Facial Change.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[5] = new Vector2(x, num10);
				array2[5] = new Vector2(x2, num11);
				array3[5] = new Rect(num12, top, (float)150, (float)23);
				array4[5] = "BackGround Change.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[6] = new Vector2(x, num10);
				array2[6] = new Vector2(x2, num11);
				array3[6] = new Rect(num12, top, (float)120, (float)23);
				array4[6] = "Lod Change.";
				num4 = (float)43;
				num6 = num2 - num4;
				num7 = 57.6f;
				num8 = 57.6f;
				num9 = 11.5f;
				float num13 = (float)220;
				float num14 = 0f;
				num14 = (float)Screen.width - num13;
				num11 = num6;
				num10 = num6 - num7;
				x2 = num - (float)10;
				x = num - (float)10 - num8;
				top = num2 - num11;
				array[7] = new Vector2(x, num10);
				array2[7] = new Vector2(x2, num11);
				array3[7] = new Rect(num14, top, (float)120, (float)23);
				array4[7] = "Camera Rotate.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[8] = new Vector2(x, num10);
				array2[8] = new Vector2(x2, num11);
				array3[8] = new Rect(num14, top, (float)120, (float)23);
				array4[8] = "Camera Move.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[9] = new Vector2(x, num10);
				array2[9] = new Vector2(x2, num11);
				array3[9] = new Rect(num14, top, (float)120, (float)23);
				array4[9] = "Camera Zoom.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				array[10] = new Vector2(x, num10);
				array2[10] = new Vector2(x2, num11);
				num14 -= (float)30;
				array3[10] = new Rect(num14, top, (float)150, (float)23);
				array4[10] = "Camera Target Lock.";
				num11 -= num7 + num9;
				num10 -= num7 + num9;
				top = num2 - num11;
				num14 += (float)30;
				array[11] = new Vector2(x, num10);
				array2[11] = new Vector2(x2, num11);
				array3[11] = new Rect(num14, top, (float)120, (float)23);
				array4[11] = "Camera Reset.";
			}
			else
			{
				num11 = num6;
				num10 = num6 - num7;
				x2 = num8 + num5;
				x = num5;
				top = num2 - num11;
				num12 = num8 + num5 + (float)10;
				array[0] = new Vector2(x, num10);
				array2[0] = new Vector2(x2, num11);
				array3[0] = new Rect(num12, top, (float)120, (float)23);
				array4[0] = "GUI On/Off.";
			}
			for (int i = 0; i < num3; i++)
			{
				if (Input.mousePosition.x > array[i].x && Input.mousePosition.x < array2[i].x && Input.mousePosition.y > array[i].y && Input.mousePosition.y < array2[i].y)
				{
					GUI.Box(array3[i], array4[i]);
				}
			}
		}
	}

	public virtual void scrollBarPos()
	{
		int num = 10;
		this.onSliderFlg = 0;
		Vector2[] array = new Vector2[num];
		Vector2[] array2 = new Vector2[num];
		array[0] = new Vector2((float)20, (float)270);
		array2[0] = new Vector2((float)280, (float)300);
		array[1] = new Vector2((float)20, (float)240);
		array2[1] = new Vector2((float)280, (float)270);
		array[2] = new Vector2((float)20, (float)210);
		array2[2] = new Vector2((float)280, (float)240);
		array[3] = new Vector2((float)20, (float)180);
		array2[3] = new Vector2((float)280, (float)210);
		array[4] = new Vector2((float)20, (float)140);
		array2[4] = new Vector2((float)280, (float)180);
		array[5] = new Vector2((float)20, (float)100);
		array2[5] = new Vector2((float)280, (float)140);
		for (int i = 0; i < num; i++)
		{
			if (Input.mousePosition.x > array[i].x && Input.mousePosition.x < array2[i].x && Input.mousePosition.y > array[i].y && Input.mousePosition.y < array2[i].y)
			{
				this.onSliderFlg = i + 1;
			}
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
		if (this.curMode != 0)
		{
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
	}

	public virtual void SetParticle()
	{
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
		if (RuntimeServices.ToBool(this.functionList["facial"]))
		{
			if (this.curLOD == (float)0)
			{
				this.SetFacialBlendShape(this.curFacial);
			}
			else
			{
				this.SetFacialTex(this.curFacial);
			}
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
			int num = 0;
			int i = 0;
			Material[] sharedMaterials = this.SM.renderer.sharedMaterials;
			int length = sharedMaterials.Length;
			while (i < length)
			{
				if (sharedMaterials[i].name == this.facialMatName + "_m")
				{
					this.SM.renderer.materials[num] = this.faceMat_M;
				}
				else if (sharedMaterials[i].name == this.facialMatName + "_l")
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
			Material[] sharedMaterials = this.faceSM.renderer.sharedMaterials;
			int length = sharedMaterials.Length;
			while (i < length)
			{
				if (sharedMaterials[i].name == this.facialMatName + "_m")
				{
					this.faceSM.renderer.materials[num] = this.faceMat_M;
				}
				else if (sharedMaterials[i].name == this.facialMatName + "_l")
				{
					this.faceSM.renderer.materials[num] = this.faceMat_L;
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
		Material[] sharedMaterials = this.faceSM.renderer.sharedMaterials;
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
		GameObject gameObject = GameObject.Find("BillBoard") as GameObject;
		Texture2D mainTexture;
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("SetBackGround : " + _name);
			this.curBgName = Path.GetFileNameWithoutExtension(_name);
			mainTexture = (Texture2D)Resources.Load(_name, typeof(Texture2D));
			GameObject gameObject2 = GameObject.Find("BillBoard") as GameObject;
			gameObject2.renderer.material.mainTexture = mainTexture;
		}
		mainTexture = (Texture2D)Resources.Load(this.stageTexList[this.curBG], typeof(Texture2D));
		this.planeObj.renderer.material.mainTexture = mainTexture;
		if (this.curBG == 0)
		{
			this.planeObj.SetActive(false);
		}
		else
		{
			this.planeObj.SetActive(true);
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
					_obj.animation.Play(this.curAnimName);
				}
				xpath = "Root/Texture[@Lod=''or@Lod='" + _lod + "'][Info[@Model=''or@Model='" + _model + "'][@Ani=''or@Ani='" + _anim + "']]";
				XmlNode xmlNode2 = _xDoc.SelectSingleNode(xpath);
				if (xmlNode2 != null)
				{
					string innerText2 = xmlNode2.Attributes["Material"].InnerText;
					string innerText3 = xmlNode2.Attributes["Property"].InnerText;
					string innerText4 = xmlNode2.Attributes["File"].InnerText;
					MonoBehaviour.print("Change Texture To " + innerText2 + " : " + innerText3 + " : " + innerText4);
					int i = 0;
					Material[] sharedMaterials = this.SM.renderer.sharedMaterials;
					int length = sharedMaterials.Length;
					while (i < length)
					{
						if (sharedMaterials[i] && sharedMaterials[i].name == innerText2)
						{
							Texture2D texture = (Texture2D)Resources.Load(innerText4, typeof(Texture2D));
							sharedMaterials[i].SetTexture(innerText3, texture);
						}
						i++;
					}
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
