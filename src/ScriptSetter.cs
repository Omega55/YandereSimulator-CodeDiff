using System;
using System.Reflection;
using UnityEngine;

public class ScriptSetter : MonoBehaviour
{
	public StudentScript OldStudent;

	public StudentScript NewStudent;

	private void Start()
	{
		foreach (Component component in base.GetComponents(typeof(Component)))
		{
			Debug.Log(string.Concat(new object[]
			{
				"name ",
				component.name,
				" type ",
				component.GetType(),
				" basetype ",
				component.GetType().BaseType
			}));
			foreach (FieldInfo fieldInfo in component.GetType().GetFields())
			{
				object obj = component;
				Debug.Log(fieldInfo.Name + " value is: " + fieldInfo.GetValue(obj));
			}
		}
	}
}
