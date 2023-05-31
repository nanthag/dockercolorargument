using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dockercolorargument.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<string> env = new List<string>();
        public List<string> args = new List<string>();
        public string color {  get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var envlist = Environment.GetEnvironmentVariables();

            foreach(var key in envlist.Keys)
            {
                env.Add(envlist[key].ToString());
            }

            color = Environment.GetEnvironmentVariable("COLOR");

            args = Environment.GetCommandLineArgs().ToList();


        }
    }
}