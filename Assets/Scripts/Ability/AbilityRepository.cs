using System.Collections.Generic;

public class AbilityRepository
{
    IReadOnlyDictionary<int, IAbility> AbilityMapByItemId { get; }
}