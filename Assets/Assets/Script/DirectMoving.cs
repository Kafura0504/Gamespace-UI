using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the attached object along the Y-axis with the defined speed
/// </summary>
public class DirectMoving : MonoBehaviour {

    [Tooltip("Moving speed on Y axis in local space")]
    public float speed;
    //private void Start()
    //{
    //    transform.rotation = Player.instance.transform.rotation; //rotating the object to the same rotation as 'Player' object
    //}
    //moving the object with the defined speed
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self); 
    }
}
