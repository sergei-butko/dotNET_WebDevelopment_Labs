import {Component} from '@angular/core';
import {DataService} from "../data.service";
import {Order} from "../order/order";
import {Portion} from "../meal/portion";

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
})

export class ShoppingCartComponent {
  private static dataService: DataService;

  static makeOrder(shoppingCart: Portion[], orderTitle: string): void {

    let totalSum = 0;
    for (let i = 0; i < shoppingCart.length; i++) {
      totalSum += shoppingCart[i].totalSum;
    }

    let order: Order = {
      title: orderTitle,
      totalSum: totalSum,
      orderTime: new Date(),
      isActive: 1
    };

    this.dataService.addNewOrder(order);
  }
}
