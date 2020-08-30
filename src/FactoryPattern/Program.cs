using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    #region Define interface
    abstract class Document
    {
        private string title;
        public string getTitle()
        {
            return title;
        }
        public void setTitle(string title)
        {
            this.title = title;
        }
        public abstract void open();
        public abstract void save();
        public abstract void close();
    }
    abstract class Editor {
        private List<Document> docs = new List<Document>();

        public void open(string file)
        {
            Document doc = createDocument(file);
            doc.setTitle(file);
            doc.open();

            docs.Add(doc);
        }
        public void save(Document doc)
        {
            doc.save();
        }
        public void close(Document doc)
        {
            doc.close();
            docs.Remove(doc);
        }
        public void close()
        {
            foreach (Document doc in docs)
            {
                doc.close();
            }
        }
        // definition of other methods
        public abstract Document createDocument(string file);
    }
    #endregion Define interface

    class DocFormat1 : Document
    {
        public override void open()
        {
            Console.WriteLine("Open DocuFormat1");
        }
        public override void save()
        {
            Console.WriteLine("Save DocuFormat1");
        }
        public override void close()
        {
            Console.WriteLine("Close DocuFormat1");
        }
    }
    class DocFormat2 : Document
    {
        public override void open()
        {
            Console.WriteLine("Open DocuFormat2");
        }
        public override void save()
        {
            Console.WriteLine("Save DocuFormat2");
        }
        public override void close()
        {
            Console.WriteLine("Close DocuFormat2");
        }
    }

    class TextEditor : Editor
    {
        public override Document createDocument(string file)
        {
            int pos = file.LastIndexOf(".");
            string ext = file.Substring(pos, file.Length - pos);

            if (ext == ".doc1")
            {
                return new DocFormat1();
            }
            else if (ext == ".doc2")
            {
                return new DocFormat2();
            }
            else
            {
                throw new Exception("There is not this file.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new TextEditor();
            editor.open("test.doc1");
            editor.open("test.doc2");
            editor.close();

            Console.ReadLine();
        }
    }
}
