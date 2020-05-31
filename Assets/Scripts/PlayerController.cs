using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExtension;
using DG.Tweening;

public class PlayerController : SceneObject //, Singleton<PlayerController>,
{
	public static PlayerController instance;

	[SerializeField] private float speed;
	[SerializeField] private bool canColorMix = false;
	[SerializeField] private bool isColorMix = false;
	[SerializeField] private VariableJoystick variableJoystick;

	private Rigidbody rb;
	private TrailRenderer trail;
	private Renderer render;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogError("You have more than one " + typeof(PlayerController).Name + " in the scene. You only need 1, it's a singleton!");
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		trail = GetComponent<TrailRenderer>();
		render = GetComponent<Renderer>();
	}

	private void FixedUpdate()
	{
		Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
		//rb.velocity = Vector3.zero;
		//rb.AddForce(direction * speed * Time.fixedDeltaTime,ForceMode.Impulse);
		//direction = Vector3.Lerp(Vect, direction, 0.07f);
		rb.velocity = direction * speed;
	}

	/// <summary>
	/// Fountain'den gelen renk bilgisinin işlenip uygulanmasını sağlar
	/// </summary>
	/// <param name="objectColor"></param>
	public void UpdateColor(ObjectColor objectColor)
	{
		if (objectColor == this.objectColor)
			return;

		if (!canColorMix)
		{
			this.objectColor = objectColor;
			Color color = GetObjectColor(objectColor);

			trail.startColor = color;
			trail.endColor = color.GetColorAlpha(0);

			render.material.color = color;
		}
		else
		{
			if (!isColorMix)
			{
				Color oldColor = GetObjectColor(this.objectColor);
				Color newColor = GetObjectColor(objectColor);

				newColor = ColorExtensions.MixColorCMY(oldColor, newColor); // I Use CMY Mix Color

				this.objectColor = (ObjectColor)((int)objectColor * (int)this.objectColor); // Find mixed color type 

				trail.startColor = newColor;
				trail.endColor = newColor.GetColorAlpha(0);

				render.material.color = newColor;
				isColorMix = true;
			}
			else
			{
				this.objectColor = objectColor;
				Color color = GetObjectColor(objectColor);

				trail.startColor = color;
				trail.endColor = color.GetColorAlpha(0);

				render.material.color = color;
				isColorMix = false;
			}

		}

	}

	/// <summary>
	/// 2. kapıdan sonra set edilen renk karışmasınının bağlı olduğu boolean'ı set eder
	/// </summary>
	/// <param name="canColorMix"></param>
	public void SetColorMix(bool canColorMix) { this.canColorMix = canColorMix; }

	private void OnTriggerEnter(Collider other)
	{
		//Game Win -> Next Level
		if (other.CompareTag("Finish"))
		{
			transform.DOScale(0, 1f);
			speed = 0;
			trail.enabled = false;
			GameManager.instance.GameWin();
		}

		// Lose color
		if (other.CompareTag("Absorber"))
		{
			UpdateColor(ObjectColor.Black);
		}

		// Game Over
		if (other.CompareTag("Laser"))
		{
			transform.DOScale(0, 1f);
			speed = 0;
			trail.enabled = false;
			GameManager.instance.GameOver();
		}
	}

	
}
