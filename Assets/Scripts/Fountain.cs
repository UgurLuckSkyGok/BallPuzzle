using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : SceneObject
{
	[SerializeField] private ParticleSystem particle;



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
		UpdateParticleColor();
	}

	private void UpdateParticleColor()
	{
		var main = particle.main;
		main.startColor = GetObjectColor(objectColor);
	}

	/// <summary>
	/// Set Player Color
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerController.instance.UpdateColor(objectColor);
		}
	}

	/// <summary>
	/// Objenin bilgilerini değiştirir (Editor Only)
	/// </summary>
	private void OnValidate()
	{
		if (!gameObject.activeInHierarchy)
			return;
		gameObject.name = "Fountain - " + objectColor;
		UpdateParticleColor();
	}
}
