namespace MordorCruelPlan.Moods
{
    public abstract class Mood
    {
        private string mood;

        public Mood(string mood)
        {
            this.mood = mood;
        }

        public override string ToString()
        {
            return this.mood;
        }
    }
}