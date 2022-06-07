namespace ArraySample.Service
{
    public interface IProductService
    {
        int[] ReverseArray(int[] array);

        int[] DeleteFromArray(int[] array, int position);
    }
}