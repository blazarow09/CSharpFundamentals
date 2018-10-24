public class Threeuple<T, K, V>
{
    public Threeuple(T firstValue, K secondValue, V thirdValue)
    {
        this.firstValue = firstValue;
        this.secondValue = secondValue;
        this.ThirdValue = thirdValue;
    }

    public T firstValue { get; private set; }
    public K secondValue { get; private set; }
    public V ThirdValue { get; private set; }

    public override string ToString()
    {
        return $"{this.firstValue} -> {this.secondValue} -> {this.ThirdValue}";
    }
}