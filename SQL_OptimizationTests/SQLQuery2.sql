

use WideWorldImporters;

-- total sales amount for each customer in 2015, sorted by highest total.


select c.CustomerName,
	sum(l.Quantity * l.UnitPrice) 'Total'
	from Sales.Customers c
	inner join Sales.Orders o on c.CustomerID = o.CustomerID
	inner join Sales.OrderLines l on o.OrderID = l.OrderID
	where YEAR(o.OrderDate) = 2015
	group by c.CustomerName
	order by sum(l.Quantity * l.UnitPrice) desc;


CREATE NONCLUSTERED INDEX [IX_Suggested]
ON [Sales].[OrderLines] ([OrderID])
INCLUDE ([Quantity], [UnitPrice])

