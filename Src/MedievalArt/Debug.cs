using Godot;

namespace MedievalArt.MedievalArt
{
    public class Debug : CanvasLayer
    {
        private VBoxContainer debugContainer;
        private Label debugCoordinates;
        private Label debugFPS;
        public override void _Ready()
        {
            debugContainer = GetNode<VBoxContainer>("DebugContainer");
            debugCoordinates = debugContainer.GetNode<Label>("Coordinates");
            debugFPS = debugContainer.GetNode<Label>("FPS");
        }

        public override void _Process(float delta)
        {
            debugFPS.Text = "FPS: " + Engine.GetFramesPerSecond();
        }
    }
}
