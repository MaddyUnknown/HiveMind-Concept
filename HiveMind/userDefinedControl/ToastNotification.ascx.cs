using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace HiveMind.Userdefined.Control
{
    public partial class ToastNotification : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ImageUrl
        {
            get
            {
                return BannerImage.ImageUrl;
            }
            set
            {
                if(value != null)
                {
                    BannerImage.ImageUrl = value;
                }
                else
                {
                    throw new ArgumentNullException("Image Url");
                }
            }
        }
        public string Title
        {
            get
            {
                return Heading.Text;
            }
            set
            {
                if (value != null)
                {
                    Heading.Text = value;
                }
                else
                {
                    throw new ArgumentNullException("Heading Title");
                }
            }
        }

        public string Content
        {
            get
            {
                return Body.Text;
            }
            set
            {
                if (value != null)
                {
                    Body.Text = value;
                }
                else
                {
                    throw new ArgumentNullException("Body Content");
                }
            }
        }

        public Color TextColor
        {
            set
            {
                if(value != null) {
                    Body.ForeColor = value;
                    Heading.ForeColor = value;
                }
                else
                {
                    throw new ArgumentNullException("Invalid Color");
                }
            }
        }
    }
}