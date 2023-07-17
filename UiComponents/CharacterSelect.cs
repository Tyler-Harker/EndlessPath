using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using EndlessPath.Domain;


public partial class CharacterSelect : VBoxContainer
{
	private VBoxContainer CharacterVBoxContainer => (VBoxContainer)FindChild("CharacterVBoxContainer");
    private Button CreateNewButton => (Button)FindChild("CreateNewButton");
    
    private List<CharacterSelectItem> AvailableCharacters { get; set; } = new List<CharacterSelectItem>()
	{
	};

    public Action? OnClickCreateNew;

    public Action? OnSelectCharacter;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        RegisterEventListeners();
		//var label = new Label();
		//label.Text = "This is a test";
		//this.AddChild(label);
		//var test1 = this.GetChild<VBoxContainer>(2);
		//var test = GetNode<VBoxContainer>("CharacterSelect");
		//var container = GetNode<VBoxContainer>("CharacterSelect/ScrollContainer/VBoxContainer");

		foreach (var availableCharacter in AvailableCharacters)
		{
			
			var scene = GD.Load<PackedScene>("res://UiComponents/CharacterSelectItem.tscn");
			var instance = scene.Instantiate<CharacterSelectItem>();
			//instance.Position = new Vector2(0, topY);
			//topY += instance.Size.Y;
			//AddChild(instance);
			CharacterVBoxContainer.AddChild(instance);
		}

		var nodes = this.GetChildren();
	}

    private void RegisterEventListeners()
    {
        CreateNewButton.Pressed += CreateNewButtonClicked;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void CreateNewButtonClicked()
    {
		OnClickCreateNew?.Invoke();
    }
}
