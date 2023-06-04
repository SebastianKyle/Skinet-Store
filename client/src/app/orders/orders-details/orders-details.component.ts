import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/shared/models/order';
import { OrdersService } from '../orders.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-orders-details',
  templateUrl: './orders-details.component.html',
  styleUrls: ['./orders-details.component.scss'],
  providers: [DatePipe]
})
export class OrdersDetailsComponent implements OnInit {
  order: IOrder;

  constructor(private ordersService: OrdersService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService, private datePipe: DatePipe) {
    this.bcService.set('@ordersDetails', ' ');
  }

  ngOnInit(): void {
    this.getOrdersById();
  }

  getOrdersById() {
    this.ordersService.getOrderById(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(response => {
      this.order = response;
      const date = new Date(this.order.orderDate);
      this.order.orderDate = this.datePipe.transform(date, 'MMM dd, yyyy, HH:mm:ss a');

      this.bcService.set('@ordersDetails', 'Order# ' + this.order.id + ' - ' + this.order.status);
    }, error => {
      console.log(error);
    });
  }

}
