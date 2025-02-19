public static class ScoreFormatter
{
    private static readonly string[] PostScripts = { " ", "K", "M", "B", "T", "Qa", "Qi", "Sx" };

    public static string Format(double value)
    {
        if (value == 0.0D)
        {
            return "0 <sprite=0>";
        }

        if (value < 1000.0D)
        {
            return value.ToString("F0") + " <sprite=0>";
        }

        int i = 0;
        
        for (; value >= 1000.0D; i++)
        {
            value /= 1000.0D;
        }

        if (value < 10)
        {
            return value.ToString("F1") + PostScripts[i] + " <sprite=0>";
        }
        else
        {
            return value.ToString("F0") + PostScripts[i] + " <sprite=0>";
        }
    }
}