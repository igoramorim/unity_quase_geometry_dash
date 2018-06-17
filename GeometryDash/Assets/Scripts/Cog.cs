using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour {

    public float speedRotation;     //Velocidade de rotacao da engrenagem

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Rotaciona o GameObject na velocidade da variavel speedRotation em Z
        //(0, 0, speedRotation) significa os eixos X, Y e Z
        transform.Rotate(0, 0, speedRotation);
    }
}
