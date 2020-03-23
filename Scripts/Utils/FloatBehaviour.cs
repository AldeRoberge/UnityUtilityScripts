using System;
using UnityEngine;

namespace _01_Main.Scripts
{
    public class FloatBehavior : MonoBehaviour
    {
        private float originalY;
	    public float floatStrength = 1;

	    void Start()
	    {
	        originalY = transform.position.y;
	    }

	    void Update()
	    {
	        transform.position = new Vector3(transform.position.x,
	            originalY + ((float) Math.Sin(Time.time) * floatStrength),
	            transform.position.z);
	    }
    }
}