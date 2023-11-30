namespace Utils;

public static class FileReader
{
    public static string[] ReadFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllLines(filePath);
        }

        throw new FileNotFoundException();
    }
}
