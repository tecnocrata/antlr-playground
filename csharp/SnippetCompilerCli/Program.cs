// See https://aka.ms/new-console-template for more information
//using SnippetCompiler.Library;

using ClassLibrary1;

Console.WriteLine("Hello, World!");
var expression = @"USES ""demo.dll
USE ""Abacaledrssjk.dll""
//demo aa
USES abc.dcx.dll""
 {a: '3' }
";
//var result = SnippetParser.SingleParse(expression);

//if (result.IsValid)
//{
//    Console.WriteLine($"Result {result.Result}");
//}
//else
//{
//    Console.WriteLine($"Error : {result.ErrorMessage}");
//}


//var result = SnippetParser.Parse(expression);

//if (result.IsValid)
//{
//    Console.WriteLine($"Result {result.Result} OK");
//}
//else
//{
//    Console.WriteLine($"How many errors? {result.ErrorResult.Count}");
//    foreach (var error in result.ErrorResult)
//    {
//        Console.WriteLine($"Error : {error.ErrorMessage}");
//    }
//}

var result = SnippetParser.Parse2(expression);
Console.WriteLine($"Result {result} OK");

//if (result.IsValid)
//{
//    Console.WriteLine($"Result {result.Result} OK");
//}
//else
//{
//    Console.WriteLine($"How many errors? {result.ErrorResult.Count}");
//    foreach (var error in result.ErrorResult)
//    {
//        Console.WriteLine($"Error : {error.ErrorMessage}");
//    }
//}