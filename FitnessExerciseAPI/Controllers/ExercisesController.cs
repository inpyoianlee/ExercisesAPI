using FitnessExerciseAPI.Data;
using FitnessExerciseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessExerciseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ExerciseContext _dbContext;

        public ExercisesController(ExerciseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.Exercises.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            if (_dbContext.Exercises == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Exercises.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/exercises
        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
        {
            _dbContext.Exercises.Add(exercise);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExercise), new {id = exercise.Id}, exercise);
        }
        // PUT: api/exercises/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutExercise(int id, Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(exercise).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ExerciseExists(long id)
        {
            return (_dbContext.Exercises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        // DELETE: api/exercises/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercise>> DeleteExercise(int id)
        {
            if (_dbContext.Exercises == null)
            {
                return NotFound();
            }

            var exercise = await _dbContext.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            _dbContext.Exercises.Remove(exercise);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}