namespace Automation.FrameworkCore.Interfaces
{
    public interface IHome : IBase
    {
        void GoTo();
        void Login(string userName, string password);
        bool LoginErrorIsDisplayed();
        bool SigninButtonIsVisible();
        bool CreateAccountButtonIsVisible();
    }
}