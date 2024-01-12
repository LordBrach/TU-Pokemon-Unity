
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
        public void critTest()
        {
            // si on ne précise pas une 6eme valeur, le taux de crit de base est de 15%
            Character wailord = new Character(200, 50, 10, 20, TYPE.NORMAL);
            Character tiplouf = new Character(100, 40, 20, 30, TYPE.NORMAL, 100);
            Fight f = new Fight(wailord, tiplouf);
            Punch p = new Punch();

            // wailord possède beaucoup de vie, mais tiplouf fait un crit qui lui permet de le KO en un tour
            f.ExecuteTurn(p, p);

            Assert.That(wailord.CurrentHealth, Is.EqualTo(0));
            Assert.That(wailord.IsAlive, Is.EqualTo(false));
            Assert.That(tiplouf.IsAlive, Is.EqualTo(true));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));
        }
    }
}
