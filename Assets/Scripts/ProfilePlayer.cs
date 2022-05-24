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
            PlayerBanditizm = new Banditry(nameof(Banditry));

        }
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }

        public Money PlayerMoney;
        public Health PlayerHealth;
        public Force PlayerForce;
        public Banditry PlayerBanditizm;
    }
}