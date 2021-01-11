using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI.BLL
{
    class CalendarBLL
    {
        public void openCalendar(ChromiumWebBrowser chrome, string linkCalendar, FormCalendar form)
        {
            
            CefSettings settings = new CefSettings();
            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings);
            }
            chrome = new ChromiumWebBrowser(linkCalendar);

            chrome.Load(linkCalendar);
            form.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
        }

    }
}
