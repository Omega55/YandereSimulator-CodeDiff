using System;
using UnityEngine;

public class CleaningManagerScript : MonoBehaviour
{
	public Transform[] Windows;

	public Transform[] Desks;

	public Transform[] Floors;

	public Transform[] Toilets;

	public Transform[] Rooftops;

	public Transform[] ClappingSpots;

	public Transform Spot;

	public int Role;

	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			for (int i = 1; i < this.ClappingSpots.Length; i++)
			{
				this.ClappingSpots[i].transform.position = new Vector3(this.ClappingSpots[i].transform.position.x, this.ClappingSpots[i].transform.position.y, this.ClappingSpots[i].transform.position.z + 1f);
			}
		}
	}

	public void GetRole(int StudentID)
	{
		switch (StudentID)
		{
		case 1:
			this.Role = 4;
			this.Spot = this.Toilets[0];
			break;
		case 2:
			this.Role = 1;
			this.Spot = this.Windows[1];
			break;
		case 3:
			this.Role = 1;
			this.Spot = this.Windows[2];
			break;
		case 4:
			this.Role = 1;
			this.Spot = this.Windows[3];
			break;
		case 5:
			this.Role = 1;
			this.Spot = this.Windows[4];
			break;
		case 6:
			this.Role = 1;
			this.Spot = this.Windows[5];
			break;
		case 7:
			this.Role = 1;
			this.Spot = this.Windows[6];
			break;
		case 8:
			this.Role = 2;
			this.Spot = this.Desks[1];
			break;
		case 9:
			this.Role = 2;
			this.Spot = this.Desks[2];
			break;
		case 10:
			this.Role = 2;
			this.Spot = this.Desks[3];
			break;
		case 11:
			this.Role = 2;
			this.Spot = this.Desks[4];
			break;
		case 12:
			this.Role = 2;
			this.Spot = this.Desks[5];
			break;
		case 13:
			this.Role = 2;
			this.Spot = this.Desks[6];
			break;
		case 14:
			this.Role = 5;
			this.Spot = this.Rooftops[1];
			break;
		case 15:
			this.Role = 5;
			this.Spot = this.Rooftops[2];
			break;
		case 16:
			this.Role = 5;
			this.Spot = this.Rooftops[5];
			break;
		case 17:
			this.Role = 5;
			this.Spot = this.Rooftops[3];
			break;
		case 18:
			this.Role = 5;
			this.Spot = this.Rooftops[4];
			break;
		case 19:
			this.Role = 5;
			this.Spot = this.Rooftops[6];
			break;
		case 20:
			this.Role = 3;
			this.Spot = this.Floors[5];
			break;
		case 21:
			this.Role = 3;
			this.Spot = this.Floors[6];
			break;
		case 22:
			this.Role = 3;
			this.Spot = this.Floors[4];
			break;
		case 23:
			this.Role = 3;
			this.Spot = this.Floors[2];
			break;
		case 24:
			this.Role = 3;
			this.Spot = this.Floors[3];
			break;
		case 25:
			this.Role = 3;
			this.Spot = this.Floors[1];
			break;
		case 26:
			this.Role = 4;
			this.Spot = this.Toilets[6];
			break;
		case 27:
			this.Role = 4;
			this.Spot = this.Toilets[5];
			break;
		case 28:
			this.Role = 4;
			this.Spot = this.Toilets[4];
			break;
		case 29:
			this.Role = 4;
			this.Spot = this.Toilets[3];
			break;
		case 30:
			this.Role = 4;
			this.Spot = this.Toilets[2];
			break;
		case 31:
			this.Role = 4;
			this.Spot = this.Toilets[1];
			break;
		case 33:
			this.Role = 4;
			this.Spot = this.Toilets[0];
			break;
		}
	}
}
