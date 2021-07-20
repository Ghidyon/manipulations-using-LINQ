using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNEnrollmentApp.Events
{
    public class Event
    {
        public event EventHandler<EventArgsModel> SendEmail; // event

        protected virtual void OnSendingEmail(EventArgsModel model)
        {
            // if SendEmail event is not null, then call delegate
            SendEmail?.Invoke(this, model);
        }

        public void RunEvent(EventArgsModel model)
        {
            OnSendingEmail(model);
        }
    }
}
