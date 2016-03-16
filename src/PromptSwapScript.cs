using System;
using UnityEngine;

[Serializable]
public class PromptSwapScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public UISprite MySprite;

	public string KeyboardName;

	public string GamepadName;

	public PromptSwapScript()
	{
		this.KeyboardName = string.Empty;
		this.GamepadName = string.Empty;
	}

	public virtual void Start()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = (InputDeviceScript)this.transform.parent.gameObject.GetComponent("InputDeviceScript");
		}
	}

	public virtual void Update()
	{
		if (this.InputDevice != null)
		{
			if (this.InputDevice.Type == 1)
			{
				this.MySprite.spriteName = this.GamepadName;
			}
			else
			{
				this.MySprite.spriteName = this.KeyboardName;
			}
		}
		else
		{
			Debug.Log("My name is " + this.gameObject.name);
		}
	}

	public virtual void Main()
	{
	}
}
