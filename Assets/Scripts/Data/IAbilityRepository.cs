using System.Collections.Generic;

public interface IAbilityRepository
{
    public IReadOnlyDictionary<int, IAbility> AbilitiesMap { get; }
}