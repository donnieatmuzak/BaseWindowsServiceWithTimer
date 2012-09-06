using System;
using System.ServiceProcess;
using Mood.MediaServices.Synchronization;
using System.Configuration;


namespace Mood.MediaServices
{
   public partial class MediaSynchronizationService : ServiceBase
   {


      #region Variables
      private SynchronizerBase _SyncBase;
      #endregion




      #region Constructor
      public MediaSynchronizationService()
      {
         InitializeComponent();

         if (!InitializeApp())
         {
            return;
         }
      }
      #endregion



      #region Generic Functions
      public string AppVersion
      {
         get
         {
            return System.Reflection.Assembly.GetExecutingAssembly().
            GetName().Version.ToString();
         }
      }
      #endregion




      #region Primary Functions
      private bool InitializeApp()
      {
         bool result = false;

         try
         {
            _SyncBase = new SynchronizerBase();

            result = true;
         }

         catch (Exception ex)
         {
            result = false;
         }

         return result;
      }






      private void StartSynchronizer()
      {
         if (_SyncBase.IsRunning)
         {
            return;
         }


         try
         {
            _SyncBase.Interval = (int.Parse(ConfigurationManager.AppSettings["Interval"]) * 1000);
         } catch(Exception ex)
         {
            _SyncBase.Interval = (120 * 1000);
         }


         _SyncBase.Run();
      }


      private void StopSynchronizer()
      {
         if (_SyncBase.IsRunning)
         {
            _SyncBase.Stop();
         }
      }










      #endregion






      #region Start Stop
      protected override void OnStart(string[] args)
      {
         StartSynchronizer();
      }



      protected override void OnStop()
      {
         StopSynchronizer();
      }
      #endregion




   }           // Close Class
}              // Close Namespace
