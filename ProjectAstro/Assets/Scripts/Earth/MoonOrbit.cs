using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    public float a = 5;
     public float b = 3;
     public float h = 1;
     public float k = 1;
     public float theta = 45;
     public int resolution = 1000;
     private Vector3[] positions;
     public Transform TargetObject;
     protected Transform myTransform;
 
     void Start () {
         myTransform = GetComponent<Transform>();
         positions = CreateEllipse(a,b,h,k,theta,resolution);
         //positions = CreateEllipse(a,myTransform.position[0],myTransform.position[1],myTransform.position[2],theta,resolution);
         LineRenderer lr = GetComponent<LineRenderer>();
         lr.SetVertexCount (resolution+1);
         for (int i = 0; i <= resolution; i++) {
             lr.SetPosition(i, positions[i]);
         }

         
     }

     void Update(){
         positions = CreateEllipse(a,b,h,k,theta,resolution);
         //positions = CreateEllipse(a,myTransform.position[0],myTransform.position[1],myTransform.position[2],theta,resolution);
         LineRenderer lr = GetComponent<LineRenderer>();
         lr.SetVertexCount (resolution+1);
         for (int i = 0; i <= resolution; i++) {
            lr.SetPosition(i, positions[i]);
         }
         Debug.Log(transform.rotation.eulerAngles.y);
     }
     Vector3[] CreateEllipse(float a, float b, float h, float k, float theta, int resolution) {
         positions = new Vector3[resolution+1];
         Quaternion q = Quaternion.AngleAxis (theta, (Vector3.right)*10);
         Vector3 center = new Vector3(h,k,0.0f);
         for (int i = 0; i <= resolution; i++) {
             float angle = (float)i / (float)resolution * 2.0f * Mathf.PI;
             positions[i] = new Vector3(a * Mathf.Cos (angle), b * Mathf.Sin (angle), 0.0f);
             positions[i] = q * positions[i] + center;
         }
         return positions;
     }
}
