namespace Automation.FrameworkCore.Interfaces
{
    public interface IHomePage : IBasePage
    {
        void GoTo();
        void Login(string userName, string password);
        bool LoginErrorIsDisplayed();
        bool SigninButtonIsVisible();
        bool CreateAccountButtonIsVisible();
    }
}