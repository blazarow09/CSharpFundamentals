public class Robot : IRobot, IMember
{
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model { get; }

    public string Id { get; }
}