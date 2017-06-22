using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using ArtOfTest.WebAii.Design.Extensibility;
using ArtOfTest.Common.Design;

namespace ExportToTRX
{
    /// <summary>
    /// 
    /// </summary>
    public class Export : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion

        /// <summary>
        /// This is the convert class that returns results.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns>Boolean</returns>
        [CodedStep(@"New Coded Step")]
        public Boolean Export_CodedStep(string input, string output)
        {
            PublishManager myPublicMnager = new PublishManager();

            string myinput = input;
            string myoutput = output;

            //input = @"C:\Dev\CreateTRX\Results\_updated_temp131400969253251369.aiiresult";
            //output = @"C:\Dev\CreateTRX\Results\out.trx";

            var loader = new FileHandler<RunResult>();
            var runResult = loader.LoadFromDisk(myinput, true);

            bool success = false;
            success = myPublicMnager.CreateTRX(runResult, myoutput);

            // Keep the console window open in debug mode.
            // Console.WriteLine("Press any key to exit.");
            // Console.ReadKey();

            return success;
        }
    }

    public class Program
    {
        /// <summary>
        /// This is the main class.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>integer</returns>
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("Please enter exactly two file paths (from and to) as arguments!");

                // Keep the console window open in debug mode.
                // Console.WriteLine("Press any key to exit.");
                // Console.ReadKey();

                return 1;
            }

            string input = "";
            string output = ""; 

            input = args[0];
            output = args[1];

            Export myExport = new Export();
            bool result = myExport.Export_CodedStep(input, output);

            if (result) { 
                System.Console.WriteLine("Converting to TRX successfully!");

                // Keep the console window open in debug mode.
                // Console.WriteLine("Press any key to exit.");
                // Console.ReadKey();

                return 0; 
            }
            else { 
                System.Console.WriteLine("Converting to TRX failed!");

                // Keep the console window open in debug mode.
                // Console.WriteLine("Press any key to exit.");
                // Console.ReadKey();

                return 1; 
            }
        }
    }
}

