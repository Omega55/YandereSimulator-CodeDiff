using System;
using System.Linq.Expressions;
using System.Xml.Serialization;

[XmlRoot]
[Serializable]
public class SaveFileData
{
	public int Kills;

	public float Atmosphere;

	public int Alerts;

	public int Week;

	public string Day;

	public string Rival;

	public float Reputation;

	public string Club;

	public int Friends;

	public static readonly StringAndStringArrayDictionary GlobalsMappings = new StringAndStringArrayDictionary
	{
		{
			SaveFileData.NameOf<SaveFileData, int>((SaveFileData s) => s.Kills),
			new string[]
			{
				SaveFileData.NameOf<int>(() => Globals.Kills)
			}
		},
		{
			SaveFileData.NameOf<SaveFileData, float>((SaveFileData s) => s.Atmosphere),
			new string[]
			{
				SaveFileData.NameOf<float>(() => Globals.SchoolAtmosphere)
			}
		},
		{
			SaveFileData.NameOf<SaveFileData, float>((SaveFileData s) => s.Reputation),
			new string[]
			{
				SaveFileData.NameOf<float>(() => Globals.Reputation)
			}
		}
	};

	private static string NameOf<T, U>(Expression<Func<T, U>> expr)
	{
		MemberExpression memberExpression = expr.Body as MemberExpression;
		if (memberExpression != null)
		{
			return memberExpression.Member.Name;
		}
		MethodCallExpression methodCallExpression = expr.Body as MethodCallExpression;
		if (methodCallExpression != null)
		{
			return methodCallExpression.Method.Name;
		}
		throw new InvalidCastException("Unrecognized expression.");
	}

	private static string NameOf<T, U>(Expression<Action<T, U>> expr)
	{
		MemberExpression memberExpression = expr.Body as MemberExpression;
		if (memberExpression != null)
		{
			return memberExpression.Member.Name;
		}
		MethodCallExpression methodCallExpression = expr.Body as MethodCallExpression;
		if (methodCallExpression != null)
		{
			return methodCallExpression.Method.Name;
		}
		throw new InvalidCastException("Unrecognized statement.");
	}

	private static string NameOf<T>(Expression<Func<T>> expr)
	{
		return ((MemberExpression)expr.Body).Member.Name;
	}
}
