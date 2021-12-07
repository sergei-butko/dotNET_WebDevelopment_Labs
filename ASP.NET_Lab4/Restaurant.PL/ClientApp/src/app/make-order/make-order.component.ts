import {Component, OnInit} from '@angular/core';
import {DataService} from "../data.service";
import {Order} from "../order/order";
import {Portion} from "../meal/portion";
import {ShoppingCartComponent} from "../shopping-cart/shopping-cart.component";

@Component({
  selector: 'app-make-order',
  templateUrl: './make-order.component.html',
})

export class MakeOrderComponent {

  order: Order
  orderTitle: string;
  portions: Portion[];
  shoppingCart: Portion[] = [];

  constructor(private dataService: DataService) {
    dataService.getAllPortions().subscribe(data => this.portions = data);
  }

  addToCart(portion: Portion): void {
    this.shoppingCart.push(portion);
  }

  makeOrder(shoppingCart: Portion[], orderTitle: string) {
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
    //ShoppingCartComponent.makeOrder(shoppingCart, orderTitle);
  }

  makeMeal(){

  }

}
