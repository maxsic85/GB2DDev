using Profile.Analytic;
using System;
using Tools;
namespace Profile
{

    public class ProfilePlayer
    {
        public ProfilePlayer(float speedCar, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();

            CurrentCar = new Car(speedCar);
            AnalyticTools = analyticTools;
            PlayerMoney = new Money(nameof(Money));
            PlayerHealth = new Health(nameof(Health));
            PlayerForce = new Force(nameof(Force));
            PlayerBandetry = new Banditry(nameof(Banditry));

            CurrenMoney = new SubscriptionProperty<Money>();
            CurrenMoney.Value = this.PlayerMoney;
            CurrenHealth = new SubscriptionProperty<Health>();
            CurrenHealth.Value = this.PlayerHealth;
            CurrenPower = new SubscriptionProperty<Force>();
            CurrenPower.Value = this.PlayerForce;
            CurrenBandetry = new SubscriptionProperty<Banditry>();
            CurrenBandetry.Value = this.PlayerBandetry;

        }
        public SubscriptionProperty<GameState> CurrentState { get; }
        public SubscriptionProperty<Money> CurrenMoney { get; }
        public SubscriptionProperty<Health> CurrenHealth { get; }
        public SubscriptionProperty<Force> CurrenPower { get; }
        public SubscriptionProperty<Banditry> CurrenBandetry { get; }

        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }

        public Money PlayerMoney;
        public Health PlayerHealth;
        public Force PlayerForce;
        public Banditry PlayerBandetry;
    }
}