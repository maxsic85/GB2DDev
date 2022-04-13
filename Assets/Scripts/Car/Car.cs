public class Car : IUpgradableCar
{
    private readonly float _defaultSpeed;

    public Car(float speed)
    {
        _defaultSpeed = speed;
        Restore();
    }

    #region IUpgradableCar
    public float Speed { get; set; }
    public void Restore()
    {
        Speed = _defaultSpeed;
    }
    #endregion
}
