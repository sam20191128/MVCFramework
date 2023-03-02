using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ReusableObject
{
    public float rotateSpeed = 60;
    public override string Name { get; }

    public override void HandleEvent(string name, object data)
    {
    }

    public override void OnSpawn()
    {
    }

    public override void OnUnSpawn()
    {
        transform.localEulerAngles = Vector3.zero;
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    public virtual void HitPlayer(Transform transform)
    {
    }
}