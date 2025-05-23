using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;


    [SerializeField] private KitchenObjectSo plateKitchenObjectObjectSO;
    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int plateSpawnedAmount;
    private int plateSpawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
           spawnPlateTimer = 0;
            if (plateSpawnedAmount < plateSpawnedAmountMax) 
            {
                plateSpawnedAmount++;
                OnPlateSpawned?.Invoke(this,EventArgs.Empty);
            }
        }

    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (plateSpawnedAmount > 0)
            {
                plateSpawnedAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectObjectSO, player);

                OnPlateRemoved?.Invoke(this,EventArgs.Empty);
            }
        }
    }
}
