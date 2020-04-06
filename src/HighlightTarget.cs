﻿using System;
using UnityEngine;

[Serializable]
public struct HighlightTarget
{
	public Color TargetColor;

	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	[Range(0f, 1f)]
	public float Threshold;
}
