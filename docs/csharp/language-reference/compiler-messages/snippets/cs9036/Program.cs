class C
{
    public string? Prop { get; set; }
}

class Program
{
    public required C C { get; set; }
    
    static void Main()
    {
        // CS9036: Required member 'Program.C' must be assigned a value, 
        // it cannot use a nested member or collection initializer.
        var program = new Program()
        {
            C = { Prop = "a" }
        };
    }
}