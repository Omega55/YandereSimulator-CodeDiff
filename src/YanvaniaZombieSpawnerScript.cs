using System;
using UnityEngine;

[Serializable]
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	public YanvaniaZombieScript NewZombieScript;

	public GameObject Zombie;

	public YanvaniaYanmontScript Yanmont;

	public float SpawnTimer;

	public float RelativePoint;

	public float RightBoundary;

	public float LeftBoundary;

	public int SpawnSide;

	public int ID;

	public GameObject[] Zombies;

	public Vector3[] SpawnPoints;

	public virtual void Update()
	{
		if (this.Yanmont.transform.position.y > (float)0)
		{
			this.ID = 0;
			this.SpawnTimer += Time.deltaTime;
			if (this.SpawnTimer > (float)1)
			{
				while (this.ID < 4)
				{
					if (this.Zombies[this.ID] == null)
					{
						this.SpawnSide = UnityEngine.Random.Range(1, 3);
						if (this.Yanmont.transform.position.x < this.LeftBoundary + (float)5)
						{
							this.SpawnSide = 2;
						}
						if (this.Yanmont.transform.position.x > this.RightBoundary - (float)5)
						{
							this.SpawnSide = 1;
						}
						if (this.Yanmont.transform.position.x < this.LeftBoundary)
						{
							this.RelativePoint = this.LeftBoundary;
						}
						else if (this.Yanmont.transform.position.x > this.RightBoundary)
						{
							this.RelativePoint = this.RightBoundary;
						}
						else
						{
							this.RelativePoint = this.Yanmont.transform.position.x;
						}
						if (this.SpawnSide == 1)
						{
							this.SpawnPoints[0].x = this.RelativePoint - 2.5f;
							this.SpawnPoints[1].x = this.RelativePoint - 3.5f;
							this.SpawnPoints[2].x = this.RelativePoint - 4.5f;
							this.SpawnPoints[3].x = this.RelativePoint - 5.5f;
						}
						else
						{
							this.SpawnPoints[0].x = this.RelativePoint + 2.5f;
							this.SpawnPoints[1].x = this.RelativePoint + 3.5f;
							this.SpawnPoints[2].x = this.RelativePoint + 4.5f;
							this.SpawnPoints[3].x = this.RelativePoint + 5.5f;
						}
						this.Zombies[this.ID] = (GameObject)UnityEngine.Object.Instantiate(this.Zombie, this.SpawnPoints[this.ID], Quaternion.identity);
						this.NewZombieScript = (YanvaniaZombieScript)this.Zombies[this.ID].GetComponent(typeof(YanvaniaZombieScript));
						this.NewZombieScript.LeftBoundary = this.LeftBoundary;
						this.NewZombieScript.RightBoundary = this.RightBoundary;
						this.NewZombieScript.Yanmont = this.Yanmont;
						break;
					}
					this.ID++;
				}
				this.SpawnTimer = (float)0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
