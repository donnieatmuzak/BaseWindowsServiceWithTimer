using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mood.MediaServices.Synchronization
{
   ////////////////////////////////////////////////////////////////////////////
   /// <summary>
   /// Provides a data class for storing dead zone datetime information
   /// </summary>
   class DeadZone
   {
      private DateTime _startTime;
      private DateTime _endTime;

      ////////////////////////////////////////////////////////////////////////
      public DateTime StartTime
      {
         get { return _startTime; }
      }

      ////////////////////////////////////////////////////////////////////////
      public DateTime EndTime
      {
         get { return _endTime; }
      }

      ////////////////////////////////////////////////////////////////////////
      public DeadZoneTimeSpan(string startTime, string endTime)
      {
         try
         {
            _startTime = Convert.ToDateTime(startTime);
            _endTime = Convert.ToDateTime(endTime);

            if (_endTime < _startTime)
            {
               _endTime = _endTime.AddDays(1);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }

   ////////////////////////////////////////////////////////////////////////////a
   /// <summary>
   /// Manages the dead zone functionality. Constructor creates a list of dead
   /// zones that is used by InDeadZone to determine if the current time is in
   /// a dead zone.
   /// </summary>
   class DeadZonesClass
   {
      List<DeadZoneTimeSpan> _deadZones;

      ////////////////////////////////////////////////////////////////////////
      /// <summary>
      /// Constructor: Loads a list of DeadZoneTimeSpans
      /// </summary>
      /// <param name="deadZones">
      /// String: Formatting: Starting Time-Ending Time, comma separated. Time is in 24 hour format.
      /// HH:MM-HH-MM, ...
      /// Sample: 16:24-16:28,20:15-20:45,22:05-22:59,23:30-1:30
      /// NOTE: If the end time is less than the start time it is assumed that you are spanning
      /// midnight into another day. In that case 1 day is added to the end time. So, in the example
      /// above if the date is 6/1/2010 then the last entry will result in the following values:
      ///     start time = 6/1/2010 23:30, end time = 6/2/2010 01:30
      /// </param>
      public DeadZonesClass()
      {
         try
         {
            _deadZones = new List<DeadZoneTimeSpan>();

         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      /// <summary>
      /// Dead zone setter: Loads a list of DeadZoneTimeSpans
      /// </summary>
      /// <param name="deadZones">
      /// String: Formatting: Starting Time-Ending Time, comma separated. Time is in 24 hour format.
      /// HH:MM-HH-MM, ...
      /// Sample: 16:24-16:28,20:15-20:45,22:05-22:59,23:30-1:30
      /// NOTE: If the end time is less than the start time it is assumed that you are spanning
      /// midnight into another day. In that case 1 day is added to the end time. So, in the example
      /// above if the date is 6/1/2010 then the last entry will result in the following values:
      ///     start time = 6/1/2010 23:30, end time = 6/2/2010 01:30
      /// </param>
      public void SetDeadZones(string deadZones)
      {
         _deadZones.Clear();

         string[] parsed;
         string[] elements;

         try
         {
            parsed = deadZones.Split(',');

            foreach (string element in parsed)
            {
               elements = element.Split('-');
               _deadZones.Add(new DeadZoneTimeSpan(elements[0], elements[1]));
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      ////////////////////////////////////////////////////////////////////////
      /// <summary>
      /// Principal and only method: Determines if the current time is in the
      /// time spans contained in the List of DeadZoneTimeSpans.
      /// </summary>
      /// <returns>True: In a dead zone, False: Not in a dead zone</returns>
      public bool InDeadZone()
      {
         DateTime now;

         try
         {
            now = DateTime.Now;

            foreach (DeadZoneTimeSpan deadZone in _deadZones)
            {
               if (now > deadZone.StartTime && now < deadZone.EndTime)
               {
                  return true;
               }
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }

         return false;
      }
   }
}
