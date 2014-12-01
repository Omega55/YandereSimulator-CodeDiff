using System;
using UnityEngine;

[Serializable]
public class GridScript : MonoBehaviour
{
	public GameObject Tile;

	public int Row;

	public int Column;

	public int Rows;

	public int Columns;

	public int ID;

	public GridScript()
	{
		this.Rows = 25;
		this.Columns = 25;
	}

	public virtual void Start()
	{
		while (this.ID < this.Rows * this.Columns)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.Tile, new Vector3((float)this.Row, (float)0, (float)this.Column), Quaternion.identity);
			gameObject.transform.parent = this.transform;
			this.Row++;
			if (this.Row > this.Rows)
			{
				this.Row = 1;
				this.Column++;
			}
			this.ID++;
		}
		this.transform.localScale = new Vector3((float)4, (float)4, (float)4);
		this.transform.position = new Vector3((float)-52, (float)0, (float)-52);
	}

	public virtual void Main()
	{
	}
}
