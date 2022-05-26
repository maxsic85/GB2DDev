public class Car : IUpgradableCar
{
    private readonly int _defaulHealth;
    private readonly float _defaultSpeed;
    private readonly int _defaultPower;
    private readonly int _defaultBandetry;


    public Car(float speed,int health,int power,int bandetry)
    {
        _defaultSpeed = speed;
        _defaulHealth = health;
        _defaultPower = power;
        _defaultBandetry = bandetry;

        Restore();
    }

    #region IUpgradableCar
    public int Health { get; set; }
    public float Speed { get; set; }
    public int Power { get; set; }
    public int Bandetry { get; set; }

    public void Restore()
    {
        Health = _defaulHealth;
        Speed = _defaultSpeed;
        Power = _defaultPower;
        Bandetry = _defaultBandetry;

    }
    #endregion
}
