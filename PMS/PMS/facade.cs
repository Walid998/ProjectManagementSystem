using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PMS.Controllers;

namespace PMS
{
    public class facade : Interface1
    {
        private readonly IFeedback _FeedbackController;
        public facade (IFeedback feedbackController)
        {
            _FeedbackController = feedbackController;
        }
        public void done()
        {
            _FeedbackController.send();
        }

        public void failed()
        {
            _FeedbackController.error();
        }
    }
}