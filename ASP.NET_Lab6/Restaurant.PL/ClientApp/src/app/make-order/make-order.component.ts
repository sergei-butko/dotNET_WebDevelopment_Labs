import {Component} from '@angular/core';
import {DataService} from "../data.service";
import {Meal} from "../meal/meal";

@Component({
  selector: 'app-make-order',
  templateUrl: './make-order.component.html',
})

export class MakeOrderComponent {
  orderTitle: string;
  meals: Meal[] = [];
  mealsForOrder: Meal[] = [];

  constructor(private dataService: DataService) {
    dataService.showMenu().subscribe(data => this.meals = data);
  }

  addMealForOrder(meal: Meal): void {
    this.mealsForOrder.push(meal);
  }

  makeOrder() {
    this.dataService.makeOrder(this.orderTitle, this.mealsForOrder);
    window.location.href = "/";
  }
}
