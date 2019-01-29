use Catalogue;

select p.Name as 'Product name', coalesce(c.Name, '') as 'Category name' from Product (nolock) p
left join ProductToCategory (nolock) pc on p.ID = pc.ProductId
left join Category (nolock) c on c.ID = pc.CategoryId
