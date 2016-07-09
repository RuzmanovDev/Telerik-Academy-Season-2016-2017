using System;
using System.Collections.Generic;
using System.Linq;

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public abstract class Document : IDocument
{
    private string name;
    private string content;
    IList<KeyValuePair<string, object>> output;


    public Document(string name, string content = null)
    {
        this.Name = name;
        this.Content = content;
        //this.output = new List<KeyValuePair<string, object>>();
    }

    public virtual string Name
    {
        get
        {
            return this.name;
        }

        protected set
        {
            //if (string.IsNullOrEmpty(value))
            //{
            //    throw new ArgumentNullException("The name cannot be left empty!!");
            //}

            this.name = value;
        }
    }

    public virtual string Content
    {
        get
        {
            return this.content;
        }

        protected set
        {
            this.content = value;
        }
    }

    public virtual void LoadProperty(string key, string value)
    {
        key = key.ToLower();
        if (key == "name")
        { this.Name = value; }
        else if (key == "content")
        { this.Content = value; }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));

        if (this.Content != null)
            output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        var list = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(list);
        var props = list
            .OrderBy(keyValuePair => keyValuePair.Key)
            .Select(keyValuePair => string.Format("{0}={1}", keyValuePair.Key, keyValuePair.Value));


        return string.Format("{0}[{1}]", this.GetType().Name, string.Join(";", props));
    }
}

public abstract class BinaryDocument : Document
{
    private int size;
    public BinaryDocument(string name, string content = null, int size = 0) //TODO maybe not 0
        : base(name, content)
    {
        this.Size = size;
    }

    public int Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        key = key.ToLower();
        if (key == "size")
        {
            this.Size = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.Size != 0)
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        base.SaveAllProperties(output);
    }
}

public class TextDocument : Document, IEditable
{
    private string charset;


    public TextDocument(string name, string charset = null)
        : base(name)
    {
        this.Charset = charset;
    }

    

    public string Charset
    {
        get { return this.charset; }
        set { this.charset = value; }
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        key = key.ToLower();

        if (key == "charset")
        {
            this.Charset = value;
        }else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if(this.Charset != null)
        {
            output.Add(new KeyValuePair<string, object>("Charset", this.Charset));
        }
        base.SaveAllProperties(output);
    }
}
public abstract class EncryptableDocument : BinaryDocument, IDocument, IEncryptable
{
    public EncryptableDocument(string name, string content = null, int size = 0)
        : base(name, content, size)
    {
        this.IsEncrypted = false;
    }

    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        if (this.IsEncrypted)
        {
            return string.Format("{0}[encrypted]", this.GetType().Name);
        }
        else
        {
            return base.ToString();
        }
    }
}

public class PDFDocument : EncryptableDocument
{
    public PDFDocument(string name, string content = null, int size = 0, int numberOfPages = 0)
            : base(name, content, size)
    {
        this.NumberOfPages = numberOfPages;
    }

    public int NumberOfPages { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key.ToLower() == "pages")
        { this.NumberOfPages = int.Parse(value); }
        else
        { base.LoadProperty(key, value); }
    }

    public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
    {
        if (this.NumberOfPages != 0)
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
        base.SaveAllProperties(output);
    }

}

public abstract class OfficeDocument : EncryptableDocument, IDocument, IEncryptable
{
    public OfficeDocument(string name, string content = null, int size = 0, string version = null)
        : base(name, content, size)
    {
        this.Version = version;
    }

    public string Version { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key.ToLower() == "version")
        { this.Version = value; }
        else
        { base.LoadProperty(key, value); }
    }

    public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
    {
        if (this.Version != null)
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        base.SaveAllProperties(output);
    }
}

public class WordDocument : OfficeDocument, IDocument, IEncryptable, IEditable
{
    public WordDocument(string name = null, string content = null, int size = 0, string version = null, int numberOfCharacters = 0)
        : base(name, content, size, version)
    {
        this.NumberOfCharacters = numberOfCharacters;
    }

    public int NumberOfCharacters { get; private set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key.ToLower() == "chars")
        { this.NumberOfCharacters = int.Parse(value); }
        else
        { base.LoadProperty(key, value); }
    }

    public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
    {
        if (this.NumberOfCharacters != 0)
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));
        base.SaveAllProperties(output);
    }
}

