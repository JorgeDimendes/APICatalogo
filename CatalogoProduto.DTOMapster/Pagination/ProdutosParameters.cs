namespace CatalogoProduto.DTOMapster.Pagination;

public class ProdutosParameters
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1; //Mostra a pagina atual
    private int _pageSize;

    public int PageSize //Mostra a quantidade de itens na pagina
    {
        get
        {
            return _pageSize;
        }
        
        set
        {
            _pageSize = (value > maxPageSize)? maxPageSize : value;
        }
    }
}