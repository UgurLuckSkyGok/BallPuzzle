using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType { Barrier, Fountain, Door, Key, Player, Finish, Absorber, LaserT, LaserC };
public enum ObjectColor { White = 0, Red = 8, Green = 6, Blue = 12, Yellow = 2, Cyan = 3, Magenta = 4, Black = 24 };
/*  
 Renkleri birleştirmek için CMY (https://en.wikipedia.org/wiki/Subtractive_color) yöntemini kullandım.
  Y(Yellow) 2
  C(Cyan) 3
  M(Magenta) 4

  Bu sayıların birleşimi olan rengin değerini ise ana renk olarak kabul ettiim enum değerlerini kullanarak yaptım
	 
	Green (C*Y) 6 
	Red (M*Y) 8
	Blue (M*C) 12

	 */
public class SceneObject : MonoBehaviour
{
	[SerializeField] protected ObjectType objectType;
	[SerializeField] protected ObjectColor objectColor;

	/// <summary>
	/// Return Scene Data
	/// </summary>
	/// <returns></returns>
	public virtual SceneData GetSceneData()
	{
		SceneData sceneData = new SceneData();
		sceneData.pos = transform.position;
		sceneData.rot = transform.rotation;
		sceneData.scale = transform.localScale;
		sceneData.objectType = objectType;

		return sceneData;
	}

	/// <summary>
	/// Set Scene Data
	/// </summary>
	/// <param name="data"></param>
	public virtual void SetSceneData(SceneData data)
	{
		transform.position = data.pos;
		transform.rotation = data.rot;
		transform.localScale = data.scale;
		objectType = data.objectType;
	}

	/// <summary>
	/// Convert Enum to Color
	/// </summary>
	/// <param name="objectColor"></param>
	/// <returns></returns>
	protected Color GetObjectColor(ObjectColor objectColor)
	{
		switch (objectColor)
		{
			case ObjectColor.Red:
				return Color.red;

			case ObjectColor.Green:
				return Color.green;

			case ObjectColor.Blue:
				return Color.blue;

			case ObjectColor.Yellow:
				return Color.yellow;
			case ObjectColor.White:
				return Color.white;
			case ObjectColor.Cyan:
				return Color.cyan;
			case ObjectColor.Magenta:
				return Color.magenta;
			case ObjectColor.Black:
				return Color.black;
			default:
				return Color.white;
		}
	}

	/// <summary>
	/// Return Object Color
	/// </summary>
	/// <returns></returns>
	public ObjectColor GetColor() { return objectColor; }
}

/// <summary>
/// Scene Data for .JSON
/// </summary>
[Serializable]
public class SceneData
{
	public Vector3 pos;
	public Quaternion rot;
	public Vector3 scale;

	public ObjectType objectType;
	public ObjectColor objectColor;
}
