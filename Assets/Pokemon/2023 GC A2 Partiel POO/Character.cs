using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Stat de base, LUC
        /// Va de 0 a 100, 0 = aucune chance de crit alors que 100 = crit a tous les coups 
        /// </summary>
        int _baseLuck;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;

            _baseLuck = 15;

            CurrentHealth = baseHealth;
        }

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType, int baseLuck)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            
            _baseLuck = baseLuck;

            CurrentHealth = baseHealth;
        }

        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                if(CurrentEquipment != null)
                {
                    return _baseHealth + CurrentEquipment.BonusHealth;
                } else {
                    return _baseHealth;
                }
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseAttack + CurrentEquipment.BonusAttack;
                }
                else
                {
                    return _baseAttack;
                }
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseDefense + CurrentEquipment.BonusDefense;
                }
                else
                {
                    return _baseDefense;
                }
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseSpeed + CurrentEquipment.BonusSpeed;
                }
                else
                {
                    return _baseSpeed;
                }
            }
        }
        /// <summary>
        /// LUC, prendre en compte base et equipement potentiel
        /// </summary>
        public int Luck
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseLuck + CurrentEquipment.BonusLuck;
                }
                else
                {
                    return _baseLuck;
                }
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive => (CurrentHealth > 0);


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            if(IsAlive)
            {
                CurrentHealth -= (s.Power - Defense);
                if(CurrentHealth < 0) { CurrentHealth = 0; }
            }
        }


        /// <summary>
        /// Version plus complète du script d'en haut, on prends en compte de l'ennemi pour
        /// modifier les valeurs de l'attaque
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s, Character p)
        {
            if (IsAlive)
            {
                // check for crit
                int crit_val = 1;
                Random random = new Random();
                int randomNumber = random.Next(0, 101);
                if (randomNumber < p.Luck)
                    crit_val = 4;

                // check for type weaknesses
                //if(s.Type)
                // Take the damage

                CurrentHealth -= (((s.Power + p.Attack )* crit_val) - Defense);
                if (CurrentHealth < 0) { CurrentHealth = 0; }
                // check for status and apply it
                //CurrentStatus;

                //throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null)
            {
                throw new ArgumentNullException("Null Equipment");
            } else
            {

                CurrentEquipment = newEquipment;
            }

        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            if (CurrentEquipment != null)
            {
                CurrentEquipment = null;
            }
            // In case i want a message to popup saying "Cant unequip if you dont have anything on!"

        }

    }
}
