using System.Text;

namespace ConsoleLogging_6._0;

public class ConsoleWriter : TextWriter
{
    private readonly TextWriter _orig;

    public ConsoleWriter(TextWriter orig)
    {
        _orig = orig;
    }

    public override Encoding Encoding { get { return Encoding.UTF8; } }

    private readonly StringBuilder _sb = new StringBuilder();

    public override void Write(string value)
    {
        _sb.Append(value);
        base.Write(value);
        Thread.Yield();
        _orig.Write(value);
    }

    public override void WriteLine(string value)
    {
        _sb.AppendLine(value);
        base.WriteLine(value);
        Thread.Yield();
        _orig.WriteLine(value);
    }

    public string Content => _sb.ToString();
}