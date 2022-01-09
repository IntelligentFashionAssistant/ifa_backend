namespace api.ApiDTOs;

public class PageApiDto
{
    private static readonly int MAX_PAGE_SIZE = 50;

    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
    }
}