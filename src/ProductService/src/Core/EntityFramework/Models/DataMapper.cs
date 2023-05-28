using Core.Domain.Entities;
using Core.EntityFramework.Models;

namespace Core.EntityFramework.Repositories;

public class DataMapper
{
    public Product MapProduct(ProductData data)
    {
        return new Product(
            id: new Guid(data.Id),
            name: data.Name,
            price: data.Price,
            type: data.Type);
    }

    public List<Product> MapProducts(List<ProductData> datas)
    {
        return datas.Select(MapProduct).ToList();
    }

    public ProductData MapProduct(Product product)
    {
        return new ProductData(
            id: product.Id.ToString(),
            name: product.Name,
            price: product.Price,
            type: product.Type);
    }
}