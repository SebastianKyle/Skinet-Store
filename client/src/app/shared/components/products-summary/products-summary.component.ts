import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable, map, take } from 'rxjs';
import { ProductsSummaryService } from './products-summary.service';
import { IBasket, IBasketItem } from '../../models/basket';
import { IItemsList } from '../../models/item';
import { IOrder } from '../../models/order';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-products-summary',
  templateUrl: './products-summary.component.html',
  styleUrls: ['./products-summary.component.scss']
})
export class ProductsSummaryComponent implements OnInit {
  @Input() isBasket = false;
  @Input() isOrder = false;
  @Input() isReview = false;
  @Input() order: IOrder;
  @Input() basket$: Observable<IBasket>;
  @Output() decrement: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() increment: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() remove: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  itemsList$: Observable<IItemsList>; 

  constructor(private productsSummaryService: ProductsSummaryService, private basketService: BasketService) {

  }

  ngOnInit(): void {
    if (this.isBasket || this.isReview) {
      if (this.isReview) {
        this.basket$ = this.basketService.basket$;
      }
      this.itemsList$ = this.productsSummaryService.synchronizeBasketItems(this.basket$);
    } 
    else if (this.isOrder) {
      this.itemsList$ = this.productsSummaryService.synchronizeOrderItems(this.order);
    }
  }

  decrementItemQuantity(id: number) {
    this.basket$.pipe(take(1)).subscribe((basket: IBasket) => {
      const item: IBasketItem | undefined = basket.items.find(i => i.id === id);
      if (item) {
        this.decrement.emit(item);
      }
      else {
        console.log('No item was found');
      }
    });
  }

  incrementItemQuantity(id: number) {
    this.basket$.pipe(take(1)).subscribe((basket: IBasket) => {
      const item: IBasketItem | undefined = basket.items.find(i => i.id === id);
      if (item) {
        this.increment.emit(item);
      }
      else {
        console.log('No item was found');
      }
    });
  }

  removeBasketItem(id: number) {
    this.basket$.pipe(take(1)).subscribe((basket: IBasket) => {
      const item: IBasketItem | undefined = basket.items.find(i => i.id === id);
      if (item) {
        this.remove.emit(item);
      }
      else {
        console.log('No item was found');
      }
    });
  }
}
