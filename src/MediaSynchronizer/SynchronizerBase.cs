using System;
using System.ComponentModel;
using System.Timers;



namespace Mood.MediaServices.Synchronization
{

   public class SynchronizerBase : IDisposable
   {
      #region Variables
      private Component _Component;
      private bool _Disposed = false;
      private bool _IsRunning = false;
      private SynchronizeMedia _SyncMedia;
      private double _Interval;
      private System.Timers.Timer _Timer;
      private DeadZone _DeadZone;
      #endregion



      #region Constructor
      public SynchronizerBase()
      {
         try
         {
            _Timer = new Timer();
            _Component = new Component();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
      #endregion




      #region Disposal
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      private void Dispose(bool disposing)
      {
         if (!this._Disposed)
         {
            if (disposing)
            {
               _Component.Dispose();
            }

            _Disposed = true;
         }
      }
      #endregion




      #region Primary Functions
      public bool IsRunning
      {
         get { return _IsRunning; }
      }

      public double Interval
      {
         set { _Interval = value; }
      }


      public void Run()
      {
         try
         {
            _SyncMedia = new SynchronizeMedia(this);


            _IsRunning = true;
            _Timer.Interval = _Interval;
            _Timer.Start();
            GC.KeepAlive(_Timer);
         }
         catch (Exception ex)
         {
            //Console.WriteLine(ex.ToString());
            throw ex;
         }
      }


      public void Stop()
      {
         try
         {
            _Timer.Stop();
            _IsRunning = false;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }



      #endregion




   }


}
