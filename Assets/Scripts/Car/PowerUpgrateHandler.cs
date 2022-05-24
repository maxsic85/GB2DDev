public class PowerUpgrateHandler : IUpgradeCarHandler
{
    #region Fields
    private readonly float _power;
    #endregion
    #region Life cycle
    public PowerUpgrateHandler(float power)
    {
        _power = power;
    }
    #endregion
    #region IUpgradeHandler
    public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
    {
        upgradableCar.Power = _power;
        return upgradableCar;
    }
    #endregion
}
