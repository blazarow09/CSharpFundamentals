namespace MordorCruelPlan.Factories
{
    using MordorCruelPlan.Moods;

    public class MoodFactory
    {
        public static Mood GetCorrespondingMood(int moodFactor)
        {
            if (moodFactor < -5)
            {
                return new Angry();
            }
            else if (moodFactor <= 0)
            {
                return new Sad();
            }
            else if (moodFactor <= 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }
    }
}