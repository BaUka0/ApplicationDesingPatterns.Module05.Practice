using System;

namespace Practice_5
{
    public interface IDocument
    {
        void Open();
    }
    public abstract class DocumentCreator
    {
        public abstract IDocument CreateDocument();
    }


    public class Report : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Report opened!");
        }
    }
    public class Resume : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Resume opened!");
        }
    }
    public class Letter : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Letter opened!");
        }
    }
    public class Invoice : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Invoice opened!");
        }
    }

    public enum DocType
    {
        Report, Resume, Letter, Invoice
    }

    public class ReportCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            Console.WriteLine("Report created");
            return new Report();
        }
    }
    public class ResumeCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            Console.WriteLine("Resume created!");
            return new Resume();
        }
    }
    public class LetterCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            Console.WriteLine("Letter created!");
            return new Letter();
        }
    }
    public class InvoiceCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            Console.WriteLine("Invoice created!");
            return new Invoice();
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            GetDocument(DocType.Report).Open();
            GetDocument(DocType.Resume).Open();
            GetDocument(DocType.Letter).Open();
            GetDocument(DocType.Invoice).Open();

            Console.WriteLine("Enter document type (Report, Resume, Letter, Invoice):");
            string input = Console.ReadLine();

            DocType docType;
            if (Enum.TryParse(input, true, out docType))
            {
                IDocument document = GetDocument(docType);
                document.Open();
            }
            else
            {
                Console.WriteLine("Invalid document type entered!");
            }
        }

        public static IDocument GetDocument(DocType type) 
        {
            DocumentCreator creator = null;
            IDocument document = null;

            switch (type)
            {
                case DocType.Report:
                    creator = new ReportCreator();
                    break;
                case DocType.Resume:
                    creator = new ResumeCreator();
                    break;
                case DocType.Letter:
                    creator = new LetterCreator();
                    break;
                case DocType.Invoice:
                    creator = new InvoiceCreator();
                    break;
                default:
                    throw new Exception("Invalid document type!");
            }
            document = creator.CreateDocument();
            return document;
        }
    }
}