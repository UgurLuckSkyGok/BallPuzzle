using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : SceneObject
{
	[SerializeField] private Renderer render;
	[SerializeField] private Door door;

	/// <summary>
	/// Kendi ile aynı olan kapı çiftini bulur
	/// </summary>
	private void Start()
	{
		var doors = FindObjectsOfType<Door>();
		foreach (var item in doors)
		{
			if (item.GetColor() == objectColor)
				door = item;
		}
	}

	public override SceneData GetSceneData()
	{
		SceneData sceneData = new SceneData();
		sceneData.pos = transform.position;
		sceneData.rot = transform.rotation;
		sceneData.scale = transform.localScale;
		sceneData.objectType = objectType;
		sceneData.objectColor = objectColor;

		return sceneData;
	}

	public override void SetSceneData(SceneData data)
	{
		base.SetSceneData(data);
		objectColor = data.objectColor;
		UpdateKey();
	}

	private void UpdateKey()
	{
		Material material = new Material(Shader.Find("Standard"));
		material.color = GetObjectColor(objectColor);
		render.material = material;
	}

	/// <summary>
	/// Karakter ile rengi eşleşirse kapıyı açar ve açılan kapı sayınısı 1 arttırır
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("Player"))
		{
			if (PlayerController.instance.GetColor() == objectColor)
			{
				GetComponent<Collider>().enabled = false;
				door.OpenDoor();
				transform.DOScale(0, 0.2f);
				GameManager.instance.IncrementStageCount();
			}
		}
	}

	/// <summary>
	/// Objenin bilgilerini değiştirir (Editor Only)
	/// </summary>
	private void OnValidate()
	{
		if (!gameObject.activeInHierarchy)
			return;
		gameObject.name = "Key - " + objectColor;
		UpdateKey();
	}
}
