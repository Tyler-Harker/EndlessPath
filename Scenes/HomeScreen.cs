using Godot;
using System;

public partial class HomeScreen : HBoxContainer
{
    private Panel CreateCharacterPanel => (Panel)FindChild("CreateCharacterPanel");
    private CharacterSelect CharacterSelect => (CharacterSelect)FindChild("CharacterSelect");
    private CreateCharacterForm CreateCharacterForm => (CreateCharacterForm)FindChild("CreateCharacterForm", recursive:true);
    // Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        RegisterEventHandlers();
        CreateCharacterPanel.Visible = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void RegisterEventHandlers()
    {
        CreateCharacterForm.OnClickCreate = async () =>
        {
            
        };
        CreateCharacterForm.OnClickCancel = () =>
        {
            CreateCharacterPanel.Visible = false;
        };
        CharacterSelect.OnClickCreateNew = () =>
        {
            CreateCharacterPanel.Visible = true;
        };
    }
}
