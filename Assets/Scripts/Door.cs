using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : SceneObject
{
	[SerializeField] private Renderer doorRenderer;
	
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
		UpdateDoor();
	}

	public void OpenDoor()
	{
		transform.DOScale(0, 0.2f);
	}

	/// <summary>
	/// Update-Set Colors
	/// </summary>
	void UpdateDoor()
	{
		Material material = new Material(Shader.Find("Standard"));
		material.color = GetObjectColor(objectColor);
		doorRenderer.material = material;
	}

	/// <summary>
	/// Objenin bilgilerini değiştirir (Editor Only)
	/// </summary>
	void OnValidate()
	{
		if (!gameObject.activeInHierarchy)
			return;
		gameObject.name = "Door - " + objectColor;
		UpdateDoor();
	}
}
