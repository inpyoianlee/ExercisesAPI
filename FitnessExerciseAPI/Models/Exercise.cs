﻿namespace FitnessExerciseAPI.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BodyPart { get; set; }
        public string Difficulty { get; set; }

    }
}
