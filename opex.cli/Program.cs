using System.Diagnostics;

void GotoOpex(string url, string message)
{
    var psCommmand = $@"echo {message}
    Start-Process {url} --noexit";
    var psCommandBytes = System.Text.Encoding.Unicode.GetBytes(psCommmand);
    var psCommandBase64 = Convert.ToBase64String(psCommandBytes);

    var startInfo = new ProcessStartInfo
    {
        FileName = "powershell.exe",
        Arguments = $"-NoProfile -ExecutionPolicy unrestricted -EncodedCommand {psCommandBase64}",
        UseShellExecute = false
    };
    Process.Start(startInfo);
}

var opexCmd = args.AsQueryable().FirstOrDefault();

Start:
if (opexCmd == null)
{
    Console.WriteLine(@"
        use ""chapter"" to get the latest chapters");
    Console.WriteLine(@"
        use ""episodes"" to go to the latest episodes");
    Console.WriteLine(@"
        use ""opex"" to go to Opex");
    opexCmd = Console.ReadLine()!.Trim();
}

if (opexCmd == "chapter")
{
    const string url = "https://onepieceex.net/mangas/";
    GotoOpex(url, "Let read some One Piece:wq");
    opexCmd = null;
    goto Start;
}

if (opexCmd == "episodes")
{
    const string url = "https://onepieceex.net/episodios/online/";
    GotoOpex(url, "Let Watch some One Piece");
    opexCmd = null;
    goto Start;
}

if (opexCmd == "opex")
{
    const string url = "https://onepieceex.net";
    GotoOpex(url, "Let go to Opex");
    opexCmd = null;
    goto Start;
}