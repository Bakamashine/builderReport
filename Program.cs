// See https://aka.ms/new-console-template for more information
using dotenv.net;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using BuilderReport.Helper;

DotEnv.Load();
Reader reader = new Reader();

reader.ReadOrWriteFile("headerfile", out string headerfile);
reader.ReadOrWriteFile("bodyfile", out string bodyfile);
reader.ReadOrWrite("output", out string outputfile);

DocumentOperation
    .LoadFile(headerfile)
    .MergeFile(bodyfile)
    .Save(outputfile);

if (!File.Exists(outputfile))
{
    throw new FileNotFoundException(outputfile);
}

Console.WriteLine($"File {outputfile} created!");
Console.WriteLine("Push any button to continue...");
Console.ReadLine();