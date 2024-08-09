using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Transforms;

public class PlayerShootManager : MonoBehaviour
{
    [SerializeField] private GameObject shootPopupPrefab;


    private void Start()
    {
        PlayerShootingSystem playerShootingSystem =  World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PlayerShootingSystem>();
        playerShootingSystem.OnShoot += PlayerShootingSystem_OnShoot;
    }

   private void PlayerShootingSystem_OnShoot(object sender, System.EventArgs e)
    {
        Entity playerEntity = (Entity)sender;
        LocalTransform localTransform = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(playerEntity);
        Instantiate(shootPopupPrefab, localTransform.Position, Quaternion.identity);
    }
}
