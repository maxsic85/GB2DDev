﻿using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class ShedController : BaseController, IShedController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Inventory" };
    private readonly Car _car;
    private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
    private readonly ItemsRepository _upgradeItemsRepository;
    private readonly InventoryModel _inventoryModel;
    private readonly InventoryController _inventoryController;
    private readonly IInventoryView _inventoryView;
    #region Life cycle
    public ShedController([NotNull] List<UpgradeItemConfig> upgradeItemConfigs,[NotNull] Car car,
                          [NotNull] Transform placeForUi)
    {
        _inventoryView = LoadView(placeForUi);
        if (upgradeItemConfigs == null) throw new
        ArgumentNullException(nameof(upgradeItemConfigs));
        _car = car ?? throw new ArgumentNullException(nameof(car));
        _upgradeHandlersRepository
        = new UpgradeHandlersRepository(upgradeItemConfigs);
        AddController(_upgradeHandlersRepository);
        _upgradeItemsRepository
        = new ItemsRepository(upgradeItemConfigs.Select(value =>
        value.itemConfig).ToList());
        AddController(_upgradeItemsRepository);
        _inventoryModel = new InventoryModel();
        _inventoryController
        = new InventoryController(_inventoryModel, _upgradeItemsRepository, _inventoryView);
        AddController(_inventoryController);
        EnterToShed();
    }
    public void EnterToShed()
    {
        _inventoryController.ShowInventory(ExitFromShed);
    }
    public void ExitFromShed()
    {
        Debug.Log($"Exit: car has speed : {_car.Speed}");
        var equipItems = _upgradeItemsRepository.Items.Values.ToList();
        UpgradeCarWithEquippedItems(_car, equipItems, _upgradeHandlersRepository.UpgradeItems);
        Debug.Log($"Exit: car has speed : {_car.Speed}");
        _inventoryController.HideInventory();
    }
    private void UpgradeCarWithEquippedItems(
                                            IUpgradableCar upgradableCar,
                                            IReadOnlyList<IItem> equippedItems,
                                            IReadOnlyDictionary<int,
                                            IUpgradeCarHandler> upgradeHandlers)
    {
        foreach (var equippedItem in equippedItems)
        {
            if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
            {
                handler.Upgrade(upgradableCar);
            }
        }
    }
    public IInventoryView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<InventoryView>();
    }

    protected override void OnChildDispose()
    {
        base.OnChildDispose();
    }
    #endregion
}