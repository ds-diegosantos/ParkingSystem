namespace ParkingSystem.Application.Commands.Categories;

public class CategoryParameters
{
    private const int MAX_PAGE_SIZE = 50;
    private int _pageSize = MAX_PAGE_SIZE;

    public int CurrentPage { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
    }
}
