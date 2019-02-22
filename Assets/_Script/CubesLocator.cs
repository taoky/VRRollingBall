using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesLocator : MonoBehaviour {

	public float distance = 12.0f;
	public float height = 1.0f;

	// Use this for initialization
	void Start () {
		int childCount = transform.childCount;
		float angleStep = Mathf.PI * 2.0f / childCount;
		for (int i = 0; i < childCount; i++) {
			Transform childTransform = transform.GetChild (i);
			float angle = i * angleStep;
			childTransform.position = new Vector3 (Mathf.Cos (angle) * distance, height, Mathf.Sin (angle) * distance);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
