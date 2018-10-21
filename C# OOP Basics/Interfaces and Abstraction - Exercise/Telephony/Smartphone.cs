public class Smartphone : ICaling, IBrowsing
{
    public string Browse(string site)
    {
        if (IsValidSite(site) == false)
        {
            return "Invalid URL!";
        }
        return $"Browsing: {site}!";
    }

    public string Call(string number)
    {
        if (IsValidNumber(number) == false)
        {
            return "Invalid number!";
        }
        return $"Calling... {number}";
    }

    private bool IsValidNumber(string number)
    {
        for (int i = 0; i < number.Length; i++)
        {
            if (char.IsDigit(number[i]) == false)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsValidSite(string site)
    {
        for (int i = 0; i < site.Length; i++)
        {
            if (char.IsDigit(site[i]))
            {
                return false;
            }
        }

        return true;
    }
}