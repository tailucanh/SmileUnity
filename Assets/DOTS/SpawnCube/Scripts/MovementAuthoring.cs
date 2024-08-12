using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class MovementAuthoring : MonoBehaviour
{
    public class Baker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Movement
            {
                movermentVector = new float3(UnityEngine.Random.Range(-1f, +1f), 0, UnityEngine.Random.Range(-1f, +1f))
            });
        }
    }

}


public struct Movement : IComponentData
{
    public float3 movermentVector;
}