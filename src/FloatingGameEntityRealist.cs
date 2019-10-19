using System;
using ArchimedsLab;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class FloatingGameEntityRealist : GameEntity
{
	public Mesh buoyancyMesh;

	private tri[] _triangles;

	private tri[] worldBuffer;

	private tri[] wetTris;

	private tri[] dryTris;

	private uint nbrWet;

	private uint nbrDry;

	private WaterSurface.GetWaterHeight realist = (Vector3 pos) => (OceanAdvanced.GetWaterHeight(pos + new Vector3(-0.1f, 0f, -0.1f)) + OceanAdvanced.GetWaterHeight(pos + new Vector3(0.1f, 0f, -0.1f)) + OceanAdvanced.GetWaterHeight(pos + new Vector3(0f, 0f, 0.1f))) / 3f;

	public bool Stable;

	protected override void Awake()
	{
		base.Awake();
		Mesh m = (!(this.buoyancyMesh == null)) ? this.buoyancyMesh : base.GetComponent<MeshFilter>().mesh;
		WaterCutter.CookCache(m, ref this._triangles, ref this.worldBuffer, ref this.wetTris, ref this.dryTris);
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		if (this.rb.IsSleeping())
		{
			return;
		}
		WaterCutter.CookMesh(base.transform.position, base.transform.rotation, ref this._triangles, ref this.worldBuffer);
		WaterCutter.SplitMesh(this.worldBuffer, ref this.wetTris, ref this.dryTris, out this.nbrWet, out this.nbrDry, this.realist);
		Archimeds.ComputeAllForces(this.wetTris, this.dryTris, this.nbrWet, this.nbrDry, base.speed, this.rb);
		if (this.Stable)
		{
			base.transform.localEulerAngles = new Vector3(100f, base.transform.localEulerAngles.y, 0f);
		}
	}

	private void LateUpdate()
	{
		if (this.Stable)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, 0f);
			if (base.transform.position.y > 0.5f)
			{
				base.transform.position = new Vector3(base.transform.position.x, 1f, base.transform.position.z);
			}
			else if (base.transform.position.y < -0.5f)
			{
				base.transform.position = new Vector3(base.transform.position.x, -1f, base.transform.position.z);
			}
		}
	}
}
