using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMove : MonoBehaviour {

    public float XMin = -100;
    public float XMax = 100;
    public float Speed = 100;
    private int Dir = 1;
    // Use this for initialization
    void Start () {
        //transform.localPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Dir * Speed * Time.deltaTime, 0, 0));
        if(transform.localPosition.x > XMax)
        {
            Dir = -1;
        }
        if (transform.localPosition.x < XMin)
        {
            Dir = 1;
        }
		
	}
}
