﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace Toaster
{
    public sealed class Toaster : IBackgroundTask
    {
        BackgroundTaskDeferral _deferal;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferal = taskInstance.GetDeferral();
            taskInstance.Canceled += TaskInstance_Canceled;
            taskInstance.Task.Completed += Task_Completed;
            var details = taskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;

            if (details != null)
            {
                try
                {
                    string arguments = details.Argument;
                    var userInput = details.UserInput;
                    string title = (string)userInput["title"];
                    string detail = (string)userInput["detail"];
                    var notify = (byte)int.Parse(userInput["notification"].ToString());
                    //var snoozeTime = (int)userInput["snoozeTime"];
                }
                catch (Exception ex) { }

            }
            Core.Classes.LiveTile.livetile();
        }
        private void Task_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            _deferal.Complete();
        }

        private void TaskInstance_Canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _deferal.Complete();
        }
    }
}
