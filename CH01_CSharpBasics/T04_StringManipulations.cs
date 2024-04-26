namespace CH01_CSharpBasics;

public class T04_StringManipulations
{
    public void Test()
    {
        Trimming();
    }

    public void Trimming()
    {
        //it is used to remove space, new line characters, tabs, etc from endings.
        string s = " Today is a Friday ";
        var result = s.Trim();
    }
    public void LowerCase()
    {
        string s = "Today is a Friday";
        var result = s.ToLower();
        //It is mostly used in comparasion
        var resultComparasion = s.ToLower() == result.ToLower();
        resultComparasion = s.Equals(result,StringComparison.OrdinalIgnoreCase);
    }
    public void UpperCase()
    {
        string s = "Today is a Friday";
        var result = s.ToUpper();
    }
    public void Splitting()
    {
        string s = "Today is a Friday";
        var result = s.Split(' ');
    }
    public void CharacterIndexOfString()
    {
        string s = "Hello World";
        var result = s.IndexOf('o');
        result = s.LastIndexOf('o');
    }
    public void Substring()
    {
        string s = "Hello world";
        var result = s.Substring(6, 5);
        result = s.Substring(s.IndexOf("w"), 5);
    }
    public void Concatenation()
    {
        //Not recommended to use in practical scenerio
        var result = "Hello" + " " + "World";
        var password = "12" + 1234;//if any operand is string then result of + is concatenation.
    }
    public void PlaceholderMethod()
    {
        string s1 = "Hello", s2 = "World";
        Console.WriteLine("{0} {1}", s1, s2);
    }
    public void Interpolation()
    {
        //Recommended
        string s1 = "Hello", s2 = "World";
        var result = $"{s1} {s2}";
        string name = "Irfan sir";
        result = $"My name is {name}";
    }

}
