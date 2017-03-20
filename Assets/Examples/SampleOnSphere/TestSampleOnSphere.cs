using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gist;

public class TestSampleOnSphere : MonoBehaviour {
	public GameObject fab;
	public int count = 100;

	List<GameObject> pins;

	void Awake() {
		pins = new List<GameObject>();
	}

	void Start () {
		for (var i = 0; i < count; i++) {
			var p = Instantiate (fab);
			var tr = p.transform;
			float lat, lon;
			RandomOnSphere.RandomPolar (out lat, out lon);
			tr.SetParent (transform, false);
			tr.localRotation = Quaternion.Euler (lat, lon / 4f, 0f);
			pins.Add (p);
		}
	}
}
