using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewscript : MonoBehaviour
{
	public Transform target;

	public string mode;

	public float x;

	public float y;

	public float distance;

	public float xSpeed;

	public float ySpeed;

	public float movSpeed;

	public float yMinLimit;

	public float yMaxLimit;

	public float zoomSpeed;

	public float zoomWheelBias;

	public float zoomMin;

	public float zoomMax;

	public Transform curTarget;

	private float xBk;

	private float yBk;

	private float movX;

	private float movY;

	private float wheel;

	private float distanceBk;

	private Vector3 cameraBk;

	private bool isMouseLocked;

	private bool isFixTarget;

	private Transform localTarget;

	public succubus_twins_character_pack_viewscript()
	{
		this.mode = "rote";
		this.x = 180f;
		this.y = 30f;
		this.distance = (float)1;
		this.xSpeed = 500f;
		this.ySpeed = 250f;
		this.movSpeed = 250f;
		this.yMinLimit = (float)-90;
		this.yMaxLimit = (float)90;
		this.zoomSpeed = 0.5f;
		this.zoomWheelBias = (float)5;
		this.zoomMin = 0.1f;
		this.zoomMax = (float)5;
		this.isFixTarget = true;
	}

	public virtual void Start()
	{
		this.xBk = this.x;
		this.yBk = this.y;
		this.distanceBk = this.distance;
		GameObject.Find("Directional light").GetComponent<Light>().intensity = 0.5f;
	}

	public virtual void LateUpdate()
	{
		this.movX = Input.GetAxis("Mouse X");
		this.movY = Input.GetAxis("Mouse Y");
		this.wheel = Input.GetAxis("Mouse ScrollWheel");
		if (!this.isMouseLocked && Input.GetMouseButton(0))
		{
			string a = this.mode;
			if (a == "move")
			{
				this.TargetMove(this.movX, this.movY);
			}
			else if (a == "rote")
			{
				this.CameraRote(this.movX, this.movY);
			}
			else if (a == "zoom")
			{
				this.CameraZoom(this.movX, this.movY);
			}
		}
		if (Input.GetMouseButton(2))
		{
			this.TargetMove(this.movX, this.movY);
		}
		if (Input.GetMouseButton(1))
		{
			this.CameraZoom(this.movX, this.movY);
		}
		this.CameraZoom(this.wheel * this.zoomWheelBias, 0);
		if (this.isFixTarget && this.curTarget)
		{
			this.localTarget = this.curTarget;
		}
		else
		{
			this.localTarget = this.target;
		}
		Quaternion rotation = Quaternion.Euler(this.y, this.x, (float)0);
		Vector3 position = rotation * new Vector3((float)0, (float)0, -this.distance) + this.localTarget.position;
		this.transform.position = position;
		if (this.isFixTarget && this.curTarget)
		{
			this.localTarget = this.curTarget;
		}
		else
		{
			this.localTarget = this.target;
		}
		this.transform.LookAt(this.localTarget.position, Vector3.up);
	}

	public virtual void CameraRote(object _x, object _y)
	{
		this.x = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", this.x, RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", _x, this.xSpeed), 0.01f)));
		this.y = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Subtraction", this.y, RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", _y, this.ySpeed), 0.01f)));
		this.y = succubus_twins_character_pack_viewscript.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
	}

	public virtual void CameraZoom(object _x, object _y)
	{
		this.distance = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", this.distance, RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeUnaryOperator("op_UnaryNegation", _y), 10), this.zoomSpeed), 0.02f)));
		this.distance = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", this.distance, RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeUnaryOperator("op_UnaryNegation", _x), 10), this.zoomSpeed), 0.02f)));
		if (this.distance < this.zoomMin)
		{
			this.distance = this.zoomMin;
		}
		if (this.distance > this.zoomMax)
		{
			this.distance = this.zoomMax;
		}
	}

	public virtual void TargetMove(object _x, object _y)
	{
		if (!this.isFixTarget)
		{
			object value = RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeUnaryOperator("op_UnaryNegation", _x), this.movSpeed), 0.055f), Time.deltaTime);
			object value2 = RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeUnaryOperator("op_UnaryNegation", _y), this.movSpeed), 0.055f), Time.deltaTime);
			Vector3 vector = new Vector3(RuntimeServices.UnboxSingle(value), RuntimeServices.UnboxSingle(value2));
			vector = this.GetComponent<Camera>().cameraToWorldMatrix.MultiplyVector(vector);
			this.target.Translate(vector);
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < (float)-360)
		{
			angle += (float)360;
		}
		if (angle > (float)360)
		{
			angle -= (float)360;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public virtual void ModeMove()
	{
		this.mode = "move";
		MonoBehaviour.print("move");
	}

	public virtual void ModeRote()
	{
		this.mode = "rote";
		MonoBehaviour.print("rote");
	}

	public virtual void ModeZoom()
	{
		this.mode = "zoom";
		MonoBehaviour.print("zoom");
	}

	public virtual void Reset()
	{
		this.distance = this.distanceBk;
		this.x = this.xBk;
		this.y = this.yBk;
		this.isFixTarget = true;
	}

	public virtual void FixTarget(bool _flag)
	{
		this.isFixTarget = _flag;
		if (this.curTarget)
		{
			this.target.position = this.curTarget.position;
		}
	}

	public virtual void ModelTarget(Transform _transform)
	{
		this.curTarget = _transform;
	}

	public virtual void MouseLock(bool _flag)
	{
		if (_flag || !Input.GetMouseButton(0))
		{
			this.isMouseLocked = _flag;
		}
	}

	public virtual void Main()
	{
	}
}
