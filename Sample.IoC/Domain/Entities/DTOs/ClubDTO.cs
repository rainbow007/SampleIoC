using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.IoC.Domain.Entities.DTOs
{
    public class ClubDTO
    {
        public string Name { get; set; }
        public int PointsEarned { get; set; }
        public int GamesPlayed { get; set; }
    }
}
