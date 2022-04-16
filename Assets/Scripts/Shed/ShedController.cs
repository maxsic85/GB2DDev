using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class ShedController : BaseController,IShedController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Inventory" };
    private readonly Car _car;
    private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
    private readonly ItemsRepository _upgradeItemsRepository;
    private readonly InventoryModel _inventoryModel;
    private readonly InventoryController _inventoryController;
    private readonly IInventoryView _inventoryView;
    #region Life cycle
    public ShedController(
    [NotNull] List<UpgradeItemConfig> upgradeItemConfigs,
    [NotNull] Car car,
    [NotNull]Transform placeForUi)
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
        = new InventoryController(_inventoryModel, _upgradeItemsRepository,_inventoryView);
        AddController(_inventoryController);
        Enter();
      //  _inventoryView.Display(_upgradeItemsRepository.Items.Values.ToList());
    }

    public void Enter()
    {
        _inventoryController.ShowInventory(Exit);
    }

    public void Exit()
    {
        _inventoryController.HideInventory();
      

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