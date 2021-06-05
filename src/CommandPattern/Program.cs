using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    interface IDrawing
    {
        void ProcessSome();
        void ProcessOther();
        void ProcessAnother();
    }

    class DrawingImpl : IDrawing
    {
        public DrawingImpl()
        { }

        public void ProcessSome()
        {
            Console.WriteLine($"Do Some process for image.");
        }
        public void ProcessOther() 
        {
            Console.WriteLine($"Do Other process for image.");
        }
        public void ProcessAnother()
        { 
            Console.WriteLine($"Do ProcessAnother process for image.");
        }
    }

    interface ICommand
    {
        void Execute(IDrawing drawing);
    }
    class ImageService
    {
        private Dictionary<string, ICommand> mCommands;
        private IDrawing mDrawing;
        public ImageService()
        {
            mCommands = new Dictionary<string, ICommand>();
            mDrawing = new DrawingImpl();
        }

        public void AddCommand(string effect, ICommand command)
        {
            mCommands.Add(effect, command);
        }
        public void DoEffect(string effect)
        {
            mCommands[effect].Execute(mDrawing);
        }
    }

    class AEffectCommand : ICommand
    {
        public void Execute(IDrawing drawing)
        {
            Console.WriteLine("Execute A effect");
            drawing.ProcessSome();
            drawing.ProcessOther();

            Console.WriteLine("");
        }
    }

    class BEffectCommand : ICommand
    {
        public void Execute(IDrawing drawing)
        {
            Console.WriteLine("Execute B effect");
            drawing.ProcessOther();
            drawing.ProcessAnother();

            Console.WriteLine("");
        }
    }

    class CEffectCommand : ICommand
    {
        public void Execute(IDrawing drawing)
        {
            Console.WriteLine("Execute C effect");
            drawing.ProcessOther();
            drawing.ProcessSome();
            drawing.ProcessAnother();

            Console.WriteLine("");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ImageService service = new ImageService();
            service.AddCommand("AEffect", new AEffectCommand());
            service.AddCommand("BEffect", new BEffectCommand());
            service.AddCommand("CEffect", new CEffectCommand());

            // execute as require
            service.DoEffect("AEffect");
            service.DoEffect("BEffect");
            service.DoEffect("CEffect");

            Console.ReadLine();
        }
    }
}
