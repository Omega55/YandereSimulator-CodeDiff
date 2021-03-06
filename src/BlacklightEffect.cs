﻿using System;
using UnityEngine;

[ExecuteInEditMode]
public class BlacklightEffect : MonoBehaviour
{
	[SerializeField]
	private Color fogColorDark = new Color32(14, 11, 31, byte.MaxValue);

	[SerializeField]
	private Color fogColorLight = new Color32(87, 89, 111, byte.MaxValue);

	[SerializeField]
	[Range(0f, 1f)]
	private float fogOpacity = 1f;

	[SerializeField]
	private float fogDepth = 8f;

	[Space(5f)]
	[Header("Glow")]
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColor = new Color(0f, 0.482352942f, 0.7490196f) * 9f;

	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColorSecondary = new Color(0.7490196f, 0f, 0.6784314f) * 9f;

	[SerializeField]
	private float glowBias = 13f;

	[SerializeField]
	[Range(0f, 1f)]
	private float glowFlip;

	[SerializeField]
	private bool glow = true;

	[Space(5f)]
	[Header("Targetted highlighting")]
	[SerializeField]
	private HighlightTarget[] highlightTargets;

	[SerializeField]
	[Range(0f, 1f)]
	private float smoothDropoff;

	[Space(5f)]
	[Header("Edge")]
	[SerializeField]
	private Color edgeColor = new Color32(7, byte.MaxValue, 83, byte.MaxValue);

	[SerializeField]
	[Range(0.01f, 1f)]
	private float threshold = 0.45f;

	[SerializeField]
	[Range(0f, 1f)]
	private float edgeOpacity = 1f;

	[Space(5f)]
	[Header("Overlay")]
	[SerializeField]
	private Color overlayTop = new Color32(233, 0, byte.MaxValue, byte.MaxValue);

	[SerializeField]
	private Color overlayBottom = new Color32(0, 38, byte.MaxValue, byte.MaxValue);

	[SerializeField]
	[Range(0f, 1f)]
	private float overlayOpacity = 0.06f;

	private Color[] hTargets = new Color[100];

	private float[] hThresholds = new float[100];

	private Color[] hColors = new Color[100];

	private float[] hColorInterpolations = new float[100];

	private Camera camera;

	private Material post;

	private void Update()
	{
		if (this.camera != null)
		{
			this.camera.depthTextureMode = (DepthTextureMode.Depth | DepthTextureMode.DepthNormals);
		}
		if (this.post != null)
		{
			this.post.SetFloat("_DepthDistance", this.fogDepth);
			this.post.SetColor("_FogColorDark", this.fogColorDark);
			this.post.SetColor("_FogColorLight", this.fogColorLight);
			this.post.SetFloat("_FogOpacity", this.fogOpacity);
			this.post.SetFloat("_GlowBias", this.glowBias);
			this.post.SetColor("_GlowColor", this.glowColor);
			this.post.SetColor("_GlowColor2", this.glowColorSecondary);
			this.post.SetFloat("_GlowAmount", (float)(this.glow ? 1 : 0));
			this.post.SetColor("_EdgeColor", this.edgeColor);
			this.post.SetFloat("_EdgeThreshold", this.threshold);
			this.post.SetFloat("_EdgeStrength", this.edgeOpacity);
			this.post.SetColor("_OverlayTop", this.overlayTop);
			this.post.SetColor("_OverlayBottom", this.overlayBottom);
			this.post.SetFloat("_OverlayOpacity", this.overlayOpacity);
			this.post.SetFloat("_HighlightFlip", this.glowFlip);
			this.post.SetFloat("_HighlightTargetSmooth", this.smoothDropoff);
			if (this.highlightTargets != null)
			{
				for (int i = 0; i < this.highlightTargets.Length; i++)
				{
					this.hTargets[i] = this.highlightTargets[i].TargetColor;
					this.hThresholds[i] = this.highlightTargets[i].Threshold;
					this.hColors[i] = this.highlightTargets[i].ReplacementColor;
					this.hColorInterpolations[i] = this.highlightTargets[i].SmoothColorInterpolation;
				}
			}
			if (this.highlightTargets != null && this.highlightTargets.Length != 0)
			{
				this.post.SetInt("_HighlightTargetsLength", Mathf.Clamp(this.highlightTargets.Length, 0, 100));
			}
			this.post.SetColorArray("_HighlightTargets", this.hTargets);
			this.post.SetFloatArray("_HighlightTargetThresholds", this.hThresholds);
			this.post.SetColorArray("_HighlightColors", this.hColors);
			this.post.SetFloatArray("_SmoothColorInterpolations", this.hColorInterpolations);
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.camera == null)
		{
			this.camera = base.GetComponent<Camera>();
			return;
		}
		if (this.post == null)
		{
			this.post = new Material(Shader.Find("Abcight/BlacklightPost"));
		}
		Graphics.Blit(source, destination, this.post);
	}

	[ContextMenu("Refresh")]
	public void Refresh()
	{
		UnityEngine.Object.DestroyImmediate(this.post);
		this.post = null;
	}
}
