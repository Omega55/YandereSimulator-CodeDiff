using System;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManagerScript : MonoBehaviour
{
	[Tooltip("All defined areas should go in here. If your area is not in here, it will not count as an actual area.")]
	[SerializeField]
	private List<AreaScript> _definedAreas;

	public Transform Cube;

	public Vector3 GetCrowdedLocation()
	{
		AreaScript crowdedArea = this.GetCrowdedArea();
		Vector3 position = crowdedArea.transform.position;
		Vector3 vector = new Vector3(0f, 0f, 0f);
		float num = 0f;
		foreach (StudentScript studentScript in crowdedArea.Students)
		{
			vector += new Vector3(studentScript.transform.position.x, 0f, studentScript.transform.position.z);
			num += 1f;
		}
		vector /= num;
		int num2;
		if (position.y >= 0f && position.y < 4f)
		{
			num2 = 0;
		}
		else if (position.y >= 4f && position.y < 8f)
		{
			num2 = 4;
		}
		else if (position.y >= 8f && position.y < 12f)
		{
			num2 = 8;
		}
		else
		{
			num2 = 12;
		}
		return new Vector3(vector.x, (float)num2, vector.z);
	}

	public AreaScript GetCrowdedArea()
	{
		AreaScript result = null;
		float num = 0f;
		foreach (AreaScript areaScript in this._definedAreas)
		{
			int population = areaScript.Population;
			if ((float)population > num)
			{
				num = (float)population;
				result = areaScript;
			}
		}
		return result;
	}
}
