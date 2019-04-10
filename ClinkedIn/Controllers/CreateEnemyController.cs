
using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateEnemyController : ControllerBase
    {
        [HttpPost("addenemy")]
        public ActionResult CreateEnemy(Enemy enemy)
        {
            var newEnemy = EnemyRepository.AddEnemy(enemy.ClinkerOneId, enemy.ClinkerTwoId);

            return Created($"api/createEnemy/{newEnemy.Id}", newEnemy);
        }
    }
}