using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CubeAuthoring : MonoBehaviour
{
    private float speed = 100f;

    public class Baker : Baker<CubeAuthoring>
    {
        public override void Bake(CubeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotatingCube()
            {
            }); ;
        }
    }

}

public struct RotatingCube : IComponentData
{
}

