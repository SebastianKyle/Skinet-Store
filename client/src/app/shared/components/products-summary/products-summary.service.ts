import { Injectable, Input } from '@angular/core';
import { Observable, map, of } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { OrdersService } from 'src/app/orders/orders.service';
import { Basket, IBasket, IBasketItem } from '../../models/basket';
import { IOrder, IOrderItem } from '../../models/order';
import { IProduct, IProductList } from '../../models/product';
import { IItem, IItemsList } from '../../models/item';

@Injectable({
  providedIn: 'root'
})
export class ProductsSummaryService {
  basket$: Observable<IBasket>;
  order$: Observable<IOrder>;

  constructor(private basketService: BasketService, private ordersService: OrdersService) { }

  synchronizeBasketItems(basketInput$: Observable<IBasket>): Observable<IItemsList> {
    this.basket$ = basketInput$;
    return this.basket$.pipe(
      map((basket: IBasket) => {
        const items: IItem[] = basket.items.map((basketItem: IBasketItem) => {
          const item: IItem = {
            productID: basketItem.id,
            productName: basketItem.productName,
            price: basketItem.price,
            pictureUrl: basketItem.pictureUrl,
            productType: basketItem.type,
            productBrand: basketItem.brand,
            quantity: basketItem.quantity
          };
          return item;
        });

        const itemsList: IItemsList = {
          items: items
        };

        return itemsList;
      })
    );
  }

  synchronizeOrderItems(order: IOrder): Observable<IItemsList> {
    const items: IItem[] = order.orderItems.map((orderItem: IOrderItem) => {
      const item: IItem = {
        productID: orderItem.productId,
        productName: orderItem.productName,
        price: orderItem.price,
        pictureUrl: orderItem.pictureUrl,
        productBrand: null,
        productType: null,
        quantity: orderItem.quantity
      };
      return item;
    });

    const itemsList: IItemsList = {
      items: items
    };

    return of(itemsList);
  }
}
