// <snippetBrokenCode>
// This code would generate CS9036:
// 
// class C
// {
//     public string? Prop { get; set; }
// }
// 
// class Program
// {
//     public required C C { get; set; }
//     
//     static void BadExample()
//     {
//         var program = new Program()
//         {
//             // error CS9036: Required member 'Program.C' must be assigned a value, it cannot use a nested member or collection initializer.
//             C = { Prop = "a" }
//         };
//     }
// }
// </snippetBrokenCode>

// <snippetFixedCode>
class FixedC
{
    public string? Prop { get; set; }
}

class FixedProgram
{
    public required FixedC C { get; set; }
    
    static void GoodExample()
    {
        var program = new FixedProgram()
        {
            // Assign a complete object instance
            C = new FixedC { Prop = "a" }
        };
    }
    
    static void AlternativeExample()
    {
        var c = new FixedC { Prop = "a" };
        var program = new FixedProgram()
        {
            C = c
        };
    }
}
// </snippetFixedCode>