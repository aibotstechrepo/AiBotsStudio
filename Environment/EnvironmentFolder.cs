using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Environments
{
    public sealed class EnvironmentFolder : CodeActivity
    {
        public enum Fold
        {
            Desktop,
            Programs,
            MyDocuments,
            Favorites,
            Startup,
            SendTo,
            Recent,
            StartMenu,
            MyMusic,
            MyPictures,
            DesktopDirectory,
            MyComputer,
            NetworkShortcuts,
            Fonts,
            Templates,
            CommonStartMenu,
            CommonStartup,
            CommonTemplates,
            CommonDesktopDirectory,
            ApplicationData,
            PrinterShortcuts,
            LocalApplicationData,
            InternetCache,
            History,
            Cookies,
            CommonApplicationData,
            Windows,
            System,
            ProgramFiles,
            UserProfile,
            SystemX86,
            ProgramFilesX86,
            CommonProgramFiles,
            CommonProgramFilesX86,
            CommonDocuments,
            CommonAdminTools,
            AdminTools,
            CommonMusic,
            CommonPictures,
            CommonVideos,
            Resources,
            LocalizedResources,
            CommonOemLinks,
            CDBurning,
            MyVideos,
        }
        [Category("Input")]
        [DisplayName("SelectFolder")]

        public Fold fol { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<string> Path { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int Fold = Convert.ToInt32(fol);
            WindowsFormsSection Foldval = new WindowsFormsSection();
            string path;
            if (Fold == 0)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else if (Fold == 1)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            }
            else if (Fold == 2)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else if (Fold == 3)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            }
            else if (Fold == 4)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            }
            else if (Fold == 5)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            }
            else if (Fold == 6)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            }
            else if (Fold == 7)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            }
            else if (Fold == 8)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            }
            else if (Fold == 9)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else if (Fold == 10)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
            else if (Fold == 11)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            }
            else if (Fold == 12)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts);
            }
            else if (Fold == 13)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            }
            else if (Fold == 14)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
            }
            else if (Fold == 15)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            }
            else if (Fold == 16)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
            }
            else if (Fold == 17)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates);
            }
            else if (Fold == 18)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            }
            else if (Fold == 19)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
            else if (Fold == 20)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts);
            }
            else if (Fold == 21)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }
            else if (Fold == 22)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            }
            else if (Fold == 23)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.History);
            }
            else if (Fold == 24)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            }
            else if (Fold == 25)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            }
            else if (Fold == 26)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            }
            else if (Fold == 27)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            }
            else if (Fold == 28)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }
            else if (Fold == 29)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
            else if (Fold == 30)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            }
            else if (Fold == 31)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }
            else if (Fold == 32)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
            }
            else if (Fold == 33)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
            }
            else if (Fold == 34)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            }
            else if (Fold == 35)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonAdminTools);
            }
            else if (Fold == 36)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.AdminTools);
            }
            else if (Fold == 37)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);
            }
            else if (Fold == 38)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            }
            else if (Fold == 39)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
            }
            else if (Fold == 40)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
            }
            else if (Fold == 41)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources);
            }
            else if (Fold == 42)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CommonOemLinks);
            }
            else if (Fold == 43)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.CDBurning);
            }
            else if (Fold == 44)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            context.SetValue(Path, path);
        }

    }
}
}
