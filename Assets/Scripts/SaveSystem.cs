using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public static class SaveSystem
{
	private const string FILE_NAME = "blocks.xml";
	private static readonly string FILE_PATH = Path.Combine(Application.persistentDataPath, FILE_NAME);

	public static bool Save(List<BlockData> data)
	{
		try
		{
			if (data.Count == 0)
			{
				data = null;
			}

			File.WriteAllText(FILE_PATH, Serialize(data));
			Debug.Log($"File saved to {FILE_PATH}");
			return true;
		}
		catch(Exception e)
		{
			Debug.LogError(e);
			return false;
		}
	}

	public static List<BlockData> Load()
	{
		return Deserialize<List<BlockData>>(File.ReadAllText(FILE_PATH)).ToList();
	}

	#region Found In The Wild (When modding Muck 😁)
	public static string Serialize<T>(T toSerialize)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		StringWriter stringWriter = new StringWriter();
		xmlSerializer.Serialize(stringWriter, toSerialize);

		return stringWriter.ToString();
	}

	public static T Deserialize<T>(string toDeserialize)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		StringReader textReader = new StringReader(toDeserialize);

		return (T)((object)xmlSerializer.Deserialize(textReader));
	}
	#endregion
}
