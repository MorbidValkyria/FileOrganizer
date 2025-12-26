# FileOrganizer

A simple cross-platform **C# (.NET) command-line tool** that organizes files in a directory by their file extension.

Each file is moved into a subfolder named after its extension (e.g. `PDF/`, `JPG/`, `TXT/`).  
Files without an extension are placed in a `NOEXT/` folder.

---

## Features

- Organize files by extension
- Optional **recursive** directory scanning
- **Dry-run mode** to preview changes
- **Verbose logging**
- Works on **Linux, macOS, and Windows**

---

## Usage

```bash
FileOrganizer <path-to-folder> [options]

```
---

## Examples

Organize files in a directory:

```bash
dotnet run -- ~/Downloads
```

Dry run (no files moved):

```bash
dotnet run -- ~/Downloads --dry-run

```

Include subdirectories:

```bash
dotnet run -- ~/Downloads --recursive
```

Verbose output:

```bash
dotnet run -- ~/Downloads --verbose

```

---

## Options

| Option | Description |
|------|------------|
| `--dry-run` | Simulate file moves without making changes |
| `--recursive` | Scan subdirectories as well |
| `--verbose` | Show detailed move operations |
| `--help` | Display usage information |

---

## How It Works

1. Reads all files from the target directory
2. Determines each file’s extension
3. Creates a folder named after the extension (uppercase)
4. Moves the file into that folder
5. Files with no extension are placed in `NOEXT/`


