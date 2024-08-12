using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

public partial struct CubesSystem : ISystem
{

    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RotateSpeed>();
    }

    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        return;
      /*  foreach(var (rotateSpeed, transform) in SystemAPI.Query<RefRO<RotateSpeed>, RefRW<LocalTransform>>().WithAll<RotatingCube>()){
            float power = 1f;
            for (int i = 0; i < 100000; i++)
            {
                power *= 2f;
                power /= 2f;
            }
            transform.ValueRW = transform.ValueRO.RotateY(math.radians(rotateSpeed.ValueRO.valueSpeed * SystemAPI.Time.DeltaTime * power));
        }*/


        var job = new CubrJub
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };
        job.ScheduleParallel();
        // On complete
    }
}

[BurstCompile]
[WithAll(typeof(RotatingCube))]
public partial struct CubrJub : IJobEntity
{
    public float deltaTime;
    public void Execute(ref RotateSpeed rotateSpeed, ref LocalTransform transform)
    {
        float power = 1f;
        for(int i = 0; i < 100000; i++)
        {
            power *= 2f;
            power /= 2f;
        }
        transform = transform.RotateY(rotateSpeed.valueSpeed * deltaTime * power);

    }
}


