using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class YanSave
{
	public const string SAVE_EXTENSION = "yansave";

	public static string SaveDataPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "SaveFiles");
		}
	}

	public static void SaveData(string targetSave)
	{
		YanSaveIdentifier[] array = UnityEngine.Object.FindObjectsOfType<YanSaveIdentifier>();
		List<SerializedGameObject> list = new List<SerializedGameObject>();
		foreach (YanSaveIdentifier yanSaveIdentifier in array)
		{
			List<SerializedComponent> list2 = new List<SerializedComponent>();
			foreach (Component component in yanSaveIdentifier.gameObject.GetComponents(typeof(Component)))
			{
				if (!yanSaveIdentifier.DisabledComponents.Contains(component))
				{
					SerializedComponent serializedComponent = default(SerializedComponent);
					serializedComponent.TypePath = component.GetType().AssemblyQualifiedName;
					serializedComponent.PropertyReferences = new ReferenceDict();
					serializedComponent.PropertyValues = new ValueDict();
					serializedComponent.FieldReferences = new ReferenceDict();
					serializedComponent.FieldValues = new ValueDict();
					foreach (PropertyInfo propertyInfo in component.GetType().GetProperties())
					{
						if (propertyInfo.CanWrite && !propertyInfo.IsDefined(typeof(ObsoleteAttribute), true))
						{
							bool flag = false;
							foreach (DisabledYanSaveMember disabledYanSaveMember in yanSaveIdentifier.DisabledProperties)
							{
								if (disabledYanSaveMember.Component == component && disabledYanSaveMember.Name == propertyInfo.Name)
								{
									flag = true;
								}
							}
							if (!flag)
							{
								try
								{
									if (!typeof(Component).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(GameObject))
									{
										serializedComponent.PropertyValues.Add(propertyInfo.Name, propertyInfo.GetValue(component));
									}
									else if (typeof(Component).IsAssignableFrom(propertyInfo.PropertyType))
									{
										if (propertyInfo.GetValue(component) != null)
										{
											YanSaveIdentifier component2 = ((Component)propertyInfo.GetValue(component)).gameObject.GetComponent<YanSaveIdentifier>();
											if (component2 != null)
											{
												serializedComponent.PropertyReferences.Add(propertyInfo.Name, component2.ObjectID);
											}
										}
										else
										{
											serializedComponent.PropertyReferences.Add(propertyInfo.Name, null);
										}
									}
									else if (propertyInfo.PropertyType == typeof(GameObject))
									{
										YanSaveIdentifier component3 = ((GameObject)propertyInfo.GetValue(component)).GetComponent<YanSaveIdentifier>();
										if (component3 != null)
										{
											serializedComponent.PropertyReferences.Add(propertyInfo.Name, component3.ObjectID);
										}
										else
										{
											serializedComponent.PropertyReferences.Add(propertyInfo.Name, null);
										}
									}
								}
								catch
								{
								}
							}
						}
					}
					foreach (FieldInfo fieldInfo in component.GetType().GetFields())
					{
						if (!fieldInfo.IsLiteral && !fieldInfo.IsDefined(typeof(ObsoleteAttribute), true))
						{
							bool flag2 = false;
							foreach (DisabledYanSaveMember disabledYanSaveMember2 in yanSaveIdentifier.DisabledFields)
							{
								if (disabledYanSaveMember2.Component == component && disabledYanSaveMember2.Name == fieldInfo.Name)
								{
									flag2 = true;
								}
							}
							if (!flag2)
							{
								try
								{
									if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType) && fieldInfo.FieldType != typeof(GameObject))
									{
										serializedComponent.FieldValues.Add(fieldInfo.Name, fieldInfo.GetValue(component));
									}
									else if (typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
									{
										if (fieldInfo.GetValue(component) != null)
										{
											YanSaveIdentifier component4 = ((Component)fieldInfo.GetValue(component)).gameObject.GetComponent<YanSaveIdentifier>();
											if (component4 != null)
											{
												serializedComponent.FieldReferences.Add(fieldInfo.Name, component4.ObjectID);
											}
										}
										else
										{
											serializedComponent.FieldReferences.Add(fieldInfo.Name, null);
										}
									}
									else if (fieldInfo.FieldType == typeof(GameObject))
									{
										YanSaveIdentifier component5 = ((GameObject)fieldInfo.GetValue(component)).GetComponent<YanSaveIdentifier>();
										if (component5 != null)
										{
											serializedComponent.FieldReferences.Add(fieldInfo.Name, component5.ObjectID);
										}
										else
										{
											serializedComponent.FieldReferences.Add(fieldInfo.Name, null);
										}
									}
								}
								catch
								{
								}
							}
						}
					}
					serializedComponent.OwnerID = yanSaveIdentifier.ObjectID;
					list2.Add(serializedComponent);
				}
			}
			SerializedGameObject item = new SerializedGameObject
			{
				ActiveInHierarchy = yanSaveIdentifier.gameObject.activeInHierarchy,
				ActiveSelf = yanSaveIdentifier.gameObject.activeSelf,
				IsStatic = yanSaveIdentifier.gameObject.isStatic,
				Layer = yanSaveIdentifier.gameObject.layer,
				Tag = yanSaveIdentifier.gameObject.tag,
				Name = yanSaveIdentifier.gameObject.name,
				SerializedComponents = list2.ToArray(),
				ObjectID = yanSaveIdentifier.ObjectID
			};
			list.Add(item);
		}
		object value = new YanSaveData
		{
			LoadedLevelName = SceneManager.GetActiveScene().name,
			SerializedGameObjects = list.ToArray()
		};
		JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
		jsonSerializerSettings.ContractResolver = new YanSaveResolver();
		jsonSerializerSettings.Error = delegate(object s, Newtonsoft.Json.Serialization.ErrorEventArgs e)
		{
			e.ErrorContext.Handled = true;
		};
		string contents = JsonConvert.SerializeObject(value, jsonSerializerSettings);
		if (!Directory.Exists(YanSave.SaveDataPath))
		{
			Directory.CreateDirectory(YanSave.SaveDataPath);
		}
		File.WriteAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave"), contents);
	}

	public static void LoadData(string targetSave, bool recreateMissing = false)
	{
		if (!File.Exists(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave")))
		{
			return;
		}
		YanSaveData yanSaveData = JsonConvert.DeserializeObject<YanSaveData>(File.ReadAllText(Path.Combine(YanSave.SaveDataPath, targetSave + ".yansave")));
		if (SceneManager.GetActiveScene().name != yanSaveData.LoadedLevelName)
		{
			SceneManager.LoadScene(yanSaveData.LoadedLevelName);
		}
		foreach (SerializedGameObject serializedGameObject in yanSaveData.SerializedGameObjects)
		{
			GameObject gameObject = YanSaveIdentifier.GetObject(serializedGameObject);
			if (gameObject == null && recreateMissing)
			{
				gameObject = new GameObject
				{
					isStatic = serializedGameObject.IsStatic,
					layer = serializedGameObject.Layer,
					tag = serializedGameObject.Tag,
					name = serializedGameObject.Name
				};
				gameObject.AddComponent<YanSaveIdentifier>().ObjectID = serializedGameObject.ObjectID;
				gameObject.SetActive(serializedGameObject.ActiveSelf);
			}
			foreach (SerializedComponent serializedComponent in serializedGameObject.SerializedComponents)
			{
				if (gameObject == null)
				{
					return;
				}
				Type type = YanSave.getType(serializedComponent.TypePath);
				if (recreateMissing && gameObject.GetComponent(type) == null)
				{
					gameObject.AddComponent(type);
				}
			}
		}
		foreach (SerializedGameObject serializedGameObject2 in yanSaveData.SerializedGameObjects)
		{
			GameObject @object = YanSaveIdentifier.GetObject(serializedGameObject2);
			if (@object == null)
			{
				return;
			}
			foreach (SerializedComponent serializedComponent2 in serializedGameObject2.SerializedComponents)
			{
				Type type2 = YanSave.getType(serializedComponent2.TypePath);
				Component component = @object.GetComponent(type2);
				foreach (PropertyInfo propertyInfo in type2.GetProperties())
				{
					if (propertyInfo.CanWrite)
					{
						if (!typeof(Component).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(GameObject))
						{
							if (serializedComponent2.PropertyValues.ContainsKey(propertyInfo.Name))
							{
								object obj = serializedComponent2.PropertyValues[propertyInfo.Name];
								if (obj == null)
								{
									propertyInfo.SetValue(component, null);
								}
								else
								{
									if (obj.GetType() == typeof(JObject))
									{
										try
										{
											propertyInfo.SetValue(component, ((JObject)obj).ToObject(propertyInfo.PropertyType));
											goto IL_3B8;
										}
										catch
										{
											goto IL_3B8;
										}
									}
									if (obj.GetType() == typeof(JArray))
									{
										try
										{
											propertyInfo.SetValue(component, ((JArray)obj).ToObject(propertyInfo.PropertyType));
											goto IL_3B8;
										}
										catch
										{
											goto IL_3B8;
										}
									}
									bool isEnum = propertyInfo.PropertyType.IsEnum;
									bool flag = typeof(IConvertible).IsAssignableFrom(obj.GetType());
									propertyInfo.SetValue(component, isEnum ? Enum.ToObject(propertyInfo.PropertyType, obj) : (flag ? Convert.ChangeType(obj, propertyInfo.PropertyType) : obj));
								}
							}
						}
						else if (serializedComponent2.PropertyReferences.ContainsKey(propertyInfo.Name))
						{
							GameObject object2 = YanSaveIdentifier.GetObject(serializedComponent2.PropertyReferences[propertyInfo.Name]);
							if (!(object2 == null))
							{
								if (propertyInfo.PropertyType == typeof(Component))
								{
									propertyInfo.SetValue(component, object2.GetComponent(propertyInfo.PropertyType));
								}
								else if (propertyInfo.PropertyType == typeof(GameObject))
								{
									propertyInfo.SetValue(component, object2);
								}
							}
						}
					}
					IL_3B8:;
				}
				foreach (FieldInfo fieldInfo in type2.GetFields())
				{
					if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType) && fieldInfo.FieldType != typeof(GameObject))
					{
						if (serializedComponent2.FieldValues.ContainsKey(fieldInfo.Name))
						{
							object obj2 = serializedComponent2.FieldValues[fieldInfo.Name];
							if (obj2 == null)
							{
								fieldInfo.SetValue(component, null);
							}
							else
							{
								if (obj2.GetType() == typeof(JObject))
								{
									try
									{
										fieldInfo.SetValue(component, ((JObject)obj2).ToObject(fieldInfo.FieldType));
										goto IL_5C0;
									}
									catch
									{
										goto IL_5C0;
									}
								}
								if (obj2.GetType() == typeof(JArray))
								{
									try
									{
										fieldInfo.SetValue(component, ((JArray)obj2).ToObject(fieldInfo.FieldType));
										goto IL_5C0;
									}
									catch
									{
										goto IL_5C0;
									}
								}
								bool isEnum2 = fieldInfo.FieldType.IsEnum;
								bool flag2 = typeof(IConvertible).IsAssignableFrom(obj2.GetType());
								fieldInfo.SetValue(component, isEnum2 ? Enum.ToObject(fieldInfo.FieldType, obj2) : (flag2 ? Convert.ChangeType(obj2, fieldInfo.FieldType) : obj2));
							}
						}
					}
					else if (serializedComponent2.FieldReferences.ContainsKey(fieldInfo.Name))
					{
						GameObject object3 = YanSaveIdentifier.GetObject(serializedComponent2.FieldReferences[fieldInfo.Name]);
						if (!(object3 == null))
						{
							if (fieldInfo.FieldType == typeof(Component))
							{
								fieldInfo.SetValue(component, object3.GetComponent(fieldInfo.FieldType));
							}
							else if (fieldInfo.FieldType == typeof(GameObject))
							{
								fieldInfo.SetValue(component, object3);
							}
						}
					}
					IL_5C0:;
				}
			}
		}
	}

	private static Type getType(string typeName)
	{
		Type type = Type.GetType(typeName);
		if (type != null)
		{
			return type;
		}
		Assembly assembly = Assembly.Load(typeName.Substring(0, typeName.IndexOf('.')));
		if (assembly == null)
		{
			return null;
		}
		return assembly.GetType(typeName);
	}
}
