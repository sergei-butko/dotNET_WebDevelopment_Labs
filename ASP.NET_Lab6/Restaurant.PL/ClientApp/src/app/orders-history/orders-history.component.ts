import {Component} from '@angular/core';
import {DataService} from "../data.service";
import {Order} from "../order/order";

@Component({
  selector: 'app-orders-history',
  templateUrl: './orders-history.component.html',
})
export class OrdersHistoryComponent {
  orders!: Order[];

  constructor(private dataService: DataService) {
    dataService.getOrdersHistory().subscribe(data => this.orders = data);
  }
}
