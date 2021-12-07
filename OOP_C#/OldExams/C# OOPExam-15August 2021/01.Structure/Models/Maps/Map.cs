using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string message = string.Empty;
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                message = "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable())
            {
                message = $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                message = $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();
                IRacer winner;
                double multiplierRacerOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
                double chanceOfWinningracerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * multiplierRacerOne;
                double multiplierRacerTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
                double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * multiplierRacerTwo;
                if (chanceOfWinningracerOne > chanceOfWinningRacerTwo)
                {
                    winner = racerOne;
                }
                else
                {
                    winner = racerTwo;
                }
                message = $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
            }
            return message;
        }
    }
}
