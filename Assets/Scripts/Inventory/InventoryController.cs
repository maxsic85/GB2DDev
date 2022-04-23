using JetBrains.Annotations;
using System;
using System.Linq;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryWindowView;
    public InventoryController(
    [NotNull] IInventoryModel inventoryModel,
    [NotNull] IItemsRepository itemsRepository,
    [NotNull] IInventoryView inventoryView)
    {
        _inventoryModel
        = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository
        = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryWindowView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
        _inventoryWindowView.Init(_itemsRepository.Items.Values.ToList());
       

    }

    public void HideInventory()
    {
        _inventoryWindowView.Display();
    }

    public void ShowInventory(Action callback)
    {
        _inventoryWindowView.Display();
    }

    private void SetupView(IInventoryView inventoryView)
    {
        // здесь могут быть дополнительные настройки
        _inventoryWindowView.Selected += OnItemSelected;
        _inventoryWindowView.Deselected += OnItemDeselected;
    }
    private void CleanupView()
    {
        // здесь могут быть дополнительные зачистки
        _inventoryWindowView.Selected -= OnItemSelected;
        _inventoryWindowView.Selected -= OnItemDeselected;
    }
    private void OnItemSelected(object sender, IItem item)
    {
        _inventoryModel.EquipItem(item);
    }
    private void OnItemDeselected(object sender, IItem item)
    {
        _inventoryModel.UnequipItem(item);
    }
}