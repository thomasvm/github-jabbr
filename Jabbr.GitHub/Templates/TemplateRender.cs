using System.IO;
using System.Web;
using RazorEngine;

namespace Jabbr.GitHub
{
    public class TemplateRender
    {
        private string _basePath;

        public TemplateRender(string basePath)
        {
            _basePath = basePath;
        }

        public TemplateRender()
            : this(HttpContext.Current.Request.MapPath("~/Templates"))
        {
        }

        public string Render(string template, dynamic payload)
        {
            string path = Path.Combine(_basePath, template);

            if (!File.Exists(path))
                throw new FileNotFoundException("Unable to locate view", path);

            string content = File.ReadAllText(path);
            return Razor.Parse(content, payload, template);
        }
    }
}