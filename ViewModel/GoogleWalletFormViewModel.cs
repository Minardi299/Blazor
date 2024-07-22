using MudBlazorWebApp1.Model.Gwallet;

namespace MudBlazorWebApp1.ViewModel.Gwallet
{
    public class GoogleWalletFormViewModel
    {
        public GenericPassClass genericPass;
        public GenericPassObject genericObject;
        public GoogleWalletFormViewModel()
        {
            genericPass = new GenericPassClass("3388000000022340355", "GenericPassId5");
            genericObject = new GenericPassObject(genericPass);
        }
        public  string GetLink()
        {
            GenericCard c = new GenericCard(this.genericObject, this.genericPass);
            c.Auth();
            c.CreateClass();
            c.CreateObject();
            string link = c.CreateJWTNewObjects();
            return link;
        }
    }
}
