using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Die Klasse konvertiert die Geschwindigkeit des Autos
 * 
 * */
public class SpeedConverter : MonoBehaviour {
    static float minAngle = -60.0f;
    static float maxAngle = -300.0f;
    static SpeedConverter thisSpeedo;

    // Use this for initialization
    void Start () {
        thisSpeedo = this;
	}
	
	public static void ShowSpeed (float speed, float min, float max)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
        thisSpeedo.transform.eulerAngles = new Vector3(0, 0, ang);
    }
}