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

            CurrenMoney = new SubscriptionProperty<int>();
            CurrenMoney.Value = this.PlayerMoney.Money;
            CurrenHealth = new SubscriptionProperty<int>();
            CurrenHealth.Value = this.PlayerHealth.Health;
            CurrenPower = new SubscriptionProperty<int>();
            CurrenPower.Value = this.PlayerForce.Power;
            CurrenBandetry = new SubscriptionProperty<int>();
            CurrenBandetry.Value = this.PlayerBandetry.Bandentry;

        }
        public SubscriptionProperty<GameState> CurrentState { get; }
        public SubscriptionProperty<int> CurrenMoney { get; }
        public SubscriptionProperty<int> CurrenHealth { get; }
        public SubscriptionProperty<int> CurrenPower { get; }
        public SubscriptionProperty<int> CurrenBandetry { get; }

        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }

        public Money PlayerMoney;
        public Health PlayerHealth;
        public Force PlayerForce;
        public Banditry PlayerBandetry;
    }
}