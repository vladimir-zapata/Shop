namespace Shop.BLL.Dto
{
    public class UpdateProductDto : ProductDto
    {
        public int ProductId { get; set; }
        public bool Discontinued { get; set; }
    }
}
