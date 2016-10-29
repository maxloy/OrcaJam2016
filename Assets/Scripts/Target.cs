﻿using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour
{
	public float ScaleFactor = 0.1f;
	public float Size { get; private set; }

	public float MoveDistance = 5;
	public float Speed = 2;

	void Start()
	{
		Size = transform.localScale.x + Mathf.Abs(transform.position.y)* ScaleFactor;
		transform.localScale = new Vector3(Size, Size, Size);

		var seq = DOTween.Sequence();
		seq.Append(transform.DOMoveX(transform.position.x - MoveDistance, Speed).SetSpeedBased(true));
		seq.Append(transform.DORotate(new Vector3(0, 180, 0), 1));
		seq.Append(transform.DOMoveX(transform.position.x, Speed).SetSpeedBased(true));
		seq.Append(transform.DORotate(new Vector3(0, 0, 0), 1));
		seq.SetLoops(-1);
	}

}
