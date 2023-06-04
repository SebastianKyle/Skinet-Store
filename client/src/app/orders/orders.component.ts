import { Component, OnInit } from '@angular/core';
import { IOrder } from '../shared/models/order';
import { OrdersService } from './orders.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
  providers: [DatePipe]
})
export class OrdersComponent implements OnInit {
  orders: IOrder[];

  constructor(private ordersService: OrdersService, private datePipe: DatePipe) {

  }

  ngOnInit(): void {
    this.getOrdersForUser();
  }

  getOrdersForUser() {
    this.ordersService.getOrdersForUser().subscribe(response => {
      this.orders = response;
      this.orders.forEach(order => {
        const date = new Date(order.orderDate);
        order.orderDate = this.datePipe.transform(date, 'MMM dd, yyyy, HH:mm:ss a'); 
      });
    }, error => {
      console.log(error);
    });
  }
}
