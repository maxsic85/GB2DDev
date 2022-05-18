using JetBrains.Annotations;
using System;

public class AbilitiesController : BaseController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IRepository<int, IAbility> _abilityRepository;
    private readonly ItemsRepository _items;
    private readonly IAbilityCollectionView _abilityCollectionView;
    private readonly IAbilityActivator _abilityActivator;
    public AbilitiesController(
    [NotNull] IAbilityActivator abilityActivator,
    [NotNull] IInventoryModel inventoryModel,
    [NotNull] IRepository<int, IAbility> abilityRepository,
    [NotNull] IAbilityCollectionView abilityCollectionView,
    [NotNull] ItemsRepository itemsRepository)
    {
        _abilityActivator = abilityActivator ?? throw new
        ArgumentNullException(nameof(abilityActivator));
        _inventoryModel = inventoryModel ?? throw new
        ArgumentNullException(nameof(inventoryModel));
        _abilityRepository = abilityRepository ?? throw new
        ArgumentNullException(nameof(abilityRepository));
        _abilityCollectionView = abilityCollectionView ?? throw new
        ArgumentNullException(nameof(abilityCollectionView));
        _abilityCollectionView.UseRequested += OnAbilityUseRequested;
        //_abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        SetupView(_abilityCollectionView);
        ShowAbilities();
    }

    private void OnAbilityUseRequested(object sender, IItem e)
    {
        if (_abilityRepository.Content.TryGetValue(e.Id, out var ability))
            ability.Apply(_abilityActivator);
    }

    private void SetupView(IAbilityCollectionView view)
    {
        // здесь могут быть дополнительные настройки
        view.UseRequested += OnAbilityUseRequested;
    }
    private void CleanupView(IAbilityCollectionView view)
    {
        // здесь могут быть дополнительные зачистки
        view.UseRequested -= OnAbilityUseRequested;
    }
    public void ShowAbilities()
    {
        if (_items==null)
        {
            return;
        }
        foreach (var item in _items.Items.Values)
        {
            _inventoryModel.EquipItem(item);
        }


        _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        _abilityCollectionView.Show();
    }

}
