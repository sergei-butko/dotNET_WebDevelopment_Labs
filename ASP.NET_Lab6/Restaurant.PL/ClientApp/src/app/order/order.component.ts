import {Component} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {DataService} from "../data.service";
import {Meal} from "../meal/meal";

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
})
export class OrderComponent {
  id: number;
  meals!: Meal[];

  constructor(private dataService: DataService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.id = params['id']
    })
    this.dataService.getOrderMeals(this.id).subscribe(data => this.meals = data);
  }
}
