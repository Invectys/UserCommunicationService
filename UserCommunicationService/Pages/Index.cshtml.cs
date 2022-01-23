using Invectys.UsersService.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserCommunicationService.Core.Services.Configuration;
using UserCommunicationService.Core.Services.Users;

namespace UserCommunicationService.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(
            ILogger<IndexModel> logger, 
            AppConfigurationService appConfigurationService,
            IUsersService usersService
            )
        {
            _logger = logger;
            _appConfigurationService = appConfigurationService;
            _usersService = usersService;
        }

        [BindProperty]
        public string UserServiceUrl { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private AppConfigurationService _appConfigurationService;
        
        private IUsersService _usersService;

        public void OnGet()
        {
            UserServiceUrl = _appConfigurationService.GetValue("USER_SERVICE_URL", "http://194.67.104.187:5022/");
        }

        public void OnPost()
        {
            // users service url chnager
            UserServiceUrl = Request.Form["usersServiceUrl"];
            _appConfigurationService.Values["USER_SERVICE_URL"] = UserServiceUrl;

            _usersService.UsersServiceApi = new UsersServiceApi(UserServiceUrl);
        }
    }
}