public class ExcelDocument : OfficeDocument, IDocument, IEncryptable
{
    public ExcelDocument(string name, string content = null, int size = 0, string version = null, int numberOfColumns = 0, int numberOfRows = 0)
        : base(name, content, size, version)
    {
        this.NumberOfColumns = numberOfColumns;
        this.NumberOfRows = numberOfRows;
    }

    public int NumberOfColumns { get; private set; }

    public int NumberOfRows { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key.ToLower() == "rows")
        { this.NumberOfRows = int.Parse(value); }
        else if (key.ToLower() == "cols")
        { this.NumberOfColumns = int.Parse(value); }
        else
        { base.LoadProperty(key, value); }
    }

    public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
    {
        if (this.NumberOfColumns != 0)
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));

        if (this.NumberOfRows != 0)
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));

        base.SaveAllProperties(output);
    }
}
public abstract class MultimediaDocument : BinaryDocument, IDocument
{
    public MultimediaDocument(string name, string content = null, int size = 0, int length = 0)
        : base(name, content, size)
    {
        this.Length = length;
    }

    public int Length { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key.ToLower() == "length")
        { this.Length = int.Parse(value); }
        else
        { base.LoadProperty(key, value); }
    }

    public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
    {
        if (this.Length != 0)
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}
public class AudioDocument : MultimediaDocument, IDocument
{
    public AudioDocument(string name, string content = null, int size = 0, int length = 0, double sampleRate = 0.0)
        : base(name, content, size, length)
    {
        this.SampleRate = sampleRate;
    }

    public double SampleRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key.ToLower() == "samplerate")
        { this.SampleRate = int.Parse(value); }
        else { base.LoadProperty(key, value); }
    }

    public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
    {
        if (this.SampleRate != 0)
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        base.SaveAllProperties(output);
    }
}
public class VideoDocument : MultimediaDocument, IDocument
{
    public VideoDocument(string name, string content = null, int size = 0, int length = 0, int frameRate = 0)
        : base(name, content, size, length)
    {
        this.FrameRate = frameRate;
    }

    public int FrameRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key.ToLower() == "framerate")
        { this.FrameRate = int.Parse(value); }
        else { base.LoadProperty(key, value); }
    }

    public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
    {
        if (this.FrameRate != 0)
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        base.SaveAllProperties(output);
    }
}
public class PreDocumentSystem
{
    private static ICollection<IDocument> documents = new List<IDocument>();

    public static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        IDocument doc = new TextDocument("");
        AddDocument(attributes, doc);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        IDocument doc = new PDFDocument("");
        AddDocument(attributes, doc);
    }

    private static void AddWordDocument(string[] attributes)
    {
        IDocument doc = new WordDocument();
        AddDocument(attributes, doc);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        IDocument doc = new ExcelDocument("");
        AddDocument(attributes, doc);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        IDocument doc = new AudioDocument("");
        AddDocument(attributes, doc);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        IDocument doc = new VideoDocument("");
        AddDocument(attributes, doc);
    }

    private static void ListDocuments()
    {
        if (documents.Any())
        {
            foreach (var doc in documents)
            {
                Console.WriteLine(doc);
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        var encryptableDocs = documents
            .Where(d => d.Name == name);

        if (encryptableDocs.Any())
        {
            foreach (IDocument doc in encryptableDocs)
            {
                var encryptableDoc = doc as IEncryptable;
                if (encryptableDoc != null)
                {
                    encryptableDoc.Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        var encryptableDocs = documents
            .Where(d => d.Name == name);

        if (encryptableDocs.Any())
        {
            foreach (IDocument doc in encryptableDocs)
            {
                var encryptableDoc = doc as IEncryptable;
                if (encryptableDoc != null)
                {
                    encryptableDoc.Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        var encryptableDocs = documents
            .Where(d => d is IEncryptable)
            .Select(d => d as IEncryptable);

        if (encryptableDocs.Any())
        {
            foreach (IEncryptable doc in encryptableDocs)
            {
                doc.Encrypt();
            }

            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        var editableDocs = documents.Where(d => d.Name == name);

        if (editableDocs.Any())
        {
            foreach (var doc in editableDocs)
            {
                var editableDoc = doc as IEditable;
                if (editableDoc != null)
                {
                    editableDoc.ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void AddDocument(string[] attributes, IDocument doc)
    {
        foreach (string attr in attributes)
        {
            string[] keyValue = attr.Split('=');
            doc.LoadProperty(keyValue[0], keyValue[1]);
        }

        if (!string.IsNullOrEmpty(doc.Name))
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }
}
