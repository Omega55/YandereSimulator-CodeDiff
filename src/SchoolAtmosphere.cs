using System;

public static class SchoolAtmosphere
{
	public static SchoolAtmosphereType Type
	{
		get
		{
			float num = SchoolGlobals.SchoolAtmosphere / 100f;
			if (num > 0.6666667f)
			{
				return SchoolAtmosphereType.High;
			}
			if (num > 0.333333343f)
			{
				return SchoolAtmosphereType.Medium;
			}
			return SchoolAtmosphereType.Low;
		}
	}
}
