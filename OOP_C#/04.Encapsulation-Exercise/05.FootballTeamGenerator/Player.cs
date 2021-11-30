using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinRange = 0;

        private const int Maxrange = 100;

        private string name;

        private int endurance;

        private int sprint;

        private int dribble;

        private int passing;

        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value; 
            }
        }

        private int Endurance
        {
            get { return endurance; }
            set
            {
                if (value <= MinRange || value >= Maxrange)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between {MinRange} and {Maxrange}.");
                }
                endurance = value;
            }
        }

        private int Sprint
        {
            get { return sprint; }
            set 
            {
                if (value <= MinRange || value >= Maxrange)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between {MinRange} and {Maxrange}.");
                }
                sprint = value; 
            }
        }

        private int Dribble
        {
            get { return dribble; }
            set 
            {
                if (value <= MinRange || value >= Maxrange)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between {MinRange} and {Maxrange}.");
                }
                dribble = value; 
            }
        }

        private int Passing
        {
            get { return passing; }
            set 
            {
                if (value <= MinRange || value >= Maxrange)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between {MinRange} and {Maxrange}.");
                }
                passing = value; 
            }
        }

        private int Shooting
        {
            get { return shooting; }
            set 
            {
                if (value <= MinRange || value >= Maxrange)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between {MinRange} and {Maxrange}.");
                }
                shooting = value; 
            }
        }

        public int Stat => GetStatus();

        private int GetStatus()
        {
            double countSkills = 5.0;
            return (int)Math.Round((this.Endurance + this.Dribble + this.Sprint + this.Passing + this.Shooting) / countSkills);
        }
    }
}
