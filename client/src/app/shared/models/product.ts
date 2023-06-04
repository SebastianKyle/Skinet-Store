export interface IProduct {
  productID: number,
  productName: string,
  description: string,
  price: number,
  pictureUrl: string,
  productType: string,
  productBrand: string
}

export interface IProductList {
  products: IProduct[];
}