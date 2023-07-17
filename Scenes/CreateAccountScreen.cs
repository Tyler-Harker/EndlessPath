using Godot;
using System;
using System.Threading.Tasks;
using EndlessPath.Constants;
using EndlessPath.Services;

public partial class CreateAccountScreen : Control
{
    private Button CreateAccountButton => (Button)FindChild("CreateAccountButton");
    private Button BackButton => (Button)FindChild("BackButton");
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
        CreateAccountButton.Pressed += async () =>
        {
            await ClickCreateAccountButton();
        };
        BackButton.Pressed += () =>
        {
            GetTree().ChangeSceneToFile(SceneConstants.Login);
        };
    }

    private async Task ClickCreateAccountButton()
    {
        var username = UsernameInput.Text;
        var password = PasswordInput.Text;
        var isCreateSuccess = await AuthService.CreateAccountAsync(username, password);

        if (isCreateSuccess)
        {
            GetTree().ChangeSceneToFile(SceneConstants.Login);
        }
    }
}
