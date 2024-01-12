using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Ici est rangé un set de compétences afin d'être prête à être utilisé en combat
/// Vous pouvez changer/adapter ces skills au besoin du moment que c'est pertinent dans le reste du code.
namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Coup de poing basique
    /// </summary>
    public class Punch : Skill
    {
        public Punch() : base(TYPE.NORMAL, 70, StatusPotential.NONE) { }
    }

    /// <summary>
    /// I am firing my laserrr (stp ait la ref)
    /// </summary>
    public class Ultralaser : Skill
    {
        public Ultralaser() : base(TYPE.NORMAL, 15000, StatusPotential.NONE) { }
    }

    /// <summary>
    /// Coup de poing basique ++
    /// </summary>
    public class MegaPunch : Skill
    {
        public MegaPunch() : base(TYPE.NORMAL, 7000, StatusPotential.NONE) { }
    }

    /// <summary>
    /// Boule de feu qui ajoute le statut BURN
    /// </summary>
    public class FireBall : Skill
    {
        public FireBall() : base(TYPE.FIRE, 50, StatusPotential.BURN) { }
    }
    /// <summary>
    /// Attaque eau basique
    /// </summary>
    public class WaterBlouBlou : Skill
    {
        public WaterBlouBlou() : base(TYPE.WATER, 20, StatusPotential.NONE) { }
    }
    /// <summary>
    /// Attaque plante qui inflige le statut SLEEP
    /// </summary>
    public class MagicalGrass : Skill
    {
        public MagicalGrass() : base(TYPE.GRASS, 70, StatusPotential.SLEEP) { }
    }
    /// <summary>
    /// Attaque plante qui inflige le statut SLEEP
    /// </summary>
    public class Spore : Skill
    {
        public Spore() : base(TYPE.GRASS, 0, StatusPotential.SLEEP) { }
    }
    /// <summary>
    /// Attaque feu qui inflige le statut BURN
    /// </summary>
    public class FeuFollet : Skill
    {
        public FeuFollet() : base(TYPE.FIRE, 0, StatusPotential.BURN) { }
    }
    /// <summary>
    /// Attaque normale qui inflige le statut CRAZY
    /// </summary>
    public class DizzyPunch : Skill
    {
        public DizzyPunch() : base(TYPE.NORMAL, 15, StatusPotential.CRAZY) { }
    }
    /// <summary>
    /// Fait la sieste et perds un tour
    /// </summary>
    public class RonPshhhhhh : Skill
    {
        public RonPshhhhhh() : base(TYPE.NORMAL, 0, StatusPotential.NONE) { }
    }
}
