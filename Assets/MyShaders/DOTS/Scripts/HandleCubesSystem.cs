using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
public partial struct HandleCubesSystem : ISystem
{

    public void OnUpdate(ref SystemState state)
    {
        foreach(var cubeAspect in SystemAPI.Query<RotatingMovingCubeAspect>())
        {
            cubeAspect.MoveAndRotate(SystemAPI.Time.DeltaTime);
        }

    }
}