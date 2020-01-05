using System;
using UnityEngine;

public class NormalBufferView : MonoBehaviour
{
	[SerializeField]
	private Camera camera;

	[SerializeField]
	private Shader normalShader;

	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}
}
