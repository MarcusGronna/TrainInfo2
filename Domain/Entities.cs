namespace Domain;

public class Train
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Model { get; set; }

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
