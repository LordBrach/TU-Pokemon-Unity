
using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer les TU sur le reste et de les implémenter

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        [Test]
        public void CritTest()
        {
            // si on ne précise pas une 6eme valeur, le taux de crit de base est de 15%
            Character wailord = new Character(200, 50, 10, 20, TYPE.WATER);
            Character tiplouf = new Character(100, 40, 20, 30, TYPE.WATER, 100);
            Fight f = new Fight(wailord, tiplouf);
            Punch p = new Punch();

            // wailord possède beaucoup de vie, mais tiplouf fait un crit qui lui permet de le KO en un tour
            f.ExecuteTurn(p, p);

            Assert.That(wailord.CurrentHealth, Is.EqualTo(0));
            Assert.That(wailord.IsAlive, Is.EqualTo(false));
            Assert.That(tiplouf.IsAlive, Is.EqualTo(true));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));
        }

        [Test]
        public void ImpossibleCritTest()
        {
            Character regigigas = new Character(1000, 0, 5, 2, TYPE.NORMAL);
            Character tiplouf = new Character(100, 1, 20, 30, TYPE.WATER, 0);
            Fight f = new Fight(regigigas, tiplouf);
            Punch p = new Punch();
            RonPshhhhhh r = new RonPshhhhhh();

            for (int i = 0; i < 100; i++)
            {
                f.ExecuteTurn(p, r);
                Assert.That(regigigas.CurrentHealth, Is.AtLeast(1));
            }
        }

        [Test]
        public void SleepAndBurnTest()
        {
            Character giratina = new Character(4000, 400, 200, 300, TYPE.NORMAL, 0);
            Character balignon = new Character(100, 30, 30, 30, TYPE.GRASS, 0);
            Fight f = new Fight(balignon, giratina);
            FeuFollet feufollet = new FeuFollet();
            Spore spore = new Spore();
            f.ExecuteTurn(spore, feufollet);

            Assert.That(giratina.CurrentStatus.CanAttack, Is.EqualTo(false));
            Assert.That(balignon.CurrentStatus.DamageEachTurn, Is.EqualTo(10));
            Ultralaser ultralaser = new Ultralaser();
            // execute turns to verify that the status effects do count down
            // and also to make sure that giratina cant attack while asleep
            f.ExecuteTurn(spore, ultralaser);
            f.ExecuteTurn(spore, ultralaser);
            f.ExecuteTurn(spore, ultralaser);
            Assert.That(balignon.IsAlive, Is.EqualTo(true));
            f.ExecuteTurn(spore, ultralaser);
            // Check that burn did lower balignon's health over time (10 hp times 5 round = -50hp)
            Assert.That(balignon.CurrentHealth, Is.EqualTo(50));
            // Check that giratina woke up and can now attack
            Assert.That(giratina.CurrentStatus == null);
            f.ExecuteTurn(spore, ultralaser);

            Assert.That(balignon.IsAlive, Is.EqualTo(false));
        }

        [Test]
        public void CrazyTest()
        {
            Character tiplouf = new Character(100, 40, 20, 30, TYPE.WATER, 100);
            Character ferosinge = new Character(100, 200, 20, 20, TYPE.NORMAL, 0);

            DizzyPunch dp = new DizzyPunch();
            Punch p = new Punch();

            Fight f = new Fight(tiplouf, ferosinge);
            f.ExecuteTurn(dp, p);
            Assert.That(ferosinge.CurrentHealth, Is.EqualTo(0));

        }
    }
}
