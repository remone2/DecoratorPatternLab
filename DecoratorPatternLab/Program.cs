using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new MainCharacter();
            Enemy enemy1 = new Mob();
            Enemy enemy2 = new Mob();

            player = new AddExcalibur(player);       
            enemy2 = new AddBoss(enemy2);

            Console.WriteLine("Fight the enemy");
            Console.WriteLine(enemy1.Name());
            Console.WriteLine("swing sword? type y");
            string action = Console.ReadLine();

            int health = enemy1.Health();

            if (action == "y")
            {
                health = enemy1.Health() - player.Attack();
                Console.WriteLine($"enemy hp: {health}");
            }
            else
            {
                Console.WriteLine("ok well you lost then");
            }

            Console.WriteLine("Equip special ability? type y");
            action = Console.ReadLine();

            if (action == "y")
            {
                player = new AddFlameToWeapon(player);
                health = enemy1.Health() - player.Attack();
                Console.WriteLine($"enemy hp: {health}");
                Console.WriteLine("you win");
            }
            else
            {
                Console.WriteLine("ok well you lost then");
            }

            Console.ReadLine();
        }
    }

    public abstract class Player
    {
        protected string Name { get; set; }
        protected int _attack { get; set; }
        protected int Health { get; set; }

        public virtual int Attack()
        {
            return _attack;
        }
    }

    public class MainCharacter : Player
    {
        public MainCharacter()
        {
            Name = "steve";
            _attack = 10;
            Health = 100;
        }
    }

    public abstract class Weapon : Player
    {
        public Player Player { get; set; }

        public abstract override int Attack();
    }

    public class AddExcalibur : Weapon
    {
        public AddExcalibur(Player player)
        {
            Player = player;
        }

        public override int Attack()
        {
            return Player.Attack() + 10;
        }
    }

    public class AddFlameToWeapon : Weapon
    {
        public AddFlameToWeapon(Player player)
        {
            Player = player;
        }

        public override int Attack()
        {
            return Player.Attack() + 10;
        }
    }

    public abstract class Enemy
    {
        protected string _name { get; set; }
        protected int _attack { get; set; }
        protected int _health { get; set; }

        public virtual string Name()
        {
            return _name;
        }

        public virtual int Attack()
        {
            return _attack;
        }

        public virtual int Health()
        {
            return _health;
        }
    }

    public class Mob : Enemy
    {
        public Mob()
        {
            _name = "goblin";
            _attack = 5;
            _health = 50;
        }
    }

    public abstract class Type : Enemy
    {
        public Enemy Enemy { get; set; }

        public abstract override string Name();
        public abstract override int Attack();
        public abstract override int Health();
    }

    public class AddBoss : Type
    {
        public AddBoss(Enemy enemy)
        {
            Enemy = enemy;
        }

        public override string Name()
        {
            return Enemy.Name() + "boss";
        }

        public override int Attack()
        {
            return Enemy.Attack() + 5;
        }

        public override int Health()
        {
            return Enemy.Health() + 50;
        }
    }
}
