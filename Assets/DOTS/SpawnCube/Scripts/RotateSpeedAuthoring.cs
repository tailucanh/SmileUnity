using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


public class RotateSpeedAuthoring : MonoBehaviour
{
    public float valueSpeed;

    private class Baker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new RotateSpeed
            {
                valueSpeed = authoring.valueSpeed
            });
        }
    }
}


public struct RotateSpeed : IComponentData
{
    public float valueSpeed;
}
