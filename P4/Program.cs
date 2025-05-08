using System;
using System.Windows.Forms;

namespace HotelDafam
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // untuk .NET 6+
            Application.Run(new Form1());
        }
    }
}
