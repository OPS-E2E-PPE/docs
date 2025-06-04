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
//
// This would also generate CS9036 with collections:
//
// using System.Collections.Generic;
// 
// class Program2
// {
//     public required List<string> Items { get; set; }
//     
//     static void BadCollectionExample()
//     {
//         var program = new Program2()
//         {
//             // error CS9036: Required member 'Program2.Items' must be assigned a value, it cannot use a nested member or collection initializer.
//             Items = { "item1", "item2" }
//         };
//     }
// }
// </snippetBrokenCode>

// <snippetFixedCode>
using System.Collections.Generic;

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

class FixedProgram2
{
    public required List<string> Items { get; set; }
    
    static void GoodCollectionExample()
    {
        var program = new FixedProgram2()
        {
            // Assign a complete collection instance
            Items = new List<string> { "item1", "item2" }
        };
    }
    
    static void AlternativeCollectionExample()
    {
        var items = new List<string> { "item1", "item2" };
        var program = new FixedProgram2()
        {
            Items = items
        };
    }
}
// </snippetFixedCode>