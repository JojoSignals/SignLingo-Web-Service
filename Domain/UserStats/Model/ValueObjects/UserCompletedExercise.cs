using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UserStats.Model.Agreggates;

namespace Domain.UserStats.Model.ValueObjects;
public class UserCompletedExercise
{
    public int UserStatId { get; set; }
    public UserStat UserStat { get; set; }

    public int ExerciseId { get; set; }
}
