using System;
public class CreateFileOrFolder
{
    static void Main()
    {
        string folderName = @"C:\SlackArchives";


        Console.WriteLine("WARNING! This Application Will Create A NEW Directory: " + folderName);
        Console.WriteLine("\nIf you are sure of creating this directory , please click any key to continue!\n");
        Console.WriteLine("If you are not, close the application!");
        Console.ReadKey();
        Console.ReadKey();

        string pathString1 = System.IO.Path.Combine(folderName, "exe files");
        string pathString2 = System.IO.Path.Combine(folderName, "pdf files");
        string pathString3 = System.IO.Path.Combine(folderName, "java files");
        string pathString4 = System.IO.Path.Combine(folderName, "txt files");
        string pathString5 = System.IO.Path.Combine(folderName, "iso files");
        string pathString6 = System.IO.Path.Combine(folderName, "image files");

        System.IO.Directory.CreateDirectory(pathString1);
        System.IO.Directory.CreateDirectory(pathString2);
        System.IO.Directory.CreateDirectory(pathString3);
        System.IO.Directory.CreateDirectory(pathString4);
        System.IO.Directory.CreateDirectory(pathString5);
        System.IO.Directory.CreateDirectory(pathString6);

        Console.WriteLine("The directory has been succesfully created!");
        Console.WriteLine("Path for directory: " + folderName);


        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }

}
