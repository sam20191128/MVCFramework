using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : View
{
    public float rotateSpeed = 60;
    
    public override string Name { get; }

    public override void HandleEvent(string name, object data)
    {
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}