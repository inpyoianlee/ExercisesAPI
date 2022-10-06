using FitnessExerciseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessExerciseAPI.Data
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
    }
}
