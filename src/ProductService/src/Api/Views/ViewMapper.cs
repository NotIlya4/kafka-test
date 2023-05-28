using Core.Domain.Entities;

namespace Api.Views;

public class ViewMapper
{
    public Product MapProduct(ProductView view)
    {
        return new Product(
            id: view.Id,
            name: view.Name,
            price: view.Price,
            type: view.Type);
    }

    public ProductView MapProduct(Product product)
    {
        return new ProductView(
            id: product.Id,
            name: product.Name,
            price: product.Price,
            type: product.Type);
    }

    public List<ProductView> MapProducts(List<Product> product)
    {
        return product.Select(MapProduct).ToList();
    }
}