// See https://aka.ms/new-console-template for more information
using LanguageLibrary.Sample01;
using LanguageLibrary.Sample02;
using LanguageLibrary.Sample03;
using LanguageLibrary.Sample04;
using LanguageLibrary.Sample06;
using LanguageLibrary.Sample07;
using LanguageLibrary.Sample08;

Console.WriteLine("Hello, World!");
var translator = new Translator();
translator.Translate("{99, 3, 451}");

Console.ReadLine();

var operations = @"193
a=5
b=6 
a+b*2 
(1+2)*3";

var calc = new Calculator();
calc.Calulate(operations);
Console.ReadLine();

var javaCode = @"
import java.util.List;
  import java.util.Map;
  public class Demo {
          void f(int x, String y) { }
          int[ ] g(/*no args*/) { return null; }
          List<Map<String, Integer>>[] h() { return null; }
}";

var extractor = new InterfaceExtractor();
extractor.Extractor(javaCode);
Console.ReadLine();


var rows = @"
Terence Parr    101
Tom Burns       020
Kevin Edgar     008";
var colExtractor = new ColumnExtractor();
colExtractor.Extract(rows, 2);


var inserter = new SerialInserter();
var codeTransformed = inserter.Insert(javaCode);
Console.WriteLine(codeTransformed);

var properties = @"user=""parrt""
machine=""maniac""

";
var converterUsingListener = new PropertyFileConverterToJson();
converterUsingListener.Convert(properties); // The output happens inside

var converterUsingVisitor = new PropertyFileConvertertoJsonVisitor();
converterUsingVisitor.Convert(properties); // The output happens inside

var expr = "1+2*3";
var calcVisitor = new LanguageLibrary.Sample09._01VisitorWay.Calculator();
calcVisitor.Calculate(expr);

var calcListener = new LanguageLibrary.Sample09._02ListenerWay.Calculator();
calcListener.Calculate(expr);
