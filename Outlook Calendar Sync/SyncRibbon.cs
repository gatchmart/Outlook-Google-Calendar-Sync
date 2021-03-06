﻿using System;
using System.IO;
using Microsoft.Office.Tools.Ribbon;
using Outlook_Calendar_Sync.Properties;
using Outlook_Calendar_Sync.Scheduler;

namespace Outlook_Calendar_Sync {
    public partial class SyncRibbon {
        private SyncerForm m_syncerForm;

        private void SyncRibbon_Load( object sender, RibbonUIEventArgs e ) {

            m_syncerForm = new SyncerForm();
            m_syncerForm.Ribbon = this;
            var path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ) +
                       "\\OutlookGoogleSync\\initialStartup.ini";

            if ( !File.Exists( path ) ) {
                var initial = new InitialLoadForm();
                initial.Show();

                Settings.Default.IsInitialLoad = false;
                Settings.Default.Save();
            }
#if DEBUG
            Debug_BTN.Visible = true;
#endif

        }

        private void Sync_BTN_Click( object sender, RibbonControlEventArgs e ) {
            m_syncerForm.Show();
        }

        private void Settings_BTN_Click( object sender, RibbonControlEventArgs e ) {
            var settings = new SchedulerForm();
            settings.Show();
        }

        private void Debug_BTN_Click( object sender, RibbonControlEventArgs e ) {
            var debug = new DebuggingForm();
            debug.Show();
        }

        private void AboutBtn_Click(object sender, RibbonControlEventArgs e)
        {
            var about = new O2GAboutBox();
            about.Show();
        }
    }
}
