using System;
using ArchimedsLab;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class FloatingGameEntityStorm : GameEntity
{
	public Mesh buoyancyMesh;

	private tri[] _triangles;

	private tri[] worldBuffer;

	private tri[] wetTris;

	private tri[] dryTris;

	private uint nbrWet;

	private uint nbrDry;

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
		WaterCutter.SplitMesh(this.worldBuffer, ref this.wetTris, ref this.dryTris, out this.nbrWet, out this.nbrDry, WaterSurface.simpleWater);
		Archimeds.ComputeAllForces(this.wetTris, this.dryTris, this.nbrWet, this.nbrDry, base.speed, this.rb);
	}
}
