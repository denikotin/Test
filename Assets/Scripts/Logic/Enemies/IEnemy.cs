using Assets.Scripts.Infrastructure.Services.Factory.EnemyFactoryFolder;


public interface IEnemy
{
    public EnemyID EnemyID { get; set; }
    public int HealthPoint { get; set; } 
}
