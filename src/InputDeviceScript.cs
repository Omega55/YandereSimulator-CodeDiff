using System;
using UnityEngine;

[Serializable]
public class InputDeviceScript : MonoBehaviour
{
	public int Type;

	public Vector3 MousePrevious;

	public Vector3 MouseDelta;

	public float Horizontal;

	public float Vertical;

	public InputDeviceScript()
	{
		this.Type = 1;
	}

	public virtual void Update()
	{
		this.MouseDelta = Input.mousePosition - this.MousePrevious;
		this.MousePrevious = Input.mousePosition;
		if (Input.anyKey || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || this.MouseDelta != new Vector3((float)0, (float)0, (float)0))
		{
			this.Type = 2;
		}
		if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Joystick1Button5) || Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.Joystick1Button8) || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button10) || Input.GetKey(KeyCode.Joystick1Button11) || Input.GetKey(KeyCode.Joystick1Button12) || Input.GetKey(KeyCode.Joystick1Button13) || Input.GetKey(KeyCode.Joystick1Button14) || Input.GetKey(KeyCode.Joystick1Button15) || Input.GetKey(KeyCode.Joystick1Button16) || Input.GetKey(KeyCode.Joystick1Button17) || Input.GetKey(KeyCode.Joystick1Button18) || Input.GetKey(KeyCode.Joystick1Button19) || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("DpadY") > 0.5f || Input.GetAxis("DpadY") < -0.5f)
		{
			this.Type = 1;
		}
		if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d") && (Input.GetAxis("Vertical") == (float)1 || Input.GetAxis("Vertical") == (float)-1 || Input.GetAxis("Horizontal") == (float)1 || Input.GetAxis("Horizontal") == (float)-1))
		{
			this.Type = 1;
		}
		this.Horizontal = Input.GetAxis("Horizontal");
		this.Vertical = Input.GetAxis("Vertical");
	}

	public virtual void Main()
	{
	}
}
