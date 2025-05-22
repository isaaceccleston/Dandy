using Godot;

public partial class Player : CharacterBody2D
{
    // How fast the player moves in meters per second.
    [Export]
    public int Speed { get; set; } = 100;
    // The downward acceleration when in the air, in meters per second squared.

    private Vector2 _targetVelocity = Vector2.Zero;

    public override void _PhysicsProcess(double delta)
    {
        var direction = Vector2.Zero;

        if (Input.IsActionPressed("move_right"))
        {
            direction.X += 1.0f;
        }
        if (Input.IsActionPressed("move_left"))
        {
            direction.X -= 1.0f;
        }
        if (Input.IsActionPressed("move_down"))
        {
            direction.Y += 1.0f;
        }
        if (Input.IsActionPressed("move_up"))
        {
            direction.Y -= 1.0f;
        }

        // Ground velocity
        _targetVelocity.X = direction.X * Speed;
        _targetVelocity.Y = direction.Y * Speed;

        // Moving the character
        Velocity = _targetVelocity;
        MoveAndSlide();
    }
}
