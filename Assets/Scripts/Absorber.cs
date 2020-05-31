using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Absorber : SceneObject
{
	/// <summary>
	/// Animation Absorver
	/// </summary>
	void Start()
	{
		transform.localScale = Vector3.zero;
		Sequence mySequence = DOTween.Sequence().Append(transform.DOScale(1.5f, 0.7f)).SetLoops(-1, LoopType.Yoyo).PrependInterval(.7f);
	}


}
