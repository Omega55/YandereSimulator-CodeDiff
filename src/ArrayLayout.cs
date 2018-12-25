using System;

[Serializable]
public class ArrayLayout
{
	[Serializable]
	public struct rowData
	{
		public bool[] row;
	}

	public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];
}
