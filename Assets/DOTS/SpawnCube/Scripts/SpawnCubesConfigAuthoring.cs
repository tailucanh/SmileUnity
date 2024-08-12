using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

public class SpawnCubesConfigAuthoring : MonoBehaviour
{
    public GameObject cubePrefab;
    public int amount;

    public class Baker : Baker<SpawnCubesConfigAuthoring>
    {
        public override void Bake(SpawnCubesConfigAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new SpawnCubesConfig {
                cubePrefabEntity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic),
                amount = authoring.amount
            });
        }
    }
}


public struct SpawnCubesConfig : IComponentData
{
    public Entity cubePrefabEntity;
    public int amount;
}