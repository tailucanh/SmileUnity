using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
public partial class SpawnCubesSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SpawnCubesConfig>();

    }
    protected override void OnUpdate()
    {
        this.Enabled = false;

        SpawnCubesConfig spawnCubesConfig =  SystemAPI.GetSingleton<SpawnCubesConfig>();
        for(int i =0; i < spawnCubesConfig.amount; i++)
        {
          Entity spawnEntity =  EntityManager.Instantiate(spawnCubesConfig.cubePrefabEntity);
            EntityManager.SetComponentData(spawnEntity, new LocalTransform { 
                Position =  new float3(UnityEngine.Random.Range(-10f, +5f), 0.6f, UnityEngine.Random.Range(-4f, +7f)),
                Rotation = quaternion.identity,
                Scale = 0.5f

            });
        }
    }
}
