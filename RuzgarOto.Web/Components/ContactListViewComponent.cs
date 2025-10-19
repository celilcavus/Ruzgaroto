using _01.RuzgarOto.Entity;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RuzgarOto.Web.Components
{
	public class ContactListViewComponent:ViewComponent
	{
		private readonly IContactServices contactServices;

		public ContactListViewComponent(IContactServices contactServices)
		{
			this.contactServices = contactServices;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = this.contactServices.GetAll();
			if (values is null)
			{
				return View(Enumerable.Empty<Contact>);
			}
			return View(values);
		}
	}
}
