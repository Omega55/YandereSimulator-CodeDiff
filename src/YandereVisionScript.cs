using System;
using UnityEngine;

[Serializable]
public class YandereVisionScript : MonoBehaviour
{
	public WallVisionOutlineEffect StudentWallVisionOutlineEffect;

	public WallVisionOutlineEffect CorpseWallVisionOutlineEffect;

	public WallVisionOutlineEffect SenpaiWallVisionOutlineEffect;

	public WallVisionOutlineEffect TargetWallVisionOutlineEffect;

	public AntialiasingAsPostEffect AntialiasingAsPostEffect;

	public ColorCorrectionCurves ColorCorrectionCurves;

	public DepthOfFieldScatter DepthOfFieldScatter;

	public AmbientObscurance AmbientObscurance;

	public CameraMotionBlur CameraMotionBlur;

	public SSAOEffect SSAOEffect;

	public Vignetting Vignetting;

	public Bloom Bloom;

	public virtual void Start()
	{
		this.Deactivate();
	}

	public virtual void Activate()
	{
		this.StudentWallVisionOutlineEffect.enabled = true;
		this.CorpseWallVisionOutlineEffect.enabled = true;
		this.SenpaiWallVisionOutlineEffect.enabled = true;
		this.TargetWallVisionOutlineEffect.enabled = true;
		this.AntialiasingAsPostEffect.enabled = true;
		this.ColorCorrectionCurves.enabled = true;
		this.AmbientObscurance.enabled = true;
		this.CameraMotionBlur.enabled = true;
		this.SSAOEffect.enabled = true;
		this.Vignetting.enabled = true;
		this.Bloom.enabled = true;
	}

	public virtual void Deactivate()
	{
		this.StudentWallVisionOutlineEffect.enabled = false;
		this.CorpseWallVisionOutlineEffect.enabled = false;
		this.SenpaiWallVisionOutlineEffect.enabled = false;
		this.TargetWallVisionOutlineEffect.enabled = false;
		this.AntialiasingAsPostEffect.enabled = false;
		this.ColorCorrectionCurves.enabled = false;
		this.AmbientObscurance.enabled = false;
		this.CameraMotionBlur.enabled = false;
		this.SSAOEffect.enabled = false;
		this.Vignetting.enabled = false;
		this.Bloom.enabled = false;
	}

	public virtual void Main()
	{
	}
}
