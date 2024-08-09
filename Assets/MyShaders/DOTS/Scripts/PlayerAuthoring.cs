using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlayerAuthoring : MonoBehaviour
{

    public class Baker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Player());
        }
    }

}

public struct Player : IComponentData
{

}