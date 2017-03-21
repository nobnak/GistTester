using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gist;

public class TestSampleOnSphere : MonoBehaviour {
	public GameObject fab;
	public int count = 100;
    public float sphereRadius = 1f;
    public float lonWidth = 90f;

	List<GameObject> pins;

	void Awake() {
		pins = new List<GameObject>();
	}

	void Start () {
		for (var i = 0; i < count; i++) {
			var p = Instantiate (fab);
			var tr = p.transform;
			float lat, lon;
            RandomOnSphere.RandomPolar (out lat, out lon, -0.5f * lonWidth, 0.5f * lonWidth);
			tr.SetParent (transform, false);
            var qr = Quaternion.Euler (lat, lon, 0f);
            tr.localPosition = sphereRadius * (qr * Vector3.forward);
            tr.localRotation = qr;
			pins.Add (p);
		}
	}
}
