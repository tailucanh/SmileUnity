using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class StunnedAuthoring : MonoBehaviour
{
    public class Baker : Baker<StunnedAuthoring>
    {
        public override void Bake(StunnedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Stunned());
            SetComponentEnabled<Stunned>(entity, false);
        }
    }
}


public struct Stunned : IComponentData, IEnableableComponent
{

}