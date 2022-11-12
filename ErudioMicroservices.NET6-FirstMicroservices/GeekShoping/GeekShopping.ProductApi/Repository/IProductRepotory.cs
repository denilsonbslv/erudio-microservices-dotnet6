using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repository
{
    public interface IProductRepotory
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long idProduct);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long idProduct);
    }
}
