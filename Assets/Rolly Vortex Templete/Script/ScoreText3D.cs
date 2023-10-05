using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, -10 * Time.deltaTime));
		
	}
}
