USE [master]
GO

-- DROP DATABASE [Practica_3]
-- GO

CREATE DATABASE [Practica_3]
GO

USE [Practica_3]
GO

-- Tables.
CREATE TABLE [dbo].[tProducto](
	[CodigoCompra] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tProducto] PRIMARY KEY CLUSTERED 
(
	[CodigoCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tAbono](
	[IdAbono] [int] IDENTITY(1,1) NOT NULL,
	[MontoAbono] [decimal](18, 2) NOT NULL,
	[CodigoCompraProductoID] [int] NOT NULL,
 CONSTRAINT [PK_tAbono] PRIMARY KEY CLUSTERED 
(
	[IdAbono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- INSERTS.
SET IDENTITY_INSERT [dbo].[tProducto] ON 
GO
INSERT [dbo].[tProducto] ([CodigoCompra], [Descripcion], [PrecioUnitario], [Saldo], [Estado]) VALUES 
(1, N'Camiseta Sport del Real Madrid Númer 9', CAST(10000.00 AS Decimal(18, 2)), 0, 1)
GO
INSERT [dbo].[tProducto] ([CodigoCompra], [Descripcion], [PrecioUnitario], [Saldo], [Estado]) VALUES 
(2, N'Camiseta Sport del FC Barcelona Númer 9', CAST(20000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[tProducto] ([CodigoCompra], [Descripcion], [PrecioUnitario], [Saldo], [Estado]) VALUES 
(3, N'Camiseta Sport del Juventus Númer 9', CAST(30000.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)), 0)
GO
SET IDENTITY_INSERT [dbo].[tProducto] OFF
GO

-- Foreign Key.
ALTER TABLE [dbo].[tAbono]  WITH CHECK ADD  CONSTRAINT [FK_tAbono_tProducto] FOREIGN KEY([CodigoCompraProductoID])
REFERENCES [dbo].[tProducto] ([CodigoCompra])
GO
ALTER TABLE [dbo].[tAbono] CHECK CONSTRAINT [FK_tAbono_tProducto]
GO

-- SP.
CREATE PROCEDURE [dbo].[ConsultarProductos]

AS
BEGIN

	SELECT	CodigoCompra,
			Descripcion,
			PrecioUnitario,
			Estado
	  FROM	dbo.tProducto prod
	  ORDER BY Estado

END
GO

CREATE PROCEDURE [dbo].[ConsultarProducto]
	@CodigoCompraID INT
AS
BEGIN

	SELECT	CodigoCompra,
			Descripcion,
			PrecioUnitario,
			Estado
	  FROM	dbo.tProducto prod
	  WHERE CodigoCompra = @CodigoCompraID
END
GO

--CREATE PROCEDURE [dbo].[PagarCarrito]
--	@ConsecutivoUsuario INT
--AS
--BEGIN
	
--	INSERT	INTO dbo.tMaestro (Consecutivo,Fecha,SubTotal,Impuesto,Total)
--	SELECT	ConsecutivoUsuario,
--			GETDATE(),
--			SUM(P.PrecioUnitario * Cantidad),
--			SUM((P.PrecioUnitario * Cantidad) * 0.13),
--			SUM((P.PrecioUnitario * Cantidad) + (P.PrecioUnitario * Cantidad) * 0.13)
--	FROM	tCarrito C
--	INNER	JOIN	tProducto P ON C.IdProducto = P.IdProducto
--	WHERE	ConsecutivoUsuario = @ConsecutivoUsuario
--	GROUP BY ConsecutivoUsuario


--	INSERT INTO dbo.tDetalle (IdMaestro,IdProducto,Cantidad,PrecioUnitario,SubTotal,Impuesto,Total)
--	SELECT	SCOPE_IDENTITY(),
--			C.IdProducto,
--			Cantidad,
--			P.PrecioUnitario,
--			P.PrecioUnitario * Cantidad,
--			(P.PrecioUnitario * Cantidad) * 0.13,
--			(P.PrecioUnitario * Cantidad) + (P.PrecioUnitario * Cantidad) * 0.13
--	FROM	tCarrito C
--	INNER	JOIN	tProducto P ON C.IdProducto = P.IdProducto
--	WHERE	ConsecutivoUsuario = @ConsecutivoUsuario


--	UPDATE	P
--	SET Inventario = Inventario - C.Cantidad
--	FROM tProducto P
--	INNER JOIN tCarrito C ON P.IdProducto = C.IdProducto
--	WHERE	ConsecutivoUsuario = @ConsecutivoUsuario


--	DELETE FROM tCarrito WHERE ConsecutivoUsuario = @ConsecutivoUsuario

--END
--GO