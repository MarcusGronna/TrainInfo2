namespace Domain;

public class Train
{
    public required Guid Id { get; set; }
    public required string Number { get; set; }
    public required string Model { get; set; }

    public Train()
    {
    }

    public Train(string number, string model)
    {
        Number = number;
        Model = model;
    }

    public void SetModel(string model)
    {
        Model = model;
    }

    public void SetNumber(string number)
    {
        Number = number;
    }
}
