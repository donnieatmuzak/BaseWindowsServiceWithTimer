using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mood.MediaServices.Synchronization
{
   class SynchronizeMedia {
      private SynchronizerBase _SyncBase;



      public SynchronizeMedia(SynchronizerBase SyncBase)
      {
         _SyncBase = SyncBase;
      }
   }

}
