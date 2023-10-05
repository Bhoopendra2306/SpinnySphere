using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeMove : MonoBehaviour {

    public MeshFilter mf;
	// Use this for initialization
	void Start () {
        Vector3[] vertexs = mf.mesh.vertices;
        float max = vertexs.Max(v => v.y);
        float min = vertexs.Min(v => v.y);
        Debug.Log(min + "  " + max);
    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
