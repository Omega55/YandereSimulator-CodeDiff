using System;
using UnityEngine;

public class OceanAdvanced : MonoBehaviour
{
	private class Wave
	{
		public Wave(float waveLength, float speed, float amplitude, float sharpness, Vector2 direction)
		{
			this.waveLength = waveLength;
			this.speed = speed;
			this.amplitude = amplitude;
			this.sharpness = sharpness;
			this.direction = direction.normalized;
			this.frequency = 6.28318548f / waveLength;
			this.phase = this.frequency * speed;
		}

		public float waveLength { get; private set; }

		public float speed { get; private set; }

		public float amplitude { get; private set; }

		public float sharpness { get; private set; }

		public float frequency { get; private set; }

		public float phase { get; private set; }

		public Vector2 direction { get; private set; }
	}

	public Material ocean;

	public Light sun;

	private int interaction_id;

	private Vector4[] interactions = new Vector4[64];

	private const int NB_WAVE = 5;

	private const int NB_INTERACTIONS = 64;

	private static OceanAdvanced.Wave[] waves = new OceanAdvanced.Wave[]
	{
		new OceanAdvanced.Wave(99f, 1f, 1.4f, 0.9f, new Vector2(1f, 0.2f)),
		new OceanAdvanced.Wave(60f, 1.2f, 0.8f, 0.5f, new Vector2(1f, 3f)),
		new OceanAdvanced.Wave(20f, 3.5f, 0.4f, 0.8f, new Vector2(2f, 4f)),
		new OceanAdvanced.Wave(30f, 2f, 0.4f, 0.4f, new Vector2(-1f, 0f)),
		new OceanAdvanced.Wave(10f, 3f, 0.05f, 0.9f, new Vector2(-1f, 1.2f))
	};

	private void Awake()
	{
		Vector4[] array = new Vector4[5];
		Vector4[] array2 = new Vector4[5];
		for (int i = 0; i < 5; i++)
		{
			array[i] = new Vector4(OceanAdvanced.waves[i].frequency, OceanAdvanced.waves[i].amplitude, OceanAdvanced.waves[i].phase, OceanAdvanced.waves[i].sharpness);
			array2[i] = new Vector4(OceanAdvanced.waves[i].direction.x, OceanAdvanced.waves[i].direction.y, 0f, 0f);
		}
		this.ocean.SetVectorArray("waves_p", array);
		this.ocean.SetVectorArray("waves_d", array2);
		for (int j = 0; j < 64; j++)
		{
			this.interactions[j].w = 500f;
		}
		this.ocean.SetVectorArray("interactions", this.interactions);
		this.ocean.SetVector("world_light_dir", -this.sun.transform.forward);
	}

	private void FixedUpdate()
	{
		this.ocean.SetVector("world_light_dir", -this.sun.transform.forward);
		this.ocean.SetVector("sun_color", new Vector4(this.sun.color.r, this.sun.color.g, this.sun.color.b, 0f));
	}

	public void RegisterInteraction(Vector3 pos, float strength)
	{
		this.interactions[this.interaction_id].x = pos.x;
		this.interactions[this.interaction_id].y = pos.z;
		this.interactions[this.interaction_id].z = strength;
		this.interactions[this.interaction_id].w = Time.time;
		this.ocean.SetVectorArray("interactions", this.interactions);
		this.interaction_id = (this.interaction_id + 1) % 64;
	}

	public static float GetWaterHeight(Vector3 p)
	{
		float num = 0f;
		for (int i = 0; i < 5; i++)
		{
			num += OceanAdvanced.waves[i].amplitude * Mathf.Sin(Vector2.Dot(OceanAdvanced.waves[i].direction, new Vector2(p.x, p.z)) * OceanAdvanced.waves[i].frequency + Time.time * OceanAdvanced.waves[i].phase);
		}
		return num - 1f;
	}
}
