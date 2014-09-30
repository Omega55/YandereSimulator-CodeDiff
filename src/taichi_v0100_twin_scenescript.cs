﻿using System;
using System.Collections;
using System.IO;
using System.Xml;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class taichi_v0100_twin_scenescript : MonoBehaviour
{
	public GUISkin guiSkin;

	public taichi_v0100_twin_viewscript viewCam;

	public string boneName;

	public Rect camGuiBodyRect;

	public Rect modelBodyRect;

	public Rect textGuiBodyRect;

	public Rect sliderGuiBodyRect;

	public Rect sliderTextBodyRect;

	public Rect guiOnButtonRect;

	public Rect guiOnBGRect;

	private bool guiShowFlg;

	private float guiShowTime;

	private float guiShowAlpha;

	private string segmentCode;

	private string CharacterCode;

	private string FBXListFile;

	private string AnimationListFile;

	private string AnimationListFileAll;

	private string FbxCtrlFile;

	private string ParticleListFile;

	private string ParticleAnimationListFile;

	private string FacialTexListFile;

	private string facialMatName;

	private float curParticle;

	private Vector2 oldMousePosition;

	private float popupWaitingTime;

	private float popupWaitingTimeNow;

	private bool guiOn;

	private float initPosX;

	private bool autoResourceMode;

	private string settingFileDir;

	private int curBG;

	private int curAnim;

	private int curModel;

	private int curCharacter;

	private int curFacial;

	private bool animReplay;

	private bool playOnceFlg;

	private string resourcesPathFull;

	private string resourcesPath;

	private float animSpeed;

	private float motionDelay;

	private float curLOD;

	private string curModelName;

	private string curAnimName;

	private string curBgName;

	private string curFacialName;

	private string curParticleName;

	private string curCharacterName;

	private int facialCount;

	private float positionY;

	private string animationPath;

	private string[] animationList;

	private string[] animationListAll;

	private string[] animationNameList;

	private string[] modelList;

	private string[] modelNameList;

	private string[] facialTexList;

	private string[] particleAnimationList;

	private string[] particleList;

	private float animSpeedSet;

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

	private XmlDocument xDoc;

	private XmlNodeList xNodeList;

	private float nowTime;

	private bool playFlg;

	private Material faceMat_L;

	private Material faceMat_M;

	private GameObject BGObject;

	private GameObject BGEff;

	private GameObject BGPlane;

	private Hashtable functionList;

	private GameObject planeObj;

	private bool animationPlayFlgOld;

	private int onSliderFlg;

	private Vector3 scale;

	public taichi_v0100_twin_scenescript()
	{
		this.boneName = "Hips";
		this.camGuiBodyRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.modelBodyRect = new Rect((float)20, (float)40, (float)300, (float)500);
		this.textGuiBodyRect = new Rect((float)20, (float)510, (float)300, (float)70);
		this.sliderGuiBodyRect = new Rect((float)770, (float)520, (float)170, (float)150);
		this.sliderTextBodyRect = new Rect((float)770, (float)520, (float)170, (float)150);
		this.guiOnButtonRect = new Rect((float)20, (float)40, (float)300, (float)500);
		this.guiOnBGRect = new Rect((float)20, (float)40, (float)300, (float)500);
		this.guiShowAlpha = 1f;
		this.segmentCode = "_A";
		this.CharacterCode = "M01/";
		this.FBXListFile = "fbx_list";
		this.AnimationListFile = "animation_list";
		this.AnimationListFileAll = "animation_list_all";
		this.FbxCtrlFile = "fbx_ctrl";
		this.ParticleListFile = "ParticleList";
		this.ParticleAnimationListFile = "ParticleAnimationList";
		this.FacialTexListFile = "facial_texture_list";
		this.facialMatName = "chr01_F03_face";
		this.curParticle = (float)1;
		this.popupWaitingTime = (float)2;
		this.guiOn = true;
		this.initPosX = 0.3f;
		this.autoResourceMode = true;
		this.settingFileDir = "Taichi_v0100/TwinViewer Settings/";
		this.curFacial = 1;
		this.animReplay = true;
		this.playOnceFlg = true;
		this.resourcesPathFull = "Assets/Taichi Character Pack/Resources/Taichi_v0100";
		this.resourcesPath = string.Empty;
		this.animSpeed = (float)1;
		this.curModelName = string.Empty;
		this.curAnimName = string.Empty;
		this.curBgName = string.Empty;
		this.curFacialName = string.Empty;
		this.curParticleName = string.Empty;
		this.curCharacterName = string.Empty;
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
		this.playFlg = true;
		this.functionList = new Hashtable();
	}

	public virtual void Start()
	{
		this.viewCam = (taichi_v0100_twin_viewscript)GameObject.Find("Main Camera").GetComponent("taichi_v0100_twin_viewscript");
		this.nowTime += Time.deltaTime;
		this.planeObj = (GameObject.Find("Plane") as GameObject);
		this.txt = (TextAsset)Resources.Load(this.settingFileDir + "background_list", typeof(TextAsset));
		this.backGroundList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingFileDir + "stage_texture_list", typeof(TextAsset));
		this.stageTexList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.SetSettings(0);
		this.SetInitBackGround();
		this.SetInitModel();
		this.SetInitMotion();
		this.SetAnimationSpeed(this.animSpeed);
		float x = this.initPosX;
		Vector3 position = this.obj.transform.position;
		float num = position.x = x;
		Vector3 vector = this.obj.transform.position = position;
	}

	public virtual void Update()
	{
		if (!this.obj.animation.IsPlaying(this.curAnimName) && this.animationPlayFlgOld)
		{
			this.nowTime = (float)0;
			this.playFlg = true;
		}
		this.animationPlayFlgOld = this.obj.animation.IsPlaying(this.curAnimName);
		this.nowTime += Time.deltaTime;
		if (this.nowTime > this.motionDelay)
		{
			this.SetAnimationSpeed(this.animSpeedSet);
			this.playAnimation();
		}
		else
		{
			this.SetAnimationSpeed((float)0);
			this.playAnimation();
		}
		if (Input.GetKeyDown("1"))
		{
			this.SetNextModel(-1);
		}
		if (Input.GetKeyDown("2"))
		{
			this.SetNextModel(-1);
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
			float num4 = num2 - (float)10;
			float num5 = (float)50;
			float num6 = (float)100;
			float num7 = 9.5f;
			float num8 = 0f;
			float y = 0f;
			float num9 = 0f;
			float num10 = 0f;
			if (this.guiOn)
			{
				num10 = num4;
				y = num4 - num5;
				num8 = (float)10;
				num9 = num6 + num8;
				array[0] = new Vector2(num8, y);
				array2[0] = new Vector2(num9, num10);
				array3[0] = new Rect((float)123, (float)10, (float)120, (float)23);
				array4[0] = "Character Change.";
				num10 = num4 - num5 - num7;
				y = num4 - num5 * (float)2 - num7;
				array[1] = new Vector2(num8, y);
				array2[1] = new Vector2(num9, num10);
				array3[1] = new Rect((float)123, (float)69, (float)120, (float)23);
				array4[1] = "Model Change.";
				num10 = num4 - num5 * (float)2 - num7 * (float)2;
				y = num4 - num5 * (float)3 - num7 * (float)2;
				array[2] = new Vector2(num8, y);
				array2[2] = new Vector2(num9, num10);
				array3[2] = new Rect((float)123, (float)129, (float)120, (float)40);
				array4[2] = "Motion Change.\nRepeat Setting.";
				num10 = num4 - num5 * (float)3 - num7 * (float)3;
				y = num4 - num5 * (float)4 - num7 * (float)3;
				array[3] = new Vector2(num8, y);
				array2[3] = new Vector2(num9, num10);
				array3[3] = new Rect((float)123, (float)190, (float)120, (float)23);
				array4[3] = "Facial Change.";
				num10 = num4 - num5 * (float)4 - num7 * (float)4;
				y = num4 - num5 * (float)5 - num7 * (float)4;
				array[4] = new Vector2(num8, y);
				array2[4] = new Vector2((float)120, num10);
				array3[4] = new Rect((float)123, (float)250, (float)120, (float)23);
				array4[4] = "Lod Change.";
				float num11 = (float)245;
				float left = 0f;
				left = (float)Screen.width - num11;
				num10 = num4;
				y = num4 - num5;
				num9 = num - (float)10;
				num8 = num - (float)10 - num6;
				array[5] = new Vector2(num8, y);
				array2[5] = new Vector2(num9, num10);
				array3[5] = new Rect(left, (float)10, (float)120, (float)23);
				array4[5] = "Character Change.";
				num10 = num4 - num5 - num7;
				y = num4 - num5 * (float)2 - num7;
				array[6] = new Vector2(num8, y);
				array2[6] = new Vector2(num9, num10);
				array3[6] = new Rect(left, (float)69, (float)120, (float)23);
				array4[6] = "Model Change.";
				num10 = num4 - num5 * (float)2 - num7 * (float)2;
				y = num4 - num5 * (float)3 - num7 * (float)2;
				array[7] = new Vector2(num8, y);
				array2[7] = new Vector2(num9, num10);
				array3[7] = new Rect(left, (float)129, (float)120, (float)40);
				array4[7] = "Motion Change.\nRepeat Setting.";
				num10 = num4 - num5 * (float)3 - num7 * (float)3;
				y = num4 - num5 * (float)4 - num7 * (float)3;
				array[8] = new Vector2(num8, y);
				array2[8] = new Vector2(num9, num10);
				array3[8] = new Rect(left, (float)190, (float)120, (float)23);
				array4[8] = "Facial Change.";
				num10 = num4 - num5 * (float)4 - num7 * (float)4;
				y = num4 - num5 * (float)5 - num7 * (float)4;
				array[9] = new Vector2(num8, y);
				array2[9] = new Vector2(num9, num10);
				array3[9] = new Rect(left, (float)250, (float)120, (float)23);
				array4[9] = "Lod Change.";
			}
			if (this.guiShowFlg)
			{
				num10 = num2 - (float)50;
				y = num10 - (float)50;
				float x = this.camGuiBodyRect.x;
				num6 = (float)50;
				num7 = (float)8;
				num9 = x + num6;
				num8 = x;
				array[10] = new Vector2(num8, y);
				array2[10] = new Vector2(num9, num10);
				array3[10] = new Rect(num8, (float)25, (float)150, (float)20);
				array4[10] = "Camera Rotate.";
				num9 += num6 + num7;
				num8 += num6 + num7;
				array[11] = new Vector2(num8, y);
				array2[11] = new Vector2(num9, num10);
				array3[11] = new Rect(num8, (float)25, (float)150, (float)20);
				array4[11] = "Camera Move.";
				num9 += num6 + num7;
				num8 += num6 + num7;
				array[12] = new Vector2(num8, y);
				array2[12] = new Vector2(num9, num10);
				array3[12] = new Rect(num8, (float)25, (float)150, (float)20);
				array4[12] = "Camera Zoom.";
				num9 += num6 + num7;
				num8 += num6 + num7;
				array[13] = new Vector2(num8, y);
				array2[13] = new Vector2(num9, num10);
				array3[13] = new Rect(num8 - (float)100, (float)25, (float)150, (float)20);
				array4[13] = "Camera Target Lock.";
				num9 += num6 + num7;
				num8 += num6 + num7;
				array[14] = new Vector2(num8, y);
				array2[14] = new Vector2(num9, num10);
				array3[14] = new Rect(num8 - (float)100, (float)25, (float)150, (float)20);
				array4[14] = "Camera Reset.";
				num8 = this.guiOnButtonRect.x;
				num9 = num8 + (float)100;
				array[15] = new Vector2(num8, y);
				array2[15] = new Vector2(num9, num10);
				array3[15] = new Rect(num8 + (float)50 - (float)73, (float)25, (float)150, (float)20);
				array4[15] = "BackGround:" + (this.curBG + 1) + "/" + Extensions.get_length(this.backGroundList) + ":" + this.curBgName + "\n";
				num8 = this.guiOnButtonRect.x + num6 * (float)2 + (float)70;
				num9 = num8 + num6;
				array[16] = new Vector2(num8, y);
				array2[16] = new Vector2(num9, num10);
				array3[16] = new Rect(num8 + num6 / (float)2 - (float)50, (float)25, (float)100, (float)20);
				if (this.guiOn)
				{
					array4[16] = "Viewer UI:On";
				}
				else
				{
					array4[16] = "Viewer UI:Off";
				}
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
		float x = 0f;
		float x2 = 0f;
		float num2 = 0f;
		float num3 = 0f;
		x = (float)10;
		x2 = (float)270;
		array[0] = new Vector2(x, (float)267);
		array2[0] = new Vector2(x2, (float)295);
		array[1] = new Vector2(x, (float)235);
		array2[1] = new Vector2(x2, (float)267);
		array[2] = new Vector2(x, (float)205);
		array2[2] = new Vector2(x2, (float)235);
		array[3] = new Vector2(x, (float)175);
		array2[3] = new Vector2(x2, (float)205);
		array[4] = new Vector2(x, (float)130);
		array2[4] = new Vector2(x2, (float)175);
		array[5] = new Vector2(x, (float)85);
		array2[5] = new Vector2(x2, (float)130);
		for (int i = 0; i < num; i++)
		{
			if (Input.mousePosition.x > array[i].x && Input.mousePosition.x < array2[i].x && Input.mousePosition.y > array[i].y && Input.mousePosition.y < array2[i].y)
			{
				this.onSliderFlg = i + 1;
			}
		}
	}

	public virtual void OnGUI()
	{
		float num = (float)Screen.width;
		float num2 = (float)Screen.height;
		float num3 = (float)40;
		float num4 = (float)20;
		float num5 = (float)(Screen.width / 2) - num3 / (float)2;
		float num6 = num5 + num3;
		float num7 = (float)Screen.height - num4;
		float num8 = (float)Screen.height;
		this.guiOnBGRect.x = num / (float)2 - this.guiOnBGRect.width / (float)2;
		this.guiOnButtonRect.x = num / (float)2 + (float)40;
		this.camGuiBodyRect.x = num / (float)2 - this.guiOnBGRect.width / (float)2 + (float)20;
		if (Input.mousePosition.x > num5 && Input.mousePosition.x < num6 && Input.mousePosition.y > num7 && Input.mousePosition.y < num8)
		{
			this.guiShowFlg = true;
			this.guiShowAlpha = (float)1;
			this.guiShowTime = (float)0;
		}
		float num9 = (float)Screen.height - this.guiOnBGRect.height + num4;
		float num10 = (float)(Screen.width / 2) - this.guiOnBGRect.width / (float)2;
		float num11 = (float)(Screen.width / 2) + this.guiOnBGRect.width / (float)2;
		if (Input.mousePosition.x < num10 || Input.mousePosition.x > num11 || Input.mousePosition.y < num9)
		{
			this.guiShowFlg = false;
		}
		if (!this.guiShowFlg)
		{
			this.guiShowTime += Time.deltaTime;
		}
		if (!this.guiShowFlg && this.guiShowTime > (float)5 && this.guiShowAlpha > 0.5f)
		{
			this.guiShowAlpha -= Time.deltaTime * 0.5f;
		}
		float a = this.guiShowAlpha;
		Color color = GUI.color;
		float num12 = color.a = a;
		Color color2 = GUI.color = color;
		taichi_v0100_twin2nd_scenescript taichi_v0100_twin2nd_scenescript = (taichi_v0100_twin2nd_scenescript)this.gameObject.GetComponent("taichi_v0100_twin2nd_scenescript");
		if (this.guiSkin)
		{
			GUI.skin = this.guiSkin;
		}
		float num13 = (float)200;
		if (this.guiShowFlg)
		{
			if (this.guiOnBGRect.y < (float)-30)
			{
				this.guiOnBGRect.y = this.guiOnBGRect.y + Time.deltaTime * num13;
				this.guiOnButtonRect.y = this.guiOnButtonRect.y + Time.deltaTime * num13;
				this.camGuiBodyRect.y = this.camGuiBodyRect.y + Time.deltaTime * num13;
			}
			else
			{
				this.guiOnBGRect.y = (float)-30;
				this.guiOnButtonRect.y = (float)50;
				this.camGuiBodyRect.y = (float)50;
			}
		}
		else if (this.guiOnBGRect.y > (float)-158)
		{
			this.guiOnBGRect.y = this.guiOnBGRect.y - Time.deltaTime * num13;
			this.guiOnButtonRect.y = this.guiOnButtonRect.y - Time.deltaTime * num13;
			this.camGuiBodyRect.y = this.camGuiBodyRect.y - Time.deltaTime * num13;
		}
		else
		{
			this.guiOnBGRect.y = (float)-158;
			this.guiOnButtonRect.y = (float)-80;
			this.camGuiBodyRect.y = (float)-80;
		}
		GUI.Label(this.guiOnBGRect, string.Empty, "GUIOnBG");
		GUILayout.BeginArea(this.guiOnButtonRect);
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
		GUILayout.FlexibleSpace();
		bool flag = GUILayout.Toggle(this.guiOn, string.Empty, "GUIOn", new GUILayoutOption[0]);
		if (this.guiOn != flag)
		{
			this.guiOn = flag;
			taichi_v0100_twin2nd_scenescript.guiOn = flag;
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		float a2 = 1f;
		Color color3 = GUI.color;
		float num14 = color3.a = a2;
		Color color4 = GUI.color = color3;
		GUILayout.BeginArea(this.camGuiBodyRect);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		bool flag2 = default(bool);
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
			this.viewCam.ModelTarget(this.GetBone(this.obj, this.boneName));
			this.viewCam.Reset();
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		if (!this.guiOn)
		{
			this.popUp();
		}
		else
		{
			this.scale.x = (float)1;
			this.scale.y = (float)1;
			this.scale.z = 1f;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, this.scale);
			this.textGuiBodyRect.y = num2 - (this.textGuiBodyRect.height + (float)10);
			this.sliderGuiBodyRect.y = num2 - (this.sliderGuiBodyRect.height + this.textGuiBodyRect.height + (float)28);
			this.sliderTextBodyRect.y = num2 - (this.sliderTextBodyRect.height + this.textGuiBodyRect.height + (float)15);
			this.scrollBarPos();
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height - 80), (float)300, (float)30), "MotionSyncro") || Input.GetKeyDown("space"))
			{
				this.timerReset();
				taichi_v0100_twin2nd_scenescript.timerReset();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height - 40), (float)300, (float)30), "Reset"))
			{
				int num15 = 0;
				Vector3 eulerAngles = this.obj.transform.eulerAngles;
				float num16 = eulerAngles.y = (float)num15;
				Vector3 vector = this.obj.transform.eulerAngles = eulerAngles;
				float x = 0.3f;
				Vector3 position = this.obj.transform.position;
				float num17 = position.x = x;
				Vector3 vector2 = this.obj.transform.position = position;
				int num18 = 0;
				Vector3 position2 = this.obj.transform.position;
				float num19 = position2.y = (float)num18;
				Vector3 vector3 = this.obj.transform.position = position2;
				int num20 = 0;
				Vector3 position3 = this.obj.transform.position;
				float num21 = position3.z = (float)num20;
				Vector3 vector4 = this.obj.transform.position = position3;
				this.animSpeed = (float)1;
				this.motionDelay = (float)0;
				this.SetAnimationSpeed(this.animSpeed);
				taichi_v0100_twin2nd_scenescript.sliderReset();
			}
			float pixels = (float)8;
			GUILayout.BeginArea(this.modelBodyRect);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextCharacter(-1);
			}
			GUILayout.Label(string.Empty, "Chara", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextCharacter(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(pixels);
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
				float num22 = color5.a = a3;
				Color color6 = GUI.color = color5;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGrayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "Costume", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGrayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a4 = 1f;
				Color color7 = GUI.color;
				float num23 = color7.a = a4;
				Color color8 = GUI.color = color7;
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextMotion(-1);
			}
			bool flag3 = GUILayout.Toggle(this.animReplay, string.Empty, "AnimReplay", new GUILayoutOption[0]);
			if (this.animReplay != flag3)
			{
				this.animReplay = flag3;
			}
			if (this.animReplay)
			{
				this.playOnceFlg = true;
			}
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextMotion(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(pixels);
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
				float a5 = 0.5f;
				Color color9 = GUI.color;
				float num24 = color9.a = a5;
				Color color10 = GUI.color = color9;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGrayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "Facial", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGrayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.Space(pixels);
				float a6 = 1f;
				Color color11 = GUI.color;
				float num25 = color11.a = a6;
				Color color12 = GUI.color = color11;
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
				GUILayout.FlexibleSpace();
			}
			else
			{
				float a7 = 0.5f;
				Color color13 = GUI.color;
				float num26 = color13.a = a7;
				Color color14 = GUI.color = color13;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "LeftGrayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.Label(string.Empty, "LOD", new GUILayoutOption[0]);
				if (GUILayout.Button(string.Empty, "RightGrayOut", new GUILayoutOption[0]))
				{
				}
				GUILayout.EndHorizontal();
				GUILayout.FlexibleSpace();
				float a8 = 1f;
				Color color15 = GUI.color;
				float num27 = color15.a = a8;
				Color color16 = GUI.color = color15;
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUILayout.BeginArea(this.sliderTextBodyRect);
			GUILayout.FlexibleSpace();
			string text = "Position X : " + string.Format("{0:F1}", this.obj.transform.position.x);
			GUILayout.Box(text, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			string text2 = "Position Y : " + string.Format("{0:F1}", this.obj.transform.position.y);
			GUILayout.Box(text2, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			string text3 = "Position Z : " + string.Format("{0:F1}", this.obj.transform.position.z);
			GUILayout.Box(text3, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			string text4 = "Rotate : " + string.Format("{0:F1}", this.obj.transform.eulerAngles.y);
			GUILayout.Box(text4, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			string text5 = "Animation\nSpeed : " + string.Format("{0:F1}", this.animSpeed);
			GUILayout.Box(text5, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			string text6 = "Motion\nDelay : " + string.Format("{0:F1}", this.motionDelay);
			GUILayout.Box(text6, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
			GUILayout.BeginArea(this.sliderGuiBodyRect);
			if (this.onSliderFlg == 1)
			{
				float a9 = 1f;
				Color color17 = GUI.color;
				float num28 = color17.a = a9;
				Color color18 = GUI.color = color17;
			}
			else
			{
				float a10 = 0.4f;
				Color color19 = GUI.color;
				float num29 = color19.a = a10;
				Color color20 = GUI.color = color19;
			}
			float num30 = GUILayout.HorizontalSlider(this.obj.transform.position.x, (float)1, (float)-1, new GUILayoutOption[0]);
			if (this.obj.transform.position.x != num30)
			{
				float x2 = num30;
				Vector3 position4 = this.obj.transform.position;
				float num31 = position4.x = x2;
				Vector3 vector5 = this.obj.transform.position = position4;
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.Space((float)0);
			if (this.onSliderFlg == 2)
			{
				float a11 = 1f;
				Color color21 = GUI.color;
				float num32 = color21.a = a11;
				Color color22 = GUI.color = color21;
			}
			else
			{
				float a12 = 0.4f;
				Color color23 = GUI.color;
				float num33 = color23.a = a12;
				Color color24 = GUI.color = color23;
			}
			float num34 = GUILayout.HorizontalSlider(this.obj.transform.position.y, (float)0, (float)3, new GUILayoutOption[0]);
			if (this.obj.transform.position.y != num34)
			{
				float y = num34;
				Vector3 position5 = this.obj.transform.position;
				float num35 = position5.y = y;
				Vector3 vector6 = this.obj.transform.position = position5;
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.Space((float)0);
			if (this.onSliderFlg == 3)
			{
				float a13 = 1f;
				Color color25 = GUI.color;
				float num36 = color25.a = a13;
				Color color26 = GUI.color = color25;
			}
			else
			{
				float a14 = 0.4f;
				Color color27 = GUI.color;
				float num37 = color27.a = a14;
				Color color28 = GUI.color = color27;
			}
			float num38 = GUILayout.HorizontalSlider(this.obj.transform.position.z, (float)1, (float)-1, new GUILayoutOption[0]);
			if (this.obj.transform.position.z != num38)
			{
				float z = num38;
				Vector3 position6 = this.obj.transform.position;
				float num39 = position6.z = z;
				Vector3 vector7 = this.obj.transform.position = position6;
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.Space((float)-3);
			if (this.onSliderFlg == 4)
			{
				float a15 = 1f;
				Color color29 = GUI.color;
				float num40 = color29.a = a15;
				Color color30 = GUI.color = color29;
			}
			else
			{
				float a16 = 0.4f;
				Color color31 = GUI.color;
				float num41 = color31.a = a16;
				Color color32 = GUI.color = color31;
			}
			float num42 = GUILayout.HorizontalSlider(this.obj.transform.eulerAngles.y, (float)0, 359.9f, new GUILayoutOption[0]);
			if (this.obj.transform.eulerAngles.y != num42)
			{
				float y2 = num42;
				Vector3 eulerAngles2 = this.obj.transform.eulerAngles;
				float num43 = eulerAngles2.y = y2;
				Vector3 vector8 = this.obj.transform.eulerAngles = eulerAngles2;
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.Space((float)6);
			if (this.onSliderFlg == 5)
			{
				float a17 = 1f;
				Color color33 = GUI.color;
				float num44 = color33.a = a17;
				Color color34 = GUI.color = color33;
			}
			else
			{
				float a18 = 0.4f;
				Color color35 = GUI.color;
				float num45 = color35.a = a18;
				Color color36 = GUI.color = color35;
			}
			this.animSpeedSet = GUILayout.HorizontalSlider(this.animSpeed, (float)0, (float)2, new GUILayoutOption[0]);
			if (this.animSpeed != this.animSpeedSet)
			{
				this.animSpeed = this.animSpeedSet;
				this.SetAnimationSpeed(this.animSpeed);
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.Space((float)13);
			if (this.onSliderFlg == 6)
			{
				float a19 = 1f;
				Color color37 = GUI.color;
				float num46 = color37.a = a19;
				Color color38 = GUI.color = color37;
			}
			else
			{
				float a20 = 0.4f;
				Color color39 = GUI.color;
				float num47 = color39.a = a20;
				Color color40 = GUI.color = color39;
			}
			float num48 = GUILayout.HorizontalSlider(this.motionDelay, (float)0, (float)5, new GUILayoutOption[0]);
			if (this.motionDelay != num48)
			{
				this.motionDelay = num48;
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.EndArea();
			float a21 = 1f;
			Color color41 = GUI.color;
			float num49 = color41.a = a21;
			Color color42 = GUI.color = color41;
			string text7 = string.Empty;
			text7 += "Character : " + this.curCharacterName + "\n";
			if (RuntimeServices.ToBool(this.functionList["model"]))
			{
				text7 += "Costume : " + (this.curModel + 1) + " / " + Extensions.get_length(this.modelList) + " : " + this.curModelName + "\n";
			}
			text7 += "Animation : " + (this.curAnim + 1) + " / " + Extensions.get_length(this.animationList) + " : " + this.curAnimName + "\n";
			if (RuntimeServices.ToBool(this.functionList["facial"]))
			{
				text7 += "Facial : " + (this.curFacial + 1) + " / " + this.facialCount + " : " + this.curFacialName + "\n";
			}
			if (RuntimeServices.ToBool(this.functionList["lod"]))
			{
				text7 += "Quality : " + this.lodTextList[(int)this.curLOD] + "\n";
			}
			GUI.Box(this.textGuiBodyRect, text7);
			this.popUp();
		}
	}

	public virtual void SetInit()
	{
		this.SetInitModel();
		this.SetInitMotion();
		this.SetAnimationSpeed(this.animSpeed);
		if (RuntimeServices.ToBool(this.functionList["facial"]))
		{
			this.SetInitFacial();
		}
	}

	public virtual void timerReset()
	{
		this.nowTime = (float)0;
		this.obj.animation.Stop();
		this.playOnceFlg = true;
	}

	public virtual void SetSettings(int _i)
	{
		string path = null;
		this.curAnim = 0;
		this.curModel = 0;
		this.curLOD = (float)0;
		if (_i == 0)
		{
			this.resourcesPathFull = "Assets/Taichi Character Pack/Resources/Taichi_v0100";
			this.resourcesPath = "Taichi_v0100/";
			this.animationPath = "Taichi_v0100/Animations Legacy/m01@";
			this.CharacterCode = "M01/";
			this.AnimationListFile = "animation_list";
			this.AnimationListFileAll = "animation_list";
			path = "Taichi_v0100/TwinViewer Settings/" + this.CharacterCode + "fbx_ctrl";
			this.faceMat_L = (Material)Resources.Load("Taichi_v0100/Materials/m01_face_00_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load("Taichi_v0100/Materials/m01_face_00_m", typeof(Material));
			this.functionList["model"] = true;
			this.functionList["facial"] = false;
			this.functionList["lod"] = true;
			this.curCharacterName = "Taichi Hayami";
		}
		else if (_i == 1)
		{
			this.resourcesPathFull = "Assets/Taichi Character Pack/Resources/Puppet";
			this.resourcesPath = "Puppet/";
			this.animationPath = "Taichi_v0100/Animations Legacy/m01@";
			this.AnimationListFile = "animation_list";
			this.AnimationListFileAll = "animation_list";
			this.CharacterCode = "Puppet/";
			path = this.settingFileDir + this.CharacterCode + "fbx_ctrl";
			this.functionList["model"] = false;
			this.functionList["facial"] = false;
			this.functionList["lod"] = false;
			this.curCharacterName = "Puppet";
		}
		else if (_i == 2)
		{
			this.resourcesPathFull = "Assets/HonokaFutabaBasicSet Ver1.12/Resources/Honoka_v0112";
			this.resourcesPath = "Honoka_v0112/";
			this.animationPath = "Honoka_v0112/Animations Legacy/f01@";
			this.AnimationListFile = "animation_list";
			this.AnimationListFileAll = "animation_list_all";
			this.CharacterCode = "F01/";
			path = this.settingFileDir + this.CharacterCode + "fbx_ctrl";
			this.functionList["model"] = true;
			this.functionList["facial"] = false;
			this.functionList["lod"] = true;
			this.faceMat_L = (Material)Resources.Load("Honoka_v0112/Materials/f01_face_00_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load("Honoka_v0112/Materials/f01_face_00_m", typeof(Material));
			this.curCharacterName = "Honoka Futaba";
		}
		else if (_i == 3)
		{
			this.resourcesPathFull = "Assets/Aoi Character Pack Ver1.10/Resources/Aoi_v0111";
			this.resourcesPath = "Aoi_v0111/";
			this.animationPath = "Aoi_v0111/Animations Legacy/f02@";
			this.AnimationListFile = "animation_list";
			this.AnimationListFileAll = "animation_list_all";
			this.CharacterCode = "F02/";
			path = this.settingFileDir + this.CharacterCode + "fbx_ctrl";
			this.functionList["model"] = true;
			this.functionList["facial"] = false;
			this.functionList["lod"] = true;
			this.faceMat_L = (Material)Resources.Load("Aoi_v0111/Materials/f02_face_00_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load("Aoi_v0111/Materials/f02_face_00_m", typeof(Material));
			this.curCharacterName = "Aoi Kiryu";
		}
		else if (_i == 4)
		{
			this.resourcesPathFull = "Assets/Succubus Twins Character Pack Ver1.10/Resources/Arum_v0111/";
			this.resourcesPath = "Arum_v0111/";
			this.animationPath = "Arum_v0111/Animations Legacy/animation@";
			this.AnimationListFile = "animation_list_a";
			this.AnimationListFileAll = "animation_list_a";
			this.FacialTexListFile = this.settingFileDir + this.CharacterCode + "facial_texture_list_a";
			this.CharacterCode = "F03/Arum/";
			path = this.settingFileDir + this.CharacterCode + "fbx_ctrl";
			this.functionList["model"] = false;
			this.functionList["facial"] = true;
			this.functionList["lod"] = true;
			this.txt = (TextAsset)Resources.Load(this.FacialTexListFile, typeof(TextAsset));
			this.facialTexList = this.txt.text.Split(new string[]
			{
				"\r",
				"\n"
			}, StringSplitOptions.RemoveEmptyEntries);
			this.faceObjName = "succubus_a";
			this.facialMatName = "succubus_a_face";
			this.faceMat_L = (Material)Resources.Load("Arum_v0111/Materials/succubus_a_face_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load("Arum_v0111/Materials/succubus_a_face_m", typeof(Material));
			this.FacialTexListFile = this.settingFileDir + this.CharacterCode + "facial_texture_list_a";
			this.curCharacterName = "Succubus Arum";
		}
		else if (_i == 5)
		{
			this.resourcesPathFull = "Assets/Succubus Twins Character Pack Ver1.10/Resources/Asphodel_v0111/";
			this.resourcesPath = "Asphodel_v0111/";
			this.animationPath = "Asphodel_v0111/Animations Legacy/animation@";
			this.CharacterCode = "F03/Asphodel/";
			this.AnimationListFile = "animation_list_b";
			this.AnimationListFileAll = "animation_list_b";
			this.FacialTexListFile = this.settingFileDir + this.CharacterCode + "facial_texture_list_b";
			path = this.settingFileDir + this.CharacterCode + "fbx_ctrl";
			this.functionList["model"] = false;
			this.functionList["facial"] = true;
			this.functionList["lod"] = true;
			this.txt = (TextAsset)Resources.Load(this.FacialTexListFile, typeof(TextAsset));
			this.facialTexList = this.txt.text.Split(new string[]
			{
				"\r",
				"\n"
			}, StringSplitOptions.RemoveEmptyEntries);
			this.faceObjName = "succubus_b";
			this.facialMatName = "succubus_b_face";
			this.faceMat_L = (Material)Resources.Load("Asphodel_v0111/Materials/succubus_b_face_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load("Asphodel_v0111/Materials/succubus_b_face_m", typeof(Material));
			this.curCharacterName = "Succubus Asphodel";
		}
		else if (_i == 6)
		{
			this.resourcesPathFull = "Assets/Satomi Character Pack/Resources/Satomi_v0100";
			this.resourcesPath = "Satomi_v0100/";
			this.animationPath = "Satomi_v0100/Animations Legacy/f05@";
			this.AnimationListFile = "animation_list";
			this.AnimationListFileAll = "animation_list_all";
			this.CharacterCode = "F05/";
			path = this.settingFileDir + this.CharacterCode + "fbx_ctrl";
			this.faceMat_L = (Material)Resources.Load("Satomi_v0100/Materials/f05_face_00_l", typeof(Material));
			this.faceMat_M = (Material)Resources.Load("Satomi_v0100/Materials/f05_face_00_m", typeof(Material));
			this.functionList["model"] = true;
			this.functionList["facial"] = false;
			this.functionList["lod"] = true;
			this.curCharacterName = "Satomi Makise";
		}
		this.txt = (TextAsset)Resources.Load(this.settingFileDir + this.CharacterCode + this.FBXListFile, typeof(TextAsset));
		this.modelList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingFileDir + this.CharacterCode + this.AnimationListFile, typeof(TextAsset));
		this.animationList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingFileDir + this.CharacterCode + this.AnimationListFileAll, typeof(TextAsset));
		this.animationListAll = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(path, typeof(TextAsset));
		this.xDoc = new XmlDocument();
		this.xDoc.LoadXml(this.txt.text);
		this.SetInit();
	}

	public virtual void SetNextCharacter(int _add)
	{
		this.curCharacter += _add;
		if (this.curCharacter > 6)
		{
			this.curCharacter = 0;
		}
		else if (this.curCharacter < 0)
		{
			this.curCharacter = 6;
		}
		int num = this.curCharacter;
		if (num == 0)
		{
			this.CharacterCode = "M01/";
		}
		else if (num == 1)
		{
			this.CharacterCode = "Puppet/";
		}
		else if (num == 2)
		{
			this.CharacterCode = "F01/";
		}
		else if (num == 3)
		{
			this.CharacterCode = "F02/";
		}
		else if (num == 4)
		{
			this.CharacterCode = "F03/Arum/";
		}
		else if (num == 5)
		{
			this.CharacterCode = "F03/Asphodel/";
		}
		else if (num == 6)
		{
			this.CharacterCode = "F05/";
		}
		this.txt = (TextAsset)Resources.Load(this.settingFileDir + this.CharacterCode + this.FBXListFile, typeof(TextAsset));
		this.modelList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		GameObject x = (GameObject)Resources.Load(this.modelList[0] + "_h", typeof(GameObject));
		if (x == null)
		{
			this.SetNextCharacter(_add);
		}
		this.SetSettings(this.curCharacter);
	}

	public virtual void setAnimationList_old()
	{
		object[] array = Resources.LoadAll("Animations Legacy", typeof(AnimationClip));
		int i = 0;
		object[] array2 = array;
		int length = array2.Length;
		while (i < length)
		{
			object obj2;
			object obj = obj2 = array2[i];
			if (!(obj is AnimationClip))
			{
				obj2 = RuntimeServices.Coerce(obj, typeof(AnimationClip));
			}
			AnimationClip animationClip = (AnimationClip)obj2;
			i++;
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

	public virtual void SetInitFacial()
	{
		this.curFacial = 0;
		this.curFacialName = "Default";
		GameObject gameObject = GameObject.Find(this.curModelName + "_face");
		Mesh sharedMesh = ((SkinnedMeshRenderer)gameObject.GetComponent(typeof(SkinnedMeshRenderer))).sharedMesh;
		this.facialCount = sharedMesh.blendShapeCount + 1;
		gameObject.name += this.segmentCode;
	}

	public virtual void SetFacialBlendShape(int _i)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)GameObject.Find(this.curModelName + "_face" + this.segmentCode).GetComponent(typeof(SkinnedMeshRenderer));
		Mesh sharedMesh = ((SkinnedMeshRenderer)GameObject.Find(this.curModelName + "_face" + this.segmentCode).GetComponent(typeof(SkinnedMeshRenderer))).sharedMesh;
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

	public virtual void SetFacialTex(int _i)
	{
		string path = this.resourcesPath + "Textures/" + this.facialTexList[_i] + this.lodList[(int)this.curLOD];
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
				if (sharedMaterials[i].name == this.faceMat_M.name)
				{
					this.faceSM.renderer.materials[num] = this.faceMat_M;
				}
				else if (sharedMaterials[i].name == this.faceMat_L.name)
				{
					this.faceSM.renderer.materials[num] = this.faceMat_L;
				}
				num++;
				i++;
			}
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
		if (RuntimeServices.ToBool(this.functionList["facial"]))
		{
			if (this.curLOD == (float)0)
			{
				GameObject gameObject = GameObject.Find(this.curModelName + "_face");
				if (gameObject)
				{
					gameObject.name += this.segmentCode;
				}
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
			this.curModelName = Path.GetFileNameWithoutExtension(_name);
			GameObject original = (GameObject)Resources.Load(_name, typeof(GameObject));
			Vector3 position;
			float y;
			if (this.obj)
			{
				position = this.obj.transform.position;
				y = this.obj.transform.eulerAngles.y;
			}
			UnityEngine.Object.Destroy(this.obj);
			this.obj = (((GameObject)UnityEngine.Object.Instantiate(original)) as GameObject);
			this.obj.transform.position = position;
			float y2 = y;
			Vector3 eulerAngles = this.obj.transform.eulerAngles;
			float num = eulerAngles.y = y2;
			Vector3 vector = this.obj.transform.eulerAngles = eulerAngles;
			this.SM = (((SkinnedMeshRenderer)this.obj.GetComponentInChildren(typeof(SkinnedMeshRenderer))) as SkinnedMeshRenderer);
			this.SM.quality = SkinQuality.Bone4;
			this.SM.updateWhenOffscreen = false;
			if (this.curCharacter != 1)
			{
				int num2 = 0;
				int i = 0;
				Material[] sharedMaterials = this.SM.renderer.sharedMaterials;
				int length = sharedMaterials.Length;
				while (i < length)
				{
					if (sharedMaterials[i].name == this.faceMat_M.name)
					{
						this.SM.renderer.materials[num2] = this.faceMat_M;
					}
					else if (sharedMaterials[i].name == this.faceMat_L.name)
					{
						this.SM.renderer.materials[num2] = this.faceMat_L;
					}
					num2++;
					i++;
				}
			}
			int j = 0;
			string[] array = this.animationListAll;
			int length2 = array.Length;
			while (j < length2)
			{
				GameObject gameObject = (GameObject)Resources.Load(this.animationPath + array[j]);
				AnimationClip clip = gameObject.animation.clip;
				this.obj.animation.AddClip(clip, array[j]);
				j++;
			}
			this.viewCam.ModelTarget(this.GetBone(this.obj, this.boneName));
			if (RuntimeServices.ToBool(this.functionList["facial"]))
			{
				this.facialMaterialSet();
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

	public virtual void SetNextMotion(int _add)
	{
		this.curAnim += _add;
		this.playOnceFlg = true;
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

	public virtual void playAnimation()
	{
		this.obj.animation.wrapMode = WrapMode.Once;
		if (this.playOnceFlg)
		{
			this.obj.animation.Play(this.curAnimName);
		}
		if (this.animReplay && this.playOnceFlg)
		{
			this.playOnceFlg = true;
		}
		else
		{
			this.playOnceFlg = false;
		}
	}

	public virtual void SetAnimation(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			this.curAnimName = string.Empty + _name;
			this.timerReset();
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
			this.curBgName = Path.GetFileNameWithoutExtension(_name);
			Texture2D mainTexture = (Texture2D)Resources.Load(_name, typeof(Texture2D));
			GameObject gameObject = GameObject.Find("BillBoard") as GameObject;
			gameObject.renderer.material.mainTexture = mainTexture;
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
					_obj.animation.Play(this.curAnimName);
				}
				Vector3 vector = default(Vector3);
				Vector3 vector2 = default(Vector3);
				xpath = "Root/Position[@Ani=''or@Ani='" + _anim + "']";
				xmlNode2 = _xDoc.SelectSingleNode(xpath);
				if (xmlNode2 != null)
				{
					vector.x = float.Parse(xmlNode2.Attributes["PosX"].InnerText);
					vector.y = float.Parse(xmlNode2.Attributes["PosY"].InnerText);
					vector.z = float.Parse(xmlNode2.Attributes["PosZ"].InnerText);
					vector2.x = float.Parse(xmlNode2.Attributes["RotX"].InnerText);
					vector2.y = float.Parse(xmlNode2.Attributes["RotY"].InnerText);
					vector2.z = float.Parse(xmlNode2.Attributes["RotZ"].InnerText);
					float y = vector.y;
					Vector3 position = this.obj.transform.position;
					float num = position.y = y;
					Vector3 vector3 = this.obj.transform.position = position;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
