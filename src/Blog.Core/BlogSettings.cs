using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public class BlogSettings
    {
        public const string AppSettingsSection = "blog";
        public string BlogPostEndpoint { get; set; }
    }
}
