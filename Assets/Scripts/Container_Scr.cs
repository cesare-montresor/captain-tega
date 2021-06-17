using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Container_Scr : MonoBehaviour {
    public Color[] colors;
    
    private uint prime1 = 2879;
    private uint prime2 = 4111;
    private uint prime3 = 7507;

    void Start() {
        var mesh = transform.GetChild(0);
        var rend = mesh.GetComponent<Renderer>();
        
        foreach(var mat in rend.materials) {
            var rand = new Random(prime1 * (uint)mesh.position.x + prime2 * (uint)mesh.position.y + prime3 * (uint)mesh.position.z);
            var color = colors[rand.NextInt(0, colors.Length)];
            
            mat.SetColor("_BaseColor", color);
        }
    }
}
