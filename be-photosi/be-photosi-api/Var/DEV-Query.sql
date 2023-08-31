select * from Category

select * from Products

select * from Address

select * from Users

select * from orders

select * from OrderProduct

select * from Products p inner join Category c on c.Id= p.CategoryId

select o.id, p.Name, c.Name, u.Username, a.City, a.State
		 from Orders o 
		 inner join OrderProduct op on op.OrderId = o.Id
		 inner join Products p on p.Id = op.ProductId
		 inner join Category c on c.Id = p.CategoryId
		 inner join Users u on u.Id = o.UserId
		 inner join Address a on a.Id = o.AddressId


-- delete from orders
-- delete from OrderProduct
