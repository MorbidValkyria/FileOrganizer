/**
** Organizes files in a directory

*/


if (args.Length == 0)
{
    Console.WriteLine("Usage: FileOrganizer <path-to-folder>");
    return;
}

var targetPath = args[0];

if (args.Contains("--help"))
{
    Console.WriteLine("FileOrganizer Help:");
    Console.WriteLine("Usage: FileOrganizer <path-to-folder> [--dry-run] [--recursive]");
    Console.WriteLine("--dry-run    Simulate file moves without applying changes");
    Console.WriteLine("--recursive  Scan subdirectories as well");
    Console.WriteLine("--help       Display help message");
    Console.WriteLine("--verbose    Show more details.");
    return;
}

bool dryRun = args.Contains("--dry-run");
bool recursive = args.Contains("--recursive");
bool verbose = args.Contains("--verbose");

SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;


// var files = Directory.GetFiles(targetPath);

if (!Directory.Exists(targetPath))
{
    Console.WriteLine($"Error: The directory '{targetPath}' does not exist.");
    return;
}

var files = Directory.GetFiles(targetPath, "*", searchOption);


foreach (var file in files)
{
    var extension = Path.GetExtension(file).TrimStart('.').ToUpper();
    if (string.IsNullOrEmpty(extension))
    {
        extension = "NOEXT";
    }
    var newDir = Path.Combine(targetPath, extension);
    Directory.CreateDirectory(newDir);
    var newPath = Path.Combine(newDir, Path.GetFileName(file));
    if (dryRun)
    {
        Console.WriteLine($"[Dry Run] Would move {file} -> {newPath}");
    }

    else
    {
        if (verbose)
        Console.WriteLine($"Moving {file} -> {newPath}");
        File.Move(file, newPath);

    }
}

Console.WriteLine("Files organized!");