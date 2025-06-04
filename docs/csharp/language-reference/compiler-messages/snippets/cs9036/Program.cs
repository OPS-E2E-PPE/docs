using System;

namespace CS9036Example;

#if COMPILE_ERROR_EXAMPLE
// <CS9036>
class C
{
    public string? Prop { get; set; }
}

class Program
{
    public required C C { get; set; }
    
    static void Example()
    {
        // CS9036: Required member 'Program.C' must be assigned a value, 
        // it cannot use a nested member or collection initializer.
        var program = new Program()
        {
            C = { Prop = "a" }
        };
    }
}
// </CS9036>
#endif

// <CS9036Fix>
class CFix
{
    public string? Prop { get; set; }
}

class ProgramFix
{
    public required CFix C { get; set; }
    
    static void Main()
    {
        // Correct: Directly assign a value to the required member
        var program = new ProgramFix()
        {
            C = new CFix { Prop = "a" }
        };
        
        Console.WriteLine($"Program created with C.Prop = {program.C.Prop}");
    }
}
// </CS9036Fix>