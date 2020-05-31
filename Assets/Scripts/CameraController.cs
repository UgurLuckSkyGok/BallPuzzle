using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	[SerializeField] private GameObject player;
	[SerializeField] private float speed = 2.0f;

	Vector3 dif; 

	/// <summary>
	/// Kamera ile karakter arasındaki fark vector cinsinden bulunur
	/// </summary>
	private void Start()
	{
		dif = player.transform.position - transform.position;
	}


	void Update()
	{
		FollowCharacter();
	}

	/// <summary>
	/// Karakter takibi yapar.
	/// </summary>
	void FollowCharacter()
	{
		float interpolation = speed * Time.deltaTime;

		Vector3 position = transform.position;
		position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x - dif.x, interpolation);
		position.z = Mathf.Lerp(this.transform.position.z, player.transform.position.z - dif.z, interpolation);

		transform.position = position;
	}
}
