using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    static class EnemyRepository
    {
        static List<Enemy> _enemies = new List<Enemy>();

        public static Enemy AddEnemy(int clinkerOneId, int clinkerTwoId)
        {
            var newEnemy = new Enemy() { ClinkerOneId = clinkerOneId, ClinkerTwoId = clinkerTwoId };

            newEnemy.Id = _enemies.Count + 1;

            _enemies.Add(newEnemy);

            return newEnemy;
        }
    }
}
