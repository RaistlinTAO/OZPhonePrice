#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2012 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: OZPhonePrice
// PROJECT:    OZPhonePrice
// FILENAME:  Program.cs
// 
// CREATED IN 9:21 PM (11/02/2013)
// 
// LAST EDITED: 10:42 PM (12/02/2013)

#endregion

using System;
using System.Windows.Forms;
using OZPhonePrice.Views;

namespace OZPhonePrice
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}