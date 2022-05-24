public class Car : IUpgradableCar
{
    private readonly float _defaultSpeed;
    private readonly float _defaultPower;
    private readonly float _defaultBandetry;


    public Car(float speed)
    {
        _defaultSpeed = speed;
        Restore();
    }

    #region IUpgradableCar
    public float Speed { get; set; }
    public float Power { get; set; }
    public float Bandetry { get; set; }

    public void Restore()
    {
        Speed = _defaultSpeed;
        Power = _defaultPower;
        Bandetry = _defaultBandetry;

    }
    #endregion
}
