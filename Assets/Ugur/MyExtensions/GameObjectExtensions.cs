using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExtension
{
	public static class GameObjectExtensions
	{

		public static void EnableObjs(this GameObject[] array, bool doEnable)
		{
			int len = array.Length;
			for (int i = 0; i < len; i++)
				array[i].SetActive(doEnable);
		}

		public static void DestroyAllChild(this Transform transform)
		{
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Object.DestroyImmediate(transform.GetChild(0).gameObject);
			}

		}
	}
}