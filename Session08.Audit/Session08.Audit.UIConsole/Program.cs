using Session08.Audit.EFDAL;
using Session08.Audit.Entities;
using System;

namespace Session08.Audit.UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            TeacherContext TCtx = new TeacherContext();
            TCtx.Add(new Teacher{Name = "ziarati"}); 
            TCtx.Add(new Student { Name = "somaye ziarati" });
            TCtx.SaveChanges();
            Console.WriteLine("Hello World!");
        }
    }
}
