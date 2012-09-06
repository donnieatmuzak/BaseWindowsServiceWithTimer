using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Mood.MediaServices;

namespace BaseService
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      static void Main()
      {
         ServiceBase[] ServicesToRun;
         ServicesToRun = new ServiceBase[] 
			{ 
				new MediaSynchronizationService() 
			};
         ServiceBase.Run(ServicesToRun);
      }
   }
}
