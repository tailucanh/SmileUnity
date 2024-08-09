using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System;

public partial class PlayerShootingSystem : SystemBase
{

    public event EventHandler OnShoot;


    protected override void OnCreate()
    {
        RequireForUpdate<Player>();
    }


    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, true);

        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, false);

        }
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }


        SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();
        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(WorldUpdateAllocator);

        foreach (var (localTransform, entity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>().WithDisabled<Stunned>().WithEntityAccess())
        {
            Entity spawnEntity = entityCommandBuffer.Instantiate(spawnCubesConfig.cubePrefabEntity);
            entityCommandBuffer.SetComponent(spawnEntity, new LocalTransform
            {
                Position = localTransform.ValueRO.Position,
                Rotation = quaternion.identity,
                Scale = 0.5f

            });
            OnShoot?.Invoke(entity, EventArgs.Empty);
        }
        entityCommandBuffer.Playback(EntityManager);



    }
}
