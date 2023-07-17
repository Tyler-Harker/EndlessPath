using Godot;
using System;
using System.Linq;
using System.Threading.Tasks;
using EndlessPath.Constants;
using EndlessPath.Extensions;
using EndlessPath.Services;

public partial class LoginScreen : Control
{
    private Button CreateAccountButton => (Button)FindChild("CreateAccountButton");
    private Button SignInButton => (Button)FindChild("SignInButton");
    private LineEdit UsernameInput => (LineEdit)FindChild("UsernameInput");
    private LineEdit PasswordInput => (LineEdit)FindChild("PasswordInput");
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RegisterEventHandlers();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void RegisterEventHandlers()
    {
        CreateAccountButton.Pressed += () =>
        {
            GetTree().ChangeSceneToFile(SceneConstants.CreateAccount);
        };
        SignInButton.Pressed += async () =>
        {
            await ClickSignInButton();
        };
    }

    private async Task ClickSignInButton()
    {
        var username = UsernameInput.Text;
        var password = PasswordInput.Text;
        var result = await AuthService.LoginAsync(username, password);
        if (result)
        {
            GetTree().ChangeSceneToFile(SceneConstants.Home);
        }
    }
}
