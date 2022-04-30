string startFolder = @"C:\Users\AYGUN\Downloads\Compressed\test";
string[] packages=Directory.GetDirectories(startFolder);
List<string> libs=new List<string>();
foreach (string package in packages)
{
    libs.AddRange(Directory.GetDirectories(package));
}
libs = libs.Where(str => str.EndsWith("lib")).ToList();
List<string> dllPaths=new List<string>(libs.Count);
foreach (string lib in libs)
{
    try
    {
        string standartPath = Path.Combine(lib, "netstandard2.0");
        dllPaths.AddRange(Directory.GetFiles(standartPath));
    }
    catch (Exception e)
    {

        Console.WriteLine(e.Message);
    }
    
}

dllPaths = dllPaths.Where(dll => dll.EndsWith("dll")).ToList();
foreach (string dllPath in dllPaths)
{
    File.Copy(dllPath, Path.Combine(dllPath, startFolder, Path.GetFileName(dllPath)));
}

Console.WriteLine("Bitti");
Console.ReadLine();
