//Prikladan oblikovni obrazac je Kompozit obrazac. On spada u skupinu strukturnih obrazaca. 

using System.Collections.Generic;
using System.Security.Claims;
using System.Xml.Linq;
using System;

Komponenta:


public interface IFileSystemElement
{
    void Display();
}
List:

public class File : IFileSystemElement
{
    private string Name;

    public File(string name)
    {
        Name = name;
    }

    public void Display()
    {
        Console.WriteLine($"File: {Name}");
    }
}
Kompozit:



public class Directory : IFileSystemElement
{
    private string Name;
    private List<IFileSystemElement> Elements = new List<IFileSystemElement>();

    public Directory(string name)
    {
        Name = name;
    }

    public void AddElement(IFileSystemElement element)
    {
        Elements.Add(element);
    }

    public void RemoveElement(IFileSystemElement element)
    {
        Elements.Remove(element);
    }

    public void Display()
    {
        Console.WriteLine($"Directory: {Name}");
        foreach (var element in Elements)
        {
            element.Display();
        }
    }
}

Client:


public class FileSystemClient
{
    public static void Main()
    {
        IFileSystemElement file1 = new File("File1.txt");
        IFileSystemElement file2 = new File("File2.txt");

        IFileSystemElement directory1 = new Directory("Folder1");
        directory1.AddElement(file1);
        directory1.AddElement(file2);

        IFileSystemElement file3 = new File("File3.txt");

        IFileSystemElement root = new Directory("Root");
        root.AddElement(directory1);
        root.AddElement(file3);

        root.Display();
    }
}

//IFileSystemElement predstavlja zajedničko sučelje za sve elemente sustava datoteka. File predstavlja konkretnu datoteku,
//Directory predstavlja direktorij koji može sadržavati druge datoteke ili direktorije.
//Directory implementira IFileSystemElement