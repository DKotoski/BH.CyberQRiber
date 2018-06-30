using System;

public static class Int32Extensions
{
    public static int ConvertOrDefault(this string input)
    {
        try
        {
            var result = Convert.ToInt32(input);
            return result;
        }
        catch
        {
            return default(int);
        }
    }
}
