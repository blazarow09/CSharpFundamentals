public class Box<T>
{
    private T input;

    public Box(T input)
    {
        this.input = input;
    }

    public override string ToString()
    {
        return $"{this.input.GetType().FullName}: {this.input}";
    }
}