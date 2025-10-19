using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
	public class ClientsViewComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
