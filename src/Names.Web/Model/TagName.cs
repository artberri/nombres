using System;
using Names.Domain.Entities;

namespace Names.Web.Model
{
    public class TagName : Name
    {
        public bool IsClicked { get; set; }
        public string Class
        {
            get
            {
                var classes = Gender ? "tag female" : "tag male";
                if (IsClicked)
                {
                    classes = classes + " active";
                }

                return classes;
            }
        }
    }
}
