using System;
using UnityEngine;

public class RPG_Camera : MonoBehaviour
{
	public struct ClipPlaneVertexes
	{
		public Vector3 UpperLeft;

		public Vector3 UpperRight;

		public Vector3 LowerLeft;

		public Vector3 LowerRight;
	}

	public static RPG_Camera instance;

	public static Camera MainCamera;

	public Transform cameraPivot;

	public float distance = 5f;

	public float distanceMax = 30f;

	public float distanceMin = 2f;

	public float mouseSpeed = 8f;

	public float mouseScroll = 15f;

	public float mouseSmoothingFactor = 0.08f;

	public float camDistanceSpeed = 0.7f;

	public float camBottomDistance = 1f;

	public float firstPersonThreshold = 0.8f;

	public float characterFadeThreshold = 1.8f;

	public Vector3 desiredPosition;

	public float desiredDistance;

	private float lastDistance;

	public float mouseX;

	public float mouseXSmooth;

	private float mouseXVel;

	public float mouseY;

	public float mouseYSmooth;

	private float mouseYVel;

	private float mouseYMin = -89.5f;

	private float mouseYMax = 89.5f;

	private float distanceVel;

	private bool camBottom;

	private bool constraint;

	private static float halfFieldOfView;

	private static float planeAspect;

	private static float halfPlaneHeight;

	private static float halfPlaneWidth;

	private void Awake()
	{
		RPG_Camera.instance = this;
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		RPG_Camera.MainCamera = base.GetComponent<Camera>();
		this.distance = Mathf.Clamp(this.distance, 0.05f, this.distanceMax);
		this.desiredDistance = this.distance;
		RPG_Camera.halfFieldOfView = RPG_Camera.MainCamera.fieldOfView / 2f * 0.0174532924f;
		RPG_Camera.planeAspect = RPG_Camera.MainCamera.aspect;
		RPG_Camera.halfPlaneHeight = RPG_Camera.MainCamera.nearClipPlane * Mathf.Tan(RPG_Camera.halfFieldOfView);
		RPG_Camera.halfPlaneWidth = RPG_Camera.halfPlaneHeight * RPG_Camera.planeAspect;
		this.UpdateRotation();
	}

	public void UpdateRotation()
	{
		this.mouseX = this.cameraPivot.transform.eulerAngles.y;
		this.mouseY = 15f;
	}

	public static void CameraSetup()
	{
		GameObject gameObject;
		if (RPG_Camera.MainCamera != null)
		{
			gameObject = RPG_Camera.MainCamera.gameObject;
		}
		else
		{
			gameObject = new GameObject("Main Camera");
			gameObject.AddComponent<Camera>();
			gameObject.tag = "MainCamera";
		}
		if (!gameObject.GetComponent("RPG_Camera"))
		{
			gameObject.AddComponent<RPG_Camera>();
		}
		RPG_Camera rpg_Camera = gameObject.GetComponent("RPG_Camera") as RPG_Camera;
		GameObject gameObject2 = GameObject.Find("cameraPivot");
		rpg_Camera.cameraPivot = gameObject2.transform;
	}

	private void LateUpdate()
	{
		if (Time.deltaTime > 0f)
		{
			if (this.cameraPivot == null)
			{
				this.cameraPivot = GameObject.Find("CameraPivot").transform;
				return;
			}
			this.GetInput();
			this.GetDesiredPosition();
			this.PositionUpdate();
			this.CharacterFade();
		}
	}

	public void GetInput()
	{
		if ((double)this.distance > 0.1)
		{
			this.camBottom = Physics.Linecast(base.transform.position, base.transform.position - Vector3.up * this.camBottomDistance);
		}
		bool flag = this.camBottom && base.transform.position.y - this.cameraPivot.transform.position.y <= 0f;
		this.mouseX += Input.GetAxis("Mouse X") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (float)OptionGlobals.Sensitivity * 10f;
		if (flag)
		{
			if (Input.GetAxis("Mouse Y") < 0f)
			{
				if (!OptionGlobals.InvertAxis)
				{
					this.mouseY -= Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (float)OptionGlobals.Sensitivity * 10f;
				}
				else
				{
					this.mouseY += Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (float)OptionGlobals.Sensitivity * 10f;
				}
			}
			else if (!OptionGlobals.InvertAxis)
			{
				this.mouseY -= Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (float)OptionGlobals.Sensitivity * 10f;
			}
			else
			{
				this.mouseY += Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (float)OptionGlobals.Sensitivity * 10f;
			}
		}
		else if (!OptionGlobals.InvertAxis)
		{
			this.mouseY -= Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (float)OptionGlobals.Sensitivity * 10f;
		}
		else
		{
			this.mouseY += Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * (float)OptionGlobals.Sensitivity * 10f;
		}
		this.mouseY = this.ClampAngle(this.mouseY, -89.5f, 89.5f);
		this.mouseXSmooth = Mathf.SmoothDamp(this.mouseXSmooth, this.mouseX, ref this.mouseXVel, this.mouseSmoothingFactor);
		this.mouseYSmooth = Mathf.SmoothDamp(this.mouseYSmooth, this.mouseY, ref this.mouseYVel, this.mouseSmoothingFactor);
		if (flag)
		{
			this.mouseYMin = this.mouseY;
		}
		else
		{
			this.mouseYMin = -89.5f;
		}
		this.mouseYSmooth = this.ClampAngle(this.mouseYSmooth, this.mouseYMin, this.mouseYMax);
		this.desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * this.mouseScroll;
		if (this.desiredDistance > this.distanceMax)
		{
			this.desiredDistance = this.distanceMax;
		}
		if (this.desiredDistance < this.distanceMin)
		{
			this.desiredDistance = this.distanceMin;
		}
	}

