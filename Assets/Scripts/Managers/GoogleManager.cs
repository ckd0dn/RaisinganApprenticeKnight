using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;

public class GoogleManager : Singleton<GoogleManager>
{
    public TextMeshProUGUI logText;

    private void Start()
    {
        SingIn();
    }

    public void SingIn()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            
            if (result == SignInStatus.Success)
            {
                string name = PlayGamesPlatform.Instance.GetUserDisplayName();
                string id = PlayGamesPlatform.Instance.GetUserId();
                string imgUrl = PlayGamesPlatform.Instance.GetUserImageUrl();

                logText.text = "Sucess \n" + name;
            }
            else
            {
                logText.text = "Failed ";
            }
        });
    }


    //internal void ProcessAuthentication(SignInStatus status)
    //{
    //    if (status == SignInStatus.Success)
    //    {
    //        string name = PlayGamesPlatform.Instance.GetUserDisplayName();
    //        string id = PlayGamesPlatform.Instance.GetUserId();
    //        string imgUrl = PlayGamesPlatform.Instance.GetUserImageUrl();

    //        logText.text = "Sucess \n" + name;
    //    }
    //    else
    //    {
    //        logText.text = "Failed ";
    //    }
    //}
}
