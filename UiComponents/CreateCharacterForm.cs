using Godot;
using System;
using System.Threading.Tasks;
using EndlessPath.Domain.Enums;

public partial class CreateCharacterForm : VBoxContainer
{
    private Button CreateButton => (Button)FindChild("CreateButton");

    private Button CancelButton => (Button)FindChild("CancelButton");

    private OptionButton ClassTypeButton => (OptionButton)FindChild("ClassTypeButton");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        RegisterEventHandlers();
        ClassTypeButton.RemoveItem(0);
        foreach (var classType in Enum.GetValues(typeof(ClassType)))
        {
            ClassTypeButton.AddItem(classType.ToString());
        }
    }

    private void RegisterEventHandlers()
    {
        CreateButton.Pressed += CreateButtonClicked;
        CancelButton.Pressed += CancelButtonClicked;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public Action? OnClickCancel;
    public Action? OnClickCreate;

    private void CancelButtonClicked()
    {
        OnClickCancel?.Invoke();
    }

    private void CreateButtonClicked()
    {
        OnClickCreate?.Invoke();
    }
}
