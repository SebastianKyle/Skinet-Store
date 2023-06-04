export interface IItemsList {
  items: IItem[]; 
}

export interface IItem {
  productID: number;
  productName: string;
  productBrand: string;
  productType: string;
  pictureUrl: string;
  price: number;
  quantity: number;
}