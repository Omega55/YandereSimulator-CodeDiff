using System;
using UnityEngine;

public class InputDeviceScript : MonoBehaviour
{
	public InputDeviceType Type = InputDeviceType.Gamepad;

	public Vector3 MousePrevious;

	public Vector3 MouseDelta;

	public float Horizontal;

	public float Vertical;

	private void Update()
	{
		this.MouseDelta = Input.mousePosition - this.MousePrevious;
		this.MousePrevious = Input.mousePosition;
		InputDeviceType type = this.Type;
		if ((Input.GetJoystickNames().Length == 0 && Input.anyKey) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || this.MouseDelta != Vector3.zero)
		{
			this.Type = InputDeviceType.MouseAndKeyboard;
		}
		else
		{
			bool flag = false;
			for (int i = 0; i < 20; i++)
			{
				if (Input.GetKey("joystick 1 button " + i))
				{
					flag = true;
					break;
				}
			}
			bool flag2 = Math.Abs(Input.GetAxis("DpadX")) > 0.5f || Math.Abs(Input.GetAxis("DpadY")) > 0.5f;
			bool flag3 = Mathf.Abs(Input.GetAxis("Vertical")) == 1f || Mathf.Abs(Input.GetAxis("Horizontal")) == 1f;
			if (flag || flag2 || flag3)
			{
				this.Type = InputDeviceType.Gamepad;
			}
		}
		if (this.Type != type)
		{
			PromptSwapScript[] array = Resources.FindObjectsOfTypeAll<PromptSwapScript>();
			foreach (PromptSwapScript promptSwapScript in array)
			{
				promptSwapScript.UpdateSpriteType(this.Type);
			}
		}
		this.Horizontal = Input.GetAxis("Horizontal");
		this.Vertical = Input.GetAxis("Vertical");
	}
}
