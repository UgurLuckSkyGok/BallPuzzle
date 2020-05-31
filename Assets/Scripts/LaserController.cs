using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : SceneObject
{
	/// <summary>
	/// Laser tipi
	/// </summary>
	public enum LaserType
	{
		constant,
		turning
	}

	/// <summary>
	/// Dönme yönü(Kullanılmadı!)
	/// </summary>
	public enum TurnWay
	{
		clockwise,
		reverse
	}

	[SerializeField] private GameObject laser;
	[SerializeField] private LaserType laserType;
	[SerializeField] private TurnWay turnWay;
	[SerializeField] private float turnSpeed;
	[SerializeField] private float duration;

	/// <summary>
	/// Laser tipine göre çalışmasını sağlar
	/// </summary>
	void Start()
	{

		if (laserType == LaserType.constant)
		{
			StartCoroutine(ConstantLaserIE());
		}
		else
		{
			StartCoroutine(ConstantLaserIE());
			StartCoroutine(TurningLaserIE());
		}
	}

	IEnumerator ConstantLaserIE()
	{
		while (true)
		{
			yield return new WaitForSeconds(duration);
			laser.SetActive(false);
			yield return new WaitForSeconds(duration);
			laser.SetActive(true);
		}
	}

	IEnumerator TurningLaserIE()
	{
		while (true)
		{
			if (turnWay == TurnWay.clockwise)
			{
				transform.Rotate(0, turnSpeed * 1, 0);
			}
			else
			{
				transform.Rotate(0, -1 * turnSpeed, 0);
			}

			yield return new WaitForFixedUpdate();
		}
	}
}
