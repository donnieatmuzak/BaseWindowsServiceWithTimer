namespace Mood.MediaServices
{
   partial class ProjectInstaller
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.MediaSyncServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
         this.MediaSyncServiceInstaller = new System.ServiceProcess.ServiceInstaller();
         // 
         // MediaSyncServiceProcessInstaller
         // 
         this.MediaSyncServiceProcessInstaller.Password = null;
         this.MediaSyncServiceProcessInstaller.Username = null;
         // 
         // MediaSyncServiceInstaller
         // 
         this.MediaSyncServiceInstaller.Description = "Media Synchronization Service";
         this.MediaSyncServiceInstaller.DisplayName = "Media Synchronization Service";
         this.MediaSyncServiceInstaller.ServiceName = "MediaSynchronizationService";
         this.MediaSyncServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
         // 
         // ProjectInstaller
         // 
         this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MediaSyncServiceProcessInstaller,
            this.MediaSyncServiceInstaller});

      }

      #endregion

      private System.ServiceProcess.ServiceProcessInstaller MediaSyncServiceProcessInstaller;
      private System.ServiceProcess.ServiceInstaller MediaSyncServiceInstaller;
   }
}