// See https://aka.ms/new-console-template for more information

using BuilderReport.Helper;
using dotenv.net;
using QuestPDF.Fluent;

DotEnv.Load();
var reader = new Reader();

reader.ReadOrWriteFile("headerfile", out var headerfile);
reader.ReadOrWriteFile("bodyfile", out var bodyfile);
reader.ReadOrWrite("output", out var outputfile);

DocumentOperation
    .LoadFile(headerfile)
    .MergeFile(bodyfile)
    .Save(outputfile);

if (!File.Exists(outputfile)) throw new FileNotFoundException(outputfile);

Console.WriteLine($"File {outputfile} created!");
Console.WriteLine("Push any button to continue...");
Console.ReadLine();