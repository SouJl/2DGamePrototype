namespace PixelGame.Game.Weapon
{
    internal class EnemyWeapon : AbstractWeapon
    {
        public override IAttackData CurrentAttack => Data.Attacks[AttackIndex];

        public EnemyWeapon(IWeaponView view) : base(view) { }
    
        public override void Attack()
        {
            if (AttackIndex + 1 > Data.Attacks.Count)
                AttackIndex = 0;

            View.CheckTouchDamage();
            AttackIndex++;
        }

        protected override void Init()
        {
            AttackIndex = 0;
            View.Init(this);
        }
    }
}
