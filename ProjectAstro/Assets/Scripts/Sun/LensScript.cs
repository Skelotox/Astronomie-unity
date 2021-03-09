using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensScript : MonoBehaviour
{

    public LensFlare lensFlare;
	public float strength;
    // Start is called before the first frame update
    void Start()
    {
        strength = 3500f;
        lensFlare = GetComponent<LensFlare>();
		Vector3 heading = gameObject.transform.position - Camera.main.transform.position;
		float dist = heading.magnitude;
        lensFlare.brightness = strength / dist;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 heading = gameObject.transform.position - Camera.main.transform.position;
		float dist = heading.magnitude;
        lensFlare.brightness = Mathf.Clamp(strength / dist, 1, Mathf.Infinity);
    }
}