	public void GetDesiredPosition()
	{
		this.distance = this.desiredDistance;
		this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
		this.constraint = false;
		float num = this.CheckCameraClipPlane(this.cameraPivot.position, this.desiredPosition);
		if (num != -1f)
		{
			this.distance = num;
			this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
			this.constraint = true;
		}
		if (RPG_Camera.MainCamera == null)
		{
			RPG_Camera.MainCamera = base.GetComponent<Camera>();
		}
		this.distance -= RPG_Camera.MainCamera.nearClipPlane;
		if (this.lastDistance < this.distance || !this.constraint)
		{
			this.distance = Mathf.SmoothDamp(this.lastDistance, this.distance, ref this.distanceVel, this.camDistanceSpeed);
		}
		if ((double)this.distance < 0.05)
		{
			this.distance = 0.05f;
		}
		this.lastDistance = this.distance;
		this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
	}

	public void PositionUpdate()
	{
		base.transform.position = this.desiredPosition;
		if ((double)this.distance > 0.05)
		{
			base.transform.LookAt(this.cameraPivot);
		}
	}

	private void CharacterFade()
	{
		if (RPG_Animation.instance == null)
		{
			return;
		}
		if (this.distance < this.firstPersonThreshold)
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = false;
		}
		else if (this.distance < this.characterFadeThreshold)
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
			float num = 1f - (this.characterFadeThreshold - this.distance) / (this.characterFadeThreshold - this.firstPersonThreshold);
			if (RPG_Animation.instance.GetComponent<Renderer>().material.color.a != num)
			{
				RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, num);
			}
		}
		else
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
			if (RPG_Animation.instance.GetComponent<Renderer>().material.color.a != 1f)
			{
				RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, 1f);
			}
		}
	}

	private Vector3 GetCameraPosition(float xAxis, float yAxis, float distance)
	{
		Vector3 point = new Vector3(0f, 0f, -distance);
		Quaternion rotation = Quaternion.Euler(xAxis, yAxis, 0f);
		return this.cameraPivot.position + rotation * point;
	}

	private float CheckCameraClipPlane(Vector3 from, Vector3 to)
	{
		float num = -1f;
		RPG_Camera.ClipPlaneVertexes clipPlaneAt = RPG_Camera.GetClipPlaneAt(to);
		int layerMask = 257;
		if (RPG_Camera.MainCamera != null)
		{
			RaycastHit raycastHit;
			if (Physics.Linecast(from, to, out raycastHit, layerMask))
			{
				num = raycastHit.distance - RPG_Camera.MainCamera.nearClipPlane;
			}
			if (Physics.Linecast(from - base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.UpperLeft, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point + base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
			if (Physics.Linecast(from + base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.UpperRight, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point - base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
			if (Physics.Linecast(from - base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.LowerLeft, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point + base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
			if (Physics.Linecast(from + base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.LowerRight, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point - base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
		}
		return num;
	}

	private float ClampAngle(float angle, float min, float max)
	{
		while (angle < -360f || angle > 360f)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
		}
		return Mathf.Clamp(angle, min, max);
	}

	public static RPG_Camera.ClipPlaneVertexes GetClipPlaneAt(Vector3 pos)
	{
		RPG_Camera.ClipPlaneVertexes result = default(RPG_Camera.ClipPlaneVertexes);
		if (RPG_Camera.MainCamera == null)
		{
			return result;
		}
		Transform transform = RPG_Camera.MainCamera.transform;
		float nearClipPlane = RPG_Camera.MainCamera.nearClipPlane;
		result.UpperLeft = pos - transform.right * RPG_Camera.halfPlaneWidth;
		result.UpperLeft += transform.up * RPG_Camera.halfPlaneHeight;
		result.UpperLeft += transform.forward * nearClipPlane;
		result.UpperRight = pos + transform.right * RPG_Camera.halfPlaneWidth;
		result.UpperRight += transform.up * RPG_Camera.halfPlaneHeight;
		result.UpperRight += transform.forward * nearClipPlane;
		result.LowerLeft = pos - transform.right * RPG_Camera.halfPlaneWidth;
		result.LowerLeft -= transform.up * RPG_Camera.halfPlaneHeight;
		result.LowerLeft += transform.forward * nearClipPlane;
		result.LowerRight = pos + transform.right * RPG_Camera.halfPlaneWidth;
		result.LowerRight -= transform.up * RPG_Camera.halfPlaneHeight;
		result.LowerRight += transform.forward * nearClipPlane;
		return result;
	}

	public void RotateWithCharacter()
	{
		float num = Input.GetAxis("Horizontal") * RPG_Controller.instance.turnSpeed;
		this.mouseX += num;
	}
}
